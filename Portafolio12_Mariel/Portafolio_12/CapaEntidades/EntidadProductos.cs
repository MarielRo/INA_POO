using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    class EntidadProductos
    {
        #region Atributos
        private string id_productos;
        private string descripcion;
        private decimal precio_compra;
        private decimal precio_venta;
        private int gravado;
        #endregion

        #region Propiedades
        public string Id_productos { get => id_productos; set => id_productos = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio_compra { get => precio_compra; set => precio_compra = value; }
        public decimal Precio_venta { get => precio_venta; set => precio_venta = value; }
        public int Gravado { get => gravado; set => gravado = value; }
        #endregion

        #region Constructores
        public EntidadProductos()
        {
           this.id_productos = string.Empty;
            this.descripcion = string.Empty;
            this.precio_compra = 0;
            this.precio_venta = 0;
            this.gravado = 0;
        }

        public EntidadProductos(string id_productos,string descripcion,decimal precio_compra,decimal precio_venta,int gravado)
        {
            this.id_productos = id_productos;
            this.descripcion = descripcion;
            this.precio_compra = precio_compra;
            this.precio_venta = precio_venta;
            this.gravado = gravado;
        }
        #endregion
    }
}
