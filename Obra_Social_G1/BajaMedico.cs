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
    public partial class BajaMedico : Form
    {
        Logica.MedicoLogica medicoLogica;
        public BajaMedico()
        {
            InitializeComponent();
            medicoLogica=new Logica.MedicoLogica();
        }

        private void dgvListaMedicos_SelectionChanged(object sender, EventArgs e)
        {
            txtEmailMed.Text = Convert.ToString(dgvListaMedicos.CurrentRow.Cells["email_medico"].Value);
            txtNombre.Text = Convert.ToString(dgvListaMedicos.CurrentRow.Cells["nombre"].Value);
            txtApellido.Text = Convert.ToString(dgvListaMedicos.CurrentRow.Cells["apellido"].Value);
            comboBox1.Text = Convert.ToString(dgvListaMedicos.CurrentRow.Cells["especialidad"].Value);
            txtNM.Text = Convert.ToString(dgvListaMedicos.CurrentRow.Cells["numero_matricula"].Value);
            txtTelefono.Text = Convert.ToString(dgvListaMedicos.CurrentRow.Cells["telefono"].Value);
        }

        private void BajaMedico_Load(object sender, EventArgs e)
        {
            string mensaje;
            DataTable medicos = medicoLogica.ObtenerMedicos(out mensaje);

            if (medicos != null)
            {
                dgvListaMedicos.DataSource = medicos;
            }
            else
            {
                MessageBox.Show(mensaje, "Error al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarMed_Click(object sender, EventArgs e)
        {
            string email_medico = txtEmailMed.Text.Trim();
            string mensaje;
            // Validar si el campo no está vacío

            if (string.IsNullOrEmpty(email_medico))
            {
                MessageBox.Show("Por favor, indique un nombre.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar la clinica en la base de datos
            Medico medico = medicoLogica.ObtenerMedico(email_medico, out mensaje);


            if (medico != null)
            {
                // Confirmación para dar de baja
                var confirmacion = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar a {medico.nombre} {medico.apellido} ({medico.numero_matricula})?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    // Intentar dar de baja al afiliado
                    if (medicoLogica.DarDeBajaMedico(email_medico, out mensaje))
                    {
                        MessageBox.Show("Médico dado de baja correctamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarTextBoxes();
                        ActualizarMedicosActivos(); // Actualiza el DataGridView

                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(mensaje, "Médico no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
        private void ActualizarMedicosActivos()
        {
            string mensaje;
            var medicosActivos = medicoLogica.ObtenerMedicos(out mensaje);

            if (medicosActivos != null)
            {
                dgvListaMedicos.DataSource = medicosActivos;
            }
            else
            {
                MessageBox.Show(mensaje, "Error al obtener médicos activos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnBuscarNA_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarNA.Text.Trim();
            DataTable dt = medicoLogica.ObtenerMedicosFiltrados(nombre);
            dgvListaMedicos.DataSource = dt;
        }
    }
}
