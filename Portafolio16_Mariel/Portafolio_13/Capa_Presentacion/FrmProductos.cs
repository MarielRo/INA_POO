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
        EntidadProductos productoRegistrado;
        public FrmProductos()
        {
            InitializeComponent();
        }

        // generar entidad cliente para luego poder guardar los clientes
        public EntidadProductos GenerarEntidadProducto() 
        {
            EntidadProductos producto;

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                producto = productoRegistrado;
            }
            else 
            {
                producto = new EntidadProductos();
            }
            producto.Descripcion = txtdescripcion.Text;
            producto.Precio_compra = txtCompra.Text;
            producto.Precio_venta = txtVenta.Text;

            return producto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadProductos producto; 
            BLProductos logica = new BLProductos(Configuracion.getConnectionString); // llama al construcctor,recibe parametros, llamar meytodo get conexion string, asigna los parametor s BLCliente
            int resultado;

            try
            {
                if (!string.IsNullOrEmpty(txtdescripcion.Text) && !string.IsNullOrEmpty(txtCompra.Text) 
                    && !string.IsNullOrEmpty(txtVenta.Text))
                {
                    producto = GenerarEntidadProducto();
                    if (!producto.Existe)
                    {
                        resultado = logica.Insertar(producto);
                    }
                    else
                    {
                        resultado = logica.Modificar(producto);
                    }
                    if (resultado > 0)
                    {
                        Limpiar();
                        MessageBox.Show("Operación realizada con éxito", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarListaDataSet();
                    }
                    else 
                    {
                        MessageBox.Show("No se realizaron los cambios", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {           
                    MessageBox.Show("Los datos son obligatorios", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtVenta.Text = string.Empty;
            txtCompra.Text = string.Empty;
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
                    txtVenta.Text = producto.Precio_venta;
                    txtVenta.Text = producto.Precio_venta;

                    productoRegistrado = producto;
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

        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                // se recupero el ID
                id = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
                // ya con el id recuperado se puede llamar a la funcion que carga el cliente
                // desde la base de datos del form
                CargarProducto(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//DoubleClick




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EntidadProductos producto;
            int resultado;
            BLProductos logica = new BLProductos(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    // busca primero el producto antes de borrarlo prara ver si existe
                    producto = logica.ObtenerProducto(int.Parse(txtCodigo.Text)); // metodo obtener cliente
                    if (producto != null)
                    {

                        resultado = logica.EliminarProducto(producto);
                        MessageBox.Show(logica.Mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        cargarListaDataSet();
                    }
                    else
                    {
                        MessageBox.Show("El Producto no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Limpiar();
                        cargarListaDataSet();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un producto antes de eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}// fin de class


