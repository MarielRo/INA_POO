using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio22_Mariel
{
    public partial class FrmProductos : System.Web.UI.Page
    {

        private void CargarGridTodosLosProductos()
        {
            ViewState["Lista"] = 0;
            BD_TIENDADataContext dataContext = new BD_TIENDADataContext();
            var consulta = from productos in dataContext.PRODUCTOS
                           select productos;
            grdProductos.DataSource = consulta;
            grdProductos.DataBind();
        }

        private void cargarProductos()
        {
            BD_TIENDADataContext dataContext = new BD_TIENDADataContext();
            var consulta = from productos in dataContext.PRODUCTOS
                           select new
                           {
                               productos.ID_PRODUCTO ,
                               productos.DESCRIPCION,
                               productos.PRECIOCOMPRA,
                               productos.PRECIOVENTA,
                               productos.GRAVADO
                           };
            cboProductos.DataValueField = "DESCRIPCION";
            cboProductos.DataSource = consulta;
            cboProductos.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void CargarProductosFacturas()
        {
            ViewState["Lista"] = 1;

            BD_TIENDADataContext dataContext = new BD_TIENDADataContext();
            var consulta = from producto in dataContext.PRODUCTOS
                           join factura in dataContext.ENCABEZADO_FACTURA
                           on producto.ID_PRODUCTO equals factura.ID_FACTURA
                           select new
                           {
                               producto.ID_PRODUCTO,
                               producto.DESCRIPCION,
                               producto.PRECIOCOMPRA,
                               producto.PRECIOVENTA,
                               producto.GRAVADO,
                               factura.FECHA,
                               factura.SUBTOTAL,
                               factura.IMPUESTO,
                               factura.MONTODESCUENTO

                           };

            cboProductos.DataSource = consulta;
            cboProductos.DataBind();

        }




        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            CargarGridTodosLosProductos();
        }

        protected void btnProductosFacturas_Click(object sender, EventArgs e)
        {
            CargarProductosFacturas();
        }

        protected void grdProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductos.PageIndex = e.NewPageIndex;

            if (Convert.ToInt32(ViewState["Lista"]) == 0)
            {
                CargarGridTodosLosProductos();
            }
            else
            {
                CargarProductosFacturas();
            }
        }
    }
}