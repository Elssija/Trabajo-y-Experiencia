class WSGIServer:
    allow_reuse_address = False


class WSGIRequestHandler:
    pass


def make_server(*args, **kwargs):
    raise NotImplementedError("wsgiref no disponible en Android")