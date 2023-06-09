using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System;
using System.Linq;
using System.Threading.Tasks;
using CapaEntidades;
using CapaLogicaNegocio;

namespace Capa_Presentacion
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        // generar entidad cliente para luego poder guardar los clientes
        public EntidadCliente GenerarEntidadCliente()
        {
            EntidadCliente cliente = new EntidadCliente();
            cliente.Nombre = txtNombre.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Direccion = txtDireccion.Text;

            return cliente;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            EntidadCliente cliente; //= new EntidadCliente();
            BLCliente logica = new BLCliente(Configuracion.getConnectionString); // llama al construcctor,recibe parametros, llamar meytodo get conexion string, asigna los parametor s BLCliente
            int resultado;

            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) | string.IsNullOrEmpty(txtTelefono.Text)
                  | string.IsNullOrEmpty(txtDireccion.Text))
                {
                    MessageBox.Show("Faltan datos. Favor complete los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cliente = GenerarEntidadCliente();
                    resultado = logica.Insertar(cliente);
                    
                    MessageBox.Show("Operación realizada con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Limpiar()
        {
     
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtNombre.Focus(); //el cursor se posicionará automáticamente dentro del cuadro de texto txtNombre
        }
    }
}
