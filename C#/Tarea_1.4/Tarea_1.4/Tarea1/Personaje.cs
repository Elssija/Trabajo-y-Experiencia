using System;
using System.Collections.Generic;
using System.Text;
using Tarea_1._4.Tarea1.Enum;

namespace Tarea_1._4.Tarea1
{
    public class Personaje
    {
        public string Nombre { get; set; }

        public Genero Genero { get; set; }

        public string Tipo { get; set; }

        public int SaludMaxima { get; set; } = 0;

        public int SaludActual { get; set; } = 0;

        public int MagiaMaxima { get; set; } = 0;

        public int MagiaActual { get; set; } = 0;

        public List<Artefacto> Inventario;

        public Hechizo[] Hechizos;

        public Personaje(string nombre, Genero genero, string tipo, int saludMaxima, int saludActual, int magiaMaxima, int magiaActual, List<Artefacto> inventario, Hechizo[] hechizos)
        {
            this.Nombre = nombre;
            this.Genero = genero;
            this.Tipo = tipo;
            this.SaludMaxima = saludMaxima;
            this.SaludActual = saludActual;
            this.MagiaMaxima = magiaMaxima;
            this.MagiaActual = magiaActual;
            this.Inventario = inventario;
            this.Hechizos = hechizos;
        }

        public void Imprimir()
        {
            Console.WriteLine("****Estatus del Personaje****");
            if (this.Nombre == null)
            {
                throw new ArgumentException("Debe Ingresar el Nombre del Personaje");
            }
            Console.WriteLine($"Nombre: {this.Nombre}");
            Console.WriteLine($"Genero: {this.Genero}");
            if (this.Tipo == null)
            {
                throw new ArgumentException("Debe ingresar el tipo del Personaje");
            }
            Console.WriteLine($"Tipo: {this.Tipo}");
            Console.WriteLine($"HP max: {this.SaludMaxima}");
            Console.WriteLine($"HP: {this.SaludActual}");

            Console.WriteLine($"\nInventario:\n***********");
            if (this.Inventario == null)
                Console.WriteLine($"No tiene [No tiene] (Ataque: No tiene, Defensa: No tiene)");
            else
            {
                foreach (Artefacto item in this.Inventario)
                {
                    Console.WriteLine($"{item.Nombre} [{item.Tipo}] (Ataque:{item.PoderAtaque}, Defensa: {item.PoderDefensa})");
                }

            }

            Console.WriteLine("\nHechizos:\n*********");
            if (this.Hechizos== null)
            {
                Console.WriteLine($"No tiene [No tiene] (Ataque: no tiene)");
            }

            else
            {
                foreach (Hechizo item in this.Hechizos)
                {
                    Console.WriteLine($"{item.Nombre} [{item.Elemento}] (Ataque: {item.PoderAtaque})");
                }
            }
                
        }
    }
}
