import flet as ft
from fpdf import FPDF
from datetime import date, datetime
import flet.canvas as cv
import Correo_Envio as cen

import conexion_sheets as cs
import Verificacion_IA_Pago as via

# Nombres de mes en español, sin depender del locale del sistema (en
# Android/iOS el Python empacado no siempre trae instalados los locales,
# y locale.setlocale('es_...') puede fallar o simplemente dar el nombre
# en inglés).
NOMBRES_MES = {
    1: "Enero", 2: "Febrero", 3: "Marzo", 4: "Abril", 5: "Mayo", 6: "Junio",
    7: "Julio", 8: "Agosto", 9: "Septiembre", 10: "Octubre", 11: "Noviembre", 12: "Diciembre",
}

# La hoja "Pagos" se asume con las columnas: Cliente | Monto | FechaPago | NombreCliente
# (mismo orden que el INSERT original en SQL). El identificador usado para
# filtrar/relacionar pagos con un cliente es el "codigo" de residencia.


# ─── Genera el PDF del recibo con formato de factura ─────────────────────
def generar_pdf(e, page, monto, fecha_pago, nombre_cliente, codigo):
    def _tarea():
        pdf = FPDF()
        pdf.add_page()

        # ── Encabezado ──────────────────────────────
        pdf.set_fill_color(25, 118, 210)
        pdf.rect(0, 0, 210, 28, 'F')
        pdf.set_text_color(255, 255, 255)
        pdf.set_font("Arial", 'B', 20)
        pdf.set_xy(10, 6)
        pdf.cell(0, 10, "RECIBO DE PAGO", ln=True)
        pdf.set_font("Arial", '', 10)
        pdf.set_xy(10, 18)
        pdf.cell(0, 6, f"Residencia - Código: {codigo}")
        pdf.set_text_color(0, 0, 0)
        pdf.set_xy(10, 36)

        # ── No. de recibo / fecha de emisión ────────
        numero_recibo = f"{codigo}-{date.today().strftime('%Y%m%d%H%M%S')}"
        pdf.set_font("Arial", '', 11)
        pdf.cell(95, 8, f"No. de recibo: {numero_recibo}")
        pdf.cell(95, 8, f"Emitido: {date.today().strftime('%d/%m/%Y')}", align="R", ln=True)
        pdf.ln(6)

        # ── Datos del cliente ────────────────────────
        pdf.set_font("Arial", 'B', 12)
        pdf.cell(0, 8, "Datos del cliente", ln=True)
        pdf.set_draw_color(200, 200, 200)
        pdf.line(10, pdf.get_y(), 200, pdf.get_y())
        pdf.ln(3)
        pdf.set_font("Arial", '', 11)
        pdf.cell(0, 7, f"Cliente: {nombre_cliente}", ln=True)
        pdf.cell(0, 7, f"Código de residencia: {codigo}", ln=True)
        pdf.ln(6)

        # ── Detalle del pago (tabla) ────────────────
        pdf.set_font("Arial", 'B', 12)
        pdf.cell(0, 8, "Detalle del pago", ln=True)
        pdf.line(10, pdf.get_y(), 200, pdf.get_y())
        pdf.ln(3)

        pdf.set_fill_color(240, 240, 240)
        pdf.set_font("Arial", 'B', 11)
        pdf.cell(130, 9, "Concepto", border=1, fill=True)
        pdf.cell(60, 9, "Monto", border=1, fill=True, align="R", ln=True)

        pdf.set_font("Arial", '', 11)
        pdf.cell(130, 9, "Mensualidad", border=1)
        pdf.cell(60, 9, f"L. {float(monto):.2f}", border=1, align="R", ln=True)

        pdf.cell(130, 9, "Fecha de pago", border=1)
        pdf.cell(60, 9, str(fecha_pago), border=1, align="R", ln=True)
        pdf.ln(2)

        pdf.set_font("Arial", 'B', 13)
        pdf.cell(130, 10, "TOTAL PAGADO", border=1)
        pdf.cell(60, 10, f"L. {float(monto):.2f}", border=1, align="R", ln=True)

        # ── Pie ───────────────────────────────────────
        pdf.ln(14)
        pdf.set_font("Arial", 'I', 9)
        pdf.set_text_color(120, 120, 120)
        pdf.multi_cell(0, 5, "Este recibo es un comprobante generado automáticamente y no requiere firma.", align="C")

        nombre_archivo = f"Recibo_{codigo}_{date.today().strftime('%Y-%m-%d_%H%M%S')}.pdf"
        pdf.output(nombre_archivo)
        page.show_dialog(ft.SnackBar(ft.Text("PDF generado")))
        page.update()

    # page.run_thread ejecuta la tarea en el executor de ESTA página/sesión,
    # así page.update() se refleja de inmediato en el cliente (a diferencia
    # de threading.Thread, cuyos cambios quedaban pendientes hasta el
    # siguiente evento disparado desde el hilo principal).
    page.run_thread(_tarea)


