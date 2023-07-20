using System;
using CapaLogicaNegocio;
using CapaEntidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitioWeb
{
    public partial class FrmClientes : System.Web.UI.Page
    {
        string mensajeScript = "";
        public void Limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadCliente cliente;
            BLCliente logica = new BLCliente(clsConfiguracion.getConnectionString);
            int identificacion;

            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["id_del_cliente"] != null)
                    {
                        identificacion = int.Parse(Session["id_del_cliente"].ToString());
                        cliente = logica.ObtenerCliente(identificacion);
                        if (cliente.Existe)
                        {
                            txtId.Text = cliente.Id_cliente.ToString();
                            txtNombre.Text = cliente.Nombre;
                            txtTelefono.Text = cliente.Telefono;
                            txtDireccion.Text = cliente.Direccion;

                            lblid.Visible = true;
                            txtDireccion.Visible = true;
                        }
                        else
                        {
                            mensajeScript = string.Format("javascript:mostrarMensaje('Cliente no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), " MensajeRetorno", mensajeScript, true);
                        }
                    }
                    else
                    {
                        Limpiar();
                        txtId.Text = "-1";
                        lblid.Visible = false;
                        txtId.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), " MensajeRetorno", mensajeScript, true);
                Response.Redirect("Default.aspx");
            }
        }

        private EntidadCliente GenerarEntidadCliente()
        {
            EntidadCliente cliente = new EntidadCliente();

            if (Session["id_del_cliente"] != null)
            {
                cliente.Id_cliente = int.Parse(Session["id_del_cliente"].ToString());
                cliente.Existe = true;

            }
            else
            {
                cliente.Id_cliente = -1;
                cliente.Existe = false;
            }

            cliente.Nombre = txtNombre.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Direccion = txtDireccion.Text;

            return cliente;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadCliente cliente;
            BLCliente logica = new BLCliente(clsConfiguracion.getConnectionString);
            int resultado;

            try
            {
                cliente = GenerarEntidadCliente();
                if (cliente.Existe)
                {
                    resultado = logica.Modificar(cliente);
                }
                else
                {

                    if (!string.IsNullOrEmpty(txtNombre.Text))
                    {
                        resultado = logica.Insertar(cliente);
                    }
                    else
                    {
                        mensajeScript = string.Format("javascript:mostrarMensaje('Debe agregar almenos el nombre del cliente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        resultado = -1;
                    }

                }

                if (resultado > 0)
                {

                    mensajeScript = string.Format("javascript:mostrarMensaje('Operacion realizada con exito')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    mensajeScript = string.Format("javascript:mostrarMensaje('No se pudo realizar operacion')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                }
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}