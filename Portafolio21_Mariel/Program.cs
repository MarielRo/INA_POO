using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariel_Portafolio_21
{
    class Program
    {
        static void Main(string[] args)
        {
            //Obtención de uno o varios orígenes de datos
            //Creación de la consulta(que la vamos a guardar en una variable)
            //Ejecución de la consulta


            // 1.origen de datos

            //a.Cree un arreglo de clases anónimas de 6 Materias(cod, nombre, creditos)

            var materias = new[]
            {
            new { cod = 1, nombre = "Matemáticas", creditos = 4 },
            new { cod = 2, nombre = "Física", creditos = 3 },
            new { cod = 3, nombre = "Química", creditos = 3 },
            new { cod = 4, nombre = "Programación", creditos = 4 },
            new { cod = 5, nombre = "Electrónica", creditos = 5 },
            new { cod = 6, nombre = "Circuitos Electricos", creditos = 5 }
            };

            // b.Cree un arreglo de clases anónimas de 4 Estudiantes(id, Nombre y telefono)

            // Crear un arreglo de clases anónimas de 4 Estudiantes (id, Nombre y telefono)
            var estudiantes = new[]
            {
            new { id = 1, Nombre = "Mariel", telefono =  "45642184" },
            new { id = 2, Nombre = "Jose", telefono =    "12345678" },
            new { id = 3, Nombre = "Claudio", telefono = "11111111" },
            new { id = 4, Nombre = "Gabriela", telefono ="88888888" }
            };


            // c.Cree un arreglo de clases anónimas de 2 Matriculas (codMatricula, id_Estudiante, cod_Materia).
            var matriculas = new[]
            {
            new { codMatricula = 111, id_Estudiante = 1, cod_Materia = 2 },
            new { codMatricula = 112, id_Estudiante = 1, cod_Materia = 4 },
            new { codMatricula = 113, id_Estudiante = 2, cod_Materia = 4 },
            new { codMatricula = 114, id_Estudiante = 4, cod_Materia = 6 }
            };

            //-----------------------------------------------------------------------
            //Continuando con los datos anteriores y utilizando consultas LINQ
            // 2.Definir la consulta
            // Mariel, Jose y Gabriela, claudio no esta ,matriculado
            //3.Seleccione el nombre de los estudiantes matriculados, muestre el resultado con un foreach.
            
            var estuMatriculados = from matricula in matriculas
                                          join estudiante in estudiantes 
                                          on matricula.id_Estudiante
                                          equals estudiante.id //==
                                          select estudiante.Nombre;

            //4.En matriculas muestre la cantidad de veces que se ha
            //matriculado una materia, muestre el resultado con un foreach.

            var cantidadMatriculasPorMateria = from matricula in matriculas
                                               group matriculas by matricula.cod_Materia
                                               into g
                                               select new
                                               {

                                                   cod_Materia = g.Key,
                                                   cant_Matriculas = g.Count()


                                               };


            //5.	Muestre el nombre de los estudiantes matriculados y el nombre
            //de la materia en la que se matriculó, muestre el resultado con un foreach
             
            var estuMatriculados_Materia = from matricula in matriculas
                                                  join estudiante in estudiantes on matricula.id_Estudiante equals estudiante.id // estudiantes matricu
                                                  join materia in materias on matricula.cod_Materia equals materia.cod // nombre materia qeue se matriculo
                                                  select new
                                                  {
                                                      NombreEstudiante = estudiante.Nombre,
                                                      MateriaMatriculada = materia.nombre
                                                  };

            //6. Crear la siguiente clase anonima                                    

            var autos = new[]
            {
                new { Cod = 1, Marca = "Toyota", Precio = 40000, Modelo = 2020},
                new { Cod = 2, Marca = "Honda", Precio = 30000, Modelo = 2020},
                new { Cod = 3, Marca = "Toyota", Precio = 50000, Modelo = 2022},
                new { Cod = 4, Marca = "Honda", Precio = 35000, Modelo = 2021},
                new { Cod = 5, Marca = "Toyota", Precio = 45000, Modelo = 2021},
                new { Cod = 6, Marca = "Toyota", Precio = 37000, Modelo = 2019}
            };

            //7.	Realice una consulta LINQ para:

            // a.Mostrar el precio más alto por cada modelo.

            var preciosMayor = from auto in autos
                                           group auto by auto.Modelo into grupoModelo
                                           select new
                                           {
                                               Modelo = grupoModelo.Key,
                                               PrecioMayor = grupoModelo.Max(auto => auto.Precio) //mas alto
                                           };

            //b.Mostrar el precio más bajo por cada modelo.
            var preciosMenor = from auto in autos
                                           group auto by auto.Modelo into grupoModelo
                                           select new
                                           {
                                               Modelo = grupoModelo.Key,
                                               PrecioMenor = grupoModelo.Min(auto => auto.Precio) //mas bajo
                                           };

            //c.	Mostrar la suma total de los precios por modelo.
            var sumaPrecios = from auto in autos
                                       group auto by auto.Modelo into grupoModelo
                                       select new
                                       {
                                           Modelo = grupoModelo.Key,
                                           SumaPrecios = grupoModelo.Sum(auto => auto.Precio)
                                       };



            //4. Ejecutar consultas
            Console.WriteLine("Nombre de los estudiantes matriculados:");
            foreach (var nombreEstudiante in estuMatriculados)
            {
                Console.WriteLine(nombreEstudiante);
            }

            Console.WriteLine();

            Console.WriteLine("Cantidad de veces que se ha matriculado cada materia:");
            foreach (var materia in cantidadMatriculasPorMateria)
            {
                Console.WriteLine($"Materia con código {materia.cod_Materia}: {materia.cant_Matriculas} matrículas");
            }

            Console.WriteLine();

            Console.WriteLine("Nombre de los estudiantes matriculados y materia en la que se matricularon:");
            foreach (var nombre in estuMatriculados_Materia)
            {
                Console.WriteLine($"Estudiante: {nombre.NombreEstudiante}, Materia: {nombre.MateriaMatriculada}");
            }
            Console.WriteLine();
            Console.WriteLine("Precio más alto por cada modelo:");
            foreach (var precioModelo in preciosMayor)
            {
                Console.WriteLine($"Modelo: {precioModelo.Modelo}, Precio más alto: {precioModelo.PrecioMayor}");
            }

            Console.WriteLine();

            Console.WriteLine("Precio más bajo por cada modelo:");
            foreach (var precioModelo in preciosMenor)
            {
                Console.WriteLine($"Modelo: {precioModelo.Modelo}, Precio más bajo: {precioModelo.PrecioMenor}");
            }

            Console.WriteLine();

            Console.WriteLine("Suma total de los precios por modelo:");
            foreach (var sumaPorModelo in sumaPrecios)
            {
                Console.WriteLine($"Modelo: {sumaPorModelo.Modelo}, Suma de precios: {sumaPorModelo.SumaPrecios:C}");
            }

            Console.ReadLine();
        }
    }
}
