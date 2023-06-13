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

        FrmBuscarProductos formularioBuscar;
        public FrmProductos()
        {
            InitializeComponent();
        }

        // generar entidad cliente para luego poder guardar los clientes
        public EntidadProductos GenerarEntidadProducto() 
        {
            EntidadProductos producto = new EntidadProductos();
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
                    producto = GenerarEntidadProducto(); // El producto se genera 
                    Limpiar();
                    resultado = logica.Insertar(producto); // se guarda en la base de datos

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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cargarListaDataSet(string condicion = "", string orden = "")
        {
            BLProductos logica = new BLProductos(Configuracion.getConnectionString);
            DataSet DSProductos;
            try
            {
                DSProductos = logica.ListarProdcutos(condicion, orden);
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
            formularioBuscar = new FrmBuscarProductos();
            formularioBuscar.Aceptar += new EventHandler(Aceptar);
            formularioBuscar.ShowDialog();
            //FrmBuscarClientes frm = new FrmBuscarClientes();
            //frm.Show();
        }

        // llamar al form FrmBuscarProductos


        private void Aceptar(object id, EventArgs e)
        {
            try
            {
                int idProducto = (int)id;
                if (idProducto != -1)
                {
                    CargarProducto(idProducto);
                }
                else
                {
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }// fin de aceptar

        private void CargarProducto(int id)
        {
            EntidadProductos producto = new EntidadProductos();
            BLProductos traerProducto = new BLProductos(Configuracion.getConnectionString);
            try
            {
                producto = traerProducto.ObtenerProducto(id);

                if (producto != null)
                {
                    txtCodigo.Text = producto.Id_productos.ToString();
                    txtdescripcion.Text = producto.Descripcion;
                    nudVenta.Value = producto.Precio_venta;
                    nudVenta.Value = producto.Precio_venta;
                }
                else
                {
                    MessageBox.Show("El cliente no se encuentra en la base de datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cargarListaDataSet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}// fin de class


