using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Tarea_1._4.Tarea2.Enum;

namespace Tarea_1._4.Tarea2
{
    public class RegistroVenta
    {
        public string Nombre { get; set; }
        public TipoRegistro TipoRegistro {  get; set; }
        public Auto Auto { get; set; }
        public List<Vendedor> Vendedor { get; set; }

        public RegistroVenta(string nombre,TipoRegistro tipoRegstro, List<Vendedor> vendedor)
        {
            this.Nombre = nombre;
            this.TipoRegistro = tipoRegstro;
            this.Vendedor = vendedor;
        }

        public void Imprimir()
        {
            if (this.Nombre == null)
            {
                throw new ArgumentException("Debe Ingresar el nombre del tipo de registro");
            }
            Console.WriteLine($"Registro de {this.TipoRegistro}: "+this.Nombre);

            float totalventas = 0f;
            int i = 0;

            Console.WriteLine("{0,-20} {1,-20} {2,-15} {3,-15} {4,-15} {5,-15} {6,-15} {7,-15}", "Vendedor", "Fecha","Marca","Modelo","Color","Motor","Anio","Precio");
            Console.WriteLine("******************************************************************************************************************************************");

            if (this.Vendedor == null)
                throw new ArgumentException("No hay vendedores");

            while (i < this.Vendedor.Count)
            {
                if (this.Vendedor[i] == null)
                {
                    i++;
                    continue;
                }
                if (i < this.Vendedor.Count - 1)
                {
                    DateTime a = this.Vendedor[i].FechaVenta;
                    DateTime b = this.Vendedor[i + 1].FechaVenta;

                    if (a.Month != b.Month || a.Year != b.Year)
                    {
                        throw new ArgumentException("La fecha no concuerda con el tipo de registro :(");
                    }
                }
                Console.WriteLine("{0,-20} {1,-20} {2,-15} {3,-15} {4,-15} {5,-15} {6,-15} {7,-15}", $"{ this.Vendedor[i].Nombre}", $"{this.Vendedor[i].FechaVenta.ToString("yy/MM/dd")}",
                    $"{this.Vendedor[i].Auto.Marca}",$"{this.Vendedor[i].Auto.Modelo}",$"{this.Vendedor[i].Auto.Color}",$"{this.Vendedor[i].Auto.Motor.Tipo}",$"{this.Vendedor[i].Auto.Anio}",$"{this.Vendedor[i].Auto.Precio}");
                totalventas += this.Vendedor[i].Auto.Precio;
                i++; 
            }

            Console.WriteLine("******************************************************************************************************************************************");
            Console.WriteLine("{0,-20} {1,-20} {2,-15} {3,-15} {4,-15} {5,-15} {6,-15} {7,-15}","Total:", "", "", "", "", "", "", totalventas);
        }
    }
}
