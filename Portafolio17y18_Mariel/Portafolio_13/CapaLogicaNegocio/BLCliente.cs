using System;
using System.Collections.Generic;
using System.Text;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;

namespace CapaLogicaNegocio
{
    public class BLCliente
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public BLCliente(string cadenaConexion)// recibe como prametro cadena conexion 
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        // Método para llamar al metodo insertar de lacapaAccesoDatos
        // 
        public int Insertar(EntidadCliente cliente)
        {
            int id_cliente = 0;
            DACliente accessoDatos = new DACliente(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                id_cliente = accessoDatos.Insertar(cliente); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return id_cliente;
        }// fin de insertar

        // llama al metodo listar clientes y trae los datos en un dataSet
        public DataSet ListarClientes(string condicion, string orden)
        {
            DataSet DS;
            DACliente accesoDatos = new DACliente(_cadenaConexion);
            //se instancia el acceso a los datos
            try
            {
                DS = accesoDatos.ListarClientes(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }

            return DS;
        }// ListarClientes

        //se crea el procedimiento para llamar listarClientes(que devuelve lista de clientes)
        //de la capa de acceso a datos.
        public List<EntidadCliente> ListarClientes(string condicion = "")
        {
            List<EntidadCliente> listaClientes;
            DACliente accesoDatos = new DACliente(_cadenaConexion);
            try
            {
                listaClientes = accesoDatos.ListarClientes(condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return listaClientes;
        }

        //se llama el método de la capa de acceso a datos que me recupera un cliente de la base de datos.

        public EntidadCliente ObtenerCliente(int id)
        {
            EntidadCliente cliente;
            DACliente accessoDatos = new DACliente(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                cliente = accessoDatos.ObtenerCliente(id); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return cliente;
        }// fin de insertar


        public int EliminarConSP(EntidadCliente cliente)
        {
            int resultado;
            DACliente accesoDatos = new DACliente(_cadenaConexion);
            try
            {
                // aqui antes de eliminar se podria verificar si es posible eliminar
                resultado = accesoDatos.EliminarRegistroConSP(cliente);
                _mensaje = accesoDatos.Mensaje;
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }//EliminarConSP

        //llama el metodo creado en la capa de acceso 
        // el cual elimina un cliente
        public int EliminarCliente(EntidadCliente cliente)
        {
            int resultado;
            DACliente accesoDatos = new DACliente(_cadenaConexion);
            try
            {
                resultado = accesoDatos.EliminarCliente(cliente);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

        //llama el metodo creado en la capa de acceso el cual modifica un cliente
        public int Modificar(EntidadCliente cliente)
        {
            int filasAfectadas =0 ;
            DACliente accesoDatos = new DACliente(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.Modificar(cliente);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }

    }
}
