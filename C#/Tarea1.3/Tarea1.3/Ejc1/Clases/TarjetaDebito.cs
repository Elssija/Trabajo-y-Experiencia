using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea1._3.Ejc1.Clases
{
    public class TarjetaDebito
    {
        private DateTime _date;
        public DateTime Expiracion
        {
            get => _date;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Debe establecer la fecha");
                else
                    _date = value;
            }
        }
        public string Cvv { get; set; }
        public string Numero { get; set; }

        public TarjetaDebito(DateTime expiracion, string cvv, string numero)
        {
            this.Expiracion = expiracion;
            this.Cvv = cvv;
            this.Numero = numero;
        }
    }
}
