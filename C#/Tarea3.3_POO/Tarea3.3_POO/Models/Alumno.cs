using System;
using System.Collections.Generic;

namespace Tarea3._3_POO.Models;

public partial class Alumno
{
    public long AlumnoId { get; set; }

    public string Cuenta { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Carrera { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Observaciones { get; set; } = null!;
}
