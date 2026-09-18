
import os
import smtplib
from email.message import EmailMessage
from datetime import date
import flet as ft
 
REMITENTE = "PRIVADO"       # cuenta que envía
DESTINATARIO = "PRIVADO"    # cuenta que recibe la notificación

CLAVE_APP = os.environ.get("GMAIL_APP_PASSWORD") or "PRIVADO"
 
 
def enviar_correo(page, asunto: str, cuerpo: str, destinatario: str = DESTINATARIO):
    """
    Envía un correo simple de texto. Devuelve True si se envió bien,
    False si hubo un error (y lo imprime en consola).
    """
    if not CLAVE_APP:
        page.show_dialog(ft.SnackBar(ft.Text("ERROR: no se encontró GMAIL_APP_PASSWORD en las variables de entorno."), bgcolor=ft.Colors.RED_400))
        page.update()
        return
 
    msg = EmailMessage()
    msg["Subject"] = asunto
    msg["From"] = REMITENTE
    msg["To"] = destinatario
    msg.set_content(cuerpo)
 
    try:
        with smtplib.SMTP_SSL("smtp.gmail.com", 465) as smtp:
            smtp.login(REMITENTE, CLAVE_APP)
            smtp.send_message(msg)
        return
    except Exception as e:
        page.show_dialog(ft.SnackBar(ft.Text(f"ERROR al enviar correo: {e}"), bgcolor=ft.Colors.RED_400))
        page.update()
        return
 
 
def notificar_pago_registrado(page, nombre_cliente: str, monto: str, codigo,) -> bool:
    """
    Ejemplo de función lista para usar cuando se registra un pago
    en tu app de residencias.
    """
    asunto = f"Pago registrado - {nombre_cliente}-{codigo}"
    cuerpo = (
        f"Se registró un nuevo pago.\n\n"
        f"Cliente: {nombre_cliente}\n"
        f"Monto: {monto}\n"
        f"Fecha: {date.today().strftime('%d/%m/%Y')}\n"
    )
    return enviar_correo(page ,asunto, cuerpo)