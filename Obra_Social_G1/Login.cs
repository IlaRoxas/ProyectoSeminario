using Obra_Social_G1;
using System;
using System.Windows.Forms;
using Infraestructura;
namespace Presentacion
{
    public partial class Login : Form
    {
        private Logica.Usuario usuario;

        /// <summary>
        /// Constructor de la clase <see cref="Login"/>.
        /// Inicializa los componentes de la interfaz y crea una nueva instancia de la clase <see cref="Logica.Usuario"/>.
        /// </summary>
        public Login()
        {
            InitializeComponent();
            usuario = new Logica.Usuario();
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón de iniciar sesión.
        /// Valida las credenciales del usuario e inicia la sesión si son correctas.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Argumentos del evento que contienen la información de la acción.</param>
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

        /// <summary>
        /// Evento que se dispara cuando el texto en el campo de contraseña cambia.
        /// Establece el carácter de contraseña del campo de texto para ocultar la entrada del usuario.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento (en este caso, el campo de texto de la contraseña).</param>
        /// <param name="e">Argumentos del evento que contienen la información sobre el cambio de texto.</param>
        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
            txtContrasenia.UseSystemPasswordChar = true;
        }
    }
}
