using Entidades;
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
    public partial class BajaAfiliado : Form
    {
        AfiliadoLogica afiliadoLogica;

        public BajaAfiliado()
        {
            InitializeComponent();
            afiliadoLogica=new AfiliadoLogica();
        }

        /// <summary>
        /// Manejador del evento que se activa al cargar el formulario.
        /// Carga la lista de afiliados y la muestra en el DataGridView.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BajaAfiliados_Load(object sender, EventArgs e)
        {
            string mensaje;
            DataTable clinicas = afiliadoLogica.ObtenerAfiliados(out mensaje);

            if (clinicas != null)
            {
                dgvListaAfiliados.DataSource = clinicas;
            }
            else
            {
                MessageBox.Show(mensaje, "Error al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador del evento que se activa al cambiar la selección en el DataGridView.
        /// Muestra los detalles del afiliado seleccionado en los campos de texto.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void dgvListaAfiliados_SelectionChanged(object sender, EventArgs e)
        {
            txtNroAf.Text = Convert.ToString(dgvListaAfiliados.CurrentRow.Cells["numero_afiliado"].Value);
            txtNombre.Text = Convert.ToString(dgvListaAfiliados.CurrentRow.Cells["nombre"].Value);
            txtApellido.Text = Convert.ToString(dgvListaAfiliados.CurrentRow.Cells["apellido"].Value);
            txtDomicilio.Text = Convert.ToString(dgvListaAfiliados.CurrentRow.Cells["domicilio"].Value);
            txtTelefono.Text = Convert.ToString(dgvListaAfiliados.CurrentRow.Cells["telefono"].Value);
            txtEmail.Text = Convert.ToString(dgvListaAfiliados.CurrentRow.Cells["email"].Value);

        }

        /// <summary>
        /// Manejador del evento que se activa al hacer clic en el botón de eliminar afiliado.
        /// Valida el campo de número de afiliado y, si es correcto, intenta eliminar al afiliado del sistema.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnEliminarAf_Click(object sender, EventArgs e)
        {
            string numero_afiliado = txtNroAf.Text.Trim();
            string mensaje;
            // Validar si el campo no está vacío

            if (string.IsNullOrEmpty(numero_afiliado))
            {
                MessageBox.Show("Por favor, indique un nombre.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar la clinica en la base de datos
            Afiliado afiliado = afiliadoLogica.ObtenerAfiliado(numero_afiliado, out mensaje);


            if (afiliado != null)
            {
                // Confirmación para dar de baja
                var confirmacion = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar a {afiliado.nombre} {afiliado.apellido} ({afiliado.numero_afiliado})?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    // Intentar dar de baja al afiliado
                    if (afiliadoLogica.DarDeBajaAfiliado(numero_afiliado, out mensaje))
                    {
                        MessageBox.Show("Afiliado dado de baja correctamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarTextBoxes();
                        ActualizarAfiliadosActivos(); // Actualiza el DataGridView

                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(mensaje, "Afiliado no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Actualiza la lista de afiliados activos en el DataGridView.
        /// Este método se llama después de eliminar un afiliado para reflejar los cambios.
        /// </summary>
        private void ActualizarAfiliadosActivos()
        {
            string mensaje;
            var afiliadosActivos = afiliadoLogica.ObtenerAfiliados(out mensaje);

            if (afiliadosActivos != null)
            {
                dgvListaAfiliados.DataSource = afiliadosActivos;
            }
            else
            {
                MessageBox.Show(mensaje, "Error al obtener afiliados activos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador del evento que se activa al hacer clic en el botón de buscar afiliados por nombre y apellido.
        /// Filtra la lista de afiliados y muestra los resultados en el DataGridView.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnBuscarNA_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarNA.Text.Trim();
            DataTable dt = afiliadoLogica.ObtenerAfiliadosFiltrados(nombre);
            dgvListaAfiliados.DataSource = dt;
        }

        /// <summary>
        /// Limpia todos los campos de texto en el formulario.
        /// Este método se utiliza para restablecer el formulario después de una operación.
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
        private void btnCancelarAf_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
