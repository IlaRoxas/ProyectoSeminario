using Obra_Social_G1;
using System;
using System.Windows.Forms;
using Infraestructura;
namespace Presentacion
{
    public partial class Login : Form
    {
        private Logica.Usuario usuario;

        public Login()
        {
            InitializeComponent();
            usuario = new Logica.Usuario();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {            
            string mail = txtMail.Text.Trim();
            string password = txtContrasenia.Text.Trim();

            string mensaje;

            if(usuario.Login(mail, password, out mensaje)) 
            {
                Sesion.UsuarioActivo = mail;
                frmInicio formInicio = new frmInicio();
                formInicio.Show();
                //Ocultar o cerrar el formulario de inicio de sesión
                this.Hide();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
            
        }

        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
            txtContrasenia.UseSystemPasswordChar = true;
        }
    }
}
