using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea2._3.Ejc3
{
    public class Conferencista:Profesor
    {
        public int TalleresImpartidos { get; set; } = 0;
        public float PagoPorTaller { get; set; } = 0f;

        public Conferencista(string nombre, string identidad, DateTime fecha, int talleresimpartidos, float pagoportaller) : base(nombre, identidad, fecha) 
        { 
            this.TalleresImpartidos = talleresimpartidos;
            this.PagoPorTaller = pagoportaller;
        }

        public override void DatosGenerales()
        {
            if (Nombre != null)
                Console.WriteLine($"El nombre del Conferencista es: {Nombre}");
            if (Identidad != null)
                Console.WriteLine($"La identidad del Conferencista es: {Identidad}");
            if (FechaNacimiento.ToString() != null)
                Console.WriteLine($"La fecha de Nacimiento del Conferencista es: {FechaNacimiento.ToString("yy/MM/dd")}");
        }
        public override void SalarioProfesor()
        {
            Console.WriteLine($"El salario del conferencista por taller es: {PagoPorTaller}");
        }

        public override void TipoImparte()
        {
                Console.WriteLine($"El conferencista ha impartido un total de {TalleresImpartidos} talleres");
        }
    }
}
