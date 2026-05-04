using Tarea1._3;
using Tarea2._3.Ejc1;
using Tarea2._3.Ejc2;
using Tarea2._3.Ejc3;

namespace Tarea2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Datos de las clases:
                ProfesorPorHora pph = new ProfesorPorHora("Carlos","0501200009889", new DateTime(2000,12,12),15000.78f,5);
                Conferencista c1 = new Conferencista("Alvaro", "0988198209887", new DateTime(1982, 11, 12), 12, 2000);

                //Ingreso de datos de los ejercicios: 
                Tareas tareas = new Tareas(new Division(28,3), new SuperHeroe1("Rangiku"),new Instructor(pph));
                tareas.Proceso();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
            
        }
    }
}
