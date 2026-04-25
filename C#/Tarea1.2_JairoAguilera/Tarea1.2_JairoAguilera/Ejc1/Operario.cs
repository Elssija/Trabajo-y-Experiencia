using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Tarea1._2_JairoAguilera.Ejc1.Enum;

namespace Tarea1._2_JairoAguilera.Ejc1
{
    public class Operario
    {
        private string _Nombre;
        private float _Salario;
        private int _Edad;
        public Genero Genero { get; set; }

        public string Nombre
        {
            get => _Nombre;
            set
            {
                if (value.Trim().Length <= 10)
                    _Nombre = value;
                else
                    throw new ArgumentException("Solo se permiten cadenas de texto de 10 o mas caracteres");
            }
        }

        public float Salario
        {
            get => _Salario;
            set {
                if (value >= 0)
                    _Salario = value;
                else
                    throw new ArgumentException("Solo se permiten Salarios mayores o iguales a cero"); }
        }

        public int Edad
        {
            get => _Edad;
            set
            {
                if (value >= 18)
                    _Edad = value;
                else
                    throw new ArgumentException("Solo se permiten mayores o iguales a 18 años");
            }
        }

        //creando el contructor de la clase
        public Operario(string nombre, Genero genero, int edad, float salario)
        {
            this.Nombre = nombre;
            this.Salario = salario;
            this.Genero = genero;
            this.Edad = edad;
        }

        //creando la el metodo imprimir

        public void Imprimir ()
        {
            Console.WriteLine($"El nombre del operario es: {this.Nombre}");
            Console.WriteLine($"El Genero del operario es: {this.Genero}");
            Console.WriteLine($"La edad del operario es: {this.Edad}");
            Console.WriteLine($"El salario del operario es: {this.Salario}");
        }
    }
}
