import threading
import time
import random
from collections import deque

# ============================================================
# CONFIGURACION GLOBAL
# ============================================================
# TICK_DURATION: cuantos segundos reales dura 1 tick del reloj del
# sistema. Esto es lo que define que tan rapido o lento se ve la
# simulacion en pantalla. 1 tick = 1 unidad de tiempo de procesamiento
# para los "hilos" (por eso su tiempo_requerido es un numero de ticks
# entre 20 y 50, y no un tiempo real en segundos).
TICK_DURATION = 0.1


# ============================================================
# CLASE HILO
# ============================================================
class Hilo:
    """
    Representa el "hilo" que se esta simulando dentro del sistema.
    OJO: esto NO es un threading.Thread real, es un objeto de datos que
    los Procesadores (que si son threading.Thread) van a ir procesando,
    incrementando su tiempo_realizado hasta que llegue a tiempo_requerido.
    """

    def __init__(self, id_hilo, tiempo_entrada):
        self.id_hilo = id_hilo

        # tiempo de procesamiento requerido: numero aleatorio entre 20 y
        # 50 ticks. Se fija UNA sola vez al crear el hilo y ya no cambia
        # durante toda la simulacion (lo asigna el hilo generador).
        self.tiempo_requerido = random.randint(20, 50)

        # tiempo de procesamiento realizado: cuanto tiempo (en ticks) ha
        # estado el hilo en un procesador. Lo va incrementando el hilo
        # Reloj mientras el hilo este en estado "ejecucion".
        self.tiempo_realizado = 0

        # estado del hilo: espera | ejecucion | terminado
        self.estado = "espera"

        # tiempo del sistema (en ticks) en el que el hilo entro a la
        # cola global, y tiempo del sistema en el que salio (termino).
        # Con estos dos datos se puede sacar el tiempo de espera total
        # por matematica: (tiempo_salida - tiempo_entrada) - tiempo_requerido
        self.tiempo_entrada = tiempo_entrada
        self.tiempo_salida = None

    def esta_terminado(self):
        return self.tiempo_realizado >= self.tiempo_requerido

    def tiempo_espera(self):
        # tiempo de espera total = tiempo que el hilo estuvo en el
        # sistema completo - tiempo que realmente estuvo siendo
        # procesado (tiempo_requerido).
        if self.tiempo_salida is None:
            return None
        tiempo_en_sistema = self.tiempo_salida - self.tiempo_entrada
        return tiempo_en_sistema - self.tiempo_requerido

    def __str__(self):
        return (f"Hilo {self.id_hilo} "
                f"[{self.tiempo_realizado}/{self.tiempo_requerido} ticks] "
                f"estado={self.estado}")


# ============================================================
# COLA GLOBAL DE HILOS (protegida con semaforo)
# ============================================================
class ColaGlobalHilos:
    """
    Cola global UNICA donde se depositan los "hilos" en espera. El
    enunciado pide explicitamente que el acceso a esta cola este
    protegido con un semaforo, para garantizar que solo un procesador
    pueda tomar un hilo a la vez (que no choquen dos procesadores por
    el mismo hilo). Aqui se usa un semaforo binario (mutex).
    """

    def __init__(self):
        self._cola = deque()
        # semaforo que actua como candado (mutex) de la cola: solo un
        # hilo (procesador) a la vez puede entrar a agregar/quitar.
        self._semaforo = threading.Semaphore(1)

    def agregar(self, hilo):
        self._semaforo.acquire()
        try:
            hilo.estado = "espera"
            self._cola.append(hilo)
        finally:
            self._semaforo.release()

    def quitar(self):
        # Saca y devuelve el primer hilo de la cola (FCFS por
        # naturaleza). Round Robin reutiliza esta misma cola: cuando un
        # hilo no termina su quantum, se vuelve a meter al final con
        # agregar(), asi que la cola global sirve para ambas estrategias.

        #Aquí se establece la adquisicion del recurso en este caso el hilo.
        self._semaforo.acquire() #aquire() funciona para adquirir el recurso
        try:
            if self._cola:
                #Punto Importante: aqui lo que pasa es que
                # elimina y devuelve el primer elemento de eso
                #se encargar el popleft().
                return self._cola.popleft()
            return None
        finally:
            #Aqui se establece la liberacion del hilo
            self._semaforo.release()

    def cantidad(self):
        self._semaforo.acquire()
        try:
            return len(self._cola)
        finally:
            self._semaforo.release()


