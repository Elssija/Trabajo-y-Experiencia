using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea2._3.Ejc2
{
    public class SuperHeroe1 : SuperHeroe
    {
        public SuperHeroe1(string nombre) : base(nombre, "Capcom", "Destello Negro", "Golpe Fantasma", "Expansion de Dominio")
        {

        }
        public override void Ataque1()
        {
            Console.WriteLine($"{Nombre} lanza un {Poder1} devastador, dejando espacio para un {Poder2} que noquea al rival.");
        }

        public override void Ataque2()
        {
            Console.WriteLine($"{Nombre} activa su técnica suprema ¡{Poder3}! ahora el campo de batalla ahora le pertenece pasa a ser su dominio totalmente.");
        }
    }
}
