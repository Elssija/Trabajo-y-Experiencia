using Tarea_1._4.Tarea1;
using Tarea_1._4.Tarea2;
using Tarea1._3;

namespace Tarea_1._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Ejc1
                Artefacto artefacto1 = new Artefacto("La Torreta", "Estructura", 500, 250);
                Artefacto artefacto2 = new Artefacto("Sanpakuto", "Espada", 800, 700);

                Hechizo hechizo = new Hechizo("Chidori", "Rayo", 650);
                Hechizo hechizo2 = new Hechizo("Resplandor Final", "Rayo", 800);
                Hechizo hechizo3 = new Hechizo("Katon", "Fuego", 300);
                List<Artefacto> artefactos = new List<Artefacto>();
                artefactos.Add(artefacto1);
                artefactos.Add(artefacto2);

                Hechizo[] hechizos = { hechizo, hechizo2, hechizo3 };

                Personaje Tarea1 = new Personaje("Picachu", _4.Tarea1.Enum.Genero.Masculino, "Asesino", 1350, 900, 1500, 700, artefactos, hechizos);

                //ejc2

                Auto auto1 = new Auto("Nissan", "Xterra", "Negro", 2008, 170000f,121312, "Gasolina");
                Auto auto2 = new Auto("Toyota", "Hillux", "Rojo", 2012, 300000f,912039021,"Diesel");
                Auto auto3 = new Auto("Hyundai", "Tucson", "Azul", 2016, 350000f,2313231, "Diesel");
                Auto auto4 = new Auto("Subaru", "Impreza", "Naranja", 2000, 155000f,31241321,"Gasolina");

                Vendedor vendedor1 = new Vendedor("Eusebio Santos", "Matutina", new DateTime(2024, 08, 09), "9987", _4.Tarea2.Enum.TipoRegistro.Mes, 08, auto1);
                Vendedor vendedor2 = new Vendedor("Javier Garcia", "Vespertina", new DateTime(2024, 08, 12), "9865", _4.Tarea2.Enum.TipoRegistro.Anio, 08, auto2);
                Vendedor vendedor3 = new Vendedor("Irving Lopez", "Matutina", new DateTime(2024, 08, 25), "8556", _4.Tarea2.Enum.TipoRegistro.Mes, 08, auto3);
                Vendedor vendedor4 = new Vendedor("Irving Lopez", "Matutina", new DateTime(2024, 08, 25), "8556", _4.Tarea2.Enum.TipoRegistro.Mes, 08, auto4);

                List<Vendedor> vendedores = new List<Vendedor>();

                vendedores.Add(vendedor1);
                vendedores.Add(vendedor2);
                vendedores.Add(vendedor3);
                vendedores.Add(vendedor4);

                RegistroVenta Tarea2 = new RegistroVenta("Septiembre", _4.Tarea2.Enum.TipoRegistro.Mes, vendedores);

                Tareas tareas = new Tareas(Tarea1, Tarea2);
                tareas.Proceso();
            }
            catch (Exception ex)
            {

               Console.WriteLine(ex.Message);
            }
            
        }
    }
}