# ============================================================
# ESTRATEGIAS DE PLANIFICACION
# ============================================================
class FIFO:
    """
    Estrategia FCFS (First Come First Served): el procesador corre el
    hilo hasta que termine, sin interrupciones por quantum.
    """

    nombre = "FCFS"

    def ticks_por_turno(self):
        # None = "sin limite", el procesador corre el hilo hasta que
        # termine por completo.
        return None


class RoundRobin:
    """
    Estrategia Round Robin: cada procesador solo le da "quantum" ticks
    al hilo por turno. Si el hilo no termina en ese quantum, regresa a
    la cola global para que otro (o el mismo) procesador lo retome mas
    adelante.
    """

    nombre = "Round Robin"

    def __init__(self, quantum):
        self.quantum = quantum

    def ticks_por_turno(self):
        return self.quantum


# ============================================================
# HILO GENERADOR
# ============================================================
class GeneradorHilos(threading.Thread):
    """
    Hilo encargado de ir creando los "hilos" (objetos Hilo) y
    agregarlos a la cola global, tal como pide el enunciado.
    """

    def __init__(self, cantidad_hilos, cola_global, reloj):
        #llamas a los recursos o datos de la funcion threading
        super().__init__(name="GeneradorHilos")
        self.cantidad_hilos = cantidad_hilos
        self.cola_global = cola_global
        self.reloj = reloj
        # guardamos referencia a todos los hilos creados para poder
        # imprimir el reporte final de la simulacion.
        self.hilos_generados = []

    def run(self):
        print("\n>>> Generador: comenzando a crear hilos...")
        for i in range(self.cantidad_hilos):
            nuevo_hilo = Hilo(i, self.reloj.tiempo_actual())
            self.hilos_generados.append(nuevo_hilo)
            self.cola_global.agregar(nuevo_hilo)
            print(f">>> Generador: Hilo {nuevo_hilo.id_hilo} creado y puesto en la "
                  f"cola global (necesita {nuevo_hilo.tiempo_requerido} ticks)")
            time.sleep(TICK_DURATION)
        print(">>> Generador: ya se crearon todos los hilos.\n")


# ============================================================
# HILO RELOJ DEL SISTEMA
# ============================================================
class Reloj(threading.Thread):
    """
    Hilo que lleva el control del tiempo del sistema. En cada tick,
    incrementa el tiempo_realizado de todos los hilos que en ese
    momento esten en estado "ejecucion" dentro de algun procesador.
    """
    def __init__(self, procesadores):
        super().__init__(name="Reloj")
        self._tiempo_sistema = 0
        self._lock = threading.Lock() #Bloquea el paso de Hilos.
        self.procesadores = procesadores  # lista de objetos Procesador
        self._detener = threading.Event() #Bandera establecer que no se ha detenido retorna false

    def tiempo_actual(self):
        with self._lock:
            return self._tiempo_sistema

    def detener(self):
        self._detener.set() #Detiene el hilo

    def run(self):
        while not self._detener.is_set(): #verfica el estado del hilo, es decir, que si está detenido
            time.sleep(TICK_DURATION) #Aqui le da la duracion de descanso del tiempo del Tick
            with self._lock:  #con el hilo bloqueado incrementa el tiempo del sistema
                self._tiempo_sistema += 1
            # incrementamos el tiempo_realizado de cada hilo que este
            # actualmente en ejecucion en algun procesador.
            for procesador in self.procesadores:
                hilo_actual = procesador.hilo_actual
                if hilo_actual is not None and hilo_actual.estado == "ejecucion":
                    hilo_actual.tiempo_realizado += 1


