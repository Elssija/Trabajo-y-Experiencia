import flet as ft
import requests  # Asegúrate de tenerlo instalado: pip install requests
import Funciones_Dueno as fo
import os

API_KEY_IA = "PRIVADO"
#API_KEY_IA = ""  # Reemplaza con tu clave real
# --- CONFIGURACIÓN GRATUITA (Usando Groq) ---
URL_API_IA = "https://api.groq.com/openai/v1/chat/completions"
MODELO_IA = "openai/gpt-oss-120b"



def obtener_contexto_actualizado() -> list[str]:
    """Carga los datos en tiempo real de las residencias para dárselos a la IA."""
    try:
        pagos = fo.cargar_pagos()
        residencias = fo.cargar_residencias()

        if residencias:
            contexto = "DATOS EN TIEMPO REAL - RESIDENCIAS:\n"
            for row in residencias:
                rid, nombre, precio, codigo, cliente = row
                contexto += f"- Residencia: {nombre} | Precio: {precio:.2f} Lps. | Código: {codigo} | Inquilino/Pago actual: {cliente}\n"
        else:
            contexto = "No hay residencias registradas actualmente."

        if pagos:
            cont_pago = "DATOS EN TIEMPO REAL - PAGOS:\n"
            for row in pagos:
                pago_id, cliente, fecha, monto = row
                cont_pago += f"- Pago: {pago_id} | Cliente: {cliente} | Fecha: {fecha} | Monto: {monto:.2f} Lps.\n"
        else:
            cont_pago = "No hay pagos registrados actualmente."

        return [contexto, cont_pago]

    except Exception as e:
        mensaje_error = f"Error al recuperar datos del sistema: {str(e)}"
        return [mensaje_error, mensaje_error]

class BurbujaChat(ft.Row):
    def __init__(self, texto: str, es_usuario: bool):
        super().__init__()
        self.vertical_alignment = ft.CrossAxisAlignment.END
        self.alignment = ft.MainAxisAlignment.END if es_usuario else ft.MainAxisAlignment.START
        
        # Corrección en el mapeo de colores nativos
        color_fondo = ft.Colors.GREEN_200 if es_usuario else ft.Colors.WHITE
        color_texto = ft.Colors.BLACK87
        
        self.controls = [
            ft.Container(
                content=ft.Text(texto, size=14, color=color_texto),
                bgcolor=color_fondo,
                # Corrección: En Flet se escribe ft.padding.only (en minúscula)
                padding=ft.Padding.only(left=12, right=12, top=8, bottom=8),
                border_radius=ft.BorderRadius.only(
                    top_left=12,
                    top_right=12,
                    bottom_left=12 if es_usuario else 0,
                    bottom_right=0 if es_usuario else 12
                ),
                width=350,
                shadow=ft.BoxShadow(blur_radius=2, color=ft.Colors.BLACK12)
            )
        ]

