﻿namespace Obra_Social_G1
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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.altaAfiliadoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.modificacionAfiliadoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaAfiliadoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.medicoTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.modificacionMedicoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.altaMedicoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaMedicoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.clinicaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.altaClinicaTool = new System.Windows.Forms.ToolStripMenuItem();
            this.modificacionClinicaTool = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaClinicaTool = new System.Windows.Forms.ToolStripMenuItem();
            this.salirTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
            this.afiliadoTSMI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.afiliadoTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.altaAfiliadoTool,
            this.modificacionAfiliadoTool,
            this.bajaAfiliadoTool});
            this.afiliadoTSMI.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.afiliadoTSMI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.afiliadoTSMI.Name = "afiliadoTSMI";
            this.afiliadoTSMI.Size = new System.Drawing.Size(107, 34);
            this.afiliadoTSMI.Text = "Afiliados";
            this.afiliadoTSMI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(198, 26);
            this.toolStripMenuItem1.Text = "Listar y/o buscar";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // altaAfiliadoTool
            // 
            this.altaAfiliadoTool.CheckOnClick = true;
            this.altaAfiliadoTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altaAfiliadoTool.Image = ((System.Drawing.Image)(resources.GetObject("altaAfiliadoTool.Image")));
            this.altaAfiliadoTool.Name = "altaAfiliadoTool";
            this.altaAfiliadoTool.Size = new System.Drawing.Size(198, 26);
            this.altaAfiliadoTool.Text = "Agregar ";
            this.altaAfiliadoTool.Click += new System.EventHandler(this.altaAfiliadoTool_Click);
            // 
            // modificacionAfiliadoTool
            // 
            this.modificacionAfiliadoTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificacionAfiliadoTool.Image = ((System.Drawing.Image)(resources.GetObject("modificacionAfiliadoTool.Image")));
            this.modificacionAfiliadoTool.Name = "modificacionAfiliadoTool";
            this.modificacionAfiliadoTool.Size = new System.Drawing.Size(198, 26);
            this.modificacionAfiliadoTool.Text = "Modificar";
            this.modificacionAfiliadoTool.Click += new System.EventHandler(this.modificacionAfiliadoTool_Click);
            // 
            // bajaAfiliadoTool
            // 
            this.bajaAfiliadoTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bajaAfiliadoTool.Image = ((System.Drawing.Image)(resources.GetObject("bajaAfiliadoTool.Image")));
            this.bajaAfiliadoTool.Name = "bajaAfiliadoTool";
            this.bajaAfiliadoTool.Size = new System.Drawing.Size(198, 26);
            this.bajaAfiliadoTool.Text = "Eliminar";
            this.bajaAfiliadoTool.Click += new System.EventHandler(this.bajaAfiliadoTool_Click);
            // 
            // medicoTSMI
            // 
            this.medicoTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificacionMedicoTool,
            this.altaMedicoTool,
            this.toolStripMenuItem2,
            this.bajaMedicoTool});
            this.medicoTSMI.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.medicoTSMI.Margin = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.medicoTSMI.Name = "medicoTSMI";
            this.medicoTSMI.Size = new System.Drawing.Size(107, 34);
            this.medicoTSMI.Text = "Médicos";
            // 
            // modificacionMedicoTool
            // 
            this.modificacionMedicoTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificacionMedicoTool.Image = ((System.Drawing.Image)(resources.GetObject("modificacionMedicoTool.Image")));
            this.modificacionMedicoTool.Name = "modificacionMedicoTool";
            this.modificacionMedicoTool.Size = new System.Drawing.Size(198, 26);
            this.modificacionMedicoTool.Text = "Listar y/o buscar";
            this.modificacionMedicoTool.Click += new System.EventHandler(this.modificacionMedicoTool_Click);
            // 
            // altaMedicoTool
            // 
            this.altaMedicoTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altaMedicoTool.Image = ((System.Drawing.Image)(resources.GetObject("altaMedicoTool.Image")));
            this.altaMedicoTool.Name = "altaMedicoTool";
            this.altaMedicoTool.Size = new System.Drawing.Size(198, 26);
            this.altaMedicoTool.Text = "Agregar";
            this.altaMedicoTool.Click += new System.EventHandler(this.altaMedicoTool_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(198, 26);
            this.toolStripMenuItem2.Text = "Modificar ";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // bajaMedicoTool
            // 
            this.bajaMedicoTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bajaMedicoTool.Image = ((System.Drawing.Image)(resources.GetObject("bajaMedicoTool.Image")));
            this.bajaMedicoTool.Name = "bajaMedicoTool";
            this.bajaMedicoTool.Size = new System.Drawing.Size(198, 26);
            this.bajaMedicoTool.Text = "Eliminar ";
            this.bajaMedicoTool.Click += new System.EventHandler(this.bajaMedicoTool_Click);
            // 
            // clinicaTSMI
            // 
            this.clinicaTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.altaClinicaTool,
            this.modificacionClinicaTool,
            this.bajaClinicaTool});
            this.clinicaTSMI.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.clinicaTSMI.Margin = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.clinicaTSMI.Name = "clinicaTSMI";
            this.clinicaTSMI.Size = new System.Drawing.Size(96, 34);
            this.clinicaTSMI.Text = "Clínicas";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(198, 26);
            this.toolStripMenuItem3.Text = "Listar y/o buscar";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // altaClinicaTool
            // 
            this.altaClinicaTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altaClinicaTool.Image = ((System.Drawing.Image)(resources.GetObject("altaClinicaTool.Image")));
            this.altaClinicaTool.Name = "altaClinicaTool";
            this.altaClinicaTool.Size = new System.Drawing.Size(198, 26);
            this.altaClinicaTool.Text = "Agregar ";
            this.altaClinicaTool.Click += new System.EventHandler(this.altaClinicaTool_Click);
            // 
            // modificacionClinicaTool
            // 
            this.modificacionClinicaTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificacionClinicaTool.Image = ((System.Drawing.Image)(resources.GetObject("modificacionClinicaTool.Image")));
            this.modificacionClinicaTool.Name = "modificacionClinicaTool";
            this.modificacionClinicaTool.Size = new System.Drawing.Size(198, 26);
            this.modificacionClinicaTool.Text = "Modificar ";
            this.modificacionClinicaTool.Click += new System.EventHandler(this.modificacionClinicaTool_Click);
            // 
            // bajaClinicaTool
            // 
            this.bajaClinicaTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bajaClinicaTool.Image = ((System.Drawing.Image)(resources.GetObject("bajaClinicaTool.Image")));
            this.bajaClinicaTool.Name = "bajaClinicaTool";
            this.bajaClinicaTool.Size = new System.Drawing.Size(198, 26);
            this.bajaClinicaTool.Text = "Eliminar";
            this.bajaClinicaTool.Click += new System.EventHandler(this.bajaClinicaTool_Click);
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}