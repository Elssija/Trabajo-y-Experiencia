using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2_POO.Clases
{
    public class Ingrediente
    {
        public string Nombre { get; set; }
        public double Costo { get; set; } = 0;
        public Ingrediente(string nombre, double costo)
        {
            this.Nombre = nombre;
            this.Costo = costo;
        }
    }
}
