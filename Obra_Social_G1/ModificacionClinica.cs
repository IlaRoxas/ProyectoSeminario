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

        private void dgvListaClinicas_SelectionChanged(object sender, EventArgs e)
        {
            txtRazonSocialCl.Text = Convert.ToString(dgvListaClinicas.CurrentRow.Cells["razon_social"].Value);
            txtDireccionCl.Text = Convert.ToString(dgvListaClinicas.CurrentRow.Cells["direccion"].Value);
            txtTelefonoCl.Text = Convert.ToString(dgvListaClinicas.CurrentRow.Cells["telefono"].Value);
            cbTipoClinica.Text = Convert.ToString(dgvListaClinicas.CurrentRow.Cells["tipo_clinica"].Value);
        }

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

        private void btnBuscarGral_Click(object sender, EventArgs e)
        {
            string razonSocial = txtBuscarRS.Text.Trim();
            string tipoClinica = txtBuscarTP.Text.Trim();
            DataTable dt = logicaClinica.ObtenerClinicasFiltradas(razonSocial, tipoClinica);
            dgvListaClinicas.DataSource= dt;
        }

        private void btnCancelarCl_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
