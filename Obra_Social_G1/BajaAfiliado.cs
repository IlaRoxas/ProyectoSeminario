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
        private void dgvListaAfiliados_SelectionChanged(object sender, EventArgs e)
        {
            txtNroAf.Text = Convert.ToString(dgvListaAfiliados.CurrentRow.Cells["numero_afiliado"].Value);
            txtNombre.Text = Convert.ToString(dgvListaAfiliados.CurrentRow.Cells["nombre"].Value);
            txtApellido.Text = Convert.ToString(dgvListaAfiliados.CurrentRow.Cells["apellido"].Value);
            txtDomicilio.Text = Convert.ToString(dgvListaAfiliados.CurrentRow.Cells["domicilio"].Value);
            txtTelefono.Text = Convert.ToString(dgvListaAfiliados.CurrentRow.Cells["telefono"].Value);
            txtEmail.Text = Convert.ToString(dgvListaAfiliados.CurrentRow.Cells["email"].Value);

        }
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
        private void btnBuscarNA_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarNA.Text.Trim();
            DataTable dt = afiliadoLogica.ObtenerAfiliadosFiltrados(nombre);
            dgvListaAfiliados.DataSource = dt;
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
