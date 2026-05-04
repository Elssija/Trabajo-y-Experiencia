using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea_1._4.Tarea1
{
    public class Artefacto
    {
        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public int PoderAtaque { get; set; } = 0;

        public int PoderDefensa { get; set; } = 0;

        public Artefacto(string nombre, string tipo, int poderAtaque, int poderDefensa)
        {
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.PoderAtaque = poderAtaque;
            this.PoderDefensa = poderDefensa;
        }
    }
}
