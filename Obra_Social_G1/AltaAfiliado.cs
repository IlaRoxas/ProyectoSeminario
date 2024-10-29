using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infraestructura;
using Logica;

namespace Obra_Social_G1
{
    public partial class frmAltaAfiliado : Form
    {
        private Logica.Afiliado logicaAfiliado;

        public frmAltaAfiliado()
        {
            InitializeComponent();
            logicaAfiliado= new Logica.Afiliado();
        }

        private void btnAgregarAf_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreAf.Text.Trim();
            string apellido = txtApellidoAf.Text.Trim();
            string telefono = txtTelefonoAf.Text.Trim();
            string domicilio = txtDomicilioAf.Text.Trim();
            string email = txtEmailAf.Text.Trim();
            string numero_afiliado = txtNroAf.Text.Trim();
            string creadoPor = Sesion.UsuarioActivo;
            string mensaje;
            //llamar al método para agregar afiliado en la capa lógica
            bool exito = logicaAfiliado.AgregarAfiliado(nombre, apellido, telefono, domicilio, email, numero_afiliado, creadoPor, out mensaje);

            if(exito)    
            {
                MessageBox.Show("Afiliado agregado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTextBoxes();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCancelarAf_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
