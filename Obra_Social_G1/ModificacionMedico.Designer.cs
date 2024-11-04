namespace Obra_Social_G1
{
    partial class ModificacionMedico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificacionMedico));
            this.pnlSeleccion = new System.Windows.Forms.Panel();
            this.btnCancelarCl = new System.Windows.Forms.Button();
            this.btnModificarCl = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.txtBuscarNA = new System.Windows.Forms.TextBox();
            this.btnBuscarNA = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvListaMedicos = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmailMed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSeleccion.SuspendLayout();
            this.pnlBuscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMedicos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSeleccion
            // 
            this.pnlSeleccion.Controls.Add(this.comboBox1);
            this.pnlSeleccion.Controls.Add(this.label11);
            this.pnlSeleccion.Controls.Add(this.txtTelefono);
            this.pnlSeleccion.Controls.Add(this.txtEmailMed);
            this.pnlSeleccion.Controls.Add(this.label6);
            this.pnlSeleccion.Controls.Add(this.txtNombre);
            this.pnlSeleccion.Controls.Add(this.label1);
            this.pnlSeleccion.Controls.Add(this.label2);
            this.pnlSeleccion.Controls.Add(this.txtApellido);
            this.pnlSeleccion.Controls.Add(this.label4);
            this.pnlSeleccion.Controls.Add(this.txtNM);
            this.pnlSeleccion.Controls.Add(this.label3);
            this.pnlSeleccion.Controls.Add(this.btnCancelarCl);
            this.pnlSeleccion.Controls.Add(this.btnModificarCl);
            this.pnlSeleccion.Location = new System.Drawing.Point(8, 114);
            this.pnlSeleccion.Name = "pnlSeleccion";
            this.pnlSeleccion.Size = new System.Drawing.Size(276, 242);
            this.pnlSeleccion.TabIndex = 44;
            // 
            // btnCancelarCl
            // 
            this.btnCancelarCl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelarCl.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarCl.ForeColor = System.Drawing.Color.Lavender;
            this.btnCancelarCl.Location = new System.Drawing.Point(4, 195);
            this.btnCancelarCl.Name = "btnCancelarCl";
            this.btnCancelarCl.Size = new System.Drawing.Size(108, 37);
            this.btnCancelarCl.TabIndex = 10;
            this.btnCancelarCl.Text = "CANCELAR";
            this.btnCancelarCl.UseVisualStyleBackColor = false;
            // 
            // btnModificarCl
            // 
            this.btnModificarCl.BackColor = System.Drawing.Color.DarkGreen;
            this.btnModificarCl.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarCl.ForeColor = System.Drawing.Color.Lavender;
            this.btnModificarCl.Location = new System.Drawing.Point(114, 195);
            this.btnModificarCl.Name = "btnModificarCl";
            this.btnModificarCl.Size = new System.Drawing.Size(147, 37);
            this.btnModificarCl.TabIndex = 9;
            this.btnModificarCl.Text = "MODIFICAR";
            this.btnModificarCl.UseVisualStyleBackColor = false;
            this.btnModificarCl.Click += new System.EventHandler(this.btnModificarCl_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(9, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 17);
            this.label9.TabIndex = 43;
            this.label9.Text = "Clínica seleccionada";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(289, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 42;
            this.label8.Text = "Resultados";
            // 
            // pnlBuscador
            // 
            this.pnlBuscador.Controls.Add(this.txtBuscarNA);
            this.pnlBuscador.Controls.Add(this.btnBuscarNA);
            this.pnlBuscador.Controls.Add(this.label7);
            this.pnlBuscador.Location = new System.Drawing.Point(288, 10);
            this.pnlBuscador.Name = "pnlBuscador";
            this.pnlBuscador.Size = new System.Drawing.Size(488, 78);
            this.pnlBuscador.TabIndex = 41;
            // 
            // txtBuscarNA
            // 
            this.txtBuscarNA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarNA.Location = new System.Drawing.Point(9, 38);
            this.txtBuscarNA.Name = "txtBuscarNA";
            this.txtBuscarNA.Size = new System.Drawing.Size(365, 26);
            this.txtBuscarNA.TabIndex = 1;
            // 
            // btnBuscarNA
            // 
            this.btnBuscarNA.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnBuscarNA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarNA.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarNA.Location = new System.Drawing.Point(377, 36);
            this.btnBuscarNA.Name = "btnBuscarNA";
            this.btnBuscarNA.Size = new System.Drawing.Size(103, 29);
            this.btnBuscarNA.TabIndex = 2;
            this.btnBuscarNA.Text = "Buscar";
            this.btnBuscarNA.UseVisualStyleBackColor = false;
            this.btnBuscarNA.Click += new System.EventHandler(this.btnBuscarNA_Click);
            // 
            // label7
            // 
            this.label7.AllowDrop = true;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(11, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 21);
            this.label7.TabIndex = 35;
            this.label7.Text = "Buscar nombre o apellido:";
            // 
            // dgvListaMedicos
            // 
            this.dgvListaMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaMedicos.Location = new System.Drawing.Point(288, 114);
            this.dgvListaMedicos.Name = "dgvListaMedicos";
            this.dgvListaMedicos.Size = new System.Drawing.Size(488, 242);
            this.dgvListaMedicos.TabIndex = 40;
            this.dgvListaMedicos.SelectionChanged += new System.EventHandler(this.dgvListaMedicos_SelectionChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Medicina General",
            "Odontología",
            "Pediatría",
            "Oftalmología",
            "Ginecología",
            "Dermatología",
            "Medicina Física y Rehabilitación"});
            this.comboBox1.Location = new System.Drawing.Point(128, 91);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 28);
            this.comboBox1.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(7, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 21);
            this.label11.TabIndex = 26;
            this.label11.Text = "Teléfono            ";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(128, 153);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(131, 26);
            this.txtTelefono.TabIndex = 8;
            // 
            // txtEmailMed
            // 
            this.txtEmailMed.Enabled = false;
            this.txtEmailMed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailMed.Location = new System.Drawing.Point(128, 3);
            this.txtEmailMed.Name = "txtEmailMed";
            this.txtEmailMed.Size = new System.Drawing.Size(131, 26);
            this.txtEmailMed.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(7, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 21);
            this.label6.TabIndex = 25;
            this.label6.Text = "Especialidad     ";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(128, 33);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(131, 26);
            this.txtNombre.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "Email                 ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nombre            ";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(128, 63);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(131, 26);
            this.txtApellido.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(7, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 21);
            this.label4.TabIndex = 24;
            this.label4.Text = "N° de matrícula";
            // 
            // txtNM
            // 
            this.txtNM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNM.Location = new System.Drawing.Point(128, 123);
            this.txtNM.Name = "txtNM";
            this.txtNM.Size = new System.Drawing.Size(131, 26);
            this.txtNM.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(7, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 21);
            this.label3.TabIndex = 23;
            this.label3.Text = "Apellido            ";
            // 
            // ModificacionMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 560);
            this.Controls.Add(this.pnlSeleccion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pnlBuscador);
            this.Controls.Add(this.dgvListaMedicos);
            this.Name = "ModificacionMedico";
            this.Text = "Modificar médico";
            this.Load += new System.EventHandler(this.ModificacionMedico_Load);
            this.pnlSeleccion.ResumeLayout(false);
            this.pnlSeleccion.PerformLayout();
            this.pnlBuscador.ResumeLayout(false);
            this.pnlBuscador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMedicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlSeleccion;
        private System.Windows.Forms.Button btnCancelarCl;
        private System.Windows.Forms.Button btnModificarCl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlBuscador;
        private System.Windows.Forms.DataGridView dgvListaMedicos;
        private System.Windows.Forms.TextBox txtBuscarNA;
        private System.Windows.Forms.Button btnBuscarNA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmailMed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNM;
        private System.Windows.Forms.Label label3;
    }
}