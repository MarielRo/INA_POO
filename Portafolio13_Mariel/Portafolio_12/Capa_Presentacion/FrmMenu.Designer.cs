
namespace Capa_Presentacion
{
    partial class FrmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.encabezadoFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalleFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClientes,
            this.mnuProductos,
            this.mnuFacturacion});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(682, 28);
            this.mnuPrincipal.TabIndex = 1;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // mnuClientes
            // 
            this.mnuClientes.Name = "mnuClientes";
            this.mnuClientes.Size = new System.Drawing.Size(75, 24);
            this.mnuClientes.Text = "Clientes";
            this.mnuClientes.Click += new System.EventHandler(this.mnuClientes_Click);
            // 
            // mnuProductos
            // 
            this.mnuProductos.Name = "mnuProductos";
            this.mnuProductos.Size = new System.Drawing.Size(89, 24);
            this.mnuProductos.Text = "Productos";
            this.mnuProductos.Click += new System.EventHandler(this.mnuProductos_Click);
            // 
            // mnuFacturacion
            // 
            this.mnuFacturacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encabezadoFacturaToolStripMenuItem,
            this.detalleFacturaToolStripMenuItem});
            this.mnuFacturacion.Name = "mnuFacturacion";
            this.mnuFacturacion.Size = new System.Drawing.Size(98, 24);
            this.mnuFacturacion.Text = "Facturación";
            this.mnuFacturacion.Click += new System.EventHandler(this.mnuFacturacion_Click);
            // 
            // encabezadoFacturaToolStripMenuItem
            // 
            this.encabezadoFacturaToolStripMenuItem.Name = "encabezadoFacturaToolStripMenuItem";
            this.encabezadoFacturaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.encabezadoFacturaToolStripMenuItem.Text = "Encabezado Factura";
            // 
            // detalleFacturaToolStripMenuItem
            // 
            this.detalleFacturaToolStripMenuItem.Name = "detalleFacturaToolStripMenuItem";
            this.detalleFacturaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.detalleFacturaToolStripMenuItem.Text = "Detalle Factura";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 553);
            this.Controls.Add(this.mnuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuPrincipal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuClientes;
        private System.Windows.Forms.ToolStripMenuItem mnuProductos;
        private System.Windows.Forms.ToolStripMenuItem mnuFacturacion;
        private System.Windows.Forms.ToolStripMenuItem encabezadoFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detalleFacturaToolStripMenuItem;
    }
}

