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
    public partial class BajaClinica : Form
    {
        private ClinicaLogica logicaClinica;
        public BajaClinica()
        {
            InitializeComponent();
            logicaClinica = new ClinicaLogica();
        }
        private void BajaClinica_Load(object sender, EventArgs e)
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

        private void btnEliminarCl_Click(object sender, EventArgs e)
        {
            string razon_social = txtRazonSocialCl.Text.Trim();
            string mensaje;
            // Validar si el campo no está vacío

            if (string.IsNullOrEmpty(razon_social))
            {
                MessageBox.Show("Por favor, indique una clínica.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar la clinica en la base de datos
            Clinica clinica= logicaClinica.ObtenerClinica(razon_social, out mensaje);


            if (clinica != null)
            {
                // Confirmación para dar de baja
                var confirmacion = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar a {clinica.razon_social} {clinica.direccion} ({clinica.tipo_clinica})?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    // Intentar dar de baja al afiliado
                    if (logicaClinica.DarDeBajaClinica(razon_social, out mensaje))
                    {
                        MessageBox.Show("Clínica dada de baja correctamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarTextBoxes();
                        ActualizarClinicasActivas(); // Actualiza el DataGridView

                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(mensaje, "Clinica no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void ActualizarClinicasActivas()
        {
            string mensaje;
            var clinicasActivas = logicaClinica.ObtenerClinicas(out mensaje);

            if (clinicasActivas != null)
            {
                dgvListaClinicas.DataSource = clinicasActivas;
            }
            else
            {
                MessageBox.Show(mensaje, "Error al obtener clínicas activas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarGral_Click(object sender, EventArgs e)
        {
            string razonSocial = txtBuscarRS.Text.Trim();
            string tipoClinica = txtBuscarTP.Text.Trim();
            DataTable dt = logicaClinica.ObtenerClinicasFiltradas(razonSocial, tipoClinica);
            dgvListaClinicas.DataSource = dt;
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
    }
}
