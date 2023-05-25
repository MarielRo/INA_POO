using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio07_Portafolio07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite la cantidad de metros de ancho del terreno:");
            double ancho = Convert.ToDouble(Console.ReadLine());

            double largo = 2 * ancho; 

            double perimetro = 2 * (largo + ancho);

            int cantidadPostes = (int)(perimetro / 2);

            Console.WriteLine($"La cantidad de postes necesarios es: {cantidadPostes}");

            Console.ReadKey();
        }
    }
}