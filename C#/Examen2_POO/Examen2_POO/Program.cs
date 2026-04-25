using Examen2_POO.Clases;
namespace Examen2_POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jairo Jassiel Aguilera Romero\t20232001430");

            Ingrediente ingrediente1 = new Ingrediente("Jamon", 20);
            Ingrediente ingrediente2 = new Ingrediente("Carne", 35);
            Ingrediente ingrediente3 = new Ingrediente("Piña", 25);
            Ingrediente ingrediente4 = new Ingrediente("Pavo", 30);

            Pizza p1 = new PizzaSencilla(ingrediente1);
            Pizza p2 = new PizzaEspecialidad(ingrediente1, ingrediente2);
            Pizza p3 = new PizzaDeluxe(ingrediente1, ingrediente2,ingrediente3,ingrediente4);
            Console.WriteLine("\nClase 1:");
            p1.Imprimir();
            Console.WriteLine("\nClase 2:");
            p2.Imprimir();
            Console.WriteLine("\nClase 3:");
            p3.Imprimir();
        }
    }
}
