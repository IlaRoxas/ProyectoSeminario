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

        /// <summary>
        /// Constructor de la clase <see cref="ModificacionAfiliado"/>.
        /// Inicializa los componentes de la interfaz y crea una nueva instancia de la clase <see cref="AfiliadoLogica"/>.
        /// </summary>
        public ModificacionAfiliado()
        {
            InitializeComponent();
            afiliadoLogica = new AfiliadoLogica();
        }

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario de modificación de afiliado.
        /// Carga la lista de afiliados en el control de DataGridView para su visualización.
        /// </summary>
        /// <param name="sender">El objeto que disparó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <remarks>
        /// Este método utiliza la capa de lógica para obtener la lista de afiliados activos y mostrarla en un control `DataGridView`.
        /// En caso de error al cargar los datos, muestra un mensaje de error.
        /// </remarks>
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

        /// <summary>
        /// Evento que se ejecuta cuando se cambia la selección de filas en el control DataGridView de afiliados.
        /// Actualiza los campos de texto con los datos del afiliado seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que disparó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <remarks>
        /// Este método utiliza los valores de la fila actualmente seleccionada en el `DataGridView`
        /// y los asigna a los controles de texto correspondientes para su visualización o edición.
        /// </remarks>
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
        /// Evento que se ejecuta al hacer clic en el botón de modificación de afiliado. 
        /// Actualiza los datos del afiliado seleccionado con la información ingresada en los campos de texto.
        /// </summary>
        /// <param name="sender">El objeto que disparó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        /// <remarks>
        /// Este método llama al método `ActualizarAfiliado` en la capa de lógica de afiliados,
        /// utilizando los valores de los campos de texto. Si la actualización es exitosa,
        /// muestra un mensaje de confirmación y recarga los datos en el `DataGridView` para reflejar los cambios.
        /// En caso de error, muestra un mensaje de error con la razón correspondiente.
        /// </remarks>
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

        /// <summary>
        /// Carga la lista de afiliados en el control DataGridView.
        /// Obtiene todos los afiliados de la base de datos y los asigna como fuente de datos
        /// del DataGridView, ocultando las columnas innecesarias para la visualización.
        /// </summary>
        /// <remarks>
        /// Este método llama al método `ObtenerTodosLosAfiliados` en la capa de lógica de afiliados,
        /// que recupera una lista de objetos `Afiliado`. Luego, establece esta lista como la fuente de datos
        /// del DataGridView `dgvListaAfiliados`. También oculta las columnas que no son relevantes para el usuario,
        /// como `creado_por`, `creado_el`, `eliminado_el`, `actualizado_el` y `bajaLogica`.
        /// </remarks>
        private void CargarDatosAfiliados()
        {
            List<Afiliado> afiliados = afiliadoLogica.ObtenerTodosLosAfiliados(); // Este método debe obtener todos los afiliados de la base de datos.
            dgvListaAfiliados.DataSource = afiliados;
            dgvListaAfiliados.Columns["creado_por"].Visible = false;
            dgvListaAfiliados.Columns["creado_el"].Visible = false;
            dgvListaAfiliados.Columns["eliminado_el"].Visible = false;
            dgvListaAfiliados.Columns["actualizado_el"].Visible = false;
            dgvListaAfiliados.Columns["bajaLogica"].Visible = false;
        }

        private void btnCancelarAf_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarNA_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarNA.Text.Trim();
            DataTable dt = afiliadoLogica.ObtenerAfiliadosFiltrados(nombre);
            dgvListaAfiliados.DataSource = dt;
        }
    }
}
