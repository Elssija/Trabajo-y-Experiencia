using System;
using System.Collections.Generic;

namespace WinFormsAppPOO1.Models;

public partial class Producto
{
    public long ProductoId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public decimal Costo { get; set; }

    public decimal PrecioVenta { get; set; }

    public int Existencias { get; set; }

    public string? Comentarios { get; set; }
}
