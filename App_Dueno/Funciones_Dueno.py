import flet as ft
import random
import string
from datetime import date, datetime

import conexion_sheets as cs

# Nombres de mes en español, sin depender del locale del sistema (ver
# nota igual en Funciones.py).
NOMBRES_MES = {
    1: "Enero", 2: "Febrero", 3: "Marzo", 4: "Abril", 5: "Mayo", 6: "Junio",
    7: "Julio", 8: "Agosto", 9: "Septiembre", 10: "Octubre", 11: "Noviembre", 12: "Diciembre",
}


def agregar_pago(page, codigo, monto, nombre_cliente):

    bandera = True  # Asumimos que no hay pago pendiente
    def on_click_si(codigo, monto, nombre_cliente):
        pagos = cs.get_hoja(cs.HOJA_PAGOS)
        pagos.append_row([codigo, monto, date.today().strftime('%Y-%m-%d'), nombre_cliente, "PAGO MANUAL"])
        mini_ventana.open = False 
        page.show_dialog(ft.SnackBar(ft.Text(f"¡¡Pago registrado EXISTOSAMENTE!!")))

    si = ft.TextButton("Sí", on_click=lambda e: on_click_si(codigo, monto, nombre_cliente))
    no = ft.TextButton("No", on_click=lambda e: page.pop_dialog())
    mini_ventana = ft.AlertDialog(
        title=ft.Text("Aviso"),
        content=ft.Text(f"¿Deseas registrar este pago de el cliente {nombre_cliente} con codigo {codigo}?"),
        actions=[si, no],
        actions_alignment=ft.MainAxisAlignment.CENTER,
    )

    pagos = cs.get_hoja(cs.HOJA_PAGOS)
    registros = pagos.get_all_records()
    try:
        fecha_pago = None
        for r in registros:
            if r.get("Cliente") == codigo:
                if r.get("FechaPago") == None:
                    bandera = False
                    break
                else:
                    fecha_pago = r.get("FechaPago")
                    break
        
        if fecha_pago:
        # asumiendo formato "YYYY-MM-DD"
            mes_pago = fecha_pago[5:7]
            anio_pago = fecha_pago[0:4]
        else: 
            mes_pago = None
            anio_pago = None


        if mes_pago == date.today().strftime('%m') and anio_pago == date.today().strftime('%Y'):
                mini_ventana = ft.AlertDialog(
                    title=ft.Text("Aviso"),
                    content=ft.Text("¡El Cliente ya ha realizado su pago este mes!"),
                    actions=[ft.TextButton("Cerrar", on_click=lambda e: page.pop_dialog())],
                    actions_alignment=ft.MainAxisAlignment.END,
                )
        if bandera == False:
            page.show_dialog(mini_ventana)
            page.update()
            return
        # Mismo orden que el INSERT original: codigo, Monto, FechaPago, NombreCliente
    except Exception as e:
        page.show_dialog(ft.AlertDialog(ft.Text(f"Error al registrar el pago: {e}")))

    page.show_dialog(mini_ventana)
    page.update()

def generar_codigo() -> str:
    """Genera un código único de 8 caracteres alfanumérico."""
    caracteres = string.ascii_uppercase + string.digits
    hoja = cs.get_hoja(cs.HOJA_RESIDENCIAS)
    # Trae todos los códigos existentes en UNA sola llamada (columna "Codigo")
    registros = hoja.get_all_records()
    codigos_existentes = {r.get("Codigo") for r in registros}

    while True:
        codigo = ''.join(random.choices(caracteres, k=8))
        if codigo not in codigos_existentes:
            return codigo


def crear_residencia(page, nombre: str, precio: float, nombre_cliente: str):
    """Inserta la residencia en el Sheet y retorna (codigo, error)."""
    error = None
    codigo = None
    try:
        codigo = generar_codigo()
        hoja = cs.get_hoja(cs.HOJA_RESIDENCIAS)
        registros = hoja.get_all_records()
        nuevo_id = len(registros) + 1  # Id incremental simple
        # Ajusta el orden de columnas si tu encabezado es distinto
        hoja.append_row([nuevo_id, nombre, precio, codigo, nombre_cliente])
    except Exception as e:
        page.show_dialog(ft.Text(f"Error al crear residencia: {e}"))
        error = str(e)
        codigo = None
    return codigo, error

def cargar_pagos() -> list:
    """Retorna lista de tuplas (Id, Cliente, FechaPago, Monto)"""
    hoja = cs.get_hoja(cs.HOJA_PAGOS)
    registros = hoja.get_all_records()
    datos = []
    for r in registros:
        datos.append((r.get("Id"), r.get("Cliente"), r.get("FechaPago"), r.get("Monto")))
    return datos

