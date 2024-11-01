namespace Obra_Social_G1
{
    partial class ModificacionClinica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificacionClinica));
            this.dgvListaClinicas = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBuscarRS = new System.Windows.Forms.TextBox();
            this.txtBuscarTP = new System.Windows.Forms.TextBox();
            this.btnBuscarGral = new System.Windows.Forms.Button();
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnModificarCl = new System.Windows.Forms.Button();
            this.btnCancelarCl = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelefonoCl = new System.Windows.Forms.TextBox();
            this.txtDireccionCl = new System.Windows.Forms.TextBox();
            this.txtRazonSocialCl = new System.Windows.Forms.TextBox();
            this.pnlSeleccion = new System.Windows.Forms.Panel();
            this.cbTipoClinica = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClinicas)).BeginInit();
            this.pnlBuscador.SuspendLayout();
            this.pnlSeleccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListaClinicas
            // 
            this.dgvListaClinicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaClinicas.Location = new System.Drawing.Point(284, 116);
            this.dgvListaClinicas.Name = "dgvListaClinicas";
            this.dgvListaClinicas.Size = new System.Drawing.Size(488, 242);
            this.dgvListaClinicas.TabIndex = 13;
            this.dgvListaClinicas.SelectionChanged += new System.EventHandler(this.dgvListaClinicas_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(5, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 21);
            this.label4.TabIndex = 32;
            this.label4.Text = "Buscar Razón Social  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(5, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 21);
            this.label5.TabIndex = 31;
            this.label5.Text = "Buscar Tipo de clínica";
            // 
            // txtBuscarRS
            // 
            this.txtBuscarRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarRS.Location = new System.Drawing.Point(169, 5);
            this.txtBuscarRS.Name = "txtBuscarRS";
            this.txtBuscarRS.Size = new System.Drawing.Size(202, 26);
            this.txtBuscarRS.TabIndex = 1;
            // 
            // txtBuscarTP
            // 
            this.txtBuscarTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarTP.Location = new System.Drawing.Point(169, 47);
            this.txtBuscarTP.Name = "txtBuscarTP";
            this.txtBuscarTP.Size = new System.Drawing.Size(202, 26);
            this.txtBuscarTP.TabIndex = 2;
            // 
            // btnBuscarGral
            // 
            this.btnBuscarGral.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnBuscarGral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarGral.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarGral.Location = new System.Drawing.Point(382, 24);
            this.btnBuscarGral.Name = "btnBuscarGral";
            this.btnBuscarGral.Size = new System.Drawing.Size(103, 29);
            this.btnBuscarGral.TabIndex = 3;
            this.btnBuscarGral.Text = "Buscar";
            this.btnBuscarGral.UseVisualStyleBackColor = false;
            this.btnBuscarGral.Click += new System.EventHandler(this.btnBuscarGral_Click);
            // 
            // pnlBuscador
            // 
            this.pnlBuscador.Controls.Add(this.txtBuscarRS);
            this.pnlBuscador.Controls.Add(this.btnBuscarGral);
            this.pnlBuscador.Controls.Add(this.txtBuscarTP);
            this.pnlBuscador.Controls.Add(this.label4);
            this.pnlBuscador.Controls.Add(this.label5);
            this.pnlBuscador.Location = new System.Drawing.Point(284, 12);
            this.pnlBuscador.Name = "pnlBuscador";
            this.pnlBuscador.Size = new System.Drawing.Size(488, 78);
            this.pnlBuscador.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(285, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 36;
            this.label8.Text = "Resultados";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(5, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 17);
            this.label9.TabIndex = 37;
            this.label9.Text = "Clínica seleccionada";
            // 
            // btnModificarCl
            // 
            this.btnModificarCl.BackColor = System.Drawing.Color.DarkGreen;
            this.btnModificarCl.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarCl.ForeColor = System.Drawing.Color.Lavender;
            this.btnModificarCl.Location = new System.Drawing.Point(114, 186);
            this.btnModificarCl.Name = "btnModificarCl";
            this.btnModificarCl.Size = new System.Drawing.Size(147, 37);
            this.btnModificarCl.TabIndex = 8;
            this.btnModificarCl.Text = "MODIFICAR";
            this.btnModificarCl.UseVisualStyleBackColor = false;
            this.btnModificarCl.Click += new System.EventHandler(this.btnModificarCl_Click);
            // 
            // btnCancelarCl
            // 
            this.btnCancelarCl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelarCl.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarCl.ForeColor = System.Drawing.Color.Lavender;
            this.btnCancelarCl.Location = new System.Drawing.Point(4, 186);
            this.btnCancelarCl.Name = "btnCancelarCl";
            this.btnCancelarCl.Size = new System.Drawing.Size(108, 37);
            this.btnCancelarCl.TabIndex = 9;
            this.btnCancelarCl.Text = "CANCELAR";
            this.btnCancelarCl.UseVisualStyleBackColor = false;
            this.btnCancelarCl.Click += new System.EventHandler(this.btnCancelarCl_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(4, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 21);
            this.label3.TabIndex = 24;
            this.label3.Text = "Teléfono          ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(4, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 21);
            this.label2.TabIndex = 22;
            this.label2.Text = "Dirección        ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(4, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 21);
            this.label6.TabIndex = 27;
            this.label6.Text = "Tipo de clínica";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "Razón social   ";
            // 
            // txtTelefonoCl
            // 
            this.txtTelefonoCl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonoCl.Location = new System.Drawing.Point(116, 89);
            this.txtTelefonoCl.Name = "txtTelefonoCl";
            this.txtTelefonoCl.Size = new System.Drawing.Size(147, 26);
            this.txtTelefonoCl.TabIndex = 6;
            // 
            // txtDireccionCl
            // 
            this.txtDireccionCl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccionCl.Location = new System.Drawing.Point(116, 52);
            this.txtDireccionCl.Name = "txtDireccionCl";
            this.txtDireccionCl.Size = new System.Drawing.Size(147, 26);
            this.txtDireccionCl.TabIndex = 5;
            // 
            // txtRazonSocialCl
            // 
            this.txtRazonSocialCl.Enabled = false;
            this.txtRazonSocialCl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocialCl.Location = new System.Drawing.Point(116, 16);
            this.txtRazonSocialCl.Name = "txtRazonSocialCl";
            this.txtRazonSocialCl.Size = new System.Drawing.Size(147, 26);
            this.txtRazonSocialCl.TabIndex = 4;
            // 
            // pnlSeleccion
            // 
            this.pnlSeleccion.Controls.Add(this.txtRazonSocialCl);
            this.pnlSeleccion.Controls.Add(this.txtDireccionCl);
            this.pnlSeleccion.Controls.Add(this.txtTelefonoCl);
            this.pnlSeleccion.Controls.Add(this.label1);
            this.pnlSeleccion.Controls.Add(this.label6);
            this.pnlSeleccion.Controls.Add(this.label2);
            this.pnlSeleccion.Controls.Add(this.label3);
            this.pnlSeleccion.Controls.Add(this.btnCancelarCl);
            this.pnlSeleccion.Controls.Add(this.btnModificarCl);
            this.pnlSeleccion.Location = new System.Drawing.Point(4, 116);
            this.pnlSeleccion.Name = "pnlSeleccion";
            this.pnlSeleccion.Size = new System.Drawing.Size(276, 242);
            this.pnlSeleccion.TabIndex = 38;
            // 
            // cbTipoClinica
            // 
            this.cbTipoClinica.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbTipoClinica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoClinica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoClinica.FormattingEnabled = true;
            this.cbTipoClinica.Items.AddRange(new object[] {
            "Clinica general",
            "Clinica dental",
            "Clinica pediatrica",
            "Clinica oftalmologica",
            "Clinica ginecologica",
            "Clinica dermatologica",
            "Clinica de rehabilitacion"});
            this.cbTipoClinica.Location = new System.Drawing.Point(121, 242);
            this.cbTipoClinica.Name = "cbTipoClinica";
            this.cbTipoClinica.Size = new System.Drawing.Size(145, 28);
            this.cbTipoClinica.TabIndex = 7;
            // 
            // ModificacionClinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 560);
            this.Controls.Add(this.cbTipoClinica);
            this.Controls.Add(this.pnlSeleccion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pnlBuscador);
            this.Controls.Add(this.dgvListaClinicas);
            this.Name = "ModificacionClinica";
            this.Text = "Actualizar Clínica";
            this.Load += new System.EventHandler(this.ModificacionClinica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClinicas)).EndInit();
            this.pnlBuscador.ResumeLayout(false);
            this.pnlBuscador.PerformLayout();
            this.pnlSeleccion.ResumeLayout(false);
            this.pnlSeleccion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvListaClinicas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBuscarRS;
        private System.Windows.Forms.TextBox txtBuscarTP;
        private System.Windows.Forms.Button btnBuscarGral;
        private System.Windows.Forms.Panel pnlBuscador;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnModificarCl;
        private System.Windows.Forms.Button btnCancelarCl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelefonoCl;
        private System.Windows.Forms.TextBox txtDireccionCl;
        private System.Windows.Forms.TextBox txtRazonSocialCl;
        private System.Windows.Forms.Panel pnlSeleccion;
        private System.Windows.Forms.ComboBox cbTipoClinica;
    }
}