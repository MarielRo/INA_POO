using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    class EntidadFactura
    {


        #region  Atributos
        private int id_factura;
        private DateTime fecha;
        private int id_cliente;
        private decimal subtotal;
        private decimal impuesto;
        private decimal monto_descuento;
        #endregion

        #region  Propiedades
        public int Id_factura { get => id_factura; set => id_factura = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public decimal Impuesto { get => impuesto; set => impuesto = value; }
        public decimal Monto_descuento { get => monto_descuento; set => monto_descuento = value; }
        #endregion


        #region Constructores
        public EntidadFactura()
        {
            this.id_factura = 0;
            this.fecha = DateTime.Today;
            this.id_cliente = 0;
            this.subtotal = 0;
            this.impuesto = 0;
            this.monto_descuento = 0;
        }
        public EntidadFactura(int id_factura,DateTime fecha,int id_cliente,decimal subtotal, decimal impuesto,decimal monto_descuento)
        {
            this.id_factura = id_factura;
            this.fecha = fecha;
            this.id_cliente = id_cliente;
            this.subtotal = subtotal;
            this.impuesto = impuesto;
            this.monto_descuento = monto_descuento;
        }

        #endregion

    }
}
