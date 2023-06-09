using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using CapaEntidades;
using CapaLogicaNegocio;

namespace Capa_Presentacion
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        // generar entidad cliente para luego poder guardar los clientes
        public EntidadProductos GenerarEntidadProducto() 
        {
            EntidadProductos producto = new EntidadProductos();
            producto.Id_productos = txtCodigo.Text;
            producto.Descripcion = txtdescripcion.Text;
            producto.Precio_compra = nudCompra.Value;
            producto.Precio_venta = nudVenta.Value;


            return producto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadProductos producto; //= new EntidadCliente();
            BLProductos logica = new BLProductos(Configuracion.getConnectionString); // llama al construcctor,recibe parametros, llamar meytodo get conexion string, asigna los parametor s BLCliente
            int resultado;

            try
            {
                if (string.IsNullOrEmpty(txtdescripcion.Text))
                {
                    MessageBox.Show("Faltan datos. Favor complete los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    producto = GenerarEntidadProducto();
                    Limpiar();
                    resultado = logica.Insertar(producto);

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
            txtCodigo.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
            nudVenta.Value = 0;
            nudCompra.Value = 0;
            txtdescripcion.Focus();
        }
    }
    
}
