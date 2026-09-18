from datetime import date

import flet as ft
import Funciones_Dueno as fo
import IA_APP as ia
import conexion_sheets as cs

def main(page: ft.Page):
    page.title = "App Dueño"
    page.theme_mode = ft.ThemeMode.DARK
    page.padding = 20

    def mostrar_historial(codigo: str, contenido_derecho: ft.Container):
        historial = ft.ListView(expand=True, spacing=10)
        fo.cargar_historial(historial, page, codigo, contenido_derecho)

    def guardar_cambios(codigo: str, nombre, precio, ventana_editar):
        hoja = cs.get_hoja(cs.HOJA_RESIDENCIAS)
        informacion = hoja.get_all_records()
        for i,r in enumerate(informacion, start=2):
                if r['Codigo'] == codigo:
                    fila_encontrada = i
                    break

        if nombre == "" or precio == "":
            page.show_dialog(ft.SnackBar(ft.Text("Si quieres cambiar el nombre o el precio, debes ingresar un valor.")))
            page.update()
            return
        if fila_encontrada is None:
            page.show_dialog(ft.SnackBar(ft.Text(f"No se encontró la residencia con código: {codigo}")))
            page.update()
            return
        # Ajusta las columnas según el orden real de tu hoja (Id, Nombre, Precio, Codigo, etc.)
        hoja.update_cell(fila_encontrada, 5, nombre)   # columna "nombre"
        hoja.update_cell(fila_encontrada, 3, precio)   # columna "precio"
        page.show_dialog(ft.SnackBar(ft.Text(f"Guardando cambios para la residencia con código: {codigo}")))
        ventana_editar.open = False
        page.show_dialog(ft.SnackBar(ft.Text(f"Cambios guardados para la residencia con código: {codigo}")))
        cargar_lista()
        page.update()

    def editar_residencia(codigo: str,):
        # Aquí puedes implementar la lógica para editar la residencia
        nombre = ft.TextField(label="Nuevo nombre")
        precio = ft.TextField(label="Nuevo precio")
        ventana_editar = ft.AlertDialog(
            content=ft.Container(
                content=ft.Column([
                    ft.Text(f"Editar residencia con código: {codigo}"),
                    nombre,
                    precio,
                    ft.ElevatedButton("Guardar cambios", bgcolor = ft.Colors.BLUE, color = ft.Colors.WHITE, on_click=lambda e: guardar_cambios(codigo, nombre.value, precio.value, ventana_editar)),
                ]),
                width=300,
                height=200,
            ),
            alignment=ft.Alignment.CENTER,
        )
        page.show_dialog(ventana_editar)
    # ── Formulario de creación ──────────────────────────
    campo_nombre = ft.TextField(label="Nombre de la residencia", width=300)
    campo_precio = ft.TextField(label="Precio mensual (Lps.)", width=300, keyboard_type=ft.KeyboardType.NUMBER)
    campo_nombre_cliente = ft.TextField(label="Nombre del cliente", width=300)
    texto_codigo  = ft.Text("", size=22, weight=ft.FontWeight.BOLD, color=ft.Colors.GREEN_700)
    texto_error   = ft.Text("", color=ft.Colors.RED_400)
    
    Cambio_tema = ft.ElevatedButton("Cambiar tema", tooltip="Cambiar tema", icon=ft.icons.Icons.BRIGHTNESS_6, on_click=lambda e: fo.cambiar_tema(e, page))

    def al_crear(e):
        texto_error.value = ""
        texto_codigo.value = ""

        nombre = campo_nombre.value.strip()
        precio_str = campo_precio.value.strip()
        nombre_cliente = campo_nombre_cliente.value.strip()

        if not nombre or not precio_str or not nombre_cliente:
            texto_error.value = "Completa todos los campos."
            page.update()
            return
        try:
            precio = float(precio_str)
        except ValueError:
            texto_error.value = "El precio debe ser un número."
            page.update()
            return

        codigo, error = fo.crear_residencia(page,nombre, precio, nombre_cliente)
        if codigo:
            texto_codigo.value = f"Código: {codigo}"
            campo_nombre.value = ""
            campo_precio.value = ""
            campo_nombre_cliente.value = ""
            cargar_lista()
        else:
            texto_error.value = f"Error al guardar: {error}"
        page.update()

    formulario = ft.Card(
        content=ft.Container(
            content=ft.Column([
                ft.Text("Nueva Residencia", size=20, weight=ft.FontWeight.BOLD),
                campo_nombre_cliente,
                campo_nombre,
                campo_precio,
                ft.ElevatedButton(
                    "Crear y generar código",
                    icon=ft.Icons.ADD_HOME,
                    bgcolor=ft.Colors.BLUE_700,
                    color=ft.Colors.WHITE,
                    on_click=al_crear
                ),
                texto_error,
                texto_codigo,
            ], spacing=12),
            padding=20,
        )
    )

    # ── Lista de residencias ────────────────────────────
    lista = ft.ListView(expand=True, spacing=8)

    def cargar_lista():
        lista.controls.clear()
        for row in fo.cargar_residencias():
            rid, nombre, precio, codigo, cliente = row
            lista.controls.append(
                ft.Card(
                    content=ft.Container(
                        content=ft.Row([
                            ft.Column([
                                ft.Text(nombre, size=16, weight=ft.FontWeight.BOLD),
                                ft.Text(f"Precio: {precio:.2f} Lps.", size=13, color=ft.Colors.GREY_600),
                                ft.Text(f"Código: {codigo}", size=13, color=ft.Colors.BLUE_700),
                            ], expand=True),
                            ft.Column([
                                ft.Icon(ft.Icons.PERSON, color=ft.Colors.GREY_500),
                                ft.Text(cliente, size=13),
                            ], horizontal_alignment=ft.CrossAxisAlignment.CENTER),
                            ft.IconButton(
                                                ft.Icons.HISTORY,
                                                tooltip="Ver historial de pagos",
                                                # Los argumentos por defecto (m=, f=, n=, c=) "congelan"
                                                # los valores de ESTA fila del for. Si se usa la variable
                                                # 'r' directo dentro del lambda, Python la captura por
                                                # referencia y todos los botones terminan mostrando el
                                                # último valor que tomó 'r' en el ciclo.
                                                on_click=lambda e, c=codigo: mostrar_historial(c, contenido_derecho)),
                            ft.IconButton(
                                            ft.Icons.EDIT,
                                            tooltip="Editar residencia",
                                            on_click=lambda e, c=codigo: editar_residencia(c)
                                        ),
                            ft.IconButton(
                                ft.Icons.PAYMENT,
                                tooltip="Ingresar Pago",
                                on_click=lambda e, c=codigo, p=precio, n=cliente: fo.agregar_pago(page,c, p, n)
                            )
                        ]),
                        padding=16,
                    )
                )
            )
        page.update()   
        
    #boton para mostrar el panel de gemini
    boton_ia = ft.Container(
            
            content = ft.ElevatedButton(
                icon=ft.Icons.ROCKET_LAUNCH,
                tooltip="Abrir panel de IA",
                on_click=lambda e: ia.abrir_ventana_ia(page),
                width=50,
                height=50,
            ),
            alignment = ft.Alignment.TOP_RIGHT,
            top=10,    
            right=10,  
    )
        
    contenido_derecho = ft.Container(
            content=ft.Stack([
                    ft.Column(
                    [
                        ft.Text("Bienvenido, Dueño", size=24, text_align=ft.TextAlign.CENTER),
                        ft.Container(
                            content=ft.Column(
                            [ft.Text("Bienvenido, Dueño", size=24), formulario,],
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
    
    menu_izquierdo = ft.NavigationRail(
        selected_index=0,
        label_type=ft.NavigationRailLabelType.SELECTED,
        min_width=100,
        extended=False,
        destinations=[
            ft.NavigationRailDestination(icon=ft.Icons.HOME_OUTLINED, selected_icon=ft.Icons.HOME, label="Inicio"),
            ft.NavigationRailDestination(icon=ft.Icons.HISTORY, selected_icon=ft.Icons.HISTORY_TOGGLE_OFF, label="Historial"),
            ft.NavigationRailDestination(icon=ft.Icons.SETTINGS_OUTLINED, selected_icon=ft.Icons.SETTINGS, label="Configuración"),
        ],
        on_change=lambda e: fo.cambiar_pestana(e, formulario, lista, Cambio_tema, boton_ia, contenido_derecho)
    )
        
        
        
    cargar_lista()

    page.add(
            ft.Row(
                [
                    menu_izquierdo,
                    ft.VerticalDivider(width=1),
                    contenido_derecho
                ],
                expand=True,
                vertical_alignment=ft.CrossAxisAlignment.STRETCH
            )
        )
    

ft.app(target=main)


