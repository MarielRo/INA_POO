using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio04_Portafolio07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la cantidad de segundos:");
            int totalSegundos = Convert.ToInt32(Console.ReadLine());

            int horas = totalSegundos / 3600;  
            int minutos = (totalSegundos % 3600) / 60; // residuo de minutos de las horas y se divide entre 60 para saber cuantos minutos
            int segundos = (totalSegundos % 3600) % 60;  //  residuo de minutos que serian los segundos

            Console.WriteLine($"Horas: {horas} : Minutos: {minutos} : Segundos: {segundos}");
            Console.ReadKey();
        }
    }
}
s