def cambiar_tema(e, page):
    if page.theme_mode == ft.ThemeMode.LIGHT:
        page.theme_mode = ft.ThemeMode.DARK
    else:
        page.theme_mode = ft.ThemeMode.LIGHT
    page.show_dialog(ft.SnackBar(ft.Text("Tema cambiado")))
    page.update()


def _parsear_fecha(valor):
    """Convierte el valor de FechaPago (texto en el Sheet) a date/datetime comparable."""
    if isinstance(valor, (date, datetime)):
        return valor
    for fmt in ("%Y-%m-%d %H:%M:%S", "%Y-%m-%d", "%d/%m/%Y %H:%M:%S", "%d/%m/%Y"):
        try:
            return datetime.strptime(str(valor), fmt)
        except ValueError:
            continue
    return datetime.min


# ─── Construye la lista de ListTile a partir de los registros del Sheet ───
def _construir_historial(historial, page, nombre):
    """Lee y filtra los pagos, y llena el ListView. Se ejecuta SIEMPRE
    dentro de un hilo (page.run_thread), nunca directamente en el hilo
    principal, porque hace una llamada de red a Google Sheets."""
    historial.controls.clear()
    hoja = cs.get_hoja(cs.HOJA_PAGOS)
    registros = hoja.get_all_records()

    pagos_cliente = [r for r in registros if r.get("Cliente") == nombre]
    # Más recientes primero, igual que se vería con ORDER BY FechaPago DESC
    pagos_cliente.sort(key=lambda r: _parsear_fecha(r.get("FechaPago")), reverse=True)

    for r in pagos_cliente:
        fecha_pago = r.get("FechaPago")
        monto = r.get("Monto")
        nombre_cliente = r.get("NombreCliente")
        historial.controls.append(
            ft.ListTile(
                leading=ft.Icon(ft.Icons.CHECK_CIRCLE, color=ft.Colors.GREEN),
                title=ft.Text(NOMBRES_MES[date.today().month]),
                subtitle=ft.Text(f"Pagado el {str(fecha_pago)}"),
                trailing=ft.IconButton(
                    ft.Icons.PICTURE_AS_PDF,
                    tooltip="Descargar recibo",
                    # Los argumentos por defecto (m=, f=, n=, c=) "congelan"
                    # los valores de ESTA fila del for. Si se usa la variable
                    # 'r' directo dentro del lambda, Python la captura por
                    # referencia y todos los botones terminan mostrando el
                    # último valor que tomó 'r' en el ciclo.
                    on_click=lambda e, m=monto, f=fecha_pago, n=nombre_cliente, c=nombre: generar_pdf(e, page, m, f, n, c)
                )
            )
        )


# ─── Carga el historial (uso normal: al entrar a la app / cambiar de pestaña) ─
def cargar_historial(historial, page, nombre):
    def _tarea():
        _construir_historial(historial, page, nombre)
        page.update()

    page.run_thread(_tarea)


