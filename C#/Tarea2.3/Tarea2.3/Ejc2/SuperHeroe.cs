using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea2._3.Ejc2
{
    public abstract class SuperHeroe
    {
        public string Nombre { get; set; }
        public string Editorial { get; set; }
        public string Poder1 { get; set; }
        public string Poder2 { get; set; }
        public string Poder3 { get; set; }
        public SuperHeroe(string nombre, string editorial, string poder1, string poder2, string poder3)
        {
            this.Nombre = nombre;
            this.Editorial = editorial;
            this.Poder1 = poder1;
            this.Poder2 = poder2;
            this.Poder3 = poder3;
        }

        public abstract void Ataque1();
        public abstract void Ataque2();
    }
}
