namespace Obra_Social_G1
{
    partial class FrmAltaClinica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAltaClinica));
            this.lblAltaClinica = new System.Windows.Forms.Label();
            this.btnCancelarCl = new System.Windows.Forms.Button();
            this.btnAgregarCl = new System.Windows.Forms.Button();
            this.txtTelefonoCl = new System.Windows.Forms.TextBox();
            this.txtDireccionCl = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.lblTipoClinica = new System.Windows.Forms.Label();
            this.lblTelefonoCl = new System.Windows.Forms.Label();
            this.lblDireccionCl = new System.Windows.Forms.Label();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.cbTipoClinica = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblAltaClinica
            // 
            this.lblAltaClinica.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblAltaClinica.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltaClinica.Location = new System.Drawing.Point(0, 0);
            this.lblAltaClinica.Name = "lblAltaClinica";
            this.lblAltaClinica.Size = new System.Drawing.Size(785, 36);
            this.lblAltaClinica.TabIndex = 15;
            this.lblAltaClinica.Text = "Agregar una nueva clínica";
            this.lblAltaClinica.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancelarCl
            // 
            this.btnCancelarCl.AutoSize = true;
            this.btnCancelarCl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelarCl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarCl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarCl.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarCl.ForeColor = System.Drawing.Color.Lavender;
            this.btnCancelarCl.Location = new System.Drawing.Point(395, 451);
            this.btnCancelarCl.Name = "btnCancelarCl";
            this.btnCancelarCl.Size = new System.Drawing.Size(126, 42);
            this.btnCancelarCl.TabIndex = 6;
            this.btnCancelarCl.Text = "CANCELAR";
            this.btnCancelarCl.UseVisualStyleBackColor = false;
            this.btnCancelarCl.Click += new System.EventHandler(this.btnCancelarCl_Click);
            // 
            // btnAgregarCl
            // 
            this.btnAgregarCl.AutoSize = true;
            this.btnAgregarCl.BackColor = System.Drawing.Color.DarkGreen;
            this.btnAgregarCl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarCl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCl.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCl.ForeColor = System.Drawing.Color.Lavender;
            this.btnAgregarCl.Location = new System.Drawing.Point(532, 451);
            this.btnAgregarCl.Name = "btnAgregarCl";
            this.btnAgregarCl.Size = new System.Drawing.Size(180, 42);
            this.btnAgregarCl.TabIndex = 5;
            this.btnAgregarCl.Text = "AGREGAR";
            this.btnAgregarCl.UseVisualStyleBackColor = false;
            this.btnAgregarCl.Click += new System.EventHandler(this.btnAgregarCl_Click);
            // 
            // txtTelefonoCl
            // 
            this.txtTelefonoCl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonoCl.Location = new System.Drawing.Point(230, 159);
            this.txtTelefonoCl.Name = "txtTelefonoCl";
            this.txtTelefonoCl.Size = new System.Drawing.Size(445, 29);
            this.txtTelefonoCl.TabIndex = 3;
            // 
            // txtDireccionCl
            // 
            this.txtDireccionCl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccionCl.Location = new System.Drawing.Point(230, 114);
            this.txtDireccionCl.Name = "txtDireccionCl";
            this.txtDireccionCl.Size = new System.Drawing.Size(445, 29);
            this.txtDireccionCl.TabIndex = 2;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(230, 68);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(445, 29);
            this.txtRazonSocial.TabIndex = 1;
            // 
            // lblTipoClinica
            // 
            this.lblTipoClinica.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTipoClinica.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoClinica.Location = new System.Drawing.Point(62, 204);
            this.lblTipoClinica.Name = "lblTipoClinica";
            this.lblTipoClinica.Size = new System.Drawing.Size(148, 29);
            this.lblTipoClinica.TabIndex = 33;
            this.lblTipoClinica.Text = "Tipo de Clínica";
            this.lblTipoClinica.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTelefonoCl
            // 
            this.lblTelefonoCl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTelefonoCl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefonoCl.Location = new System.Drawing.Point(62, 159);
            this.lblTelefonoCl.Name = "lblTelefonoCl";
            this.lblTelefonoCl.Size = new System.Drawing.Size(148, 29);
            this.lblTelefonoCl.TabIndex = 32;
            this.lblTelefonoCl.Text = "Teléfono";
            this.lblTelefonoCl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDireccionCl
            // 
            this.lblDireccionCl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDireccionCl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccionCl.Location = new System.Drawing.Point(62, 114);
            this.lblDireccionCl.Name = "lblDireccionCl";
            this.lblDireccionCl.Size = new System.Drawing.Size(148, 29);
            this.lblDireccionCl.TabIndex = 31;
            this.lblDireccionCl.Text = "Dirección";
            this.lblDireccionCl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblRazonSocial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazonSocial.Location = new System.Drawing.Point(62, 68);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(148, 29);
            this.lblRazonSocial.TabIndex = 30;
            this.lblRazonSocial.Text = "Razón Social";
            this.lblRazonSocial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbTipoClinica
            // 
            this.cbTipoClinica.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbTipoClinica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoClinica.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoClinica.FormattingEnabled = true;
            this.cbTipoClinica.Items.AddRange(new object[] {
            "Clinica general",
            "Clinica dental",
            "Clinica pediatrica",
            "Clinica oftalmologica",
            "Clinica ginecologica",
            "Clinica dermatologica",
            "Clinica de rehabilitacion"});
            this.cbTipoClinica.Location = new System.Drawing.Point(230, 204);
            this.cbTipoClinica.Name = "cbTipoClinica";
            this.cbTipoClinica.Size = new System.Drawing.Size(445, 32);
            this.cbTipoClinica.TabIndex = 4;
            this.cbTipoClinica.SelectedIndexChanged += new System.EventHandler(this.cbTipoClinica_SelectedIndexChanged);
            // 
            // FrmAltaClinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 560);
            this.Controls.Add(this.cbTipoClinica);
            this.Controls.Add(this.btnCancelarCl);
            this.Controls.Add(this.btnAgregarCl);
            this.Controls.Add(this.txtTelefonoCl);
            this.Controls.Add(this.txtDireccionCl);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.lblTipoClinica);
            this.Controls.Add(this.lblTelefonoCl);
            this.Controls.Add(this.lblDireccionCl);
            this.Controls.Add(this.lblRazonSocial);
            this.Controls.Add(this.lblAltaClinica);
            this.Name = "FrmAltaClinica";
            this.Text = "Agregar clínica";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAltaClinica;
        private System.Windows.Forms.Button btnCancelarCl;
        private System.Windows.Forms.Button btnAgregarCl;
        private System.Windows.Forms.TextBox txtTelefonoCl;
        private System.Windows.Forms.TextBox txtDireccionCl;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label lblTipoClinica;
        private System.Windows.Forms.Label lblTelefonoCl;
        private System.Windows.Forms.Label lblDireccionCl;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.ComboBox cbTipoClinica;
    }
}