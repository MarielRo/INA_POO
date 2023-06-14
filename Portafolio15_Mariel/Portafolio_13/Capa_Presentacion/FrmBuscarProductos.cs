using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaEntidades;
using CapaLogicaNegocio;

namespace Capa_Presentacion
{
    public partial class FrmBuscarProductos : Form
    {

        // crear evento handler para enviar valores al formulario FrmProductos
        public event EventHandler Aceptar;

        // variable global para accederla de todos los metoso de la clase 
        int vgn_id_producto;

        public FrmBuscarProductos()
        {
            InitializeComponent();
        }


        private void cargarListaDataSet(string condicion = "", string orden = "")
        {
            BLProductos logica = new BLProductos(Configuracion.getConnectionString);
            DataSet DSProductos;
            try
            {
                DSProductos = logica.ListarProductos(condicion, orden);
                dgvProductos.DataSource = DSProductos;
                dgvProductos.DataMember = DSProductos.Tables["Productos"].TableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            try
            {
                cargarListaDataSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtdescripcion.Text))
                {
                    condicion = string.Format("Descripcion like'%{0}%'", txtdescripcion.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Debe escribir parte de la descripcion a buscar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtdescripcion.Focus();
                }

                cargarListaDataSet(condicion);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Seleccionar()
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                vgn_id_producto = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
                // le manda id al evento Aceptar que esta en FrmClientes
                Aceptar(vgn_id_producto , null);
                Close();
            }
        }// fin seleccionar

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Aceptar(-1, null);
            Close();
        }
    }
}
