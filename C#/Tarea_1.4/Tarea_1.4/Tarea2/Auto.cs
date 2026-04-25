using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tarea_1._4.Tarea2
{
    public class Auto
    {
        private string _Motor;
        public string Marca {  get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }

        public Motor Motor { get; private set;}
        public int Anio { get; set; }

        public float Precio { get; set; }

        public Auto(string marca, string modelo, string color, int anio, float precio, int serie, string tipo)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Color = color;
            this.Anio = anio;
            this.Precio = precio;
            this.Motor = new Motor(serie,tipo);
        }
    }
}
