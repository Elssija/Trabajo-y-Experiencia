using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2_POO.Clases
{
    public abstract class Pizza
    {
        public string Nombre { get; set; }
        public double PorcentajeGanancia { get; set; } = 0;
        public double CostoInicial { get; set; } = 0;

        public Pizza(string nombre, double porcentajeGanancia, double costoInicial)
        {
            this.Nombre = nombre;
            this.PorcentajeGanancia = porcentajeGanancia;
            this.CostoInicial = costoInicial;
        }

        public abstract double GetCostoTotal();
        public abstract void Imprimir();
        public double GetGananciaTotal()
        {
            return this.PorcentajeGanancia * GetCostoTotal();
        }
    }
}
