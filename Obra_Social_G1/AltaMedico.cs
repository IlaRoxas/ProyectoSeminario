using Infraestructura;
using System;
using System.Windows.Forms;
namespace Obra_Social_G1
{
    /// <summary>
    /// Clase que representa el formulario para el alta de médicos.
    /// Permite a los usuarios ingresar los datos de un nuevo médico y realizar la operación de agregarlo a la base de datos.
    /// </summary>
    public partial class AltaMedico : Form
    {
        private Logica.MedicoLogica logicaMedico;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AltaMedico"/> y configura la lógica de médicos.
        /// </summary>
        public AltaMedico()
        {
            InitializeComponent();
            logicaMedico = new Logica.MedicoLogica();
        }

        /// <summary>
        /// Manejador del evento que se activa al hacer clic en el botón de agregar médico.
        /// Valida los campos de entrada y, si son correctos, llama a la lógica para agregar el nuevo médico.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
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

        /// <summary>
        /// Limpia todos los campos de texto en el formulario.
        /// Este método se utiliza para restablecer el formulario después de una operación exitosa.
        /// </summary>
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

        /// <summary>
        /// Manejador del evento que se activa al hacer clic en el botón de cancelar.
        /// Cierra el formulario sin realizar ninguna acción adicional.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCancelarMed_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Manejador del evento que se activa al cambiar la selección del ComboBox de especialidad.
        /// Establece el estilo del ComboBox como una lista desplegable para evitar la edición manual.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //No se cambia el contenido del combobox
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }
    }
}
