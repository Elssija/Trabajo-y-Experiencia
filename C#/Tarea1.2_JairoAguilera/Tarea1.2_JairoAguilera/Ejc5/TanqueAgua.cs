using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Tarea1._2_JairoAguilera.Ejc5
{
    public class TanqueAgua
    {
        private float _CapacidadMaxima;
        public string Fabricante { get; set; }
        public string Material { get; set; }
        public float CantidadActual { get; private set; }

        
        public float CapacidadMaxima
        {
            get => _CapacidadMaxima;
            set
            {
                if (value >= 1)
                    _CapacidadMaxima = value;
                else
                    throw new ArgumentException("La capacidad del tanque no puede ser menor que 1");
            }
        }
        public TanqueAgua(float capacidadmaxima,string fabricante, string material, float capacidadactual)
        {
            this.CapacidadMaxima=capacidadmaxima;
            this.Fabricante = fabricante;
            this.Material = material;
            this.CantidadActual = capacidadactual;

        }
        public void Depositar(float cantidad)
        {
            if (cantidad >= 0 && cantidad + this.CantidadActual <= this._CapacidadMaxima)
                this.CantidadActual += cantidad;
            else if (cantidad < 0)
                throw new ArgumentException("El valor a agregar al tanque no puede ser menor que 0");
            else 
            {
                throw new ArgumentException("Capacidad de Tanque Excedida");
            }
            
        }

        public void Extraer(float cantidad)
        {
            if (cantidad >= 0 && cantidad + this.CantidadActual <= this._CapacidadMaxima)
                this.CantidadActual -= cantidad;
            else if (cantidad < 0)
                throw new ArgumentException("El valor a Extraer al tanque no puede ser menor que 0");
            else
            {
                throw new ArgumentException("No se puede extraer esa cantidad, supera la capcidad del tanque");
            }

        }

        public void Imprimir()
        {
            Console.WriteLine($"Fabricante: {this.Fabricante}");
            Console.WriteLine($"Capacidad Maxima: {this.CapacidadMaxima}");
            Console.WriteLine($"Material: {this.Material}");
            Console.WriteLine($"Cantidad Actual: {this.CantidadActual}");
        }
        public void ImprimirCantidadActual()
        {
            Console.WriteLine($"Cantidad Actual del tanque: {this.CantidadActual}");
        }
        public void ImprimirPorcentajeUsado()
        {
            Console.WriteLine($"El porcentaje actual del tanque es de: {this.CantidadActual*100/this.CapacidadMaxima}");
        }
    }
}
