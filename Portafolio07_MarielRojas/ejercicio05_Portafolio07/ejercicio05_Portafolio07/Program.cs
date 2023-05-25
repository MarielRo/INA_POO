using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio05_Portafolio07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite la cantidad de megabytes:");
            double megabytes = Convert.ToDouble(Console.ReadLine());

            double bits = megabytes * 8 * 1024 * 1024; // 
            double bytes = megabytes * 1024 * 1024;
            double kilobytes = megabytes * 1024;
            double gigabytes = megabytes / 1024;

            Console.WriteLine($"Megabytes equivalentes en bits: {bits}");
            Console.WriteLine($"Megabytes equivalentes en bytes: {bytes}");
            Console.WriteLine($"Megabytes equivalentes kilobytes: {kilobytes}");
            Console.WriteLine($"Megabytes equivalent en gigabytes: {gigabytes}");

            Console.ReadLine();
        }
    }
}
