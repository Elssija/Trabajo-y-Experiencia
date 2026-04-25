using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using Tarea1._3.Ejc1.Clases;

namespace Tarea1._3.Ejc1
{
    public class CuentaAhorro
    {
        private Banco _Banco;
        private Cliente _Cliente;
        public string Numero { get; set; }
        public TarjetaDebito Tarjeta { get; set; }
        public Banco Banco
        {
            get=>_Banco;
            set
            {
                if (value == null) throw new ArgumentNullException("Debe establecer el nombre del banco");
                else _Banco = value;
            }
        }
        public Cliente Cliente
        {
            get => _Cliente;
            set
            {
                if (value == null) throw new ArgumentException("Debe ingresar el nomnre del cliente");
                else _Cliente = value;
            }
        }
        public float Saldo
        {
            get;
            private set;
        } = 0f;
        
        public void Depositar(float saldo)
        {
            if (saldo >= 0)
                this.Saldo += saldo;
            else
                throw new ArgumentException("El valor a agregar al saldo no puede ser negativo");
            Console.WriteLine($"Su saldo es: {this.Saldo}");
        }

        public void Retirar(float saldo)
        {
            if (saldo > 0 && saldo <= this.Saldo)
                this.Saldo -= saldo;
            else
            {
                if (saldo > this.Saldo)
                    throw new ArgumentException($"El valor a retirar es mas alto que su saldo actual, recuerde que su saldo actual es: {this.Saldo}");
                else
                    throw new ArgumentException("El valor a agregar al saldo no puede ser negativo");
            }
            Console.WriteLine($"Su saldo es: {this.Saldo}");

        }
        public CuentaAhorro(Banco banco, Cliente cliente, string numero, TarjetaDebito tarjeta)
        {
            Banco = banco;
            Cliente = cliente;
            Numero = numero;
            Tarjeta = tarjeta;
        }

        public void Imprimir()
        {
            Console.WriteLine("*** Cuenta Bancaria ***");
            Console.WriteLine($"Numero:\t{this.Numero} ");
            Console.WriteLine($"Banco:\t{this.Banco.Nombre}");
            Console.WriteLine($"Cliente:\t{this.Cliente.Nombre}");
            Console.WriteLine($"DNI:\t{this.Cliente.Identidad}");
            Console.WriteLine($"Telefono:\t{this.Cliente.Telefono}");
            Console.WriteLine($"E-Mail:\t{this.Cliente.Correo}");
            if (this.Tarjeta != null)
            {
                Console.WriteLine("\n\nTarjeta de debito asociada: ");
                Console.WriteLine($"\tNumero:\t{this.Tarjeta.Numero}");
                Console.WriteLine($"\tExpiracion:\t {this.Tarjeta.Expiracion.ToString("YYYY/MM")}");
                Console.WriteLine($"\tExpiracion:\t {this.Tarjeta.Cvv}");
            }
        }
    }
}
