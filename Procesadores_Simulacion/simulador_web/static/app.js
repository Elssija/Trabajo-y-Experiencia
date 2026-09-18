// app.js
// Logica de la interfaz web. Este archivo NO toca el backend de
// Python; solo consume /api/iniciar y /api/estado (definidos en
// server.py) para dibujar el estado de la simulacion.

(() => {
  const INTERVALO_POLLING_MS = 200;

  // ---- referencias a elementos ----
  const configPanel = document.getElementById("configPanel");
  const dashboard = document.getElementById("dashboard");

  const grupoProcesadores = document.getElementById("grupoProcesadores");
  const grupoEstrategia = document.getElementById("grupoEstrategia");
  const campoQuantum = document.getElementById("campoQuantum");
  const inputHilos = document.getElementById("inputHilos");
  const inputQuantum = document.getElementById("inputQuantum");
  const btnIniciar = document.getElementById("btnIniciar");
  const mensajeError = document.getElementById("mensajeError");
  const btnReiniciar = document.getElementById("btnReiniciar");

  const relojValor = document.getElementById("relojValor");
  const estrategiaPill = document.getElementById("estrategiaPill");

  const resumenGenerados = document.getElementById("resumenGenerados");
  const resumenEspera = document.getElementById("resumenEspera");
  const resumenTerminados = document.getElementById("resumenTerminados");
  const resumenBarraFill = document.getElementById("resumenBarraFill");
  const bannerFin = document.getElementById("bannerFin");

  const contenedorCores = document.getElementById("contenedorCores");
  const contenedorCola = document.getElementById("contenedorCola");
  const colaVacia = document.getElementById("colaVacia");
  const contenedorLog = document.getElementById("contenedorLog");
  const logVacio = document.getElementById("logVacio");

  const plantillaCore = document.getElementById("plantillaCore");
  const plantillaChip = document.getElementById("plantillaChip");
  const plantillaLog = document.getElementById("plantillaLog");

  // ---- estado de seleccion del formulario ----
  let procesadoresSeleccionados = null;
  let estrategiaSeleccionada = null;
  let intervaloPolling = null; // se encarga de estarconsultado a la api cada 200 milisegundos
  let idsYaRegistradosEnLog = new Set();

  // ---- interaccion: chips de procesadores ----
  grupoProcesadores.addEventListener("click", (ev) => {
    const boton = ev.target.closest(".chip");
    if (!boton) return;
    [...grupoProcesadores.children].forEach(c => c.classList.remove("is-activo"));
    boton.classList.add("is-activo");
    procesadoresSeleccionados = boton.dataset.valor;
  });

  // ---- interaccion: chips de estrategia ----
  grupoEstrategia.addEventListener("click", (ev) => {
    const boton = ev.target.closest(".chip");
    if (!boton) return;
    [...grupoEstrategia.children].forEach(c => c.classList.remove("is-activo"));
    boton.classList.add("is-activo");
    estrategiaSeleccionada = boton.dataset.valor;
    campoQuantum.hidden = estrategiaSeleccionada !== "2";
  });

  // ---- iniciar simulacion ----
  btnIniciar.addEventListener("click", async () => {
    mensajeError.textContent = "";

    if (!procesadoresSeleccionados) {
      mensajeError.textContent = "Elige cuántos procesadores va a tener el sistema.";
      return;
    }
    if (!estrategiaSeleccionada) {
      mensajeError.textContent = "Elige una estrategia de planificación.";
      return;
    }

    const hilos = parseInt(inputHilos.value, 10);
    if (!Number.isInteger(hilos) || hilos < 1) {
      mensajeError.textContent = "La cantidad de hilos debe ser un entero mayor o igual a 1.";
      return;
    }

    let quantum = null;
    if (estrategiaSeleccionada === "2") {
      quantum = parseInt(inputQuantum.value, 10);
      if (!Number.isInteger(quantum) || quantum < 1) {
        mensajeError.textContent = "El quantum debe ser un entero mayor o igual a 1.";
        return;
      }
    }

    btnIniciar.disabled = true;
    btnIniciar.querySelector("span").textContent = "Iniciando…";

    try {
      const respuesta = await fetch("/api/iniciar", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          procesadores: procesadoresSeleccionados,
          hilos,
          algoritmo: estrategiaSeleccionada,
          quantum,
        }),
      });
      const datos = await respuesta.json();

      if (!datos.ok) {
        mensajeError.textContent = datos.mensaje || "No se pudo iniciar la simulación.";
        btnIniciar.disabled = false;
        btnIniciar.querySelector("span").textContent = "Iniciar simulación";
        return;
      }

      idsYaRegistradosEnLog = new Set();
      configPanel.hidden = true;
      dashboard.hidden = false;
      bannerFin.hidden = true;
      empezarPolling();
    } catch (err) {
      mensajeError.textContent = "No se pudo conectar con el servidor.";
      btnIniciar.disabled = false;
      btnIniciar.querySelector("span").textContent = "Iniciar simulación";
    }
  });

  // ---- reiniciar: volver al panel de configuracion ----
  btnReiniciar.addEventListener("click", () => {
    detenerPolling();
    dashboard.hidden = true;
    configPanel.hidden = false;
    mensajeError.textContent = "";
    btnIniciar.disabled = false;
    btnIniciar.querySelector("span").textContent = "Iniciar simulación";
  });

  // ---- polling del estado ----
  function empezarPolling() {
    detenerPolling();
    consultarEstado();
    intervaloPolling = setInterval(consultarEstado, INTERVALO_POLLING_MS);
  }

  function detenerPolling() {
    if (intervaloPolling) {
      clearInterval(intervaloPolling);
      intervaloPolling = null;
    }
  }

  async function consultarEstado() {
    try {
      const respuesta = await fetch("/api/estado");
      const estado = await respuesta.json();
      if (estado.iniciada) {
        renderizarEstado(estado);
        if (estado.terminada) {
          detenerPolling();
        }
      }
    } catch (err) {
      // si el servidor no responde momentaneamente, simplemente
      // esperamos al siguiente intento de polling.
    }
  }

  // ---- render ----
  function renderizarEstado(estado) {
    relojValor.textContent = String(estado.tiempo_sistema).padStart(6, "0");
    estrategiaPill.textContent = estado.estrategia;
    estrategiaPill.classList.toggle("pill--activa", estado.corriendo);

    resumenGenerados.textContent = estado.total_generados;
    resumenEspera.textContent = estado.en_espera.length;
    resumenTerminados.textContent = estado.terminados.length;

    const porcentaje = estado.total_hilos > 0
      ? Math.round((estado.terminados.length / estado.total_hilos) * 100)
      : 0;
    resumenBarraFill.style.width = porcentaje + "%";
    bannerFin.hidden = !estado.terminada;

    renderizarCores(estado.procesadores);
    renderizarCola(estado.en_espera);
    renderizarLog(estado.terminados);
  }

  function renderizarCores(procesadores) {
    // reconstruir solo si cambio la cantidad de tarjetas
    if (contenedorCores.children.length !== procesadores.length) {
      contenedorCores.innerHTML = "";
      procesadores.forEach(() => {
        contenedorCores.appendChild(plantillaCore.content.cloneNode(true));
      });
    }

    procesadores.forEach((proc, idx) => {
      const tarjeta = contenedorCores.children[idx];
      tarjeta.querySelector(".core__id").textContent = String(proc.id).padStart(2, "0");
      const ocupado = proc.hilo !== null;
      tarjeta.classList.toggle("is-ocupado", ocupado);
      tarjeta.querySelector(".core__estado").textContent = ocupado ? "procesando" : "libre";

      const idHilo = tarjeta.querySelector(".core__hilo-id");
      const ticks = tarjeta.querySelector(".core__hilo-ticks");
      const medidor = tarjeta.querySelector(".meter");

      if (ocupado) {
        idHilo.textContent = `hilo #${proc.hilo.id}`;
        ticks.textContent = `${proc.hilo.realizado}/${proc.hilo.requerido} ticks`;
        dibujarMedidor(medidor, proc.hilo.requerido, proc.hilo.realizado);
      } else {
        idHilo.textContent = "— sin hilo asignado —";
        ticks.textContent = "";
        dibujarMedidor(medidor, 0, 0);
      }
    });
  }

  function dibujarMedidor(contenedor, total, realizado) {
    // cada segmento representa 1 tick; si ya tiene el numero correcto
    // de segmentos, solo actualizamos cuales estan "encendidos".
    if (contenedor.children.length !== total) {
      contenedor.innerHTML = "";
      for (let i = 0; i < total; i++) {
        const seg = document.createElement("div");
        seg.className = "meter__seg";
        contenedor.appendChild(seg);
      }
    }
    [...contenedor.children].forEach((seg, i) => {
      seg.classList.toggle("is-lit", i < realizado);
    });
  }

  function renderizarCola(enEspera) {
    colaVacia.hidden = enEspera.length > 0;

    // limpiamos y volvemos a pintar (la cola cambia de tamano seguido)
    [...contenedorCola.querySelectorAll(".cola__chip")].forEach(el => el.remove());

    enEspera.forEach(hilo => {
      const nodo = plantillaChip.content.cloneNode(true);
      nodo.querySelector(".cola__chip-id").textContent = `H${String(hilo.id).padStart(2, "0")}`;
      nodo.querySelector(".cola__chip-ticks").textContent = `${hilo.realizado}/${hilo.requerido}t`;
      contenedorCola.appendChild(nodo);
    });
  }

  function renderizarLog(terminados) {
    logVacio.hidden = terminados.length > 0;

    terminados.forEach(hilo => {
      if (idsYaRegistradosEnLog.has(hilo.id)) return;
      idsYaRegistradosEnLog.add(hilo.id);

      const nodo = plantillaLog.content.cloneNode(true);
      nodo.querySelector(".log__id").textContent = `Hilo ${String(hilo.id).padStart(2, "0")}`;
      nodo.querySelector(".log__detalle").textContent =
        `requerido=${hilo.requerido}t · entrada=${hilo.entrada}t · salida=${hilo.salida}t · espera=${hilo.espera}t`;
      contenedorLog.insertBefore(nodo, contenedorLog.firstChild);
    });
  }
})();

