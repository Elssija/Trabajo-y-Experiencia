using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea2._3.Ejc1
{
    public class Division : Operacion


        {
        public Division(double cifra1, double cifra2) : base(cifra1, cifra2)
        {

        }

        public override double Resultado()
        {
            if (Cifra2 == 0)
                throw new ArgumentException("La cifra 2 no puede ser cero");

            Console.WriteLine("La Division de las cifras es: ");
                return Cifra1 / Cifra2; 
        }
    }
}
