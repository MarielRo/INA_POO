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
            double salarioBase, ventasMensuales, comision, salarioBruto; // variables declaradas 

            Console.WriteLine("Digite el salario base mensual del empleado:");
            salarioBase = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite el monto total de las ventas realizadas durante este mes:");
            ventasMensuales = Convert.ToDouble(Console.ReadLine());

            comision = ventasMensuales * 0.1; // 10% de comisión sobre las ventas
            salarioBruto = salarioBase + comision; // salario bruto sumando el salario base y la comisión

            Console.WriteLine($"El salario bruto mensual es: {salarioBruto}");

            Console.ReadKey();
        }
    }
}
