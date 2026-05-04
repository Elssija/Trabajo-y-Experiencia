using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea_1._4.Tarea2
{
    public class Motor
    {
        private string _Tipo;
        public int NumSerie  { get; set; }
        public string Tipo { get => _Tipo;
            set 
            {
                {
                    if (value.ToLower() == "gasolina" || value.ToLower() == "diesel" || value.ToLower() == "electrico")
                        _Tipo = value;
                    else
                        throw new ArgumentException("No existe ese tipo de motor");
                }
            }
        }

        public Motor(int NumSerie, string Tipo)
        {
            this.NumSerie = NumSerie;
            this.Tipo = Tipo;
        }
    }
}
