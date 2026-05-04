using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea1._3.Ejc1.Clases
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Identidad { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public Cliente(string nombre, string identidad, string telefono, string correo)
        {
            this.Nombre = nombre;
            this.Identidad = identidad;
            this.Telefono = telefono;
            this.Correo = correo;
        }
    }
}
