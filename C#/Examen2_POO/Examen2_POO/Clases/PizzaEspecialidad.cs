using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2_POO.Clases
{
    public class PizzaEspecialidad : Pizza
    {
        public Ingrediente Ingrediente1 { get; set; }
        public Ingrediente Ingrediente2 { get; set; }

        public PizzaEspecialidad(Ingrediente ingrediente1, Ingrediente ingrediente2) : base("Pizza Especialidad", 1.2, 110)
        {
            this.Ingrediente1 = ingrediente1;
            this.Ingrediente2 = ingrediente2;
        }

        public override double GetCostoTotal()
        {
            double costototal = 0;
            if (this.Ingrediente1 != null)
                costototal += this.Ingrediente1.Costo;
            if (this.Ingrediente2 != null)
                costototal += this.Ingrediente2.Costo;
            return CostoInicial + costototal;
        }

        public override void Imprimir()
        {
            Console.WriteLine($"{Nombre}\n******************");
            if (CostoInicial != 0)
                Console.WriteLine($"Costo Inicial: {CostoInicial}");
            if (PorcentajeGanancia != 0)
                Console.WriteLine($"Porcentaje Ganancia: {PorcentajeGanancia * 100}%");
            if (Ingrediente1 != null)
                Console.WriteLine($"Ingrediente 1: {this.Ingrediente1.Nombre} [Costo: {this.Ingrediente1.Costo}]");
            if (Ingrediente2 != null)
                Console.WriteLine($"Ingrediente 2: {this.Ingrediente2.Nombre} [Costo: {this.Ingrediente2.Costo}]");
            if (GetGananciaTotal() != 0)
                Console.WriteLine($"Costo Total: {GetCostoTotal()}");
            if (GetGananciaTotal() != 0)
                Console.WriteLine($"Ganancia Total: {GetGananciaTotal()}");
        }
    }
}
