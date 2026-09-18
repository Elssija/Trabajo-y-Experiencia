from google_auth_oauthlib.flow import InstalledAppFlow

DRIVE_SCOPES = ["https://www.googleapis.com/auth/drive.file"]

print("Iniciando flujo OAuth...")
flow = InstalledAppFlow.from_client_secrets_file("client_secret.json", DRIVE_SCOPES)
print("Client secret cargado, abriendo servidor local...")
creds = flow.run_local_server(port=0)
print("Autenticación exitosa")

with open("token_drive.json", "w") as f:
    f.write(creds.to_json())

print("Token creado con éxito en:", "token_drive.json")
