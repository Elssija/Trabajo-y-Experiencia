using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea2._3.Ejc1
{
    public class Operacion
    {
        private double _Cifra1;
        private double _Cifra2;

        public double Cifra1
        {
            get => _Cifra1;
            set
            {
                if (value < 0)
                    throw new ArgumentException("La cifra1 debe ser mayor o igual a 0");
                else
                    _Cifra1 = value;
            }
        }

        public double Cifra2
        {
            get => _Cifra2;
            set
            {
                if (value < 0)
                    throw new ArgumentException("La cifra1 debe ser mayor o igual a 0");
                else _Cifra2 = value;
            }
        }

        public Operacion(double cifra1, double cifra2)
        {
            this.Cifra1 = cifra1;
            this.Cifra2 = cifra2;
        }
        public virtual double Resultado()
        {
            return 0.00;
        }
    }
}
