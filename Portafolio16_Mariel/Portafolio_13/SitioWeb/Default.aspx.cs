using System;
using CapaLogicaNegocio;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitioWeb
{
    public partial class Default : System.Web.UI.Page
    {

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
            catch (Exception)
            {
                //throw
               //ensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
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







    }
}