using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01_Mariel
{
    class Program
    {
        /*Construya un programa que permita leer una cantidad de 20 números y nos indique finalmente cuantos fueron positivos,
            cuantos fueron negativos y cuantas veces se introdujo el cero.*/

        static void Main(string[] args)
        {
            //Declaración de variables
            int numero,positivo = 0,negativo = 0,cero = 0,i = 1;
            while(i < 21)
            {
                
                Console.WriteLine($"({i}).Ingrese un número positivo o negativo: ");
                numero = Convert.ToInt32(Console.ReadLine());
                if (numero > 0) // número mayor a cero
                {
                    positivo++;
                }  
                else if (numero < 0)  // número menor a cero
                {
                    negativo++;
                }
                else
                {
                    cero++; // ceros
                }

                i++;
            }

            Console.WriteLine($"La cantidad de números positivos fue de: {positivo}." +
                $"\nLa cantidad de números negativos fue de: {negativo}." +
                $"\nLa cantidad de números ceros fue de: {cero}. \n  ");

            Console.ReadKey();
        }
    }
}
