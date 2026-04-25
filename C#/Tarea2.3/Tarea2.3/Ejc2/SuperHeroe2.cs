using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea2._3.Ejc2
{
    public class SuperHeroe2 : SuperHeroe
    {
        public SuperHeroe2(string nombre) : base(nombre, "Capcom", "Hadoken", "Patada Relámpago", "Destrcutor de Estrellas")
        {
        }

        public override void Ataque1()
        {
            Console.WriteLine($"{Nombre} concentra su energía y lanza un {Poder1}, impactando de lleno en el pecho del oponente.");
        }

        public override void Ataque2()
        {
            Console.WriteLine($"{Nombre} ejecuta una {Poder2} seguida de su movimiento especial: ¡{Poder3}!");
        }
    }
}
