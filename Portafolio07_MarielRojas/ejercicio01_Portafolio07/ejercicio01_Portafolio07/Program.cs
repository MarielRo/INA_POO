using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio01_Portafolio07
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Calcular el área en metros cuadrados de
            un terreno rectangular cuyo frente y fondo se dan en pies.Solicite los datos de
             frente y fondo, el sistema debe mostrar el área en m2.*/

            Console.WriteLine("Área de un terreno rectangular");
            Console.WriteLine("Ingrese el frente del terreno en pies");
            float frente, fondo, metros, pies;

            frente = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite el fondo del terreno en pies");
            fondo = float.Parse(Console.ReadLine());

            pies= frente * fondo;
            metros = (float)(pies / 10.764);

            Console.WriteLine($"El área del terreno es de {metros} m2");
            Console.ReadKey();
        }
    }
}
