using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio09_Mariel
{
    class Program
    {   /*9.Leer una cantidad de números variables hasta que se ingrese un número múltiplo de 5.
         * Indicar el número de datos que fueron ingresados, sin contar el múltiplo de la condición de término.*/
        static void Main(string[] args)
        {
            //declaración de variables 
            int i = 0, numeros;

            while (true)
            {
                Console.WriteLine($"Digite un número");
                numeros = int.Parse(Console.ReadLine());

                if (numeros % 5 == 0)
                {

                    break; // se sale el ciclo while
                }

                i++;
            }

            Console.WriteLine($"Se ingresaron {i} números.");
            Console.ReadKey();
        }
    }
}
