using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11_Mariel
{
    class Program
    {
        /*11.	Construya un programa que permita leer sólo números positivos hasta reunir 10 números
         * pares, o el número 5 cuatro veces. Al final debe indicar la totalidad de números leídos*/
        static void Main(string[] args)
        {
            //declaración de variables
            int i = 0,numero,numerosPares = 0,numeroCinco = 0;

            while (numerosPares < 10 && numeroCinco < 4) // cuando la variable sea mayor a 10 o el numero cinco se repita 4 veces se sale del ciclo
            {

               Console.Write("Ingrese un número positivo:");
               //numero = int.Parse(Console.ReadLine());
              if(int.TryParse(Console.ReadLine(),out numero))
              {
                if (numero > 0)
                {
                   
                  if (numero % 2 == 0)
                  {
                     numerosPares++;
                  }

                  if (numero == 5)
                  {
                     numeroCinco++;
                  }

                        i++;
                } 
                else
                {
                    Console.Write("Solo se pueden ingresar números positivos.\n ");
                }
              }
              else
              {
                    Console.Write("Digito ingresado invalido.\n");
              }
            }

            Console.WriteLine("Cantidad total de números leídos: " + i);
            Console.ReadKey();
        }
    }
}
