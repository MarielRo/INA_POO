using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02_Mariel
{
    class Program
    {
        /*2.Construya un programa que permita leer una cantidad variable de números y nos indique
         * cuantos fueron mayores o iguales a 100 y cuántos menores a 100, cada vez que ingresa
         * un número debe preguntar si desea ingresar otro.*/
        static void Main(string[] args)
        {
            //Declaración de variables
            int mayoresIguales = 0, menores = 0, numero;
            string respuesta = "";
            bool salir = true;

            while (salir)
            {
                Console.WriteLine("Ingrese un número");
                numero = Convert.ToInt32(Console.ReadLine());
                if (numero >= 100) // número mayor a cien
                {
                    mayoresIguales++;
                }
                else if (numero < 100)  // número menor a cien
                {
                    menores++;
                }
                Console.WriteLine("¿Desea ingresar otro número?(s/n)");
                respuesta = Console.ReadLine();
                if (respuesta != "s") // si la respuesta es diferente de si entonces se sale del ciclo
                {
                    salir = false;
                }
            }
            Console.WriteLine($"Se digitaron {mayoresIguales} números mayores o iguales a 100.\n " +
                $"Se digitaron {menores} números menores a 100.\n");
            Console.ReadKey();
        }
    }
}