# ─── Registra el pago y recarga el historial en el MISMO hilo ────────────
def realizar_pago(e, historial, page, codigo, monto, nombre_cliente, cara_container, ruta_comprobante=None):
    def _tarea():
        realizar_pago_sheet(page,codigo, monto, nombre_cliente, ruta_comprobante)
        # Recargamos el historial filtrando SIEMPRE por 'codigo' (el mismo
        # identificador que usa cargar_historial al inicio), no por el
        # nombre del cliente — así el filtro siempre coincide con lo que
        # se acaba de escribir en la hoja.
        _construir_historial(historial, page, codigo)
        refrescar_cara(cara_container, codigo)
        page.show_dialog(ft.SnackBar(ft.Text("Pago realizado")))
        cen.notificar_pago_registrado(page, nombre_cliente, monto, codigo)
        page.update()

    page.run_thread(_tarea)


def realizar_pago_sheet(page, codigo, monto, nombre_cliente, ruta_comprobante=None):
    fecha_actual = date.today().strftime('%Y-%m-%d')

    # Sheets no guarda archivos, solo texto: subimos el comprobante (imagen o
    # PDF) a Drive con la misma cuenta de servicio y guardamos el link.
    url_comprobante = ""
    if ruta_comprobante:
        try:
            url_comprobante = cs.subir_comprobante_drive(ruta_comprobante)
        except Exception as e:
            print("ERROR SUBIENDO A DRIVE:", e)
            page.show_dialog(ft.SnackBar(ft.Text(f"No se pudo subir el comprobante: {e}"), bgcolor=ft.Colors.RED_400))

    try:
        hoja = cs.get_hoja(cs.HOJA_PAGOS)
        # Con =IMAGE("url") la celda muestra la foto directamente, no un
        # link de texto. value_input_option="USER_ENTERED" es obligatorio
        # para que Sheets interprete el "=" como fórmula y no como texto plano.
        formula_imagen = f'=IMAGE("{url_comprobante}")' if url_comprobante else ""
        hoja.append_row(
            [codigo, monto, fecha_actual, nombre_cliente, formula_imagen],
            value_input_option="USER_ENTERED",
        )
    except Exception as e:
        page.show_dialog(ft.SnackBar(ft.Text(f"Error al registrar el pago: {e}")))


# ─── Sin hilo: solo reorganiza widgets ya cargados en memoria ───────────────
def cambiar_pestana(e, saldo_card, historial, cambio_tema, contenido_derecho, boton_cerrar_sesion, codigo, cara_container):
    opcion_seleccionada = e.control.selected_index
    if opcion_seleccionada == 0:
        refrescar_cara(cara_container, codigo)
        contenido_derecho.content = ft.Column(
            [ft.Text("Bienvenido", size=24), saldo_card, cara_container],
            alignment=ft.MainAxisAlignment.CENTER,
            horizontal_alignment=ft.CrossAxisAlignment.CENTER
        )
    elif opcion_seleccionada == 1:
        contenido_derecho.content = ft.Column(
            [ft.Text("Historial de Pagos", size=24), historial],
            alignment=ft.Alignment.CENTER
        )
    elif opcion_seleccionada == 2:
        contenido_derecho.content = ft.Column(
            [ft.Text("Configuración del Sistema", size=24), cambio_tema, boton_cerrar_sesion],
            alignment=ft.Alignment.CENTER
        )
    contenido_derecho.update()


