using CapaEntidades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitioWeb
{
    public partial class FrmProductos : System.Web.UI.Page
    {
        string mensajeScript = "";
        public void Limpiar()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtGravado.Text = "";

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadProductos producto;
            BLProductos logica = new BLProductos(clsConfiguracion.getConnectionString);
            int identificacion;

            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["id_del_cliente"] != null)
                    {
                        identificacion = int.Parse(Session["id_del_cliente"].ToString());
                        producto = logica.ObtenerProducto(identificacion);
                        if (producto.Existe)
                        {
                            txtId.Text = producto.Id_productos.ToString(); 
                            txtDescripcion.Text = producto.Descripcion;
                            txtPrecioCompra.Text = producto.Precio_compra;
                            txtPrecioVenta.Text = producto.Precio_venta;
                            txtGravado.Text = producto.Gravado;

                            lblid.Visible = true;
                            

                        }
                        else
                        {
                            mensajeScript = string.Format("javascript:mostrarMensaje('Producto no encontrado')");
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

        private EntidadProductos GenerarEntidadProducto()
        {
            EntidadProductos producto = new EntidadProductos();


            if (Session["id_del_producto"] != null)
            {
                producto.Id_productos = int.Parse(Session["id_del_producto"].ToString());
                producto.Existe = true;

            }
            else
            {
                producto.Id_productos = -1;
                producto.Existe = false;
            }

            producto.Descripcion = txtDescripcion.Text;
            producto.Precio_compra = txtPrecioCompra.Text;
            producto.Precio_venta = txtPrecioVenta.Text;
            producto.Gravado = txtGravado.Text;

            return producto;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadProductos producto;
            BLProductos logica = new BLProductos(clsConfiguracion.getConnectionString);
            int resultado;

            try
            {
                producto = GenerarEntidadProducto();
                if (producto.Existe)
                {
                    resultado = logica.Modificar(producto);
                }
                else
                {

                    if (!string.IsNullOrEmpty(txtDescripcion.Text))
                    {
                        resultado = logica.Insertar(producto);
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