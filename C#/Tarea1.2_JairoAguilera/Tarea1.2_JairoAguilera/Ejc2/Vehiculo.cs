using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using Tarea1._2_JairoAguilera.Ejc2.Enum;

namespace Tarea1._2_JairoAguilera.Ejc2
{
    public class Vehiculo
    {
        private string _Placa;
        private int _Anio;

        public TipoVehiculo Tipo;
        public string Marca { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public string Modelo { get; set; }
        public string Placa
        {
            get => _Placa;
            set
            {
                if (value.Trim().Length == 0)
                    throw new ArgumentException("No se aceptan cadenas de texto vacias");
                else
                    _Placa = value;
            }
        }

        public int Anio
        {
            get => _Anio;
            set
            {
                if (value >= 0)
                    _Anio = value;
                else
                    throw new ArgumentException("Solo se aceptan numeros mayores o iguales a cero :(");
            }
        }

        public Estado Estado
        {
            get;
            private set;
        }

        public Vehiculo()
        {
            this.Marca = "No definido";
            this.Modelo = "No definido";
            this.Color = "No establecido";
            this.Placa = "00000000";
            this.Anio = 0000;
            this.Tipo = TipoVehiculo.Turismo;
            this.Estado = Estado.Detenido;
        }

        public Vehiculo(string marca, string modelo, string color, string placa, int anio, TipoVehiculo tipo, Estado estado)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Color = color;
            this.Placa = placa;
            this.Anio = anio;
            this.Tipo = tipo;
            this.Estado = estado;

        } 
        public void Acelerar()
        {
            this.Estado = Estado.Marcha;
        }
        public void Frenar()
        {
            this.Estado = Estado.Detenido;


        }

        public void Imprimir()
        {
            Console.WriteLine($"Marca: {this.Marca}");
            Console.WriteLine($"Modelo: {this.Modelo}");
            Console.WriteLine($"Color: {this.Color}");
            Console.WriteLine($"Placda: {this.Placa}");
            Console.WriteLine($"Anio {this.Anio}");
            Console.WriteLine($"Tipo de Vehiculo: {this.Tipo}");
            Console.WriteLine($"Estado del vehiculo:{this.Estado} ");
        }

    }
}
