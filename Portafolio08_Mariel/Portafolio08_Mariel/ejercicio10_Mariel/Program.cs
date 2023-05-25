using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio10_Mariel
{
    class Program
    {
        /*10.Leer las edades de los asistentes a un cine e indicar finalmente cuántos de estos fueron: niños (1-10), adolescentes (11-15),
         * jóvenes (16-22), adultos (23-65), adultos mayores (más de 65), preguntar si desea leer otro asistente*/
        static void Main(string[] args)
        {
            //declaración de variables
            int niños = 0, adolescentes = 0,jóvenes = 0,adultos = 0,adultosMayores = 0;
            string respuesta ="";
            bool continuar = true;

            while (continuar)
            {
                Console.Write("Digite la edad de la persona que asistió al cine: ");
                int edad = int.Parse(Console.ReadLine());

                if (edad >= 1 && edad <= 10) // de 1 a 10 años
                {
                    niños++;
                }
                else if (edad >= 11 && edad <= 15) // de 11 a 15 años
                {
                    adolescentes++;
                }
                else if (edad >= 16 && edad <= 22) // de 16 a 22 años
                {
                    jóvenes++;
                }
                else if (edad >= 23 && edad <= 65) // de 23 a 65 años
                {
                    adultos++;
                }
                else
                {
                    adultosMayores++; // mayores a 65
                }

                Console.Write("¿Desea ingresar la edad de otra persona? (s/n): ");
                respuesta = Console.ReadLine();

                if (respuesta != "s")
                {
                    continuar = false;         
                }
            }

            Console.WriteLine($"Cantidad de niños: {niños}.\n Cantidad de adolescentes: {adolescentes}." +
                $"\nCantidad de jóvenes: {jóvenes}.\n" +
                $"Cantidad de adultos:{adultos}.\n " +
                $"Cantidad de adultos mayores:{adultosMayores}");
            Console.ReadKey();
        }
    }
}
