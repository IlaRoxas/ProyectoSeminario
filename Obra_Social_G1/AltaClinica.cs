using Entidades;
using Infraestructura;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obra_Social_G1
{
    public partial class FrmAltaClinica : Form
    {
        private Logica.ClinicaLogica logicaClinica;
        public FrmAltaClinica()
        {
            InitializeComponent();
            logicaClinica = new Logica.ClinicaLogica();
        }

        private void btnAgregarCl_Click(object sender, EventArgs e)
        {
            string razonSocial=txtRazonSocial.Text.Trim();
            string direccion=txtDireccionCl.Text.Trim();
            string telefono=txtTelefonoCl.Text.Trim() ;
            string tipoClinica=cbTipoClinica.Text.Trim();
            string creado_por = Sesion.UsuarioActivo;
            string mensaje;

            if (cbTipoClinica.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione un tipo de clínica", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            bool exito = logicaClinica.AgregarClinica(razonSocial, direccion, telefono, tipoClinica, creado_por, out mensaje);
            {
                if (exito)
                {
                    MessageBox.Show("Clínica agregada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTextBoxes();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LimpiarTextBoxes()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
            }
        }

        private void btnCancelarCl_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbTipoClinica_SelectedIndexChanged(object sender, EventArgs e)
        {
            //No se cambia el contenido del combobox
            cbTipoClinica.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
