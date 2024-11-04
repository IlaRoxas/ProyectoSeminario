﻿using Entidades;
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
    public partial class ModificacionMedico : Form
    {
        MedicoLogica logicaMedico;
        public ModificacionMedico()
        {
            InitializeComponent();
            logicaMedico=new MedicoLogica();
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

        private void ModificacionMedico_Load(object sender, EventArgs e)
        {
            string mensaje;
            DataTable medicos = logicaMedico.ObtenerMedicos(out mensaje);

            if (medicos != null)
            {
                dgvListaMedicos.DataSource = medicos;
            }
            else
            {
                MessageBox.Show(mensaje, "Error al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarCl_Click(object sender, EventArgs e)
        {
            string mensaje;
            bool resultado = logicaMedico.ActualizarMedico(
                txtEmailMed.Text.Trim(),
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                comboBox1.Text.Trim(),
                txtNM.Text.Trim(),
                txtTelefono.Text.Trim(),
                out mensaje
                );
            if (resultado)
            {
                MessageBox.Show(mensaje, "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatosMedicos();//Recarga datos para reflejar los cambios en el dgv

            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarDatosMedicos()
        {
            List<Medico> medicos = logicaMedico.ObtenerTodosLosMedicos(); // Este método debe obtener todos los afiliados de la base de datos.
            dgvListaMedicos.DataSource = medicos;
            dgvListaMedicos.Columns["creado_por"].Visible = false;
            dgvListaMedicos.Columns["creado_el"].Visible = false;
            dgvListaMedicos.Columns["eliminado_el"].Visible = false;
            dgvListaMedicos.Columns["actualizado_el"].Visible = false;
            dgvListaMedicos.Columns["bajaLogica"].Visible = false;
        }

        private void btnBuscarNA_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarNA.Text.Trim();
            DataTable dt = logicaMedico.ObtenerMedicosFiltrados(nombre);
            dgvListaMedicos.DataSource = dt;
        }
    }
}