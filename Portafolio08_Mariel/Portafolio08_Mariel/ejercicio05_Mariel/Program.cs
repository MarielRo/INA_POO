using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio05_Mariel
{
    class Program
    {
        /*5.Construya un programa que permita leer una cantidad variable de números
         * hasta que se ingresen 5 números negativos. Indicar cantidad total de números leídos. */
        static void Main(string[] args)
        {
            //declaración de variables
            int i = 0, numero, cantNegativos = 0;
            bool salir = true; // cuando salir sea falso, se sale del ciclo

            while (salir) {
                Console.WriteLine("Digite un número, cuando se digiten 5 negativos el programa termina");
                numero = int.Parse(Console.ReadLine());

                if (numero < 0) // numero negativos
                {
                    cantNegativos++;

                    if (cantNegativos >= 5)
                        salir = false;
                }

                i++; // Contador de ciclos realizados, (números digitados)
            }
            Console.WriteLine($"Cantidad total de números digitados {i}");
            Console.ReadKey();
        }
    }
}
