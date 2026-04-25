using System;
using System.Collections.Generic;
using System.Text;
using Tarea_1._4.Tarea2.Enum;

namespace Tarea_1._4.Tarea2
{
    public class Vendedor
    {

        public TipoRegistro Tipo;

        public int TipoRegistro { get; set; }
        public string Nombre { get; set; }
        public string Jornada { get; set; }
        public Auto Auto { get; set; }
        public DateTime FechaVenta { get; set;}
        public string NumeroIdentifacionLaboral { get; set; }

        public Vendedor(string nombre, string jornada, DateTime fechaventa, string numeroidlaboral,TipoRegistro tipo,int tiporegistro, Auto auto) 
        {
            this.Auto = auto;
            this.Nombre = nombre;
            this.Jornada = jornada;
            this.FechaVenta = fechaventa;
            this.NumeroIdentifacionLaboral = numeroidlaboral;
            this.Tipo = tipo;
            this.TipoRegistro = tiporegistro;
        }
    }
}
