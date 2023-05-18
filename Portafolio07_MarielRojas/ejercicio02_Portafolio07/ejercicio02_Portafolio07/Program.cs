using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio02_Portafolio07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite el salario base mensual del empleado:");
            double salarioBase;
            salarioBase = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite el monto total de las ventas realizadas durante este mes:");
            double ventasMensuales;
            ventasMensuales = Convert.ToDouble(Console.ReadLine());

            double comision = ventasMensuales * 0.1; // 10% de comisión sobre las ventas
            double salarioBruto = salarioBase + comision; // salario bruto sumando el salario base y la comisión

            Console.WriteLine($"El salario bruto mensual es: {salarioBruto}");

            Console.ReadLine();
        }
    }
}
