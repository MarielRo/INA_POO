using System;
using System.Data.SqlClient;
using CapaEntidades;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.Collections.Generic;
using System.Linq;


namespace CapaAccesoDatos
{
    public class DACliente
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;
        //Propiedades
        public string Mensaje
        {
            get => _mensaje;
        }

        //Constructor 
        public DACliente(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadCliente cliente)
        {
            int id = 0;
            //Establecer el objeto de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            // Establecer los comandos SQL
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            string sentencia = "INSERT INTO CLIENTES (NOMBRE,TELEFONO,DIRECCION) VALUES(@NOMBRE, @TELEFONO,@DIRECCION) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("@NOMBRE", cliente.Nombre);
            comando.Parameters.AddWithValue("@TELEFONO", cliente.Telefono);
            comando.Parameters.AddWithValue("@DIRECCION", cliente.Direccion);
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                id = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();

            }

            return id;
        }// fin de insertar

        // se crea el método para acceder a la lista de clientes,
        // se almacenan en un dataSet, luego se pasan a una lista de clientes.
        //forma de cargar el DataGridView  con una lista de entidades
        public List<EntidadCliente> ListarClientes(string condicion = "")
        {
            //devuelve una lista clientes en lugar de un dataset
            DataSet DS = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            List<EntidadCliente> clientes; // lista entidades // 5 entidades de la lista
            string sentencia = "SELECT ID_CLIENTE,NOMBRE,TELEFONO,DIRECCION FROM CLIENTES";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(DS, "Clientes");// se llena el dataset y se le pone nombre
                // sentencia linQ para convertir el dataset en una lista "using system.Linq"
                clientes = (
                    from DataRow fila in DS.Tables["Clientes"].Rows
                        /*select new EntidadCliente((int)fila[0], fila[1].ToString(),
                        fila[2].ToString(), fila[3].ToString(),true)).ToList(); // mandarle los parametros al cosntructos 
                        */
                    select new EntidadCliente()
                    {
                        Id_cliente = (int)fila[0],
                        Nombre = fila[1].ToString(),
                        Telefono = fila[2].ToString(),
                        Direccion = fila[3].ToString(),
                        Existe = true
                    }).
                ToList();

            }
            catch (Exception)
            {
                throw;
            }

            return clientes; // devulve la lista con los clientes
        }

        //La información obtenida en la consulta se almacena en un dataReader
        //luego se pasa a la entidad cliente, que es el valor devuelto por la función. 

        public EntidadCliente ObtenerCliente(int id)
        {
            // devuelve un clietne cuando se busca
            EntidadCliente cliente = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT ID_CLIENTE, NOMBRE, TELEFONO, DIRECCION FROM CLIENTES WHERE ID_CLIENTE = " +
                " {0}", id);
            // SI EL ID ES TEXTO SE ESCRIBE ENTRE COMILLAS {0} en el string
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    cliente = new EntidadCliente();
                    dataReader.Read();
                    cliente.Id_cliente = dataReader.GetInt32(0);
                    cliente.Nombre = dataReader.GetString(1);
                    cliente.Telefono = dataReader.GetString(2);
                    cliente.Direccion = dataReader.GetString(3);
                    cliente.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return cliente;
        }

        // Eliminar un cliente seleccionado sin precedimiento almacenado
        public int EliminarCliente(EntidadCliente cliente)
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM CLIENTES";
            sentencia = string.Format("{0} WHERE ID_CLIENTE = {1}", sentencia, cliente.Id_cliente);
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                afectado = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return afectado; 
        }

        // actualizar un cliente
        // modificar los datos del cliente seleccionado
        public int Modificar(EntidadCliente cliente)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE CLIENTES SET NOMBRE = @NOMBRE, TELEFONO=@TELEFONO, DIRECCION=@DIRECCION WHERE " +
                "ID_CLIENTE=@ID_CLIENTE";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_CLIENTE", cliente.Id_cliente);
            comando.Parameters.AddWithValue("@NOMBRE", cliente.Nombre);
            comando.Parameters.AddWithValue("@TELEFONO", cliente.Telefono);
            comando.Parameters.AddWithValue("@DIRECCION", cliente.Direccion);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;

        } // modificar
    }
}
