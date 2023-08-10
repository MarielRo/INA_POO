using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Portafolio22_Mariel
{
    public partial class FrmClientes : System.Web.UI.Page
    {
        private void CargarGridTodosLosClientes()
        {
            ViewState["Lista"] = 0;
            BD_TIENDADataContext dataContext = new BD_TIENDADataContext();
            var consulta = from cliente in dataContext.CLIENTES
                           select cliente;
            grdClientes.DataSource = consulta;
            grdClientes.DataBind();

        }

        private void cargarNombres()
        {
            BD_TIENDADataContext dataContext = new BD_TIENDADataContext();
            var consulta = from cliente in dataContext.CLIENTES
                           select new
                           {
                               cliente.ID_CLIENTE,
                               cliente.NOMBRE,
                               cliente.TELEFONO
                           };
            cboClientes.DataValueField = "NOMBRE";
            cboClientes.DataSource = consulta;
            cboClientes.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarNombres();
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            CargarGridTodosLosClientes();
        }


        private void CargarClientesFacturas()
        {
            ViewState["Lista"] = 1;

            BD_TIENDADataContext dataContext = new BD_TIENDADataContext();
            var consulta = from cliente in dataContext.CLIENTES
                           join factura in dataContext.ENCABEZADO_FACTURA
                           on cliente.ID_CLIENTE equals factura.ID_CLIENTE
                           select new
                           {
                               cliente.NOMBRE,
                               cliente.TELEFONO,
                               factura.FECHA,
                               factura.SUBTOTAL,
                               factura.IMPUESTO,
                               factura.MONTODESCUENTO

                           };

            cboClientes.DataSource = consulta;
            cboClientes.DataBind();

        }


        protected void grdClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClientes.PageIndex = e.NewPageIndex;

            if (Convert.ToInt32(ViewState["Lista"]) == 0)
            {
                CargarGridTodosLosClientes();
            }
            else
            {
                CargarClientesFacturas();
            }
        }


        //protected void btnEliminar_Click(object sender, EventArgs e)
        //{
        //    int idCliente = Convert.ToInt32(cboClientes.SelectedValue);

        //    using (BD_TIENDADataContext vlo_DataContext = new BD_TIENDADataContext())
        //    {
        //        CLIENTES deleteCliente = vlo_DataContext.CLIENTES.FirstOrDefault(c => c.ID_CLIENTE.Equals(idCliente));

        //        if (deleteCliente != null)
        //        {
        //            vlo_DataContext.CLIENTES.DeleteOnSubmit(deleteCliente);
        //            vlo_DataContext.SubmitChanges();
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cliente eliminado satisfactoriamente.');", true);
        //        }
        //        else
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se encontró ningún cliente con el ID seleccionado.');", true);
        //        }
        //    }
        //}

        protected void btnClientesFacturas_Click(object sender, EventArgs e)
        {
            CargarClientesFacturas();
        }
    }
    
}




//public void Eliminar(string nombreCliete)
//{
//    int vln_idcliente;
//    string vlc_mensaje = "";
//    BD_TIENDADataContext vlo_DataContext = new BD_TIENDADataContext();
//    try
//    {
//        if (!string.IsNullOrEmpty(nombreCliete))
//        {
//            vln_idcliente = int.Parse(nombreCliete));
//vlo_DataContext.ELIMINAR(vlo_idcliente, ref vlc_mensaje);
//MessageBox.Show(vlc_mensaje);
//                }
//                else
//{
//    MessageBox.Show("Es indispensable que digite el nombre");
//}

//            }
//            catch (Exception ex)
//{
//    MessageBox.Show(ex.Message);
//}
//        }

//public void Eliminar()
//{
//    string nombreCliente = "";


//    BD_TIENDADataContext vlo_DataContext = new BD_TIENDADataContext();
//    try
//    {

//        if (CLIENTES.Cli)
//        {
//            var clienteAEliminar = vlo_DataContext.CLIENTES.FirstOrDefault(c => c.NOMBRE == nombreCliente);

//            if (clienteAEliminar != null)
//            {
//                vlo_DataContext.CLIENTES.DeleteOnSubmit(clienteAEliminar);
//                vlo_DataContext.SubmitChanges();
//                MessageBox.Show("Cliente eliminado correctamente.");
//            }
//            else
//            {
//                MessageBox.Show("No se encontró ningún cliente con ese nombre.");
//            }
//        }
//        else
//        {
//            MessageBox.Show("Es indispensable que ingrese el nombre del cliente.");
//        }

//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show(ex.Message);
//    }
//}