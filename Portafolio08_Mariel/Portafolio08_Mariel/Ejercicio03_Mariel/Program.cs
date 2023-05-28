using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio03_Mariel
{
    class Program
    {
        /*Construya un programa que permita ingresar 10 notas entre 1 y 100,
         * indicando finalmente cuántos alumnos aprobaron(>=70) y cuantos reprobaron(<70).*/
        static void Main(string[] args)
        {
            //Declaración de variables
            int nota, aprobados = 0, reprobados = 0, i = 1;
            while(i <= 10)
            {
                Console.WriteLine($"Digite la nota del alumno {i}");
                nota = int.Parse(Console.ReadLine());
                if(nota > 0 && nota <= 100 )
                {
                    if (nota >= 70)
                    {
                    aprobados++;
                    }
                    else
                    {
                    reprobados++;
                    }
                
                    i++; // contador
                }
                else
                {
                    Console.WriteLine($"Digite la nota del alumno, la nota debe ser mayor a cero y menor a 100");
                }
                            }

            Console.WriteLine($"Aprobaron {aprobados} alumnos.\n " +
               $"Reprobaron {reprobados} alumnos.\n");
            Console.ReadKey();
        }
    }
}
