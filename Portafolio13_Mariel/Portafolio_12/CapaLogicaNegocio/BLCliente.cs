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
    }
}
