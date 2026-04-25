using System.ComponentModel.Design;
using Tarea1._2_JairoAguilera.Ejc1;
using Tarea1._2_JairoAguilera.Ejc1.Enum;
using Tarea1._2_JairoAguilera.Ejc2;
using Tarea1._2_JairoAguilera.Ejc3;
using Tarea1._2_JairoAguilera.Ejc4;
using Tarea1._2_JairoAguilera.Ejc5;

namespace Tarea1._2_JairoAguilera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Operario operario = new Operario("Juan Perez", Genero.Masculino, 20, 16500.60f);
            Vehiculo vehiculo = new Vehiculo("Nissan", "X-Trail", "Rojo", "HN-098-214", 2012, Ejc2.Enum.TipoVehiculo.Camioneta, Ejc2.Enum.Estado.Marcha);
            Producto producto = new Producto("05012006", "Jairo Aguilera", 1500f, 1780.9f, 10);
            Rectangulo rectangulo = new Rectangulo(2, 2, 4, 8);
            TanqueAgua tanqueagua = new TanqueAgua(1200f, "Truper", "Aluminio", 500f);
            Tareas tarea = new Tareas(operario,vehiculo,producto,rectangulo,tanqueagua);
            tarea.Proceso();
        }
    }
}