// ===========================================================
// CONSOLA / TERMINAL (agregado)
// Bloque independiente: no modifica ni reutiliza nada del codigo
// de arriba. Solo consulta /api/estado por su cuenta y va
// "imprimiendo" lo que pasa, como si fueran prints de server.py.
// ===========================================================
(() => {
  const terminalCuerpo = document.getElementById("terminalCuerpo");
  if (!terminalCuerpo) return;

  const MAX_LINEAS = 300;
  const INTERVALO_TERMINAL_MS = 300;

  let cursorNodo = null;
  let estadoPrevioTerminal = null;
  let yaImprimioBanner = false;

  function pad(n, len) {
    return String(n).padStart(len, "0");
  }

  function imprimir(texto, tipo) {
    if (cursorNodo) cursorNodo.remove();

    const linea = document.createElement("div");
    linea.className = "terminal__linea terminal__linea--" + (tipo || "info");
    linea.textContent = texto;
    terminalCuerpo.appendChild(linea);

    while (terminalCuerpo.children.length > MAX_LINEAS) {
      terminalCuerpo.removeChild(terminalCuerpo.firstChild);
    }

    cursorNodo = document.createElement("span");
    cursorNodo.className = "terminal__cursor";
    terminalCuerpo.appendChild(cursorNodo);

    terminalCuerpo.scrollTop = terminalCuerpo.scrollHeight;
  }

  // ---- secuencia de arranque simulada ----
  const secuenciaArranque = [
    [" * Serving Flask app 'server'", "sistema"],
    [" * Debug mode: off", "sistema"],
    [" * Running on http://0.0.0.0:5000 (Press CTRL+C to quit)", "sistema"],
    ["Esperando solicitud en /api/iniciar ...", "info"],
  ];

  secuenciaArranque.forEach(([texto, tipo], i) => {
    setTimeout(() => imprimir(texto, tipo), i * 260);
  });

  function compararYImprimir(estado) {
    if (!estado || !estado.iniciada) return;

    const previo = estadoPrevioTerminal;

    // primera vez que vemos la simulacion iniciada
    if (!previo) {
      imprimir(`127.0.0.1 - - "POST /api/iniciar HTTP/1.1" 200 -`, "sistema");
      imprimir(`Simulacion iniciada -> estrategia="${estado.estrategia}", hilos_a_generar=${estado.total_hilos}, procesadores=${estado.procesadores.length}`, "ok");
    }

    // nuevos hilos generados
    if (previo && estado.total_generados > previo.total_generados) {
      for (let i = previo.total_generados + 1; i <= estado.total_generados; i++) {
        imprimir(`[tick ${pad(estado.tiempo_sistema, 6)}] GeneradorHilos -> hilo #${i} creado y encolado`, "info");
      }
    }

    // cambios en cada procesador (nueva asignacion)
    estado.procesadores.forEach((proc, idx) => {
      const procPrevio = previo && previo.procesadores[idx];
      const idAntes = procPrevio && procPrevio.hilo ? procPrevio.hilo.id : null;
      const idAhora = proc.hilo ? proc.hilo.id : null;
      if (idAhora !== null && idAhora !== idAntes) {
        imprimir(`[tick ${pad(estado.tiempo_sistema, 6)}] Procesador ${proc.id} -> toma hilo #${idAhora} (requerido=${proc.hilo.requerido} ticks)`, "proc");
      }
    });

    // hilos que terminaron desde el ultimo estado
    if (previo) {
      const idsAntes = new Set(previo.terminados.map(h => h.id));
      estado.terminados.forEach(h => {
        if (!idsAntes.has(h.id)) {
          imprimir(`[tick ${pad(estado.tiempo_sistema, 6)}] Hilo #${h.id} finalizado -> entrada=${h.entrada}t, salida=${h.salida}t, espera=${h.espera}t`, "ok");
        }
      });
    }

    // fin de la simulacion
    if (estado.terminada && !yaImprimioBanner) {
      yaImprimioBanner = true;
      imprimir(`127.0.0.1 - - "GET /api/estado HTTP/1.1" 200 -`, "sistema");
      imprimir(`>>> Simulacion completada: ${estado.total_hilos}/${estado.total_hilos} hilos procesados en ${estado.tiempo_sistema} ticks.`, "banner");
      imprimir(`Esperando solicitud en /api/iniciar ...`, "info");
    }

    // si arranco una simulacion nueva despues de una terminada
    if (previo && previo.terminada && estado.corriendo && !estado.terminada) {
      yaImprimioBanner = false;
    }

    estadoPrevioTerminal = estado;
  }

  async function consultarTerminal() {
    try {
      const respuesta = await fetch("/api/estado");
      const estado = await respuesta.json();
      compararYImprimir(estado);
    } catch (err) {
      // silencioso: si el servidor no responde, no ensuciamos la consola
    }
  }

  setInterval(consultarTerminal, INTERVALO_TERMINAL_MS);
})();