# ─── VENTANA DE PAGO ──────────────────────────────────────────────────────
def ventana_pago(e, page, historial, codigo, monto, nombre_cliente, cara_container):
    texto_archivo = ft.Text("Ningún archivo seleccionado", italic=True)
    archivo_seleccionado = {"ruta": None}

    # ── Selector de archivos multiplataforma (reemplaza tkinter) ──────────
    # tkinter no existe en Android/iOS. ft.FilePicker sí funciona en Windows,
    # Android e iOS por igual, usando el explorador nativo de cada plataforma.
    # pick_files() es async: se espera (await) y devuelve la lista de
    # archivos directamente, sin necesidad de un callback on_result.
    file_picker = ft.FilePicker()

    async def abrir_explorador(e):
        archivos = await file_picker.pick_files(
            dialog_title="Selecciona una imagen",
            file_type=ft.FilePickerFileType.CUSTOM,
            allowed_extensions=["png", "jpg", "jpeg"],
        )
        if archivos:
            archivo = archivos[0]
            archivo_seleccionado["ruta"] = archivo.path
            texto_archivo.value = f"Archivo listo: {archivo.name}"
        else:
            texto_archivo.value = "Seleccion cancelada."
        page.update()

    def cerrar_dialogo():
        mini_ventana.open = False
        page.update()

    def realizar_accion_pago(e):
        estado = texto_archivo.value
        if estado in ("Ningún archivo seleccionado", "Seleccion cancelada."):
            page.show_dialog(ft.SnackBar(ft.Text("DEBE SUBIR SU RECIBO DE PAGO :)")))
            return

        ruta_comprobante = archivo_seleccionado["ruta"]
        texto_archivo.value = page.show_dialog(ft.SnackBar(ft.Text("Validando comprobante..."), bgcolor=ft.Colors.BLUE_400))
        page.update()

        def _validar_y_pagar():
            resultado = via.validar_comprobante(monto,ruta_comprobante, hoy.month, hoy.year)

            if not resultado["valido"]:
                texto_archivo.value = f"Archivo listo: {ruta_comprobante.split('/')[-1]}"
                page.show_dialog(ft.SnackBar(ft.Text(resultado["motivo"]), bgcolor=ft.Colors.RED_400))
                page.update()
                return

            cerrar_dialogo()
            realizar_pago(e, historial, page, codigo, monto, nombre_cliente, cara_container, ruta_comprobante)

        page.run_thread(_validar_y_pagar)

    pagos = cs.get_hoja(cs.HOJA_PAGOS)
    registros = pagos.get_all_records()

    fecha_pago = None
    for r in registros:
        if r.get("Cliente") == codigo:
            fecha_pago = r.get("FechaPago")

    hoy = date.today()

    if fecha_pago:
        # asumiendo formato "YYYY-MM-DD"
        mes_pago = fecha_pago[5:7]
        anio_pago = fecha_pago[0:4]
    else: 
        mes_pago = None
        anio_pago = None


    if fecha_pago and mes_pago == hoy.strftime('%m') and anio_pago == hoy.strftime('%Y'):
        mini_ventana = ft.AlertDialog(
            title=ft.Text("Aviso"),
            content=ft.Text("¡Ya has realizado tu pago este mes!"),
            actions=[ft.TextButton("Cerrar", on_click=lambda e: page.pop_dialog())],
            actions_alignment=ft.MainAxisAlignment.END,
        )
    else:
        mini_ventana = ft.AlertDialog(
            modal=True,
            title=ft.Text("Subir Documento"),
            content=ft.Column(
                [
                    ft.Text("Por favor, selecciona un archivo de tu computadora:"),
                    ft.Row(
                        [ft.ElevatedButton(
                            "Buscar archivo...",
                            icon=ft.Icons.FOLDER_OPEN,
                            on_click=abrir_explorador,
                        )],
                        alignment=ft.MainAxisAlignment.CENTER,
                    ),
                    ft.Container(
                        content=texto_archivo,
                        padding=10,
                        alignment=ft.Alignment(0, 0)
                    ),
                ],
                tight=True,
                height=120,
            ),
            actions=[
                ft.TextButton("Cancelar", on_click=lambda e: cerrar_dialogo()),
                ft.ElevatedButton(
                    "Aceptar",
                    bgcolor=ft.Colors.BLUE,
                    color=ft.Colors.WHITE,
                    on_click=realizar_accion_pago,
                ),
            ],
            actions_alignment=ft.MainAxisAlignment.END,
        )

    page.show_dialog(mini_ventana)


