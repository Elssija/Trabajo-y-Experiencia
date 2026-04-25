using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using Tarea2._3.Ejc1;
using Tarea2._3.Ejc2;
using Tarea2._3.Ejc3;
//using Tarea2._3.Ejc2;

namespace Tarea1._3
{
    public class Tareas
    {
        private Operacion _Tarea1;
        public Operacion Tarea1
        {
            get => this._Tarea1;
            set
            {
                this._Tarea1 = value ?? throw new ArgumentException("No puede ir vacío");
            }
        }
        private SuperHeroe _Tarea2;
        public SuperHeroe Tarea2
        {
            get => this._Tarea2;
            set
            {
                this._Tarea2 = value ?? throw new ArgumentException("No puede ir vacío");
            }
        }

        private Profesor _Tarea3;
        public Profesor Tarea3
        {
            get => this._Tarea3;
            set
            {
                this._Tarea3 = value ?? throw new ArgumentException("No puede ir vacío");
            }
        }

        public Tareas(Operacion tarea1, SuperHeroe tarea2, Profesor tarea3)
        {
            this.Tarea1 = tarea1;
            this.Tarea2 = tarea2;
            this.Tarea3 = tarea3;
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
                            Console.WriteLine(Tarea1.Resultado());
                        
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
                            Console.WriteLine("Ataque 1:");
                            Tarea2.Ataque1();
                            Console.WriteLine("Ataque 2:");
                            Tarea2.Ataque2();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message); ;
                        }

                        break;
                    }
                case 3:
                    {
                        try
                        {
                            Console.WriteLine("***************EJC3***************\nJairo Jassiel Aguilera Romero \t 20232001430\n");
                            Tarea3.FullInformation();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            throw;
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
                    Console.WriteLine("Tarea1.3\t\tJairo Jassiel Aguilera Romero\t\t20232001430\n\nIngrese el numero del Ejercicio al que desea Ingresar: \n\nTrate de que los numeros sean 1 2 o 3");
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
            catch (Exception)
            {
                Console.WriteLine("Solo se permiten numeros enteros de 1 al 3 no se permiten letras ni numeros fuera de rango");
                Console.ReadKey();
                Console.Clear();
                Proceso();
            }
        }

    }
}
