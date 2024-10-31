namespace Obra_Social_G1
{
    partial class frmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.afiliadoTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.altaAfiliadoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaAfiliadoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.modificacionAfiliadoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.medicoTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.altaMedicoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaMedicoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.modificacionMedicoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.clinicaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.altaClinicaTool = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaClinicaTool = new System.Windows.Forms.ToolStripMenuItem();
            this.modificacionClinicaTool = new System.Windows.Forms.ToolStripMenuItem();
            this.salirTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afiliadoTSMI,
            this.medicoTSMI,
            this.clinicaTSMI,
            this.salirTSMI});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 38);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // afiliadoTSMI
            // 
            this.afiliadoTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaAfiliadoTool,
            this.bajaAfiliadoTool,
            this.modificacionAfiliadoTool});
            this.afiliadoTSMI.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.afiliadoTSMI.Name = "afiliadoTSMI";
            this.afiliadoTSMI.Size = new System.Drawing.Size(107, 34);
            this.afiliadoTSMI.Text = "Afiliados";
            // 
            // altaAfiliadoTool
            // 
            this.altaAfiliadoTool.CheckOnClick = true;
            this.altaAfiliadoTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altaAfiliadoTool.Image = ((System.Drawing.Image)(resources.GetObject("altaAfiliadoTool.Image")));
            this.altaAfiliadoTool.Name = "altaAfiliadoTool";
            this.altaAfiliadoTool.Size = new System.Drawing.Size(180, 26);
            this.altaAfiliadoTool.Text = "Agregar ";
            this.altaAfiliadoTool.Click += new System.EventHandler(this.altaAfiliadoTool_Click);
            // 
            // bajaAfiliadoTool
            // 
            this.bajaAfiliadoTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bajaAfiliadoTool.Image = ((System.Drawing.Image)(resources.GetObject("bajaAfiliadoTool.Image")));
            this.bajaAfiliadoTool.Name = "bajaAfiliadoTool";
            this.bajaAfiliadoTool.Size = new System.Drawing.Size(180, 26);
            this.bajaAfiliadoTool.Text = "Eliminar ";
            this.bajaAfiliadoTool.Click += new System.EventHandler(this.bajaAfiliadoTool_Click);
            // 
            // modificacionAfiliadoTool
            // 
            this.modificacionAfiliadoTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificacionAfiliadoTool.Image = ((System.Drawing.Image)(resources.GetObject("modificacionAfiliadoTool.Image")));
            this.modificacionAfiliadoTool.Name = "modificacionAfiliadoTool";
            this.modificacionAfiliadoTool.Size = new System.Drawing.Size(180, 26);
            this.modificacionAfiliadoTool.Text = "Modificar";
            this.modificacionAfiliadoTool.Click += new System.EventHandler(this.modificacionAfiliadoTool_Click);
            // 
            // medicoTSMI
            // 
            this.medicoTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaMedicoTool,
            this.bajaMedicoTool,
            this.modificacionMedicoTool});
            this.medicoTSMI.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.medicoTSMI.Margin = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.medicoTSMI.Name = "medicoTSMI";
            this.medicoTSMI.Size = new System.Drawing.Size(107, 34);
            this.medicoTSMI.Text = "Médicos";
            // 
            // altaMedicoTool
            // 
            this.altaMedicoTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altaMedicoTool.Image = ((System.Drawing.Image)(resources.GetObject("altaMedicoTool.Image")));
            this.altaMedicoTool.Name = "altaMedicoTool";
            this.altaMedicoTool.Size = new System.Drawing.Size(153, 26);
            this.altaMedicoTool.Text = "Agregar";
            // 
            // bajaMedicoTool
            // 
            this.bajaMedicoTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bajaMedicoTool.Image = ((System.Drawing.Image)(resources.GetObject("bajaMedicoTool.Image")));
            this.bajaMedicoTool.Name = "bajaMedicoTool";
            this.bajaMedicoTool.Size = new System.Drawing.Size(153, 26);
            this.bajaMedicoTool.Text = "Eliminar ";
            // 
            // modificacionMedicoTool
            // 
            this.modificacionMedicoTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificacionMedicoTool.Image = ((System.Drawing.Image)(resources.GetObject("modificacionMedicoTool.Image")));
            this.modificacionMedicoTool.Name = "modificacionMedicoTool";
            this.modificacionMedicoTool.Size = new System.Drawing.Size(153, 26);
            this.modificacionMedicoTool.Text = "Modificar ";
            // 
            // clinicaTSMI
            // 
            this.clinicaTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaClinicaTool,
            this.bajaClinicaTool,
            this.modificacionClinicaTool});
            this.clinicaTSMI.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.clinicaTSMI.Margin = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.clinicaTSMI.Name = "clinicaTSMI";
            this.clinicaTSMI.Size = new System.Drawing.Size(96, 34);
            this.clinicaTSMI.Text = "Clínicas";
            // 
            // altaClinicaTool
            // 
            this.altaClinicaTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altaClinicaTool.Image = ((System.Drawing.Image)(resources.GetObject("altaClinicaTool.Image")));
            this.altaClinicaTool.Name = "altaClinicaTool";
            this.altaClinicaTool.Size = new System.Drawing.Size(180, 26);
            this.altaClinicaTool.Text = "Agregar ";
            this.altaClinicaTool.Click += new System.EventHandler(this.altaClinicaTool_Click);
            // 
            // bajaClinicaTool
            // 
            this.bajaClinicaTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bajaClinicaTool.Image = ((System.Drawing.Image)(resources.GetObject("bajaClinicaTool.Image")));
            this.bajaClinicaTool.Name = "bajaClinicaTool";
            this.bajaClinicaTool.Size = new System.Drawing.Size(180, 26);
            this.bajaClinicaTool.Text = "Eliminar";
            // 
            // modificacionClinicaTool
            // 
            this.modificacionClinicaTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificacionClinicaTool.Image = ((System.Drawing.Image)(resources.GetObject("modificacionClinicaTool.Image")));
            this.modificacionClinicaTool.Name = "modificacionClinicaTool";
            this.modificacionClinicaTool.Size = new System.Drawing.Size(180, 26);
            this.modificacionClinicaTool.Text = "Modificar ";
            // 
            // salirTSMI
            // 
            this.salirTSMI.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.salirTSMI.Margin = new System.Windows.Forms.Padding(350, 0, 0, 0);
            this.salirTSMI.Name = "salirTSMI";
            this.salirTSMI.Size = new System.Drawing.Size(62, 34);
            this.salirTSMI.Text = "Salir";
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 560);
            this.Controls.Add(this.menuStrip);
            this.Name = "frmInicio";
            this.Text = "Inicio";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem afiliadoTSMI;
        private System.Windows.Forms.ToolStripMenuItem altaAfiliadoTool;
        private System.Windows.Forms.ToolStripMenuItem bajaAfiliadoTool;
        private System.Windows.Forms.ToolStripMenuItem modificacionAfiliadoTool;
        private System.Windows.Forms.ToolStripMenuItem medicoTSMI;
        private System.Windows.Forms.ToolStripMenuItem altaMedicoTool;
        private System.Windows.Forms.ToolStripMenuItem bajaMedicoTool;
        private System.Windows.Forms.ToolStripMenuItem modificacionMedicoTool;
        private System.Windows.Forms.ToolStripMenuItem clinicaTSMI;
        private System.Windows.Forms.ToolStripMenuItem altaClinicaTool;
        private System.Windows.Forms.ToolStripMenuItem bajaClinicaTool;
        private System.Windows.Forms.ToolStripMenuItem modificacionClinicaTool;
        private System.Windows.Forms.ToolStripMenuItem salirTSMI;
    }
}