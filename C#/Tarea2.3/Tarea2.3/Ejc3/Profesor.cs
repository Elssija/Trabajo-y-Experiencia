using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea2._3.Ejc3
{
    public abstract class Profesor
    {
        public string Nombre { get; set; }
        public string Identidad { get; set; }
        public DateTime FechaNacimiento { get; set; }


        public Profesor(string nombre, string identidad, DateTime fechanacimiento) 
        {
            this.Nombre = nombre;
            this.Identidad = identidad;
            this.FechaNacimiento = fechanacimiento;
        }
        public abstract void DatosGenerales();
        public abstract void SalarioProfesor();
        public abstract void TipoImparte();
        public void FullInformation()
        {
            DatosGenerales();
            SalarioProfesor();
            TipoImparte();
        }


    }
}
