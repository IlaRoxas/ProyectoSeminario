using System;
using Logica;
using System.Windows.Forms;

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
                MessageBox.Show("Inicio de sesión exitoso");
            }
            else
            {
                MessageBox.Show(mensaje);
            }
            
        }
    }
}
