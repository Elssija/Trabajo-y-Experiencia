using Tarea1._3.Ejc1;
using Tarea1._3.Ejc1.Clases;
using Tarea1._3.Ejc2;

namespace Tarea1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //EJC1
                Cliente cliente = new Cliente("Jairo Aguilera", "0501200603303", "95955342", "aguilerajairo185@gmail.com");
                Banco banco = new Banco("Banco Atlantida", "Honduras", "22456788");
                TarjetaDebito tarjetaDebito = new TarjetaDebito(DateTime.Now, "219", "1234 8907 7785");
                CuentaAhorro cuentaAhorro = new CuentaAhorro(banco, cliente, "231413254151346534232", tarjetaDebito);

                //EJC2
                Persona persona = new Persona("Jairo Aguilera", new DateTime(2005,12,12), "Hondureno");
                Persona persona1 = new Persona("Quijote de la mancha", new DateTime(2000,08,05), "Español");
                Persona persona2 = new Persona("Alberto Hiervabuena", new DateTime(1978,07,07), "Puerto Riqueño");
                Persona persona3 = new Persona("Aldifonso Fuentes", new DateTime(1990,09,13), "Ingles");

                Productora productora = new Productora("SONY", "Inglaterra", "Pancho Villa");
                DateTime fecha = new DateTime(2027, 07, 12);
                Pelicula pelicula = new Pelicula(productora, persona, persona2, persona1, persona3, "La hera de hielo 11", "Accion", "Se trata de animacion de animales", fecha);
                Tareas Tarea = new Tareas(cuentaAhorro, pelicula);
                Tarea.Proceso();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
