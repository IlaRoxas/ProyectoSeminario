using System;
using System.Windows.Forms;
using Logica;
using Entidades;
namespace Obra_Social_G1
{
    public partial class BajaAfiliado : Form
    {
        private readonly AfiliadoLogica afiliadoLogica;

        /// <summary>
        /// Constructor de la clase <see cref="BajaAfiliado"/>.
        /// Inicializa una nueva instancia de la clase <see cref="BajaAfiliado"/> y configura la lógica para gestionar la baja de afiliados.
        /// </summary>
        public BajaAfiliado()
        {
            InitializeComponent();
            afiliadoLogica = new AfiliadoLogica();
        }

        /// <summary>
        /// Maneja el evento de clic del botón para dar de baja a un afiliado.
        /// Valida el número de afiliado ingresado, busca al afiliado en la base de datos y, si es encontrado,
        /// solicita confirmación para proceder con la baja.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnBajaAf_Click(object sender, EventArgs e)
        {
            string numeroAfiliado = txtNroBajaAf.Text.Trim();
            string mensaje;
            // Validar si el campo no está vacío

            if (string.IsNullOrEmpty(numeroAfiliado))
            {
                MessageBox.Show("Por favor, ingrese un número de afiliado.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar el afiliado en la base de datos
            Afiliado afiliado = afiliadoLogica.ObtenerAfiliado(numeroAfiliado, out mensaje);


            if (afiliado != null)
            {
                // Confirmación para dar de baja
                var confirmacion = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar a {afiliado.nombre} {afiliado.apellido} ({afiliado.email})?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    // Intentar dar de baja al afiliado
                    if (afiliadoLogica.DarDeBajaAfiliado(numeroAfiliado, out mensaje))
                    {
                        MessageBox.Show("Afiliado dado de baja correctamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(mensaje, "Afiliado no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Limpia todos los controles de tipo TextBox en el formulario.
        /// Recorre todos los controles del formulario y establece el texto de cada TextBox en vacío.
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
    }
}