using Datos;
using System;

namespace Logica
{
    public class Usuario
    {
        private Datos.Usuario usuario;

        public Usuario()
        {
            usuario = new Datos.Usuario();
        }

        public bool Login(string email_usuario, string contrasenia, out string mensaje)
        {
            // Validar campos vacíos
            if (string.IsNullOrEmpty(email_usuario) || string.IsNullOrEmpty(contrasenia))
            {
                mensaje = "Ingrese email y contraseña";
                return false;
            }
            try
            {
                //Preguntamos si el usuario está bloqueado
                if (usuario.EstaBloqueado(email_usuario) == true)
                {
                    mensaje = "Usuario bloqueado";
                    return false;

                }
                // Llamar al método de la capa de datos para el login
                if (usuario.Login(email_usuario, contrasenia))
                {
                    usuario.RestaurarQItntentosFallidos(email_usuario);

                    mensaje = "Inicio de sesión exitoso";
                    return true;
                }
                else
                {
                    usuario.IncrementarIntentosFallidos(email_usuario);
                    int intentosFallidos = usuario.QintentosFallidosLogin(email_usuario);

                    if (intentosFallidos >= 4){
                        usuario.BloquearUsuario(email_usuario);
                        mensaje = "Usuario bloqueado debido a múltiples intentos fallidos";
                    }
                    else
                    {
                        mensaje = "Usuario o contraseña incorrectos";
                    }
                    return false;
                }
            }
            catch (DbConnectionException ex)
            {
                mensaje = $"Error de conexión a la base de datos: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                mensaje = $"Error desconocido: {ex.Message}";
                return false;
            }
        }
    }
}