# ============================================================
# PROCESADOR (cada uno es un hilo real)
# ============================================================
class Procesador(threading.Thread):
    """
    Cada Procesador es un hilo que compite junto a los demas por sacar
    "hilos" de la MISMA cola global (compartición de carga). Toma un
    hilo, lo deja "en ejecucion" (el Reloj es quien realmente avanza su
    tiempo_realizado) y espera a que termine o se le acabe el quantum,
    segun la estrategia elegida.-
    """

    def __init__(self, id_procesador, cola_global, estrategia, reloj,
                 hilos_terminados, lock_terminados, total_hilos, evento_fin):
        #Aquí es inicializamos el procesador
        super().__init__(name=f"Procesador-{id_procesador}")
        self.id_procesador = id_procesador
        self.cola_global = cola_global
        self.estrategia = estrategia 
        self.reloj = reloj
        # referencia al hilo que este procesador tiene ahora mismo (o
        # None si esta libre). El Reloj lee esto para saber a quien
        # incrementarle el tiempo_realizado.
        self.hilo_actual = None

        self.hilos_terminados = hilos_terminados
        self.lock_terminados = lock_terminados
        self.total_hilos = total_hilos

        
        self.evento_fin = evento_fin
    #Inicializacion del procesador
    def run(self):
        print(f"Procesador {self.id_procesador} listo y esperando hilos.")

        #¿Qué pasa aca? aqui nuestro procesador dice que mientras un hilo
        # no este en linea "vivo" que sigua trabajando
        while not self.evento_fin.is_set():

        #aqui el hilo que esta en ejecucion pasa a hacer lo siguiente mediante el metodo quitar():
        #Saca y devuelve el primer hilo de la cola (FCFS por
        # naturaleza). Round Robin reutiliza esta misma cola: cuando un
        # hilo no termina su quantum, se vuelve a meter al final con
        # agregar(), asi que la cola global sirve para ambas estrategias.
        #esto claramente mediante la utilizacion de semaforos
            hilo = self.cola_global.quitar()

            if hilo is None:
                # no hay hilos disponibles ahorita en la cola global,
                # esperamos un poco y volvemos a intentar.
                time.sleep(TICK_DURATION)
                continue

            hilo.estado = "ejecucion"
            self.hilo_actual = hilo
            print(f"Procesador {self.id_procesador} toma el Hilo {hilo.id_hilo} "
                  f"({hilo.tiempo_realizado}/{hilo.tiempo_requerido} ticks)")


            #aqui dependien de la estragia asignado seran lo ticks del procesador
            #FIFO = Ninguno
            #ROUND ROBIN= quantum
            ticks_asignados = self.estrategia.ticks_por_turno()
            ticks_al_iniciar_turno = hilo.tiempo_realizado

            # esperamos (con polling fino que es una forma de estar consultando constantemente) 
            # hasta que el hilo termine o se le acabe el quantum asignado. 
            # El que realmente avanza el tiempo_realizado es el hilo Reloj, no este bucle.
            while True:
                time.sleep(TICK_DURATION / 2)
                if hilo.esta_terminado():
                    break
                if ticks_asignados is not None:
                    ticks_corridos_este_turno = hilo.tiempo_realizado - ticks_al_iniciar_turno
                    if ticks_corridos_este_turno >= ticks_asignados:
                        break

            self.hilo_actual = None

            if hilo.esta_terminado():
                hilo.estado = "terminado"
                hilo.tiempo_salida = self.reloj.tiempo_actual()

                with self.lock_terminados:
                    self.hilos_terminados.append(hilo)
                    cantidad_terminados = len(self.hilos_terminados)

                print(f"Procesador {self.id_procesador}: Hilo {hilo.id_hilo} TERMINADO "
                      f"({cantidad_terminados}/{self.total_hilos} hilos completados)")

                if cantidad_terminados >= self.total_hilos:
                    # ya no quedan hilos por procesar, avisamos a todos los procesadores que la simulacion termino.
                    self.evento_fin.set()
            else:
                hilo.estado = "espera"
                print(f"Procesador {self.id_procesador}: Hilo {hilo.id_hilo} no termino su "
                      f"quantum, regresa a la cola global "
                      f"({hilo.tiempo_realizado}/{hilo.tiempo_requerido} ticks)")
                self.cola_global.agregar(hilo)
        print(f"Procesador {self.id_procesador} finalizado.")

