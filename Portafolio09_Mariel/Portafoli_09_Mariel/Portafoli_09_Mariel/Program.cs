using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portafoli_09_Mariel
{
    class Program
    {
        static void Main(string[] args)
        {
            // crear objetos 
            Libro libro_01 = new Libro();// sin parametros
            Libro libro_02 = new Libro("La Piedra filosofal", "J. K. Rowling", "Novela",1997,"Inglés", " Salamandra S.A.", true);//con parametros

            Cliente cliente_01 = new Cliente("Brisa","Rojas", 50, 123456789, "juan@example.com", false);
            Cliente cliente_02 = new Cliente();
            Cliente cliente_03 = new Cliente("Juan", "Rojas", false); // solo para verificar estado

            // llamar a getter
            //sin parametros
            Console.WriteLine(libro_01.getLibro());
            Console.WriteLine("");
            // con parametros
            Console.WriteLine(libro_02.getLibro());
            Console.WriteLine("");
            // metodo getDisponibilidad
            Console.WriteLine(libro_02.getDisponibilidad());
            Console.WriteLine("");


            //Clientes
            Console.WriteLine(cliente_01.getCliente());
            Console.WriteLine("");

            Console.WriteLine(cliente_02.getCliente());
            Console.WriteLine("");

            //Método estado cliente
            Console.WriteLine(cliente_03.getEstadoCliente01());
            Console.WriteLine("");
            
            Console.ReadKey();
        }
    }

    class Libro
    {
        //Atributos 
        private string titulo;
        private string autor;
        private string genero;
        private int anoPublicacion;
        private string idioma;
        private string editorial;
        private bool estado;

        // Métodos 
        // Constructor sin parámetros
        public Libro()
        {
            titulo = "El monje que vendió su Ferrari";
            autor = " Robin S. Sharma";
            genero = "Ficcion";
            anoPublicacion = 1996;
            idioma = "Inglés";
            editorial = "HarperCollins";
            estado = true;
        }

        // Constructor con parámetros sobrecarga
        public Libro(string titulo, string autor, string genero, int anoPublicacion, string idioma, string editorial,bool estado)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.genero = genero;
            this.anoPublicacion = anoPublicacion;
            this.idioma = idioma;
            this.editorial = editorial;
            this.estado = estado;
        }
        // Constructor con parámetros sobrecarga

        public Libro(string titulo, string autor, bool estado)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.estado = estado;
        }

        //Métodos getter para cada atributo 
        public string getTitulo()
        {
            return titulo;
        }
        public string getAutor()
        {
            return autor;
        }
        public string getGenero()
        {
            return genero;
        }
        public int getAnoPublicacion()
        {
            return anoPublicacion;
        }
        public string getIidioma()
        {
            return idioma;
        }
        public string getEditorial()
        {
            return editorial;
        }
        public bool getEstado()
        {
            return estado;
        }
        //Métodos setter para cada atributo 
        public void setTitulo(string titulo)
        {
            this.titulo = titulo;
        }
        public void setAutor(string autor)
        {
            this.autor = autor;
        }
        public void setGenero(string genero)
        {
            this.genero = genero;
        }
        public void setIdioma(string idioma)
        {
            this.idioma = idioma;
        }
        public void setEditorial(string editorial)
        {
            this.editorial = editorial;
        }
        public void setPublicacion(int anoPublicacion)
        {
            this.anoPublicacion = anoPublicacion;
        }
        public void setEstado(bool estado)
        {
            this.estado = estado;
        }
        //Método retorno de información  
        public string getLibro()
        {
            string informacion = $"Información del Libro: " +
                $"\nTítulo de Libro: {titulo}." +
                $"\nAutor: {autor}." +
                $"\nGénero: {genero}." +
                $"\nAño de Publicación: {anoPublicacion}." +
                 $"\nIdioma: {idioma}" +
                $"\nEditorial: {editorial}" +
                $"\nEstado: {estado}";
            return informacion;
        }

        public string getDisponibilidad()
        {
            string informacion = $"Dispinibilidad del Libro: " +
                $"\nTítulo de Libro: {titulo}." +
                $"\nAutor: {autor}." +
                $"\nEstado: {estado}";
            return informacion;
        }

        // seller con parametros
        public void setDisponibilidad(string titulo, string autor, bool estado)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.estado = estado;
        }

        // seller con parametros
        public void setCaracteristicas(string genero, string idioma, int anoPublicacion)
        {
            this.genero = genero;
            this.idioma = idioma;
            this.anoPublicacion = anoPublicacion;
        }

        //metodo sin sobrecarga
        public void Disponibilidad()
        {
            if (estado)
            {
                
                Console.WriteLine("El libro se encuentra disponible para su venta.");
            }
            else
            {
                Console.WriteLine("El libro no está disponible para ser prestado.");
            }
        }

        // Sobrecarga al método
        public void VerificarIdioma(string idioma)
        {
            if (idioma != "Español")
            {

                Console.WriteLine($"Unicamente hay libros en {idioma}");
            }
            else
            {
                Console.WriteLine($"El idioma {idioma} si esta disponible");
            }
        }

        // Sobrecarga al método
        public void VerificarIdioma(string titulo,string idioma)
        {
            if (idioma != "Español")
            {

                Console.WriteLine($"El libro {titulo} no se encuentra en  {idioma}");
            }
            else
            {
                Console.WriteLine($"El libro {titulo} no se encuentra en  {idioma}");
            }
        }
        // Sobrecarga al método
        public void VerificarIdioma(string titulo,string autor, string idioma)
        {
            if (idioma != "Español")
            {

                Console.WriteLine($"El libro {titulo} del autor {autor} no se encuentra en {idioma}");
            }
            else
            {
                Console.WriteLine($"El libro {titulo} del autor {autor} no se encuentra en {idioma}");
            }
        }

    }

    class Cliente
    {

        // Atributos
        private string nombre;
        private string apellidos;
        private int edad;
        private int telefono;
        private string correo;
        private bool estado;

        //Constructor sin parametros
        public Cliente()
        {
            nombre= "Mariel";
            apellidos = "Rojas";
            edad = 22;
            telefono = 83912061;
            correo = "abc@gmail.com";
            estado = true;
        }


        // Constructor con parametros sobrecarga
        public Cliente(string nombre, string apellidos, int edad, int telefono, string correo, bool estado)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
            this.telefono = telefono;
            this.correo = correo;
            this.estado = estado;
        }
        // Constructor con parámetros sobrecarga
        public Cliente(string nombre, string apellidos, bool estado)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.estado = estado;
        }
        //Métodos getter para cada atributo 
        public string getNombre()
        {
            return nombre;
        }
        public string getApellidos()
        {
            return apellidos;
        }
        public int getEdad()
        {
            return edad;
        }
        public int getTelefono()
        {
            return telefono;
        }
        public string getCorreo()
        {
            return correo;
        }
        public bool getEstadoCliente()
        {
            return estado;
        }
       
        //Métodos setter para cada atributo 
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public void setApellidos(string apellidos)
        {
            this.apellidos = apellidos;
        }
        public void setEdad(int edad)
        {
            this.edad = edad;
        }
        public void setTelefono(int telefono)
        {
            this.telefono = telefono;
        }
        public void setCorreo(string correo)
        {
            this.correo = correo;
        }
        public void setEstadoCliente(bool estado)
        {
            this.estado = estado;
        }
        //Método get retorno de información  
        public string getCliente()
        {
            string informacion = $"Información del Cliente: " +
                $"\nNombre: {nombre}." +
                $"\nApellidos: {apellidos}." +
                $"\nEdad: {edad}." +
                $"\nCorreo: {correo}." +
                 $"\nTélefono: {telefono}" +
                $"\nEstado: {estado}";
            return informacion;
        }

        //Método get retorno de información
        public string getEstadoCliente01()
        {
            string informacion = $"Estado del Cliente: " +
                $"\nNombre: {nombre}." +
                $"\nApellidos: {apellidos}." +
                $"\nEstado: {estado}";
            return informacion;
        }

        // seller con parametros
        public void setCliente( bool estado)
        {
            this.estado = estado;
        }

        // seller con parametros
        public void setContactod(string correo, int telefono)
        {
            this.correo = correo;
            this.telefono = telefono;
        }

        // metodos con sobrecarga
        public void Agregar()
        {
            if (!estado)
            {
                estado = true;
                Console.WriteLine("Cliente agregado al sistema.");
            }
            else
            {
                Console.WriteLine("El cliente ya está registrado.");
            }
        }

        // Sobrecarga del método agregar
        public void Agregar(string nombre,string correo, int telefono)
        {
            if (!estado)
            {
                this.nombre = nombre;
                this.correo = correo;
                this.telefono = telefono;
                estado = true;
                Console.WriteLine("Cliente agregado al sistema.");
            }
            else
            {
                Console.WriteLine("El cliente ya está registrado.");
            }
        }
    }

}

