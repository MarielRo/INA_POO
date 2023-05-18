using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio06_Portafolio07
{
    class Program
    {
        static void Main(string[] args)
        {
           
            double totalSalarios = 0; // Se debe inicializar para que no de error

            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine($"Ingrese el salario del mes {i}:");
                double salario = Convert.ToDouble(Console.ReadLine());
                totalSalarios += salario;
            }

            double aguinaldo = totalSalarios / 12;

            Console.WriteLine($"El monto de aguinaldo es: {aguinaldo}");

            Console.ReadKey();
        }
    }
}
