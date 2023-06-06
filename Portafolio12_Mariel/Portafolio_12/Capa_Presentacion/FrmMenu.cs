using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void mnuClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();

            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuProductos_Click(object sender, EventArgs e)
        {
            FrmProductos frm = new FrmProductos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuFacturacion_Click(object sender, EventArgs e)
        {
            FrmFacturacion frm = new FrmFacturacion();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
