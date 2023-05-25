using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio08_Mariel
{
    class Program
    {
        /*8. Leer una cantidad variable de números e indicar cuánto suman 
         * todos los números, y cuál es el promedio de los números */
        static void Main(string[] args)
        {
            // Declaración de variables
            int i = 1,cantiNum,numeros, promedio = 0, suma = 0;
            Console.WriteLine("Digite cuantos números desea ingresar");
            cantiNum = int.Parse(Console.ReadLine());

            while (i <= cantiNum)
            {
                Console.WriteLine($"{i}).Digite un número");
                numeros = int.Parse(Console.ReadLine());
                suma += numeros;
                i++;
                
            }
            promedio = suma / cantiNum;

            Console.WriteLine($"La suma de los números es de: {suma}." +
                $"\nEl promedio de los números es de: {promedio}");
            Console.ReadKey();
        }
    }
}
