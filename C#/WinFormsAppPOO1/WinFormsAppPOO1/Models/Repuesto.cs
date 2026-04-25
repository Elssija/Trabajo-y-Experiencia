using System;
using System.Collections.Generic;

namespace WinFormsAppPOO1.Models;

public partial class Repuesto
{
    public long RespuestoId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? Comentarios { get; set; }
}
