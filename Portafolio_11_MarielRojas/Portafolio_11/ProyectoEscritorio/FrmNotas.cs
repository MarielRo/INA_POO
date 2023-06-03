using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProyectoEscritorio
{
    public partial class FrmNotas : Form
    {
        public FrmNotas()
        {
            InitializeComponent();
        }
        // 15.	Comportamiento del formulario de notas: 
        private void LimpiarEtiquetaPromedio()
        {
            lblResultadoProm.ForeColor = Color.LightYellow; // color amarillo
            lblResultadoProm.Text = string.Empty; // Limpiar el texto de la etiqueta del promedio
        }

        //ClsPromedio Promedio = new ClsPromedio();


        private void btnResultado_Click(object sender, EventArgs e)
        {
            //Variables
            decimal sumaTotalNotas;
           // double promedio;
            //string condicion;

           

            if (lstNotasIngresadas != null)
            {
                sumaTotalNotas = CalcularSumaTotal();
                //promedio = Promedio.CalcularPromedio(sumaTotalNotas, lstNotasIngresadas);
                //condicion = Promedio.CalcularCondicion(promedio);
            }
            else
            {
                MessageBox.Show("No hay datos para calcular el promedio",
                    "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public decimal CalcularSumaTotal() // lista texbox, el text es donde el usuario digita la nota
        {
            decimal totalSuma = 0;
            if (string.IsNullOrEmpty(lblResultadoProm.Text))
            {
                MessageBox.Show("La lista se encuentra vacía", "Datos Incompletos", MessageBoxButtons.OK);
                return totalSuma = 0;
            }
            else
            {
                foreach (decimal nota in lstNotasIngresadas.Items) // se recorren la lista del
                {
                    totalSuma = totalSuma + nota;
                }

                return totalSuma;
            }

        }

        //Debe configurarse el cuadro de texto de la nota para que el máximo de
        //caracteres que admita sean tres.
        public void MaximoCaracteres(TextBox notaIngresada)
        {
            double n = 0;
            double.TryParse(notaIngresada.Text, out n);
            if (n > 100)
            {
                MessageBox.Show("La nota no puede ser mayor a 100", "Nota fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Error);
                notaIngresada.Text = string.Empty;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Limpiar()
        {
            txtNotaDigitada.Text = string.Empty;
        }

        public void ValidarEntrada(object sender, KeyPressEventArgs e)
        {
            // si es numerico o una tecla de retroceso, No Cancele el evento
            if (char.IsDigit(e.KeyChar) | e.KeyChar == 8 | e.KeyChar == 44)
            {
                e.Handled = false;
            }
            else
            {
                // Cancele el evento asociado
                e.Handled = true;
            }
        }

        private void tnAgregar_Click(object sender, EventArgs e)
        {
            string notaAgregada = txtNotaDigitada.Text;

            if (string.IsNullOrEmpty(txtNotaDigitada.Text) || (!decimal.TryParse(notaAgregada, out decimal nota))
                || (nota > 100))
            {
                MessageBox.Show("Datos Faltantes o invalidos",
                    "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                notaAgregada = txtNotaDigitada.Text;
                lstNotasIngresadas.Items.Add(notaAgregada);
                LimpiarEtiquetaPromedio(); // un llamado al procedimiento  que limpia el resultado del promedio
                Limpiar(); // procedimiento que limpia la nota digitada
                txtNotaDigitada.Focus();
            }
        }

        private void lstNotasIngresadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string notaSeleccionada = string.Empty; // nota que se selecciona en la lista

            if (lstNotasIngresadas.SelectedItem != null) // si la lista esta llena
            {
                 notaSeleccionada = lstNotasIngresadas.SelectedItem.ToString(); // la nota seleccionada se saca con selectedItem
                txtNotaSeleccionada.Text = notaSeleccionada; // la nota de texto se muestra en la caja de texto 
            }
        }

        //f 
        private void btnEliminarSelect_Click(object sender, EventArgs e)
        {
            string notaSeleccionada = string.Empty; // nota que se selecciona en la lista

            if (lstNotasIngresadas.SelectedItem != null)
            {          
                notaSeleccionada = lstNotasIngresadas.SelectedItem.ToString(); // la nota seleccionada se determina con selectedItem
                lstNotasIngresadas.Items.Remove(notaSeleccionada); // la nota seleccionada se elimina de la lista

                LimpiarEtiquetaPromedio(); // limpia los datos del promedio

                txtNotaSeleccionada.Text = string.Empty; // Limpiar el campo de texto de la nota seleccionada
            }
            else
            {
                MessageBox.Show("Debe seleccionar una nota de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarEtiquetaPromedio();
            lstNotasIngresadas.Items.Clear();
            txtNotaSeleccionada.Text = string.Empty;
            txtNotaDigitada.Text = string.Empty;
        }
    }
}
