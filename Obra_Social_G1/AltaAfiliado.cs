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
        private Logica.AfiliadoLogica logicaAfiliado;

        /// <summary>
        /// Constructor de la clase <see cref="frmAltaAfiliado"/>.
        /// Inicializa los componentes de la interfaz y crea una nueva instancia de la clase <see cref="Logica.AfiliadoLogica"/>.
        /// </summary>
        public frmAltaAfiliado()
        {
            InitializeComponent();
            logicaAfiliado= new Logica.AfiliadoLogica();
        }

        /// <summary>
        /// Evento que se desencadena al hacer clic en el botón para agregar un afiliado.
        /// Recoge los datos del nuevo afiliado desde los controles de texto,
        /// y llama al método correspondiente en la capa lógica para agregarlo a la base de datos.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <remarks>
        /// Este método obtiene el nombre, apellido, teléfono, domicilio, email y número de afiliado 
        /// de los controles de texto de la interfaz de usuario. Luego, llama a `logicaAfiliado.AgregarAfiliado`
        /// para intentar agregar el afiliado. Si la operación es exitosa, se muestra un mensaje de éxito
        /// y se limpian los campos de entrada. En caso de error, se muestra un mensaje con el detalle del error.
        /// </remarks>
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

        /// <summary>
        /// Limpia el contenido de todos los controles de tipo TextBox en el formulario.
        /// </summary>
        /// <remarks>
        /// Este método recorre todos los controles en el formulario y, si el control es un TextBox,
        /// establece su propiedad Text a una cadena vacía, efectivamente limpiando el campo de texto.
        /// Esto es útil para restablecer la interfaz de usuario después de agregar o modificar un afiliado.
        /// </remarks>
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
        /// Cierra el formulario de alta de afiliados.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCancelarAf_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
