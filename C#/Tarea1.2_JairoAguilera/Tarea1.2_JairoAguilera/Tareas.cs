using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Channels;
using Tarea1._2_JairoAguilera.Ejc1;
using Tarea1._2_JairoAguilera.Ejc1.Enum;
using Tarea1._2_JairoAguilera.Ejc2;
using Tarea1._2_JairoAguilera.Ejc3;
using Tarea1._2_JairoAguilera.Ejc4;
using Tarea1._2_JairoAguilera.Ejc5;

namespace Tarea1._2_JairoAguilera
{
    public class Tareas
    {
        private Operario _Tarea1;
        public Operario Tarea1
        {
            get => this._Tarea1;
            set
            {
                this._Tarea1 = value ?? throw new ArgumentException("No puede ir vacío");
            }
        }
        private    Vehiculo _Tarea2;
        public Vehiculo Tarea2
        {
            get => this._Tarea2;
            set
            {
                this._Tarea2 = value ?? throw new ArgumentException("No puede ir vacío");
            }
        }
        private Producto _Tarea3;
        public Producto Tarea3
        {
            get => this._Tarea3;
            set
            {
                this._Tarea3 = value ?? throw new ArgumentException("No puede ir vacío");
            }
        }
        private Rectangulo _Tarea4;
        public Rectangulo Tarea4
        {
            get => this._Tarea4;
            set
            {
                this._Tarea4 = value ?? throw new ArgumentException("No puede ir vacío");
            }
        }
        private TanqueAgua _Tarea5;
        public TanqueAgua Tarea5
        {
            get => this._Tarea5;
            set
            {
                this._Tarea5 = value ?? throw new ArgumentException("No puede ir vacío");
            }
        }
        public Tareas(Operario tarea1,Vehiculo tarea2, Producto tarea3, Rectangulo tarea4, TanqueAgua tarea5)
        {
            this.Tarea1 = tarea1;
            this.Tarea2 = tarea2;
            this.Tarea3 = tarea3;
            this.Tarea4 = tarea4;
            this.Tarea5 = tarea5;
        }
        public string lectura { get; set; }
        public int opcion { get; set; }
        public string seleccion {  get; set; }
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
                            
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("***************EJC2***************\nJairo Jassiel Aguilera Romero \t 20232001430");
                        Console.WriteLine("Constructor con parametros establecidos:\n");
                        Tarea2.Imprimir();
                        Console.WriteLine();
                            while (true)
                            {
                            Console.WriteLine("¿Desea cambiar el estado del vehiculo? [si]/[no]: ");
                            this.seleccion = Console.ReadLine();
                            if (this.seleccion.ToLower() == "si")
                            {
                                Console.WriteLine("Ingrese 1 para en Marcha y 2 para Detenido: ");
                                while (true)
                                {
                                    this.seleccion = Console.ReadLine();
                                    if (int.Parse(seleccion) == 1)
                                    {
                                        Tarea2.Acelerar();
                                        Tarea2.Imprimir();
                                        break;
                                    }
                                    if (int.Parse(seleccion) == 2)
                                    {
                                        Tarea2.Frenar();
                                        Tarea2.Imprimir();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ingrese un numero Correcto :( ");
                                        continue;
                                    }
                                    
                                }
                            }
                            if (this.seleccion.ToLower() == "no")
                            {
                                Console.Clear();
                                Proceso();
                                break;
                            }
                            
                        }
                        break;
                    }
                case 3:
                    {
                        try
                        {
                            Console.WriteLine("***************EJC3***************\nJairo Jassiel Aguilera Romero \t 20232001430");
                            Console.WriteLine("\nConstructor con parametros establecidos:");
                            Tarea3.Imprimir();
                            Console.WriteLine("\nConstructor con parametros establecidos:");
                            Tarea3.Imprimir();
                            while (true)
                            {
                                Console.WriteLine("¿Desea cambiar el estado de las existencias? [si]/[no]: ");
                                this.seleccion = Console.ReadLine();
                                if (this.seleccion.ToLower() == "si")
                                {
                                    Console.WriteLine("Ingrese 1 para Aumentar y 2 para Disminuir: ");
                                    while (true)
                                    {
                                        this.seleccion = Console.ReadLine();
                                        if (int.Parse(seleccion) == 1)
                                        {
                                            Console.WriteLine("Ingrese la cantidad a aumentar: ");
                                            this.seleccion = Console.ReadLine();
                                            Tarea3.Aumentar(int.Parse(this.seleccion));
                                            Tarea3.Imprimir();
                                            break;
                                        }
                                        if (int.Parse(seleccion) == 2)
                                        {
                                            Console.WriteLine("Ingrese la cantidad a Disminuir: ");
                                            this.seleccion = Console.ReadLine();
                                            Tarea3.Disminuir(int.Parse(this.seleccion));
                                            Tarea3.Imprimir();
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ingrese un numero Correcto :( ");
                                            continue;
                                        }

                                    }
                                }
                                if (this.seleccion.ToLower() == "no")
                                {
                                    Console.Clear();
                                    Proceso();
                                    break;
                                }

                            }

                        }
                        catch ( Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                    }
                case 4: 
                    {
                        try
                        {
                            Console.WriteLine("***************EJC4***************\nJairo Jassiel Aguilera Romero \t 20232001430");
                            while (true)
                            {
                                Console.WriteLine("¿Desea Obtener el Area, Perimetro Diagonal? [si]/[no]: ");
                                this.seleccion = Console.ReadLine();
                                if (this.seleccion.ToLower() == "si")
                                {
                                    Tarea4.Area();
                                    Tarea4.Perimetro();
                                    Tarea4.Diagonal();
                                    Console.ReadKey();
                                    Console.Clear();
                                    Proceso();
                                    break;

                                }
                                else if (this.seleccion.ToLower() == "no")
                                {
                                    Console.Clear();
                                    Proceso();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Ingrese [si o no]");
                                    continue;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    }
                case 5:
                    {
                        try
                        {
                            Tarea5.Imprimir();
                            while (true)
                            {
                                Console.WriteLine("¿Desea ver el estado del tanque [1] o Desea agregar o extraer cantidad del tanque [2]: ");
                                this.seleccion = Console.ReadLine();
                                if (this.seleccion == "1")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine($"Desea Ver la cantidad actual [1] o desea ver su porcentaje [2]: ");
                                        this.seleccion = Console.ReadLine();
                                        if (this.seleccion == "1")
                                        {
                                            this.Tarea5.ImprimirCantidadActual();
                                            Console.ReadKey();
                                            Console.Clear();
                                            Proceso();
                                            break;
                                        }
                                        else if (this.seleccion == "2")
                                        {
                                            this.Tarea5.ImprimirPorcentajeUsado();
                                            Console.ReadKey();
                                            Console.Clear();
                                            Proceso();
                                            break;
                                        }
                                        else
                                            Console.WriteLine("Ingrese 1 o 2, no se aceptan otros datos");
                                    }
                                }
                                else if (this.seleccion.ToLower() == "2")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine($"Desea Adicionar [1] o Desea Extraer [2]:");
                                        this.seleccion = Console.ReadLine();
                                        if (this.seleccion == "1")
                                        {
                                            Console.WriteLine($"Ingrese la Cantidad a adicionar:");
                                            this.seleccion = Console.ReadLine();
                                            Tarea5.Depositar(float.Parse(this.seleccion));
                                            Tarea5.Imprimir();
                                            Console.ReadKey();
                                            Console.Clear();
                                            Proceso();
                                            break;
                                        }
                                        else if (this.seleccion == "2")
                                        {
                                            Console.WriteLine($"Ingrese la Cantidad a Extraer: ");
                                            this.seleccion = Console.ReadLine();
                                            Tarea5.Extraer(float.Parse(this.seleccion));
                                            Tarea5.Imprimir();
                                            Console.ReadKey();
                                            Console.Clear();
                                            Proceso();
                                            break;
                                        }
                                        else
                                            Console.WriteLine("Ingrese [1 o 2]");
                                        continue;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ingrese [1 o 2] no se aceptan otros datos");
                                    continue;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Solo se Permiten Numeros");
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
                    Console.WriteLine("Tarea1.2\tJairo Jassiel Aguilera Romero\t20232001430\nIngrese el numero del Ejercicio al que desea Ingresar: \n Trate de que los numeros sean 1 2 3 4 5");
                    this.lectura = Console.ReadLine();
                    this.opcion = int.Parse(this.lectura);
                    Final(this.opcion);
                    Console.ReadKey();                    
                    while (true) {
                        Console.WriteLine("¿Desea seguir con un siguiente Ejercicio? [si]/[no]: ");
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
                Console.WriteLine("Solo se permiten numeros enteros de 1 al 5 no se permiten letras ni numeros fuera de rango");
                Console.ReadKey();
                Console.Clear();
                Proceso();
            }
        }

    } 
}
