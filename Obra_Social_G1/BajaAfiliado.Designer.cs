namespace Obra_Social_G1
{
    partial class BajaAfiliado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BajaAfiliado));
            this.lblBajaAfiliado = new System.Windows.Forms.Label();
            this.txtNroBajaAf = new System.Windows.Forms.TextBox();
            this.lblNroAfiliado = new System.Windows.Forms.Label();
            this.btnBajaAf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBajaAfiliado
            // 
            this.lblBajaAfiliado.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblBajaAfiliado.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBajaAfiliado.Location = new System.Drawing.Point(0, 0);
            this.lblBajaAfiliado.Name = "lblBajaAfiliado";
            this.lblBajaAfiliado.Size = new System.Drawing.Size(785, 36);
            this.lblBajaAfiliado.TabIndex = 15;
            this.lblBajaAfiliado.Text = "Dar de baja un afiliado";
            this.lblBajaAfiliado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNroBajaAf
            // 
            this.txtNroBajaAf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroBajaAf.Location = new System.Drawing.Point(181, 87);
            this.txtNroBajaAf.Name = "txtNroBajaAf";
            this.txtNroBajaAf.Size = new System.Drawing.Size(448, 29);
            this.txtNroBajaAf.TabIndex = 16;
            // 
            // lblNroAfiliado
            // 
            this.lblNroAfiliado.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNroAfiliado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroAfiliado.Location = new System.Drawing.Point(181, 45);
            this.lblNroAfiliado.Name = "lblNroAfiliado";
            this.lblNroAfiliado.Size = new System.Drawing.Size(448, 32);
            this.lblNroAfiliado.TabIndex = 17;
            this.lblNroAfiliado.Text = "Por favor, ingrese el número de afiliado que desea eliminar";
            this.lblNroAfiliado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBajaAf
            // 
            this.btnBajaAf.AutoSize = true;
            this.btnBajaAf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBajaAf.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBajaAf.BackgroundImage")));
            this.btnBajaAf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBajaAf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBajaAf.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajaAf.Location = new System.Drawing.Point(633, 80);
            this.btnBajaAf.Name = "btnBajaAf";
            this.btnBajaAf.Size = new System.Drawing.Size(41, 41);
            this.btnBajaAf.TabIndex = 18;
            this.btnBajaAf.UseVisualStyleBackColor = false;
            this.btnBajaAf.Click += new System.EventHandler(this.btnBajaAf_Click);
            // 
            // BajaAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 560);
            this.Controls.Add(this.btnBajaAf);
            this.Controls.Add(this.txtNroBajaAf);
            this.Controls.Add(this.lblNroAfiliado);
            this.Controls.Add(this.lblBajaAfiliado);
            this.Name = "BajaAfiliado";
            this.Text = "Eliminar afiliado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBajaAfiliado;
        private System.Windows.Forms.TextBox txtNroBajaAf;
        private System.Windows.Forms.Label lblNroAfiliado;
        private System.Windows.Forms.Button btnBajaAf;
    }
}