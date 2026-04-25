using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea2._3.Ejc3
{
    internal class Instructor : ProfesorPorHora
    {
        public ProfesorPorHora ProfesorJefe {  get; set; }

        public Instructor(ProfesorPorHora profesorjefe) : base (profesorjefe.Nombre,profesorjefe.Identidad,profesorjefe.FechaNacimiento,profesorjefe.SalarioPorHora,profesorjefe.HorasTrabajadas)
        {
            this.ProfesorJefe = profesorjefe;
        }
    }
}
