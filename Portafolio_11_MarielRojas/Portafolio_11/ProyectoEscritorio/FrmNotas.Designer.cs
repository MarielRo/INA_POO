
namespace ProyectoEscritorio
{
    partial class FrmNotas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotas));
            this.grpRegistroNotas = new System.Windows.Forms.GroupBox();
            this.lblResultadoProm = new System.Windows.Forms.Label();
            this.lstNotasIngresadas = new System.Windows.Forms.ListBox();
            this.btnResultado = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminarSelect = new System.Windows.Forms.Button();
            this.tnAgregar = new System.Windows.Forms.Button();
            this.txtNotaSeleccionada = new System.Windows.Forms.TextBox();
            this.txtNotaDigitada = new System.Windows.Forms.TextBox();
            this.lblNotaSelect = new System.Windows.Forms.Label();
            this.lblDigiteNota = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.grpRegistroNotas.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRegistroNotas
            // 
            this.grpRegistroNotas.Controls.Add(this.lblResultadoProm);
            this.grpRegistroNotas.Controls.Add(this.lstNotasIngresadas);
            this.grpRegistroNotas.Controls.Add(this.btnResultado);
            this.grpRegistroNotas.Controls.Add(this.btnLimpiar);
            this.grpRegistroNotas.Controls.Add(this.btnEliminarSelect);
            this.grpRegistroNotas.Controls.Add(this.tnAgregar);
            this.grpRegistroNotas.Controls.Add(this.txtNotaSeleccionada);
            this.grpRegistroNotas.Controls.Add(this.txtNotaDigitada);
            this.grpRegistroNotas.Controls.Add(this.lblNotaSelect);
            this.grpRegistroNotas.Controls.Add(this.lblDigiteNota);
            this.grpRegistroNotas.Location = new System.Drawing.Point(15, 15);
            this.grpRegistroNotas.Name = "grpRegistroNotas";
            this.grpRegistroNotas.Size = new System.Drawing.Size(600, 390);
            this.grpRegistroNotas.TabIndex = 1;
            this.grpRegistroNotas.TabStop = false;
            this.grpRegistroNotas.Text = "Registro de Notas";
            // 
            // lblResultadoProm
            // 
            this.lblResultadoProm.BackColor = System.Drawing.SystemColors.Info;
            this.lblResultadoProm.Location = new System.Drawing.Point(6, 300);
            this.lblResultadoProm.Name = "lblResultadoProm";
            this.lblResultadoProm.Size = new System.Drawing.Size(343, 63);
            this.lblResultadoProm.TabIndex = 8;
            // 
            // lstNotasIngresadas
            // 
            this.lstNotasIngresadas.FormattingEnabled = true;
            this.lstNotasIngresadas.ItemHeight = 20;
            this.lstNotasIngresadas.Location = new System.Drawing.Point(374, 39);
            this.lstNotasIngresadas.Name = "lstNotasIngresadas";
            this.lstNotasIngresadas.Size = new System.Drawing.Size(209, 324);
            this.lstNotasIngresadas.TabIndex = 9;
            this.lstNotasIngresadas.SelectedIndexChanged += new System.EventHandler(this.lstNotasIngresadas_SelectedIndexChanged);
            // 
            // btnResultado
            // 
            this.btnResultado.Location = new System.Drawing.Point(206, 244);
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.Size = new System.Drawing.Size(143, 29);
            this.btnResultado.TabIndex = 8;
            this.btnResultado.Text = "Ver Resultado";
            this.btnResultado.UseVisualStyleBackColor = true;
            this.btnResultado.Click += new System.EventHandler(this.btnResultado_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(6, 177);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(232, 29);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar Lista Notas";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminarSelect
            // 
            this.btnEliminarSelect.Location = new System.Drawing.Point(6, 142);
            this.btnEliminarSelect.Name = "btnEliminarSelect";
            this.btnEliminarSelect.Size = new System.Drawing.Size(232, 29);
            this.btnEliminarSelect.TabIndex = 5;
            this.btnEliminarSelect.Text = "Eliminar Seleccionado";
            this.btnEliminarSelect.UseVisualStyleBackColor = true;
            this.btnEliminarSelect.Click += new System.EventHandler(this.btnEliminarSelect_Click);
            // 
            // tnAgregar
            // 
            this.tnAgregar.Location = new System.Drawing.Point(255, 39);
            this.tnAgregar.Name = "tnAgregar";
            this.tnAgregar.Size = new System.Drawing.Size(94, 29);
            this.tnAgregar.TabIndex = 4;
            this.tnAgregar.Text = "Agregar";
            this.tnAgregar.UseVisualStyleBackColor = true;
            this.tnAgregar.Click += new System.EventHandler(this.tnAgregar_Click);
            // 
            // txtNotaSeleccionada
            // 
            this.txtNotaSeleccionada.Enabled = false;
            this.txtNotaSeleccionada.Location = new System.Drawing.Point(206, 99);
            this.txtNotaSeleccionada.Name = "txtNotaSeleccionada";
            this.txtNotaSeleccionada.Size = new System.Drawing.Size(119, 28);
            this.txtNotaSeleccionada.TabIndex = 3;
            // 
            // txtNotaDigitada
            // 
            this.txtNotaDigitada.Location = new System.Drawing.Point(153, 39);
            this.txtNotaDigitada.Name = "txtNotaDigitada";
            this.txtNotaDigitada.Size = new System.Drawing.Size(85, 28);
            this.txtNotaDigitada.TabIndex = 2;
            // 
            // lblNotaSelect
            // 
            this.lblNotaSelect.AutoSize = true;
            this.lblNotaSelect.Location = new System.Drawing.Point(6, 107);
            this.lblNotaSelect.Name = "lblNotaSelect";
            this.lblNotaSelect.Size = new System.Drawing.Size(167, 20);
            this.lblNotaSelect.TabIndex = 1;
            this.lblNotaSelect.Text = "Nota Seleccionada";
            // 
            // lblDigiteNota
            // 
            this.lblDigiteNota.AutoSize = true;
            this.lblDigiteNota.Location = new System.Drawing.Point(6, 39);
            this.lblDigiteNota.Name = "lblDigiteNota";
            this.lblDigiteNota.Size = new System.Drawing.Size(141, 20);
            this.lblDigiteNota.TabIndex = 0;
            this.lblDigiteNota.Text = "Digite la Nota :";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(511, 429);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(104, 32);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 473);
            this.Controls.Add(this.grpRegistroNotas);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Location = new System.Drawing.Point(20, 10);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNotas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.grpRegistroNotas.ResumeLayout(false);
            this.grpRegistroNotas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRegistroNotas;
        private System.Windows.Forms.Label lblNotaSelect;
        private System.Windows.Forms.Label lblDigiteNota;
        private System.Windows.Forms.Label lblResultadoProm;
        private System.Windows.Forms.ListBox lstNotasIngresadas;
        private System.Windows.Forms.Button btnResultado;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminarSelect;
        private System.Windows.Forms.Button tnAgregar;
        private System.Windows.Forms.TextBox txtNotaSeleccionada;
        private System.Windows.Forms.TextBox txtNotaDigitada;
        private System.Windows.Forms.Button btnSalir;
    }
}

