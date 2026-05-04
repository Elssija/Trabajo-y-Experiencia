using System;
using System.Collections.Generic;

namespace Tarea3._3_POO.Models;

public partial class Venta
{
    public long ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public long Existencias { get; set; }

    public string Codigo { get; set; } = null!;

    public string Observaciones { get; set; } = null!;
}
