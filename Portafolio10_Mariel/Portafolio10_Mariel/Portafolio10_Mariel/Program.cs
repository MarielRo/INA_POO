using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio10_Mariel
{
    class Program
    {
        static void Main(string[] args)
        {
            // retorno arreglo con 5 objetos
            TourVacaciones[] tours = TourVacaciones.ObtenerTours();

            // contador con la cantidad de objeto creados
            Console.WriteLine($"Cantidad de objetos: {TourVacaciones.getContadorDeObjetos()}");


            //arreglo de clases anónimas para vehículos
            var vehiculos = new[]
            {
                new { Placa = "MRS123", Tipo = "Automóvil", Color = "Rojo", Año = 2022, Fabricante = "Ford", Modelo = "Mustang" },
                new { Placa = "ABC123", Tipo = "SUB 4x4", Color = "Negro", Año = 2001, Fabricante = "Toyota", Modelo = "RAV4" },
                new { Placa = "DAF456", Tipo = "SUB 4x4", Color = "Blanco", Año = 2020, Fabricante = "Jeep", Modelo = "Wrangler" },
                new { Placa = "GDF781", Tipo = "Automóvil", Color = "Blanco", Año = 2023, Fabricante = "Chevrolet", Modelo = "Camaro" },
                new { Placa = "ZFG282", Tipo = "SUB 4x4", Color = "Gris", Año = 2019, Fabricante = "Land Rover", Modelo = "Discovery" },
                new { Placa = "KIY162", Tipo = "Automóvil", Color = "Gris", Año = 2022, Fabricante = "Huundai", Modelo = "Elantra" }
            };

            //  datos de los vehículos
            Console.WriteLine("\nDatos de los vehículos:");
            Console.WriteLine("Placa\tTipo\t\tColor\tAño\tFabricante\tModelo");
            // ciclo foreach
            foreach (var vehiculo in vehiculos)
            {
                Console.WriteLine($"{vehiculo.Placa}\t{vehiculo.Tipo}\t{vehiculo.Color}\t{vehiculo.Año}\t{vehiculo.Fabricante}\t{vehiculo.Modelo}");
            }
        }


        class TourVacaciones
        {
            // Atributos 
            private string idTour;
            private string destino;
            private double precio;
            private DateTime fechaSalida;
            private DateTime fechaRegreso;
            private string descripcion;

            //Variables estáticas
            private static int contadorDeObjetos = 0;

            //método constructor que reciba todos los atributos

            public TourVacaciones(string idTour, string destino, double precio, DateTime fechaSalida, DateTime fechaRegreso, string descripcion)
            {
                this.idTour = idTour;
                this.destino = destino;
                this.precio = precio;
                this.fechaSalida = fechaSalida;
                this.fechaRegreso = fechaRegreso;
                this.descripcion = descripcion;
            }

            //método constructor que no reciba ningún parámetro, valores por defecto
            public TourVacaciones()
            {
                idTour = string.Empty;
                destino = string.Empty;
                precio = 0;
                fechaSalida = DateTime.Now;
                fechaRegreso = DateTime.Now;
                descripcion = string.Empty;
            }

            //Propiedades del metodo acceso
            public static int getContadorDeObjetos()
            {
                return contadorDeObjetos;
            }



            //Método getter y setter de forma simplificada
            public string IdTour { get; set; }
            public string Destino { get; set; }
            public DateTime FechaSalida { get; set; }
            public DateTime FechaRegreso { get; set; }
            public string Descripcion { get; set; }
            //comprobación que el valor sea mayor a cero
            // FORMA 1 
            public double Precio
            {
                get { return precio; }
                set
                {
                    // validaciones
                    if (value > 0)
                    {
                        precio = value;
                    }
                    else
                    {
                        Console.WriteLine("El precio debe ser mayor que cero.");
                    }

                }
            }

            // método que retorne un arreglo de objetos TourVacaciones
            //crear un arreglo de objetos, ir guardando los datos
            //que escriba el usuario de cada Tour en un objeto y almacenar en cada posición cada objeto
            //retornar el arreglo con los 5 objetos. Debe utilizar los métodos de acceso creados.

            public static TourVacaciones[] ObtenerTours()
            {
                //Variables 
                string idTour, destino, descripcion;
                double precio;
                DateTime fechaSalida, fechaRegreso;
                TourVacaciones[] tours = new TourVacaciones[5];

                for (int i = 0; i < 5; i++)
                {
                    Console.Write("Digite los datos Id del tour: ");
                    idTour = Console.ReadLine();
                    Console.Write("Digite los datos del destino: ");
                    destino = Console.ReadLine();
                    Console.Write("Precio: ");
                    precio = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Fecha de salida: ");
                    fechaSalida = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Fecha de regreso: ");
                    fechaRegreso = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Descripción: ");
                    descripcion = Console.ReadLine();

                    tours[i] = new TourVacaciones(idTour, destino, precio, fechaSalida, fechaRegreso, descripcion);
                }

                return tours;
            }

        }
    }
}