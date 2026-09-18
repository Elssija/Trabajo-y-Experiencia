import flet as ft
from fpdf import FPDF
import Funciones as cp
from datetime import date
import locale
import time
import sys
import traceback

CLAVE_STORAGE = "app_pagos.codigo_residencia"

try:
    locale.setlocale(locale.LC_ALL, 'es_CO.UTF-8')
except locale.Error:
    pass

INTERVALO_REFRESCO_CARA = 3600


async def main(page: ft.Page):

    print("PASO 1: entrando a main")
    page.title = "App de Pagos"
    page.theme_mode = ft.ThemeMode.DARK
    page.padding = 20
    print("PASO 2: configuracion basica lista")

    # ── Pantalla de código ──────────────────────────────
    campo_codigo = ft.TextField(
        label="Ingresa el código de tu residencia",
        width=300,
        text_align=ft.TextAlign.CENTER,
        password=True,
        can_reveal_password=True,
    )
    texto_error = ft.Text("", color=ft.Colors.RED_400)

    async def al_ingresar_codigo(e):
        codigo = campo_codigo.value.strip().upper()
        if not codigo:
            texto_error.value = "Ingresa un código."
            page.update()
            return
        resultado = cp.verificar_codigo(codigo)
        if resultado is None:
            texto_error.value = "Código incorrecto, intenta de nuevo."
            page.update()
            return
        nombre_residencia, precio, nombre_cliente = resultado
        await page.shared_preferences.set(CLAVE_STORAGE, codigo)
        mostrar_app_principal(codigo, nombre_residencia, precio, nombre_cliente)

    pantalla_codigo = ft.Container(
        content=ft.Column(
            [
                ft.Icon(ft.Icons.LOCK_OUTLINE, size=64, color=ft.Colors.BLUE_700),
                ft.Text("Bienvenido", size=28, weight=ft.FontWeight.BOLD,
                        text_align=ft.TextAlign.CENTER),
                ft.Text("Ingresa el código que te dio el dueño",
                        size=14, color=ft.Colors.GREY_600,
                        text_align=ft.TextAlign.CENTER),
                campo_codigo,
                texto_error,
                ft.ElevatedButton(
                    "Entrar",
                    icon=ft.Icons.ARROW_FORWARD,
                    bgcolor=ft.Colors.BLUE_700,
                    color=ft.Colors.WHITE,
                    width=300,
                    on_click=al_ingresar_codigo,
                ),
            ],
            horizontal_alignment=ft.CrossAxisAlignment.CENTER,
            alignment=ft.MainAxisAlignment.CENTER,
            spacing=16,
        ),
        expand=True,
        alignment=ft.Alignment(0, 0),
    )

    # ── App principal ───────────────────────────────────
    def mostrar_app_principal(codigo: str, nombre_residencia: str, precio: float, nombre_cliente: str):
        page.controls.clear()

        Cambio_tema = ft.ElevatedButton(
            "Cambiar tema",
            tooltip="Cambiar tema",
            icon=ft.icons.Icons.BRIGHTNESS_6,
            on_click=lambda e: cp.cambiar_tema(e, page),
        )

        historial = ft.ListView(expand=True, spacing=10)
        cp.cargar_historial(historial, page, codigo)

        # Contenedor reutilizado tanto por el refresco periódico como por
        # cambiar_pestana, para no reconstruir toda la pantalla de Inicio.
        cara_container = ft.Container(
            content=cp.cara_estado_pago(codigo),
            alignment=ft.Alignment(0, 0),
        )

        saldo_card = ft.Card(
            content=ft.Container(
                content=ft.Column([
                    ft.Text("MENSUALIDAD", size=16, color=ft.Colors.GREY_700),
                    ft.Text(f"{precio:.2f} lps.", size=40, weight=ft.FontWeight.BOLD),
                    ft.Text(nombre_residencia, size=14, color=ft.Colors.GREY_600),
                    ft.ElevatedButton(
                        "Pagar ahora",
                        icon=ft.icons.Icons.PAYMENT,
                        bgcolor=ft.Colors.BLUE_700,
                        color="white",
                        on_click=lambda e: cp.ventana_pago(e, page, historial, codigo, precio, nombre_cliente, cara_container),
                    ),
                ], alignment=ft.MainAxisAlignment.CENTER, horizontal_alignment=ft.CrossAxisAlignment.CENTER),
                padding=20,
            )
        )

        contenido_derecho = ft.Container(
            content=ft.Column(
                [
                    ft.Text(f"Bienvenido", size=24, text_align=ft.TextAlign.CENTER),
                    saldo_card,
                    cara_container,
                ],
                horizontal_alignment=ft.CrossAxisAlignment.CENTER,
            ),
            expand=True,
            alignment=ft.Alignment(0, 0),
            padding=10,
        )

        sesion_activa = {"activa": True}

        async def al_cerrar_sesion(e):
            sesion_activa["activa"] = False
            await page.shared_preferences.remove(CLAVE_STORAGE) 
            page.controls.clear()
            campo_codigo.value = ""
            texto_error.value = ""
            page.add(pantalla_codigo)
            page.update()

        boton_cerrar_sesion = ft.ElevatedButton(
            "Cerrar sesión",
            icon=ft.Icons.LOGOUT,
            bgcolor=ft.Colors.RED_400,
            color=ft.Colors.WHITE,
            on_click=al_cerrar_sesion,
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
            on_change=lambda e: cp.cambiar_pestana(
                e, saldo_card, historial, Cambio_tema, contenido_derecho, boton_cerrar_sesion, codigo, cara_container
            ),
        )

        page.add(
            ft.Row(
                [
                    menu_izquierdo,
                    ft.VerticalDivider(width=1),
                    contenido_derecho,
                ],
                expand=True,
                vertical_alignment=ft.CrossAxisAlignment.STRETCH,
            )
        )
        page.update()

        # ── Refresco periódico de la carita mientras la app sigue abierta ──
        def _refrescar_cara_en_bucle():
            while sesion_activa["activa"]:
                time.sleep(INTERVALO_REFRESCO_CARA)
                if not sesion_activa["activa"]:
                    break
                cp.refrescar_cara(cara_container, codigo)
                page.update()

        page.run_thread(_refrescar_cara_en_bucle)

    # ── Al arrancar: si ya hay un código guardado, saltamos el login ──
    codigo_guardado = await page.shared_preferences.get(CLAVE_STORAGE)
    if codigo_guardado:
        resultado = cp.verificar_codigo(codigo_guardado)
        if resultado:
            nombre_residencia, precio, nombre_cliente = resultado
            mostrar_app_principal(codigo_guardado, nombre_residencia, precio, nombre_cliente)
            return
        else:
            await page.shared_preferences.remove(CLAVE_STORAGE)  # código ya no válido, limpiamos

    # ── Arrancar con pantalla de código ─────────────────
    page.add(pantalla_codigo)


ft.app(target=main)