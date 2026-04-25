using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea1._3.Ejc2
{
    public class Productora
    {
        public string Nombre { get; set;}
        public string Pais { get; set; }
        public string Fundador { get; set; }

        public Productora(string nombre, string pais, string fundador)
        {
            this.Nombre = nombre;
            this.Pais = pais;
            this.Fundador = fundador;
        }
    }
}
