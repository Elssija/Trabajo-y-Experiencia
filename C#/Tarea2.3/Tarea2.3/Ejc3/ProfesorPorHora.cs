using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea2._3.Ejc3
{
    public class ProfesorPorHora: Profesor
    {
        public float SalarioPorHora { get; set; } = 0f;
        public int HorasTrabajadas { get; set; } = 0;

        public ProfesorPorHora(string nombre, string identidad, DateTime fecha, float salariohora, int horas): base (nombre, identidad, fecha)
        {
            this.SalarioPorHora = salariohora;
            this.HorasTrabajadas = horas;
        }

        public override void DatosGenerales()
        {
            if (Nombre != null)
                Console.WriteLine($"El nombre del profesor es: {Nombre}");
            if (Identidad != null)
                Console.WriteLine($"La identidad del profesor es: {Identidad}");
            if (FechaNacimiento.ToString() != null)
                Console.WriteLine($"La fecha de Nacimiento del profesor es: {FechaNacimiento.ToString("yy/MM/dd")}");
        }
        public override void SalarioProfesor()
        {
            Console.WriteLine($"El salario que gana el Profesor Titular es: {SalarioPorHora}");
        }
        public override void TipoImparte()
        {
            if (HorasTrabajadas !=null)
                Console.WriteLine($"El profesor trabaja un total de {HorasTrabajadas} horas al dia");
        }
    }
}
