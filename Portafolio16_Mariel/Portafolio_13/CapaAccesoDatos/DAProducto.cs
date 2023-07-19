using System;
using System.Data.SqlClient;
using CapaEntidades;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace CapaAccesoDatos
{
   public class DAProducto
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
        public DAProducto(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadProductos producto)
        {
            int id = 0;
            //Establecer el objeto de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            // Establecer los comandos SQL
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            string sentencia = "INSERT INTO PRODUCTOS (DESCRIPCION,PRECIO_COMPRA,PRECIO_VENTA,GRAVADO) " +
                "VALUES(@DESCRIPCION,@PRECIO_COMPRA,@PRECIO_VENTA,@GRAVADO) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("@DESCRIPCION", producto.Descripcion);
            comando.Parameters.AddWithValue("@PRECIO_COMPRA", producto.Precio_compra);
            comando.Parameters.AddWithValue("@PRECIO_VENTA", producto.Precio_venta);
            comando.Parameters.AddWithValue("@GRAVADO", producto.Gravado);
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

        //método para acceder a la lista de clientes, estos se guardan en un dataSet, mediante un adapter.
        //forma de cargar el DataGridView
        // devuelve un dataset con datos de los productos para mostrarlos en el dataview
        public DataSet ListarProductos(string condicion = "", string orden = "")
        {
            DataSet datos = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_PRODUCTO,DESCRIPCION,PRECIO_COMPRA,PRECIO_VENTA,GRAVADO FROM PRODUCTOS";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }

            if (!string.IsNullOrEmpty(orden))
            {
                sentencia = string.Format("{0} order by {1}", sentencia, orden);
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(datos, "Productos");
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }

        public EntidadProductos ObtenerProducto(int id)
        {
            // devuelve un clietne cuando se busca
            EntidadProductos producto = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT ID_PRODUCTO,DESCRIPCION,PRECIO_COMPRA,PRECIO_VENTA,GRAVADO FROM PRODUCTOS WHERE ID_PRODUCTO = " +
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
                    producto = new EntidadProductos();
                    dataReader.Read();
                    producto.Id_productos = dataReader.GetInt32(0);
                    producto.Descripcion = dataReader.GetString(1);
                    producto.Precio_compra = dataReader.GetString(2);
                    producto.Precio_venta = dataReader.GetString(3);
                    producto.Gravado = dataReader.GetString(4);
                    producto.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return producto;
        }

        // Eliminar un cliente
        public int EliminarRegistroConSP(EntidadProductos producto)
        {
            int resultado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Eliminar";
            // Se le indica que el tipo de comando a ejecutar es PROCEDIMIENTO ALMACENADO
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@idproducto", producto.Id_productos);
            // Parámetro de salida del procediemnto almacenado
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            // se declara otro parametro de retorno del SP que reciba lo que devuelve el SP
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@msj"].Value.ToString();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        } //EliminarRegistroConSP

        // actualizar un producto
        public int Modificar(EntidadProductos producto)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE PRODUCTOS SET DESCRIPCION = @DESCRIPCION, PRECIO_VENTA=@PRECIO_VENTA, PRECIO_COMPRA=@PRECIO_COMPRA, GRAVADO = @GRAVADO WHERE " +
                "ID_PRODUCTO=@ID_PRODUCTO";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_PRODUCTO",producto.Id_productos);
            comando.Parameters.AddWithValue("@DESCRIPCION",producto.Descripcion);
            comando.Parameters.AddWithValue("@PRECIO_VENTA", producto.Precio_venta);
            comando.Parameters.AddWithValue("@PRECIO_COMPRA", producto.Precio_compra);
            comando.Parameters.AddWithValue("@GRAVADO", producto.Gravado);
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
