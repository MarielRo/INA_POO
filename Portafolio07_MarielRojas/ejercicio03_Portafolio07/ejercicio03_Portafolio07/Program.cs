using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio03_Portafolio07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite la cantidad de horas:");
            int horas = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la cantidad de minutos:");
            int minutos = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la cantidad de segundos:");
            int segundos = Int32.Parse(Console.ReadLine());

            int totalSegundos = (horas * 60 * 60) + (minutos * 60) + segundos;

            Console.WriteLine($"El total de segundos es: {totalSegundos}");

            Console.ReadLine();
        }
    }
}
