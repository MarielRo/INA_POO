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
            string sentencia = "INSERT INTO PRODUCTOS (ID_PRODUCTO,DESCRIPCION,PRECIO_COMPRA,PRECIO_VENTA,GRAVADO) " +
                "VALUES(@ID_PRODUCTO,@DESCRIPCION,@PRECIO_COMPRA,@PRECIO_VENTA,@GRAVADO) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("ID_PRODUCTO", producto.Id_productos);
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
    }
}
