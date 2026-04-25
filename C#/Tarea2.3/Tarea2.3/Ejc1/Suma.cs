using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea2._3.Ejc1
{
    public class Suma: Operacion
    {
        public Suma(double cifra1, double cifra2) : base(cifra1, cifra2)
        {

        }

        public override double Resultado()
        {
            Console.WriteLine("La suma de las cifras es: ");
            return Cifra1+Cifra2;
        }
    }
}
