using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea_1._4.Tarea1
{
    public class Hechizo
    {
        public string Nombre { get; set; }

        public string Elemento  { get; set; }

        public int PoderAtaque { get; set; } = 0;

        public Hechizo(string nombre, string elemento, int poderataque) 
        {
            this.Nombre = nombre;
            this.Elemento = elemento;
            this.PoderAtaque = poderataque;
        }
    }
}
