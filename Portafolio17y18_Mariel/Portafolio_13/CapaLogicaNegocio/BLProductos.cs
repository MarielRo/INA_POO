using System;
using System.Collections.Generic;
using System.Text;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;

namespace CapaLogicaNegocio
{
    public class BLProductos
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public BLProductos(string cadenaConexion)// recibe como prametro cadena conexion 
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        // Método para llamar al metodo insertar productos de la capaAccesoDatos
        public int Insertar(EntidadProductos productos)
        {
            int id_producto = 0;
            DAProducto accessoDatos = new DAProducto(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                id_producto = accessoDatos.Insertar(productos); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return id_producto;
        }// fin de insertar

        // 
        
        public DataSet ListarProductos(string condicion = "", string orden = "")
        {
            DataSet DS;
            DAProducto accesodatos = new DAProducto(_cadenaConexion);

            try
            {
                DS = accesodatos.ListarProductos(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;

        }// fin listar productos

        public EntidadProductos ObtenerProducto(int id)
        {
            EntidadProductos producto;
            DAProducto accessoDatos = new DAProducto(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                producto = accessoDatos.ObtenerProducto(id); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return producto;
        }// fin de insertar

        //llama el metodo creado en la capa de acceso 
        // el cual elimina un producto
        public int EliminarProducto(EntidadProductos producto)
        {
            int resultado;
            DAProducto accesoDatos = new DAProducto(_cadenaConexion);
            try
            {
                resultado = accesoDatos.EliminarRegistroConSP(producto);
                _mensaje = accesoDatos.Mensaje;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }


        //llama el metodo creado en la capa de acceso el cual modifica un cliente
        public int Modificar(EntidadProductos producto)
        {
            int filasAfectadas = 0;
            DAProducto accesoDatos = new DAProducto(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.Modificar(producto);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }

    }
}
