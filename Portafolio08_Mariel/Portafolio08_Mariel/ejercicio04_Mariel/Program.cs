using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio04_Mariel
{
    class Program
    {
        /*4.Construya un programa que permita leer una cantidad variable de números indicando finalmente lo siguiente:
         * cuantos fueron pares, cuantos fueron impares, cuántos fueron múltiplos de tres */
        static void Main(string[] args)
        {
            //Declaración de variables
            int cantiNum, pares = 0,numero =0, impares = 0, multiplosTres = 0, i = 1;
            Console.WriteLine("Digite cuantos números desea ingresar");
            cantiNum = int.Parse(Console.ReadLine());

            while (i <= cantiNum) 
            {
                Console.WriteLine($"{i}).Digite un número");
                numero = int.Parse(Console.ReadLine());
                if (numero % 2 == 0) // numeros pares
                    pares++;
                else
                    impares++; // impares

                if (numero % 3 == 0) // multiplos de tres
                    multiplosTres++;

                i++;
            }

            Console.WriteLine($"La cantidad de números pares fue de: {pares}." +
                $"\nLa cantidad de números impares fue de: {impares}." +
                $"\nLa cantidad de números multiplos de tres: {multiplosTres}. \n  ");
            Console.ReadKey();
        }
    }
}
