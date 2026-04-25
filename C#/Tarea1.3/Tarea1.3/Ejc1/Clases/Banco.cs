using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea1._3.Ejc1.Clases
{
    public class Banco
    {
        public string Nombre { get; set; }
        public string Pais {  get; set; }
        public string telefono { get; set; }

        public Banco(string nombre, string pais, string telefono)
        {
            this.Nombre = nombre;
            this.Pais = pais;
            this.telefono = telefono;
        }
    }
}
