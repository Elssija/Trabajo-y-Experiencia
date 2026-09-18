import base64
import json
import requests

# ⚠️ Ajusta este import al nombre real del archivo donde definiste
# API_KEY_IA y URL_API_IA (el mismo que usas en abrir_ventana_ia).
# Ejemplo: si ese código está en "asistente_ia.py", deja el import así.
from IA_APP import API_KEY_IA, URL_API_IA, MODELO_IA

# gpt-oss-120b (tu MODELO_IA del chat) es SOLO TEXTO, no puede leer imágenes.
# Para esto se necesita un modelo con visión aparte.
MODELO_IA_VISION = "qwen/qwen3.8-27b"

NOMBRES_MES = {
    1: "enero", 2: "febrero", 3: "marzo", 4: "abril", 5: "mayo", 6: "junio",
    7: "julio", 8: "agosto", 9: "septiembre", 10: "octubre", 11: "noviembre", 12: "diciembre",
}


def _codificar_imagen(ruta_imagen: str) -> str:
    with open(ruta_imagen, "rb") as f:
        return base64.b64encode(f.read()).decode("utf-8")


def validar_comprobante(monto, ruta_imagen: str, mes_esperado: int, anio_esperado: int) -> dict:
    """
    Le pide a la IA (Groq) que revise la imagen y diga si es un comprobante
    de pago real (transferencia, depósito, recibo en línea, etc.) y si es
    del mes/año que se está pagando.

    Devuelve:
        {"valido": bool, "motivo": str}

    Si algo falla (sin internet, respuesta rara de la IA, etc.) devuelve
    valido=False, para no dejar pasar un pago sin poder verificarlo.
    """
    nombre_mes = NOMBRES_MES.get(mes_esperado, str(mes_esperado))

    try:
        imagen_b64 = _codificar_imagen(ruta_imagen)
        extension = ruta_imagen.rsplit(".", 1)[-1].lower()
        mime = "image/png" if extension == "png" else "image/jpeg"

        prompt = (
            "Observa la imagen adjunta. Es un comprobante de pago subido por "
            "un cliente en una app de pagos de residencias/alquiler. "
            "Responde ÚNICAMENTE con un JSON, sin texto adicional y sin "
            "bloques de markdown, con exactamente estas claves:\n"
            '{"es_comprobante": true/false, "mes_detectado": number|null, '
            '"anio_detectado": number|null, "motivo": "string"}\n\n'
            "es_comprobante: true solo si es una factura, recibo, captura de "
            "transferencia bancaria, depósito o pago en línea real (no una "
            "foto random, un documento distinto, o algo ilegible).\n"
            "mes_detectado/anio_detectado: la fecha del pago que aparece en "
            "el comprobante (repórtala tal cual, aunque no coincida con lo "
            "esperado).\n"
            "motivo: 1 frase corta en español explicando tu conclusión.\n\n"
            f"Debes asegurarte que el comprobante tengo el monto equivalente a {monto} sino el recibo es invalido"
            f"El pago que se está registrando corresponde a {nombre_mes} de {anio_esperado}."
        )

        headers = {
            "Authorization": f"Bearer {API_KEY_IA}",
            "Content-Type": "application/json",
        }
        payload = {
            "model": MODELO_IA_VISION,
            "messages": [
                {
                    "role": "user",
                    "content": [
                        {"type": "text", "text": prompt},
                        {
                            "type": "image_url",
                            "image_url": {"url": f"data:{mime};base64,{imagen_b64}"},
                        },
                    ],
                }
            ],
            "temperature": 0.2,
            "response_format": {"type": "json_object"},
        }

        response = requests.post(URL_API_IA, json=payload, headers=headers, timeout=30)

        if response.status_code != 200:
            return {
                "valido": False,
                "motivo": f"No se pudo verificar el comprobante (servidor ocupado, código {response.status_code}). Intenta de nuevo.",
            }

        contenido = response.json()["choices"][0]["message"]["content"]
        datos = json.loads(contenido)

        es_comprobante = bool(datos.get("es_comprobante"))
        mes_detectado = datos.get("mes_detectado")
        anio_detectado = datos.get("anio_detectado")
        motivo_ia = datos.get("motivo", "")

        if not es_comprobante:
            return {
                "valido": False,
                "motivo": motivo_ia or "La imagen no parece ser un comprobante de pago válido.",
            }

        if mes_detectado == mes_esperado and anio_detectado == anio_esperado:
            return {"valido": True, "motivo": motivo_ia or "Comprobante válido."}

        if mes_detectado and anio_detectado:
            detalle = (
                f"El comprobante corresponde a {NOMBRES_MES.get(mes_detectado, mes_detectado)} "
                f"de {anio_detectado}, pero se esperaba {nombre_mes} de {anio_esperado}."
            )
        else:
            detalle = f"No se pudo confirmar que el comprobante sea de {nombre_mes} de {anio_esperado}."

        return {"valido": False, "motivo": detalle}

    except Exception as e:
        return {
            "valido": False,
            "motivo": f"No se pudo verificar el comprobante ({e}). Intenta de nuevo.",
        }

headers = {
            "Authorization": f"Bearer {API_KEY_IA}",
            "Content-Type": "application/json"
        }
        
payload = {
            "model": MODELO_IA,
            "messages": [
                {"role": "system", "content": "Que dia es hoy"},
                {"role": "user", "content": "Hola como estas"}
            ],
            "temperature": 0.5
        }


try:
        response = requests.post(URL_API_IA, json=payload, headers=headers)
        print("STATUS:", response.status_code)
        print("BODY:", response.text)

        if response.status_code == 200:
            ...
except Exception as ex:
        print("EXCEPCION:", ex)