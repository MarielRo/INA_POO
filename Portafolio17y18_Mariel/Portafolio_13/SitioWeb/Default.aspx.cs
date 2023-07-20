using System;
using CapaLogicaNegocio;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;

namespace SitioWeb
{
    public partial class Default : System.Web.UI.Page
    {
        string mensajeScript = "";
        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            //carga el datagridview con el dataset
            BLCliente logica = new BLCliente(clsConfiguracion.getConnectionString);
            DataSet DSClientes;

            try
            {
                DSClientes = logica.ListarClientes(condicion, orden);
                grdLista.DataSource = DSClientes;
                grdLista.DataMember = DSClientes.Tables[0].TableName;
                grdLista.DataBind();// necesario para que se vean los dattos
                //en la tabla con nombre Clientes del dataset
            }
            catch (Exception)
            {
                throw;
            }
        }// fin CargarListaDataSet
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    CargarListaDataSet();
                    cargarListaDataSetProductos();
                }
            }
            catch (Exception ex)
            {
                //throw
               mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        //PRODUCTOSS
        private void cargarListaDataSetProductos(string condicion = "", string orden = "")
        {
            BLProductos logica = new BLProductos(clsConfiguracion.getConnectionString);
            DataSet DSProductos;
            try
            {
                DSProductos = logica.ListarProductos(condicion, orden);
                grdListaProdu.DataSource = DSProductos;
                grdListaProdu.DataMember = DSProductos.Tables[0].TableName;
                grdListaProdu.DataBind();
            }
            catch (Exception)
            {
                throw;
               // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void grdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdLista.PageIndex = e.NewPageIndex;
            CargarListaDataSet();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = string.Format("NOMBRE LIKE '%{0}%' ", txtNombre.Text);
                CargarListaDataSet(condicion);
            }

            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnBuscarProdu_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = string.Format("DESCRIPCION LIKE '%{0}%' ", txtdescripcion.Text);
                CargarListaDataSet(condicion);
            }

            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            BLCliente logica = new BLCliente(clsConfiguracion.getConnectionString);
            EntidadCliente cliente;

            try
            {
                cliente = logica.ObtenerCliente(id);
                if (cliente.Existe)
                {
                    if (logica.EliminarConSP(cliente) > 0)
                    {
                        mensajeScript = string.Format("javascript:mostrarMensaje('Cliente eliminado con exito')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        CargarListaDataSet();
                        txtNombre.Text = "";
                    }
                }
                else //El cliente existe pero tiene facturasa pendientes
                {
                    mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", logica.Mensaje);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                }
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void lnkModificarProdu_Command(object sender, CommandEventArgs e)
        {
            Session["id_del_producto"] = e.CommandArgument.ToString();

            //redireccionar al formulario de frmClientes

            Response.Redirect("FrmProductos.aspx");
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            Session["id_del_cliente"] = e.CommandArgument.ToString();

            //redireccionar al formulario de frmClientes

            Response.Redirect("FrmClientes.aspx");
        }

        protected void lnkEliminarProdu_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            BLProductos logica = new BLProductos(clsConfiguracion.getConnectionString);
            EntidadProductos producto;

            try
            {
                producto = logica.ObtenerProducto(id);
                if (producto.Existe)
                {
                    if (logica.EliminarProducto(producto) > 0)
                    {
                        mensajeScript = string.Format("javascript:mostrarMensaje('Producto eliminado con exito')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        CargarListaDataSet();
                        txtNombre.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Session.Remove("id_del_cliente");
            Response.Redirect("FrmClientes.aspx");
        }

        protected void btnAgregarProdu_Click(object sender, EventArgs e)
        {
            Session.Remove("id_del_cliente");
            Response.Redirect("FrmProductos.aspx");
        }
    }
}