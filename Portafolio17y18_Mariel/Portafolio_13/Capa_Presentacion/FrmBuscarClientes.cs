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
    public partial class FrmBuscarClientes : Form
    {
        //private FrmClientes _frmClientes;
        public event EventHandler Aceptar; //Se crea la firma del evento EventHandler Aceptar

        // variable global para accederla de todos los metoso de la clase 
        int vgn_id_cliente;


        public FrmBuscarClientes()
        {
            InitializeComponent();
        }


        // se crea el método para cargar los datos que tienen la lista de clientes en el DataGridView 
        private void cargarListaArray(string condicion = "")
        {
            BLCliente logica = new BLCliente(Configuracion.getConnectionString);
            List<EntidadCliente> clientes;
            try
            {
                clientes = logica.ListarClientes(condicion);
                if (clientes.Count > 0)
                {
                    dgvListaClientes.DataSource = clientes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }// Fin cargar

        private void FrmBuscarClientes_Load(object sender, EventArgs e)
        {
            try
            {
                cargarListaArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // se carga de igual forma el dataGridView, haciendo el llamado al método CargarListaArray
        // , solo que en esta ocasión enviamos lo que el usuario desea buscar en la condición. 
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string condicion = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    condicion = string.Format("Nombre like'%{0}%'", txtNombre.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Debe escribir parte del nombre a buscar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                }

                cargarListaArray(condicion);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Seleccionar()
        {
            if (dgvListaClientes.SelectedRows.Count > 0)
            {
                vgn_id_cliente = (int)dgvListaClientes.SelectedRows[0].Cells[0].Value;
                // le manda id al evento Aceptar que esta en FrmClientes
                Aceptar(vgn_id_cliente, null);
                Close();
            }
        }// fin seleccionar

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void dgvListaClientes_DoubleClick(object sender, EventArgs e)
        {
            Seleccionar();
        }


        // se llama el método Aceptar con el parámetro -1, para indicar que no se ha seleccionado un cliente.
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Aceptar(-1, null);
            Close();
        }

        
    }
}
