using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    class EntidadDetalleFactura
    {

        #region Atributos
        private int id_factura;
        private string id_producto;
        private int cantidad;
        #endregion

        #region Atributos
        public int Id_factura { get => id_factura; set => id_factura = value; }
        public string Id_producto { get => id_producto; set => id_producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        #endregion

        #region Constructores 
        public EntidadDetalleFactura() 
        {
            this.id_factura = 0;
            this.id_producto = string.Empty;
            this.cantidad = 0;
        }

        public EntidadDetalleFactura(int id_factura,string id_producto,int cantidad)
        {
            this.id_factura = id_factura;
            this.id_producto = id_producto;
            this.cantidad = cantidad;
        }
        #endregion

    }
}
