using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea1._3.Ejc2
{
    public class Pelicula
    {
        private Productora _Estudio;
        private Persona _Director;
        private Persona _Musica;
        private Persona _Guion;
        private Persona _Protagonista1;
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Resumen { get; set; }

        public Productora Estudio
        {
            get => this._Estudio;
            set
            {
                if (value == null)
                    throw new ArgumentException("El nombre del estudio no puede ser null");
                else 
                    this._Estudio = value;
            }
        }

        public Persona Director
        {
            get => this._Director;
            set
            {
                if (value == null)
                    throw new ArgumentException("El nombre del director no puede ser null");
                else
                    this._Director = value;
            }
        }

        public Persona Musica
        {
            get => this._Musica;
            set
            {
                if (value == null)
                    throw new ArgumentException("El nombre de la musica no puede ser null");
                else
                    this._Musica = value;
            }
        }

        public Persona Guion
        {
            get => this._Guion;
            set
            {
                if (value == null)
                    throw new ArgumentException("El nombre del guion no puede ser null");
                else
                    this._Guion = value;
            }
        }

        public Persona Protagonista1
        {
            get => this._Protagonista1;
            set
            {
                if (value == null)
                    throw new ArgumentException("El nombre del Protagonista 1 no puede ser null");
                else
                    this._Protagonista1 = value;
            }
        }

        public Persona Protagonista2 { get; set; }

        public DateTime Estreno { get; set; }

        public Pelicula(Productora estudio, Persona director, Persona musica, Persona guion, Persona protagonista1, string nombre, string genero, string resumen, DateTime estreno)
        {
            this.Estudio = estudio;
            this.Director = director;
            this.Musica = musica;
            this.Guion = guion;
            this.Protagonista1 = protagonista1;
            this.Nombre = nombre;
            this.Genero = genero;
            this.Resumen = resumen;
            this.Estreno = estreno;
        }

        public void Imprimir()
        {
            if(this.Nombre!=null)
                Console.WriteLine($"Nombre: {this.Nombre}");
            if(this.Genero!=null)
                Console.WriteLine($"Genero: {this.Genero}");
            if(this.Resumen!=null)
                Console.WriteLine($"Resumen: {this.Resumen}");

            Console.WriteLine($"Estudio: {this.Estudio.Nombre}");
            Console.WriteLine($"Director: {this.Director.Nombre}");
            Console.WriteLine($"Musica: {this.Musica.Nombre}");
            Console.WriteLine($"Guion: {this.Guion.Nombre}");
            Console.WriteLine($"Protagonista1: {this.Protagonista1.Nombre}");
            if(this.Protagonista2!=null)
                Console.WriteLine($"Protagonista2: {this.Protagonista2.Nombre}");
            Console.WriteLine($"Fecha de estreno: {this.Estreno.ToString("dd/MM/yyyy")}");
        }
    }
}
