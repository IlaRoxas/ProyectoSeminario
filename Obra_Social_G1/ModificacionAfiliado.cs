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
    public partial class ModificacionAfiliado : Form
    {
        private AfiliadoLogica afiliadoLogica;

        public ModificacionAfiliado()
        {
            InitializeComponent();
            afiliadoLogica = new AfiliadoLogica();
        }

        private void ModificacionAfiliado_Load(object sender, EventArgs e)
        {
            string mensaje;
            DataTable afiliados = afiliadoLogica.ObtenerAfiliados(out mensaje);

            if (afiliados != null)
            {
                dgvListaAfiliados.DataSource = afiliados; 
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

        private void btnModificarAf_Click(object sender, EventArgs e)
        {
            string mensaje;
            bool resultado = afiliadoLogica.ActualizarAfiliado(
                txtNroAf.Text.Trim(),
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                txtDomicilio.Text.Trim(),
                txtTelefono.Text.Trim(),
                txtEmail.Text.Trim(),
                out mensaje
                );
            if (resultado)
            {
                MessageBox.Show(mensaje, "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatosAfiliados();//Recarga datos para reflejar los cambios en el dgv

            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void CargarDatosAfiliados()
        {
            List<Afiliado> afiliados = afiliadoLogica.ObtenerTodosLosAfiliados(); // Este método debe obtener todos los afiliados de la base de datos.
            dgvListaAfiliados.DataSource = afiliados;
        }
    }
}
