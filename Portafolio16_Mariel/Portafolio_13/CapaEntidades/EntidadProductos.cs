using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadProductos
    {
        #region Atributos
        private int id_productos;
        private string descripcion;
        private string precio_compra;
        private string precio_venta;
        private string gravado;
        private bool existe;
        #endregion

        #region Propiedades
        public int Id_productos { get => id_productos; set => id_productos = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Precio_compra { get => precio_compra; set => precio_compra = value; }
        public string Precio_venta { get => precio_venta; set => precio_venta = value; }
        public string Gravado { get => gravado; set => gravado = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion

        #region Constructores
        public EntidadProductos()
        {
           this.id_productos = 0;
            this.descripcion = string.Empty;
            this.precio_compra = string.Empty;
            this.precio_venta = string.Empty;
            this.gravado = string.Empty;
            this.existe = false;
        }

        public EntidadProductos(int id_productos,string descripcion, string precio_compra,string precio_venta,string gravado, bool existe)
        {
            this.id_productos = id_productos;
            this.descripcion = descripcion;
            this.precio_compra = precio_compra;
            this.precio_venta = precio_venta;
            this.gravado = gravado;
            this.existe = existe;
        }
        #endregion
    }
}
