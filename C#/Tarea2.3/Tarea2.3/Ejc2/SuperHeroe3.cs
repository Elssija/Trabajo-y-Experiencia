using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea2._3.Ejc2
{
    public class SuperHeroe3:SuperHeroe
    {
        public SuperHeroe3(string nombre) : base(nombre, "Capcom", "Corte Dimensional", "Senin", "Juicio Final")
        {
        }

        public override void Ataque1()
        {
            Console.WriteLine($"{Nombre} desenvaina rápidamente usando el {Poder1}, cortando el aire y la defensa del enemigo.");
        }

        public override void Ataque2()
        {
            Console.WriteLine($"{Nombre} entra en estado de {Poder2} y finaliza el combate con su {Poder3}.");
        }
    }
}
