using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea1._3.Ejc2
{
    public class Persona
    {
        public string Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Nacionalidad { get; set; }

        public Persona (string nombre, DateTime nacimienta, string nacionalidad)
        {
            this.Nombre = nombre;
            this.Nacimiento = nacimienta;
            this.Nacionalidad = nacionalidad;
        }
    }
}
