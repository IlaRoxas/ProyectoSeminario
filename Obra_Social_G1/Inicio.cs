using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Obra_Social_G1
{
    public partial class frmInicio : Form
    {

        public frmInicio()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Abre el formulario para dar de alta a un nuevo afiliado.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void altaAfiliadoTool_Click(object sender, EventArgs e)
        {
            frmAltaAfiliado formAgregarAfiliado= new frmAltaAfiliado();
            formAgregarAfiliado.Show();

        }

        /// <summary>
        /// Abre el formulario para dar de baja a un afiliado existente.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void bajaAfiliadoTool_Click(object sender, EventArgs e)
        {
            BajaAfiliado frmBaja = new BajaAfiliado();
            frmBaja.Show();
        }

        /// <summary>
        /// Abre el formulario para modificar los datos de un afiliado existente.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void modificacionAfiliadoTool_Click(object sender, EventArgs e)
        {
            
            ModificacionAfiliado frmModifAf = new ModificacionAfiliado();
            frmModifAf.Show();
        }

        private void altaClinicaTool_Click(object sender, EventArgs e)
        {
            FrmAltaClinica frmAltaClinica= new FrmAltaClinica();
            frmAltaClinica.Show();
        }

        private void modificacionClinicaTool_Click(object sender, EventArgs e)
        {
            ModificacionClinica frmModifCl = new ModificacionClinica();
            frmModifCl.Show();
        }

        private void bajaClinicaTool_Click(object sender, EventArgs e)
        {
            BajaClinica frmBajaCl= new BajaClinica();
            frmBajaCl.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ModificacionAfiliado frmModifAf = new ModificacionAfiliado();
            frmModifAf.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ModificacionClinica frmModifCl = new ModificacionClinica();
            frmModifCl.Show();
        }

        private void altaMedicoTool_Click(object sender, EventArgs e)
        {
            AltaMedico frmAgregarMedico= new AltaMedico();
            frmAgregarMedico.Show();    
        }

        private void bajaMedicoTool_Click(object sender, EventArgs e)
        {
            BajaMedico frmBajaMedico = new BajaMedico();
            frmBajaMedico.Show();
        }
    }
}