def cargar_residencias() -> list:
    """
    Retorna lista de tuplas (Id, Nombre, Precio, Codigo, Cliente),
    replicando el LEFT JOIN que antes hacía SQL: para cada residencia
    busca el pago más reciente cuyo 'NombreCliente' coincida con el Codigo.
    """
    hoja_res = cs.get_hoja(cs.HOJA_RESIDENCIAS)
    hoja_pag = cs.get_hoja(cs.HOJA_PAGOS)

    residencias = hoja_res.get_all_records()
    pagos = hoja_pag.get_all_records()

    # Construir, por cliente (código), el pago con la fecha más reciente
    ultimo_pago = {}
    for pago in pagos:
        cliente = pago.get("NombreCliente")
        fecha_raw = pago.get("FechaPago")
        if not cliente or not fecha_raw:
            continue
        fecha = _parsear_fecha(fecha_raw)
        if cliente not in ultimo_pago or fecha > ultimo_pago[cliente]["_fecha"]:
            pago["_fecha"] = fecha
            ultimo_pago[cliente] = pago

    datos = []
    for r in residencias:
        codigo = r.get("Codigo")
        pago = ultimo_pago.get(codigo)
        cliente = pago["Cliente"] if pago else "Sin cliente"
        datos.append((r.get("Id"), r.get("Nombre"), r.get("Precio"), codigo, r.get("Cliente")))
    return datos


def _parsear_fecha(valor):
    """Convierte el valor de FechaPago a datetime para poder compararlas.
    Ajusta el formato si tus fechas en el Sheet vienen distintas."""
    if isinstance(valor, datetime):
        return valor
    for fmt in ("%Y-%m-%d %H:%M:%S", "%Y-%m-%d", "%d/%m/%Y %H:%M:%S", "%d/%m/%Y"):
        try:
            return datetime.strptime(str(valor), fmt)
        except ValueError:
            continue
    return datetime.min  # si no se puede parsear, la manda al fondo


# ──────────────────────────────────────────────────────────
# Estas dos funciones no tocan datos, así que quedan igual
# ──────────────────────────────────────────────────────────

def cambiar_tema(e, page):
    if page.theme_mode == ft.ThemeMode.LIGHT:
        page.theme_mode = ft.ThemeMode.DARK
    else:
        page.theme_mode = ft.ThemeMode.LIGHT
    page.show_dialog(ft.SnackBar(ft.Text("Tema cambiado")))
    page.update()


def cambiar_pestana(e, formulario, lista, cambio_tema, boton_ia, contenido_derecho):
    opcion_seleccionada = e.control.selected_index
    if opcion_seleccionada == 0:
        contenido_derecho.content = ft.Container(
            content=ft.Stack([
                ft.Column(
                    [
                        ft.Text("Bienvenido, Dueño", size=24, text_align=ft.TextAlign.CENTER),
                        ft.Container(
                            content=ft.Column(
                                [formulario],
                                alignment=ft.Alignment.CENTER,
                            ),
                            alignment=ft.Alignment(0, 0),
                        ),
                    ],
                    horizontal_alignment=ft.CrossAxisAlignment.CENTER,
                ),
                boton_ia,
            ]),
            expand=True,
            alignment=ft.Alignment(0, 0),
            padding=10,
        )
    elif opcion_seleccionada == 1:
        contenido_derecho.content = ft.Stack(
            controls=[
                ft.Column(
                    [ft.Text("Registro de Residencias\n", size=24), lista],
                    alignment=ft.Alignment.CENTER,
                ),
                boton_ia,
            ],
            expand=True
        )
    elif opcion_seleccionada == 2:
        contenido_derecho.content = ft.Container(
            content=ft.Stack([
                ft.Column(
                    [
                        ft.Text("Registro de Residencias", size=24, text_align=ft.TextAlign.CENTER),
                        ft.Container(
                            content=ft.Column(
                                [cambio_tema],
                                alignment=ft.Alignment.CENTER,
                            ),
                            alignment=ft.Alignment(0, 0),
                        ),
                    ],
                    horizontal_alignment=ft.CrossAxisAlignment.CENTER,
                ),
                boton_ia,
            ]),
            expand=True,
            alignment=ft.Alignment(0, 0),
            padding=10,
        )
    contenido_derecho.update()

def _construir_historial(historial, page, codigo, contenido_derecho):
    """Lee y filtra los pagos, y llena el ListView. Se ejecuta SIEMPRE
    dentro de un hilo (page.run_thread), nunca directamente en el hilo
    principal, porque hace una llamada de red a Google Sheets."""
    historial.controls.clear()
    hoja = cs.get_hoja(cs.HOJA_PAGOS)
    registros = hoja.get_all_records()

    pagos_cliente = [r for r in registros if r.get("Cliente") == codigo]
    # Más recientes primero, igual que se vería con ORDER BY FechaPago DESC
    pagos_cliente.sort(key=lambda r: _parsear_fecha(r.get("FechaPago")), reverse=True)

    for r in pagos_cliente:
        fecha_pago = r.get("FechaPago")
        historial.controls.append(
            ft.ListTile(
                leading=ft.Icon(ft.Icons.CHECK_CIRCLE, color=ft.Colors.GREEN),
                title=ft.Text(NOMBRES_MES[date.today().month]),
                subtitle=ft.Text(f"Pagado el {str(fecha_pago)}"),
            )
        )
    contenido_derecho.content = ft.Column(
                            [ft.Text("Historial de Pagos", size=24), historial],
                            alignment=ft.Alignment.CENTER
                        )

    
def cargar_historial(historial, page, codigo, contenido_derecho):
    def _tarea():
        _construir_historial(historial, page, codigo, contenido_derecho)
        page.update()

    page.run_thread(_tarea)