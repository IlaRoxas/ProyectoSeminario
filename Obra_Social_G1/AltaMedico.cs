using Infraestructura;
using System;
using System.Windows.Forms;
namespace Obra_Social_G1
{
    public partial class AltaMedico : Form
    {
        private Logica.MedicoLogica logicaMedico;

        public AltaMedico()
        {
            InitializeComponent();
            logicaMedico = new Logica.MedicoLogica();
        }

        private void btnAgregarMed_Click(object sender, EventArgs e)
        {
            string email = txtEmailMed.Text.Trim();
            string nombre= txtNombreMed.Text.Trim();
            string apellido = txtApellidoMed.Text.Trim();
            string especialidad= comboBox1.Text.Trim();
            string numero_matricula= txtMatriculaMed.Text.Trim();
            string telefono= txtTelefonoMed.Text.Trim();
            string creadoPor = Sesion.UsuarioActivo;
            string mensaje;
            //llamar al método para agregar afiliado en la capa lógica
            bool exito = logicaMedico.AgregarMedico(email, nombre, apellido, especialidad, numero_matricula, telefono, creadoPor, out mensaje);

            if (exito)
            {
                MessageBox.Show("Médico agregado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnCancelarMed_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //No se cambia el contenido del combobox
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }
    }
}
