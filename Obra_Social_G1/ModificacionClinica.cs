using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Obra_Social_G1
{
    public partial class ModificacionClinica : Form
    {
        private ClinicaLogica logicaClinica;

        public ModificacionClinica()
        {
            InitializeComponent();
            logicaClinica=new ClinicaLogica();
        }

        /// <summary>
        /// Manejador del evento que se activa al cargar el formulario.
        /// Carga la lista de clínicas en el DataGridView desde la base de datos.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void ModificacionClinica_Load(object sender, EventArgs e)
        {
            string mensaje;
            DataTable clinicas = logicaClinica.ObtenerClinicas(out mensaje);

            if (clinicas != null)
            {
                dgvListaClinicas.DataSource = clinicas;
            }
            else
            {
                MessageBox.Show(mensaje, "Error al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador del evento que se activa cuando cambia la selección en el DataGridView de clínicas.
        /// Actualiza los campos de texto con la información de la clínica seleccionada.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void dgvListaClinicas_SelectionChanged(object sender, EventArgs e)
        {
            txtRazonSocialCl.Text = Convert.ToString(dgvListaClinicas.CurrentRow.Cells["razon_social"].Value);
            txtDireccionCl.Text = Convert.ToString(dgvListaClinicas.CurrentRow.Cells["direccion"].Value);
            txtTelefonoCl.Text = Convert.ToString(dgvListaClinicas.CurrentRow.Cells["telefono"].Value);
            cbTipoClinica.Text = Convert.ToString(dgvListaClinicas.CurrentRow.Cells["tipo_clinica"].Value);
        }

        /// <summary>
        /// Manejador del evento que se activa al hacer clic en el botón de modificar clínica.
        /// Actualiza la información de la clínica seleccionada en la base de datos.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnModificarCl_Click(object sender, EventArgs e)
        {
            string mensaje;
            bool resultado = logicaClinica.ActualizarClinica(
                txtRazonSocialCl.Text.Trim(),
                txtDireccionCl.Text.Trim(),
                txtTelefonoCl.Text.Trim(),
                cbTipoClinica.Text.Trim(),
                out mensaje
                );
            if (resultado)
            {
                MessageBox.Show(mensaje, "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatosClinicas();//Recarga datos para reflejar los cambios en el dgv

            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga la lista de todas las clínicas en el DataGridView, excluyendo algunos de sus atributos.
        /// </summary>
        private void CargarDatosClinicas()
        {
            List<Clinica> clinicas= logicaClinica.ObtenerTodasLasClinicas(); // Este método debe obtener todos los afiliados de la base de datos.
            dgvListaClinicas.DataSource = clinicas;
            dgvListaClinicas.Columns["creada_por"].Visible = false;
            dgvListaClinicas.Columns["creada_el"].Visible = false;
            dgvListaClinicas.Columns["eliminada_el"].Visible = false;
            dgvListaClinicas.Columns["actualizada_el"].Visible = false;
            dgvListaClinicas.Columns["bajaLogica"].Visible = false;
        }


        /// <summary>
        /// Manejador del evento que se activa al hacer clic en el botón de buscar clínicas.
        /// Filtra las clínicas por razón social y tipo de clínica, mostrando los resultados en el DataGridView.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnBuscarGral_Click(object sender, EventArgs e)
        {
            string razonSocial = txtBuscarRS.Text.Trim();
            string tipoClinica = txtBuscarTP.Text.Trim();
            DataTable dt = logicaClinica.ObtenerClinicasFiltradas(razonSocial, tipoClinica);
            dgvListaClinicas.DataSource= dt;
        }

        /// <summary>
        /// Manejador del evento que se activa al hacer clic en el botón de cancelar.
        /// Cierra el formulario de modificación de clínica.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCancelarCl_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
