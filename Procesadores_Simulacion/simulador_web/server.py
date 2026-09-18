"""
server.py
---------
Puente entre la interfaz web (HTML/JS) y el backend de la simulacion
(planificador_multiprocesador.py). ESTE ARCHIVO ES NUEVO: no modifica
ni una sola linea del backend original, solo lo importa y usa sus
clases tal como estan.

Lo que hace:
  - Expone /api/iniciar (POST) para arrancar una simulacion nueva con
    los parametros que el usuario eligio en la pagina.
  - Expone /api/estado (GET) para que la pagina, cada cierto tiempo,
    pregunte "como va todo" y dibuje el estado actual (procesadores,
    cola global, hilos terminados, etc).
  - Sirve la pagina (index.html / style.css / app.js) desde la carpeta
    static/.
"""

import threading

from flask import Flask, jsonify, request, send_from_directory

# Importamos las clases del backend ORIGINAL, sin tocarlas. El bloque
# "if __name__ == '__main__':" de ese archivo no se ejecuta al
# importarlo, asi que es seguro reusarlo aqui.
from planificador_multiprocesador import (
    ColaGlobalHilos,
    FIFO,
    RoundRobin,
    GeneradorHilos,
    Reloj,
    Procesador,
)

app = Flask(__name__, static_folder="static", static_url_path="")


class GestorSimulacion:
    """
    Envuelve una simulacion completa (cola global, reloj, generador y
    procesadores) para poder arrancarla desde una peticion HTTP y
    consultar su estado en cualquier momento sin bloquear al servidor.
    """

    def __init__(self):
        self.lock = threading.Lock()
        self._reset_estado()

    def _reset_estado(self):
        self.cola_global = None
        self.reloj = None
        self.generador = None
        self.procesadores = []
        self.hilos_terminados = []
        self.lock_terminados = threading.Lock()
        self.evento_fin = threading.Event()
        self.total_hilos = 0
        self.estrategia = None
        self.nombre_estrategia = ""
        self.corriendo = False
        self.terminada = False

    def iniciar(self, n_procesadores, n_hilos, algoritmo, quantum):
        with self.lock:
            if self.corriendo and not self.terminada:
                return False, "Ya hay una simulacion en curso."

            # Las mismas validaciones que hace el programa de consola,
            # ahora aplicadas a lo que llega desde el formulario web.
            if not (2 <= n_procesadores <= 6):
                return False, "El numero de procesadores debe estar entre 2 y 6."
            if n_hilos < 1:
                return False, "Debe generar al menos 1 hilo."
            if algoritmo not in ("1", "2"):
                return False, "Estrategia invalida."
            if algoritmo == "2" and (quantum is None or quantum < 1):
                return False, "El quantum debe ser un numero entero mayor o igual a 1."

            self._reset_estado()

            self.cola_global = ColaGlobalHilos()
            self.total_hilos = n_hilos

            if algoritmo == "1":
                self.estrategia = FIFO()
                self.nombre_estrategia = "FCFS"
            else:
                self.estrategia = RoundRobin(quantum)
                self.nombre_estrategia = f"Round Robin (quantum = {quantum} ticks)"

            # Igual que en el main original: primero se crean los
            # Procesadores (sin reloj todavia) para que el Reloj los
            # pueda referenciar.
            self.procesadores = []
            for i in range(n_procesadores):
                self.procesadores.append(
                    Procesador(
                        i + 1, self.cola_global, self.estrategia, None,
                        self.hilos_terminados, self.lock_terminados,
                        n_hilos, self.evento_fin,
                    )
                )

            self.reloj = Reloj(self.procesadores)
            for procesador in self.procesadores:
                procesador.reloj = self.reloj

            self.generador = GeneradorHilos(n_hilos, self.cola_global, self.reloj)

            self.corriendo = True
            self.terminada = False

            # Corremos el arranque + espera final en un hilo aparte
            # para que la peticion HTTP regrese de inmediato.
            threading.Thread(target=self._ejecutar, daemon=True).start()
            return True, "Simulacion iniciada."

    def _ejecutar(self):
        self.reloj.start()
        self.generador.start()
        for procesador in self.procesadores:
            procesador.start()

        self.generador.join()
        for procesador in self.procesadores:
            procesador.join()

        self.reloj.detener()
        self.reloj.join()

        with self.lock:
            self.terminada = True
            self.corriendo = False

    def estado(self):
        with self.lock:
            if self.cola_global is None:
                return {"iniciada": False}

            procesadores_info = []
            for procesador in self.procesadores:
                hilo_actual = procesador.hilo_actual
                procesadores_info.append({
                    "id": procesador.id_procesador,
                    "hilo": None if hilo_actual is None else {
                        "id": hilo_actual.id_hilo,
                        "realizado": hilo_actual.tiempo_realizado,
                        "requerido": hilo_actual.tiempo_requerido,
                    },
                })

            # "Espiamos" la cola global usando el mismo semaforo que ya
            # trae la clase, sin agregar metodos nuevos a ese archivo.
            self.cola_global._semaforo.acquire()
            try:
                en_espera = [
                    {
                        "id": hilo.id_hilo,
                        "requerido": hilo.tiempo_requerido,
                        "realizado": hilo.tiempo_realizado,
                    }
                    for hilo in self.cola_global._cola
                ]
            finally:
                self.cola_global._semaforo.release()

            with self.lock_terminados:
                terminados = [
                    {
                        "id": hilo.id_hilo,
                        "requerido": hilo.tiempo_requerido,
                        "entrada": hilo.tiempo_entrada,
                        "salida": hilo.tiempo_salida,
                        "espera": hilo.tiempo_espera(),
                    }
                    for hilo in sorted(self.hilos_terminados, key=lambda h: h.id_hilo)
                ]

            total_generados = len(self.generador.hilos_generados) if self.generador else 0

            return {
                "iniciada": True,
                "tiempo_sistema": self.reloj.tiempo_actual() if self.reloj else 0,
                "estrategia": self.nombre_estrategia,
                "corriendo": self.corriendo,
                "terminada": self.terminada,
                "total_hilos": self.total_hilos,
                "total_generados": total_generados,
                "procesadores": procesadores_info,
                "en_espera": en_espera,
                "terminados": terminados,
            }


gestor = GestorSimulacion()


@app.route("/")
def index():
    return send_from_directory(app.static_folder, "index.html")


@app.route("/api/iniciar", methods=["POST"])
def api_iniciar():
    datos = request.get_json(force=True, silent=True) or {}
    try:
        n_procesadores = int(datos.get("procesadores"))
        n_hilos = int(datos.get("hilos"))
        algoritmo = str(datos.get("algoritmo"))
        quantum_raw = datos.get("quantum")
        quantum = int(quantum_raw) if quantum_raw not in (None, "") else None
    except (TypeError, ValueError):
        return jsonify({"ok": False, "mensaje": "Datos invalidos."}), 400

    ok, mensaje = gestor.iniciar(n_procesadores, n_hilos, algoritmo, quantum)
    return jsonify({"ok": ok, "mensaje": mensaje})


@app.route("/api/estado")
def api_estado():
    return jsonify(gestor.estado())


if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000, debug=False)