def abrir_ventana_ia(page: ft.Page):
    datos_bd = obtener_contexto_actualizado()
    
    instrucciones_sistema = f"""
    Eres el asistente de inteligencia artificial exclusivo de esta aplicación residencial para el Dueño.
    Tu trabajo es responder dudas de manera corta, clara y precisa basándote en la información real provista abajo.

    {datos_bd[0]}  # Contexto de residencias

    REGLAS DE COMPORTAMIENTO:
    1. Si el dueño te pregunta por los registros o pagos de una persona, busca su nombre o residencia en los datos de arriba y detalla su estado actual.
    2. Si te pregunta sobre el funcionamiento de la app, explícale de forma sencilla que cuenta con un menú lateral con las secciones de 'Inicio' (para crear residencias y generar códigos), 'Historial' (para ver el registro completo) y 'Configuración' (para cambiar parámetros como el tema visual).
    3. Mantén un tono servicial, profesional y directo. Responde directamente en español de forma natural.

    {datos_bd[1]}  # Contexto de pagos
    1. Si el dueño te pregunta por los registros o pagos de una persona, busca su nombre o residencia en los datos de arriba y detalla su estado actual.
    2. Si te pregunta sobre el funcionamiento de la app, explícale de forma sencilla que cuenta con un menú lateral con las secciones de 'Inicio' (para crear residencias y generar códigos), 'Historial' (para ver el registro completo) y 'Configuración' (para cambiar parámetros como el tema visual).
    3. Mantén un tono servicial, profesional y directo. Responde directamente en español de forma natural.

    4. Debes revisar segun lo que el dueño te pregunte, si la información que desea es la pagina de pagos o la pagina de residencias
    5. Los pagos registrados son pagos que ya se realizaron, es decir estos no estan pendientes sino mas bien son ya pagos realizados.
    6. Solo habran pagos atrasados si la fecha de pago es un mes anterior al mes actual, es decir si la fecha de pago es de un mes anterior al mes actual entonces ese pago se considera atrasado.
    """
    historial_chat = ft.ListView(expand=True, spacing=10, auto_scroll=True)
    entrada_texto = ft.TextField(
        hint_text="Escribe un mensaje...",
        expand=True,
        border_radius=20,
        content_padding=12,
        bgcolor=ft.Colors.WHITE,
        color=ft.Colors.BLACK
    )
    boton_enviar = ft.IconButton(
        icon=ft.Icons.SEND,
        icon_color=ft.Colors.GREEN_700,
    )
    progreso = ft.ProgressRing(visible=False, width=20, height=20, color=ft.Colors.GREEN_700)

    historial_chat.controls.append(
        BurbujaChat("¡Hola! ¿Cómo te puedo ayudar hoy con los registros de la app?", es_usuario=False)
    )

    def enviar_mensaje(e):
        texto = entrada_texto.value.strip()
        if not texto:
            return

        historial_chat.controls.append(BurbujaChat(texto, es_usuario=True))
        entrada_texto.value = ""
        progreso.visible = True
        boton_enviar.disabled = True
        page.update()

        headers = {
            "Authorization": f"Bearer {API_KEY_IA}",
            "Content-Type": "application/json"
        }
        
        payload = {
            "model": MODELO_IA,
            "messages": [
                {"role": "system", "content": instrucciones_sistema},
                {"role": "user", "content": texto}
            ],
            "temperature": 0.5
        }

        try:
            response = requests.post(URL_API_IA, json=payload, headers=headers)
            
            if response.status_code == 200:
                resultado = response.json()
                texto_ia = resultado["choices"][0]["message"]["content"]
                historial_chat.controls.append(BurbujaChat(texto_ia, es_usuario=False))
            else:
                historial_chat.controls.append(BurbujaChat(f"Error de API: Servidor ocupado (Código {response.status_code}). Intenta de nuevo.", es_usuario=False))
        except Exception as ex:
            historial_chat.controls.append(BurbujaChat(f"Error de conexión local: {str(ex)}", es_usuario=False))

        progreso.visible = False
        boton_enviar.disabled = False
        page.update()

    boton_enviar.on_click = enviar_mensaje
    entrada_texto.on_submit = enviar_mensaje

    # CORRECCIÓN: Usamos ft.AlertDialog en lugar de BottomSheet para que sea compatible con page.open() / page.show_dialog()
    ventana_emergente = ft.AlertDialog(
        content=ft.Container(
            content=ft.Column([
                ft.Row([
                    ft.Text("Asistente Virtual IA", size=16, weight=ft.FontWeight.BOLD, color=ft.Colors.WHITE),
                    # Para cerrar usamos page.close() de forma segura
                    ft.IconButton(ft.Icons.CLOSE, icon_color=ft.Colors.WHITE, on_click=lambda _: page.pop_dialog())
                ], alignment=ft.MainAxisAlignment.SPACE_BETWEEN),
                ft.Divider(color=ft.Colors.WHITE24),
                ft.Container(
                    content=historial_chat,
                    expand=True,
                    padding=10,
                    bgcolor=ft.Colors.GREY_900,
                    border_radius=10
                ),
                ft.Container(
                    content=ft.Row([entrada_texto, progreso, boton_enviar], vertical_alignment=ft.CrossAxisAlignment.CENTER),
                    padding=ft.Padding.only(top=5) # Corrección minúscula
                )
            ]),
            padding=15,
            height=500,
            width=400, # Añadimos ancho fijo para que luzca simétrico como un modal
            bgcolor=ft.Colors.BLUE_GREY_900,
            border_radius=12
        )
    )

    #def analisis_imagen()

    # El método estándar y moderno de Flet para abrir diálogos de alerta
    
    page.show_dialog(ventana_emergente)