# ─── Recalcula la carita y la deja lista en su contenedor ───────────────────
def refrescar_cara(cara_container, codigo):
    """Vuelve a calcular el estado de pago y reemplaza el contenido del
    contenedor. Quien llame a esta función es responsable de hacer
    page.update() después (así se puede combinar con otros cambios en el
    mismo ciclo de actualización)."""
    cara_container.content = cara_estado_pago(codigo)


# ─── Sin hilo: construye y retorna un widget, no toca disco ─────────────────
def cara_estado_pago(nombre: str = None) -> ft.Control:
    """
    NOTA: la versión original en SQL tomaba el último pago de TODA la tabla
    Pagos (sin filtrar por cliente). Aquí dejo la opción de pasar 'nombre'
    (o 'codigo', según el identificador que uses) para filtrar correctamente;
    si no se pasa, se comporta igual que antes (usa el pago más reciente de
    todos).
    """
    try:
        hoja = cs.get_hoja(cs.HOJA_PAGOS)
        registros = hoja.get_all_records()
        if nombre:
            registros = [r for r in registros if r.get("Cliente") == nombre]

        if registros:
            registros.sort(key=lambda r: _parsear_fecha(r.get("FechaPago")), reverse=True)
            ultimo_pago = _parsear_fecha(registros[0].get("FechaPago"))
            if hasattr(ultimo_pago, 'date'):
                ultimo_pago = ultimo_pago.date()
            dias = (date.today() - ultimo_pago).days
            t = min(dias / 29, 1.0)
        else:
            t = 0.0
    except Exception:
        t = 0.0

    if t < 0.25:
        color = "#558B2F"
        mensaje_txt = "¡PAGO RECIENTE!"
    elif t < 0.5:
        color = "#F9A825"
        mensaje_txt = "EL MES EMPIEZA"
    elif t < 0.75:
        color = "#E64A19"
        mensaje_txt = "SE ACERCA FIN DE MES"
    else:
        color = "#B71C1C"
        mensaje_txt = "⚠️ ¡TIEMPO LIMITE DE PAGO!"

    # Desplazamiento de la boca respecto al centro (125), escalado por 1.1
    # para exagerar un poco la curva. Ojo: el 1.1 se aplica SOLO a la
    # curvatura (curvatura), nunca a ctrl_y ya sumado al 125 — si no, el
    # punto neutro (t=0.5) deja de verse recto y todo el rango queda
    # sesgado hacia la sonrisa.
    curvatura = -22 + t * 44
    ctrl_y = 125 - curvatura * 1.1

    cara = cv.Canvas(
        shapes=[
            cv.Circle(72, 85, 9, ft.Paint(color=color)),
            cv.Circle(128, 85, 9, ft.Paint(color=color)),
            cv.Path(
                elements=[
                    cv.Path.MoveTo(70, 125),
                    cv.Path.QuadraticTo(100, ctrl_y, 130, 125),
                ],
                paint=ft.Paint(
                    color=color,
                    stroke_width=4,
                    style=ft.PaintingStyle.STROKE,
                    stroke_cap=ft.StrokeCap.ROUND
                )
            ),
        ],
        width=200,
        height=200,
    )

    return ft.Column(
        controls=[
            ft.Container(
                content=cara,
                width=200,
                height=200,
                alignment=ft.Alignment(0, 0),
            ),
            ft.Text(mensaje_txt, size=18, weight=ft.FontWeight.BOLD, color=color)
        ],
        horizontal_alignment=ft.CrossAxisAlignment.CENTER,
        spacing=6
    )


# ─── función para validar el código único de la app de dueño ────────────────
def verificar_codigo(codigo: str):
    """Retorna (nombre_residencia, precio, nombre_cliente) si el código existe, sino None."""
    hoja = cs.get_hoja(cs.HOJA_RESIDENCIAS)
    registros = hoja.get_all_records()
    for r in registros:
        if r.get("Codigo") == codigo:
            return (r.get("Nombre"), r.get("Precio"), r.get("Cliente"))
    return None