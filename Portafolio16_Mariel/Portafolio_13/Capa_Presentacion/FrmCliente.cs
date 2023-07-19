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
        FrmBuscarClientes formularioBuscar;
        EntidadCliente clienteRegistrado;
        public FrmCliente()
        {
            InitializeComponent();
        }

        // generar entidad cliente para luego poder guardar los clientes
        public EntidadCliente GenerarEntidadCliente()
        {
            EntidadCliente cliente;
            if (!string.IsNullOrEmpty(txtCliente.Text))
            {
                cliente = clienteRegistrado; // si el cliente existe , utiliza la entidad clienteregistrado
                                             //y le asigna los valores a la entidad cliente
            }
            else
            {
                cliente = new EntidadCliente();
            }
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
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtTelefono.Text)
                      && !string.IsNullOrEmpty(txtDireccion.Text))
                {
                    cliente = GenerarEntidadCliente();
                    if (!cliente.Existe)
                    {
                        resultado = logica.Insertar(cliente); // si no existe se inserta
                    }
                    else
                    {
                        resultado = logica.Modificar(cliente); // si existe se modifica
                    }

                    if (resultado > 0)
                    {
                        Limpiar();
                        MessageBox.Show("Operación realizada con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarListaArray();
                    }
                    else
                    {

                        MessageBox.Show("No se realizaron ccambios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Los datos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
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


        // se llama al metodo cargarListaArray
        private void FrmCliente_Load(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            formularioBuscar = new FrmBuscarClientes();
            formularioBuscar.Aceptar += new EventHandler(Aceptar);
            formularioBuscar.ShowDialog();
        }

        


        //método Aceptar, este recibe un id_Cliente que viene de FrmBuscarCliente.
        //Si recibe -1 indica que el usuario no seleccionó nada (dio clic en Cancelar). 

        private void Aceptar(object id, EventArgs e)
        {
            try
            {
                int idCliente = (int)id;
                if (idCliente != -1)
                {
                    CargarCliente(idCliente);
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

        //un método que recibe el id_cliente y llama el método puente de la capa lógica
        //que recupera los datos del cliente de la bd, luego muestra los datos en el formulario.
        private void CargarCliente(int id)
        {
            EntidadCliente cliente = new EntidadCliente();
            BLCliente traerCliente = new BLCliente(Configuracion.getConnectionString);
            try
            {
                cliente = traerCliente.ObtenerCliente(id);

                if (cliente != null)
                {
                    txtCliente.Text = cliente.Id_cliente.ToString();
                    txtNombre.Text = cliente.Nombre;
                    txtTelefono.Text = cliente.Telefono;
                    txtDireccion.Text = cliente.Direccion;
                    // a la entidad cliente local se le asigna a la variable global
                    clienteRegistrado = cliente;
                }
                else
                {
                    MessageBox.Show("El cliente no se encuentra en la base de datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cargarListaArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cargar los datos seleccionados del datagrid a las cajas de texto
        private void dgvListaClientes_DoubleClick(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                // se recupero el ID
                id = (int)dgvListaClientes.SelectedRows[0].Cells[0].Value;
                // ya con el id recuperado se puede llamar a la funcion que carga el cliente
                // desde la base de datos del form
                CargarCliente(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }// grdLista_DoubleClick

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EntidadCliente cliente;
            int resultado;
            BLCliente logica = new BLCliente(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtCliente.Text))
                {
                    // busca primero el cljuee antes de borrarlo prara ver si existe
                    cliente = logica.ObtenerCliente(int.Parse(txtCliente.Text)); // metodo obtener cliente
                    if (cliente != null)
                    {
                        // si el cliente no es nulo puede borrarlo
                        //resultado = logica.EliminarConSP(cliente);


                        // eliminar sin procedimiento almacenado
                        resultado = logica.EliminarCliente(cliente); //  metodo eliminar cliente
                        MessageBox.Show("Eliminado sin SP", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        cargarListaArray();
                    }
                    else
                    {
                        MessageBox.Show("El cliente no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Limpiar();
                        cargarListaArray();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente antes de eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
