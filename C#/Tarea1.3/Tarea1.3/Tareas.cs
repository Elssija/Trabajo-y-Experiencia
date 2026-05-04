using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Tarea1._3.Ejc1;
using Tarea1._3.Ejc2;

namespace Tarea1._3
{
    public class Tareas
    {
        private CuentaAhorro _Tarea1;
        public CuentaAhorro Tarea1
        {
            get => this._Tarea1;
            set
            {
                this._Tarea1 = value ?? throw new ArgumentException("No puede ir vacío");
            }
        }
        private Pelicula _Tarea2;
        public Pelicula Tarea2
        {
            get => this._Tarea2;
            set
            {
                this._Tarea2 = value ?? throw new ArgumentException("No puede ir vacío");
            }
        }
       
        public Tareas(CuentaAhorro tarea1, Pelicula tarea2)
        {
            this.Tarea1 = tarea1;
            this.Tarea2 = tarea2;
        }
        public string lectura { get; set; }
        public int opcion { get; set; }
        public string seleccion { get; set; }
        public string Ingreso { get; set; }
        public void Final(int Opcion)
        {
            switch (Opcion)
            {
                case 1:
                    {
                        try
                        {
                            Console.WriteLine("***************EJC1***************\nJairo Jassiel Aguilera Romero \t 20232001430");
                            Tarea1.Imprimir();

                            {
                                try
                                {
                                    
                                        while (true)
                                        {
                                        Console.WriteLine("\nDesea Agregar o Retirar dinero de su cuenta de Banco [si]/[no]: ");
                                        this.seleccion = Console.ReadLine();
                                        if (this.seleccion.ToLower() == "si") 
                                            { 
                                                Console.WriteLine("Desea Agregar [1] o Retirar [2] dinero de su cuenta de Banco: ");
                                            this.seleccion = Console.ReadLine();
                                            if (this.seleccion == "1")
                                            {
                                                Console.WriteLine("Ingrese el monto a agregar: ");
                                                this.Ingreso = Console.ReadLine();
                                                Tarea1.Depositar(float.Parse(this.Ingreso));
                                                Console.ReadKey();
                                                break;
                                            }
                                            else
                                            {
                                                if (this.seleccion == "2")
                                                {
                                                    Console.WriteLine("Ingrese el monto a Retirar: ");
                                                    this.Ingreso = Console.ReadLine();
                                                    Tarea1.Retirar(float.Parse(this.Ingreso));
                                                    Console.ReadKey();
                                                    break;
                                                }

                                                else
                                                {
                                                    Console.WriteLine("Ingrese 1 o 2 no se aceptan otros datos");
                                                    continue;
                                                }
                                            }
                                        }
                                        if (this.seleccion.ToLower() == "no") break;
                                        else
                                        {
                                            Console.WriteLine("Debe ser [si] o [no]");
                                            continue;
                                        }
                                        
                                        
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw new ArgumentException(ex.Message);
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                    }
                case 2:
                    {
                        try
                        {
                            Console.WriteLine("***************EJC2***************\nJairo Jassiel Aguilera Romero \t 20232001430\n");
                            Tarea2.Imprimir();
                            Console.WriteLine();
                        }
                        catch ( Exception ex)
                        {

                            Console.WriteLine(ex.Message); ;
                        }
                        
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("No ha seleccionada un numero correcto de ejercicio :(");
                        break;
                    }


            }
        }
        public void Proceso()
        {
            try
            {
                while (true)
                {
                    this.opcion = 0;
                    Console.WriteLine("Tarea1.3\t\tJairo Jassiel Aguilera Romero\t\t20232001430\n\nIngrese el numero del Ejercicio al que desea Ingresar: \n\nTrate de que los numeros sean 1 o 2");
                    this.lectura = Console.ReadLine();
                    this.opcion = int.Parse(this.lectura);
                    Final(this.opcion);
                    while (true)
                    {
                        Console.WriteLine("\n¿Desea seguir con un siguiente Ejercicio? [si]/[no]: ");
                        this.seleccion = Console.ReadLine();
                        if (this.seleccion.ToLower() == "si")
                        {
                            Console.Clear();
                            break;
                        }
                        if (this.seleccion.ToLower() == "no")
                            return;
                        else
                            continue;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Solo se permiten numeros enteros de 1 al 2 no se permiten letras ni numeros fuera de rango");
                Console.ReadKey();
                Console.Clear();
                Proceso();
            }
        }

    }
}
