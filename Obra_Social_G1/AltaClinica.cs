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
    /// <summary>
    /// Clase que representa el formulario para el alta de clínicas.
    /// Permite a los usuarios ingresar los datos de una nueva clínica y realizar la operación de agregarla a la base de datos.
    /// </summary>
    public partial class FrmAltaClinica : Form
    {
        private Logica.ClinicaLogica logicaClinica;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FrmAltaClinica"/> y configura la lógica de clínicas.
        /// </summary>
        public FrmAltaClinica()
        {
            InitializeComponent();
            logicaClinica = new Logica.ClinicaLogica();
        }

        /// <summary>
        /// Manejador del evento que se activa al hacer clic en el botón de agregar clínica.
        /// Valida los campos de entrada y, si son correctos, llama a la lógica para agregar la nueva clínica.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
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
        private void btnCancelarCl_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Manejador del evento que se activa al cambiar la selección del ComboBox de tipos de clínica.
        /// Establece el estilo del ComboBox como un lista desplegable para evitar la edición manual.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void cbTipoClinica_SelectedIndexChanged(object sender, EventArgs e)
        {
            //No se cambia el contenido del combobox
            cbTipoClinica.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
