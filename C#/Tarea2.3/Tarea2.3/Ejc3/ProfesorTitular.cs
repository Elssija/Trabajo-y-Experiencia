using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tarea2._3.Ejc3
{
    public class ProfesorTitular : Profesor
    {
        public float Salario { get; set; } = 0;
        public string Facultad { get; set; } = "No tiene";

        public ProfesorTitular(string nombre, string identidad, DateTime fechanacimiento, float salario, string facultad): base( nombre, identidad, fechanacimiento)
        {
            this.Salario = salario;
            this.Facultad = facultad;
        }
        public override void DatosGenerales()
        {
            if (Nombre != null)
                Console.WriteLine($"El nombre del profesor titular es: {Nombre}");
            if (Identidad != null)
                Console.WriteLine($"La identidad del profesor titular es: {Identidad}");
            if (FechaNacimiento.ToString() != null)
                Console.WriteLine($"La fecha de Nacimiento del profesor titular es: {FechaNacimiento.ToString("yy/MM/dd")}");
        }
        public override void SalarioProfesor()
        {
            Console.WriteLine($"El salario que gana el Profesor Titular es: {Salario}");
        }

        public override void TipoImparte() 
        {
            Console.WriteLine($"Imparte Clases en la facultad de: {Facultad}");            
        }
    }
}
