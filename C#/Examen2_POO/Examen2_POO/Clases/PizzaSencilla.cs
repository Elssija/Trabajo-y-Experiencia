using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2_POO.Clases
{
    public class PizzaSencilla : Pizza
    {
        public Ingrediente Ingrediente1 { get; set; }

        public PizzaSencilla(Ingrediente ingrediente1): base("Pizza Sencilla", 1.1, 100)
        {
            this.Ingrediente1 = ingrediente1;
        }

        public override double GetCostoTotal()
        {
            double costototal = 0;
            if (this.Ingrediente1 != null)
                costototal += this.Ingrediente1.Costo;
            return CostoInicial + costototal;
        }


        public override void Imprimir()
        {
            Console.WriteLine($"{Nombre}\n******************");
            if (CostoInicial != 0)
                Console.WriteLine($"Costo Inicial: {CostoInicial}");
            if (PorcentajeGanancia != 0)
                Console.WriteLine($"Porcentaje Ganancia: {Math.Round(PorcentajeGanancia*100)}%");
            if (Ingrediente1 != null)
                Console.WriteLine($"Ingrediente 1: {this.Ingrediente1.Nombre} [Costo: {this.Ingrediente1.Costo}]");
            if (GetGananciaTotal() != 0)
                Console.WriteLine($"Costo Total: {GetCostoTotal()}");
            if (GetGananciaTotal() != 0)
                Console.WriteLine($"Ganancia Total: {GetGananciaTotal()}");
        }
    }
}
