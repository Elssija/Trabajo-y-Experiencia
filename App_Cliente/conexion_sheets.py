import os
import shutil
from pathlib import Path
from google.oauth2.service_account import Credentials
from google.oauth2.credentials import Credentials as CredencialesOAuth
from google.auth.transport.requests import Request

SCOPES = [
    "https://www.googleapis.com/auth/spreadsheets",
    "https://www.googleapis.com/auth/drive",
]
_DIR_APP = Path(__file__).resolve().parent

ARCHIVO_CREDENCIALES = _DIR_APP / "credenciales.json"   # el JSON de tu cuenta de servicio (Sheets)
ID_HOJA_CALCULO = "PRIVADO"   # el ID que aparece en la URL de tu Google Sheet
ID_CARPETA_COMPROBANTES = "PRIVADO"   # carpeta donde se guardan los comprobantes (en TU Drive)

DRIVE_SCOPES = ["https://www.googleapis.com/auth/drive.file"]
ARCHIVO_CLIENTE_OAUTH = _DIR_APP / "client_secret.json"

NOMBRE_TOKEN_OAUTH = "token_drive.json"
_TOKEN_SEMILLA = _DIR_APP / NOMBRE_TOKEN_OAUTH


def _ruta_token_drive() -> Path:
    ruta_escribible = Path(NOMBRE_TOKEN_OAUTH)  # relativo = carpeta de datos de la app
    if not ruta_escribible.exists() and _TOKEN_SEMILLA.exists():
        shutil.copy(_TOKEN_SEMILLA, ruta_escribible)
    return ruta_escribible


HOJA_RESIDENCIAS = "Residencias"
HOJA_PAGOS = "Pagos"

_cliente_gs = None  # se reutiliza entre llamadas para no re-autenticar cada vez
_servicio_drive = None  # idem, para la subida de comprobantes a Drive
_creds = None  # las credenciales se cargan una sola vez y las comparten ambos


def _get_creds():
    global _creds
    if _creds is None:
        _creds = Credentials.from_service_account_file(str(ARCHIVO_CREDENCIALES), scopes=SCOPES)
    return _creds


def get_cliente():
    global _cliente_gs
    if _cliente_gs is None:
        import gspread
        _cliente_gs = gspread.authorize(_get_creds())
    return _cliente_gs


def get_hoja(nombre_pestana: str):
    """Devuelve el objeto worksheet (pestaña) solicitado, p.ej. HOJA_RESIDENCIAS o HOJA_PAGOS."""
    libro = get_cliente().open_by_key(ID_HOJA_CALCULO)
    return libro.worksheet(nombre_pestana)


def _get_creds_drive():
    """Credenciales OAuth de tu cuenta real. Normalmente solo se refresca el
    token existente (funciona en móvil sin problema). Si el token llegara a
    invalidarse por completo, se necesitaría un navegador local para
    reautorizar — eso NO puede pasar dentro de una app móvil compilada."""
    ruta_token = _ruta_token_drive()
    creds_drive = None
    if ruta_token.exists():
        creds_drive = CredencialesOAuth.from_authorized_user_file(str(ruta_token), DRIVE_SCOPES)

    if not creds_drive or not creds_drive.valid:
        if creds_drive and creds_drive.expired and creds_drive.refresh_token:
            creds_drive.refresh(Request())
        else:
            from google_auth_oauthlib.flow import InstalledAppFlow
            flow = InstalledAppFlow.from_client_secrets_file(str(ARCHIVO_CLIENTE_OAUTH), DRIVE_SCOPES)
            creds_drive = flow.run_local_server(port=0)
        with open(ruta_token, "w") as f:
            f.write(creds_drive.to_json())

    return creds_drive


def get_drive():
    """Servicio de Drive con TU cuenta real (OAuth), reutilizado entre llamadas."""
    global _servicio_drive
    if _servicio_drive is None:
        from googleapiclient.discovery import build
        _servicio_drive = build("drive", "v3", credentials=_get_creds_drive())
    return _servicio_drive


def subir_comprobante_drive(ruta_local: str) -> str:
    """Sube un archivo (imagen o PDF) a la carpeta ID_CARPETA_COMPROBANTES,
    usando TU cuenta real vía OAuth (get_drive), y devuelve un link público
    de vista directa. Como ya subes con tu propia cuenta, la carpeta no
    necesita compartirse con nadie más — es tuya."""
    from googleapiclient.http import MediaFileUpload

    nombre = os.path.basename(ruta_local)
    metadata = {"name": nombre, "parents": [ID_CARPETA_COMPROBANTES]}
    media = MediaFileUpload(ruta_local, resumable=True)

    archivo = get_drive().files().create(
        body=metadata, media_body=media, fields="id"
    ).execute()
    file_id = archivo["id"]

    # Sin este permiso, el link queda privado y no abre para nadie más
    get_drive().permissions().create(
        fileId=file_id, body={"role": "reader", "type": "anyone"}
    ).execute()

    return f"https://drive.google.com/uc?id={file_id}"