# ============================================================
# VALIDACION DE ENTRADAS DEL USUARIO
# ============================================================
def pedir_entero(mensaje, minimo=None, maximo=None):
    """Pide un entero al usuario, validando que sea numerico y que este
    dentro del rango [minimo, maximo] si se especifica. Vuelve a
    preguntar mientras la entrada no sea valida."""
    while True:
        entrada = input(mensaje)
        try:
            valor = int(entrada)
        except ValueError:
            print("Entrada invalida, debe ingresar un numero entero.")
            continue
        if minimo is not None and valor < minimo:
            print(f"El valor debe ser mayor o igual a {minimo}.")
            continue
        if maximo is not None and valor > maximo:
            print(f"El valor debe ser menor o igual a {maximo}.")
            continue
        return valor


def pedir_opcion(mensaje, opciones_validas):
    """Pide al usuario que elija entre un conjunto de opciones validas
    (por ejemplo '1' o '2'). Vuelve a preguntar si la opcion no es
    valida."""
    while True:
        entrada = input(mensaje).strip()
        if entrada in opciones_validas:
            return entrada
        print(f"Opcion invalida, elija una de estas: {', '.join(opciones_validas)}")


# ============================================================
# PROGRAMA PRINCIPAL
# ============================================================
if __name__ == "__main__":

    print("==============================================")
    print(" SIMULADOR DE PLANIFICACION MULTIPROCESADOR")
    print("==============================================\n")

    numero_procesadores = pedir_entero(
        "Ingrese el numero de procesadores (entre 2 y 6): ", minimo=2, maximo=6)

    numero_hilos = pedir_entero(
        "Ingrese la cantidad de hilos a generar: ", minimo=1)

    print("\nEstrategias de planificacion disponibles:")
    print("  1) FCFS (First Come First Served)")
    print("  2) Round Robin")
    algoritmo = pedir_opcion("Elija estrategia (1 o 2): ", ("1", "2"))

    if algoritmo == "1":
        estrategia = FIFO()
    else:
        quantum = pedir_entero(
            "Ingrese el tamano del quantum (en ticks, ej: 5): ", minimo=1)
        estrategia = RoundRobin(quantum)

    # ---- estructuras compartidas entre todos los hilos del sistema ----
    cola_global = ColaGlobalHilos()
    evento_fin = threading.Event()
    hilos_terminados = []
    lock_terminados = threading.Lock()

    # Creamos primero los Procesadores (sin arrancarlos todavia) para
    # que el Reloj los pueda referenciar y saber a quien incrementarle
    # el tiempo mientras esten en ejecucion.
    procesadores = []
    for i in range(numero_procesadores):
        procesadores.append(
            Procesador(i + 1, cola_global, estrategia, None,
                       hilos_terminados, lock_terminados, numero_hilos, evento_fin)
        )

    reloj = Reloj(procesadores)

    # ahora si le damos a cada procesador la referencia al reloj (para
    # que pueda leer el tiempo_actual al marcar tiempo_salida)
    for procesador in procesadores:
        procesador.reloj = reloj

    generador = GeneradorHilos(numero_hilos, cola_global, reloj)

    nombre_estrategia = estrategia.nombre
    if algoritmo == "2":
        nombre_estrategia += f" (quantum = {estrategia.quantum} ticks)"

    print(f"\nIniciando simulacion con {numero_procesadores} procesadores, "
          f"{numero_hilos} hilos y estrategia {nombre_estrategia}\n")

    # ---- arrancamos todos los hilos del sistema ----
    reloj.start()
    generador.start()
    for procesador in procesadores:
        procesador.start()

    # esperamos a que el generador termine de crear hilos y a que todos
    # los procesadores terminen (esto ultimo pasa cuando evento_fin se
    # activa, porque ya se completaron todos los hilos).
    generador.join()
    for procesador in procesadores:
        procesador.join()

    reloj.detener()
    reloj.join()

    # ---- reporte final ----
    print("\n==============================================")
    print(" SIMULACION FINALIZADA - TODOS LOS HILOS TERMINARON")
    print("==============================================")
    for hilo in sorted(hilos_terminados, key=lambda h: h.id_hilo):
        print(f"Hilo {hilo.id_hilo}: requerido={hilo.tiempo_requerido} ticks, "
              f"entrada={hilo.tiempo_entrada}, salida={hilo.tiempo_salida}, "
              f"espera={hilo.tiempo_espera()} ticks")