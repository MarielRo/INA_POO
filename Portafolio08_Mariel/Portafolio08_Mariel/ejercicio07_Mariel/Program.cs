using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio07_Mariel
{
    class Program
    {
        /* 7.Leer 10 números e indicar cuánto suman los números pares.*/
        static void Main(string[] args)
        {
            //Declaración de variables
            int i = 1, numeros = 0, sumaPares = 0;

            while (i <= 10)
            {
                Console.WriteLine($"{i}).Digite un número para sumarlo");
                numeros = int.Parse(Console.ReadLine());
                if (numeros % 2 == 0)
                {
                    sumaPares += numeros;
                }
                    
                i++;
            }
            Console.WriteLine($"La suma de los números pares digitados es de: {sumaPares}");
            Console.ReadKey();
        }
    }
}
