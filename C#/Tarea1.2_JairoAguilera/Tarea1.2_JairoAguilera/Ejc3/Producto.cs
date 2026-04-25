using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

namespace Tarea1._2_JairoAguilera.Ejc3
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        private float _Costo;
        private float _PrecioVenta;
        public int Existencias { get; private set; }

        public float Costo
        {
            get => _Costo;
            set
            {
                if (value >= 0)
                    _Costo = value;
                else
                    throw new ArgumentException("Solo se aceptan costo mayores o iguales a 0");
            }
        }
        public float PrecioVenta
        {
            get => _PrecioVenta;
            set
            {
                if (value >= 0.01f)
                    _PrecioVenta = value;
                else
                    throw new ArgumentException("Solo se aceptan numeros mayores o iguales a 0.01");
            }
        }
        public void Aumentar(int cantidad)
        {
            this.Existencias += cantidad;
        }
        public void Disminuir (int cantidad)
        {
            this.Existencias -= cantidad;
        }
        public Producto()
        {
            this.Codigo = "00000000";
            this.Nombre = "Juan Perez";
            this.Costo = 0;
            this.PrecioVenta = 0.01f;
            this.Existencias = 0;
        }
        public Producto(string codigo, string nombre, float costo, float precioventa, int existencias)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Costo = costo;
            this.PrecioVenta = precioventa;
            this.Existencias = existencias;

        }
        public void Imprimir()
        {
            Console.WriteLine($"Codigo: {this.Codigo}");
            Console.WriteLine($"Nombre: {this.Nombre}");
            Console.WriteLine($"Costo: {this.Costo}");
            Console.WriteLine($"Precio de venta: {this.PrecioVenta}");
            Console.WriteLine($"Existencias: {this.Existencias}");
        }
    }
}
