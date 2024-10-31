using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pqc.Crypto.Bike;
using System;


namespace Datos
{
    public class Usuario : Conexion
    {
        /// <summary>
        /// Intenta iniciar sesión con el usuario especificado utilizando el correo electrónico y la contraseña.
        /// </summary>
        /// <param name="email_usuario">El correo electrónico del usuario que intenta iniciar sesión.</param>
        /// <param name="contrasenia">La contraseña del usuario que intenta iniciar sesión.</param>
        /// <returns>
        /// Un valor booleano que indica si el inicio de sesión fue exitoso (true) o no (false).
        /// </returns>
        /// <exception cref="DbConnectionException">
        /// Se lanza cuando hay un error al intentar realizar el login, 
        /// como problemas de conexión con la base de datos.
        /// </exception>
        public bool Login(string email_usuario, string contrasenia)
        {
            bool loginExitoso = false;

            using (var conexion = GetConnection())
            {

                string query = "SELECT COUNT(*) FROM usuario WHERE email_usuario = @email_usuario AND contrasenia = @contrasenia";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@email_usuario", email_usuario);
                    cmd.Parameters.AddWithValue("@contrasenia", contrasenia);

                    // Ejecutar el comando y verificar el resultado
                    try
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        loginExitoso = count > 0; // Si el conteo es mayor que 0, el login es exitoso
                    }
                    catch (MySqlException ex)
                    {
                        // Manejar errores relacionados con la base de datos
                        throw new DbConnectionException("Error al intentar realizar el login.", ex);
                    }
                }
            }
            return loginExitoso;
        }

        /// <summary>
        /// Verifica si el usuario con el correo electrónico especificado está bloqueado.
        /// </summary>
        /// <param name="email_usuario">El correo electrónico del usuario cuya información se está consultando.</param>
        /// <returns>
        /// Devuelve true si el usuario está bloqueado; de lo contrario, devuelve false.
        /// </returns>
        /// <exception cref="MySqlException">
        /// Se lanza cuando hay un error al intentar acceder a la base de datos.
        /// </exception> 
        public bool EstaBloqueado(string email_usuario)
        {
            try
            {
                using (MySqlConnection conexion = GetConnection())
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT bloqueado FROM usuario WHERE email_usuario = @email_usuario", conexion))
                    {
                        command.Parameters.AddWithValue("@email_usuario", email_usuario);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToBoolean(result);
                        }
                    }
                }
                return false;
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"Error en el método EstaBloqueado: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Obtiene el número de intentos fallidos de inicio de sesión del usuario especificado.
        /// </summary>
        /// <param name="email_usuario">El correo electrónico del usuario cuyo número de intentos fallidos se desea consultar.</param>
        /// <returns>
        /// Devuelve el número de intentos fallidos de inicio de sesión del usuario.
        /// </returns>
        /// <exception cref="DbConnectionException">
        /// Se lanza cuando hay un error al intentar acceder a la base de datos.
        /// </exception>
        public int QintentosFallidosLogin(string email_usuario)
        {
            int intentosFallidos = 0;
            using (var conexion = GetConnection())
            {
                string query = "SELECT intentos_fallidos FROM usuario WHERE email_usuario = @email_usuario";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@email_usuario", email_usuario);
                    try
                    {
                        intentosFallidos = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (MySqlException ex)
                    {
                        // Manejar errores relacionados con la base de datos
                        throw new DbConnectionException("Error al intentar obtener los intentos fallidos.", ex);
                    }
                }
            }
            return intentosFallidos;
        }

        /// <summary>
        /// Incrementa el contador de intentos fallidos de inicio de sesión para el usuario especificado.
        /// </summary>
        /// <param name="email_usuario">El correo electrónico del usuario cuyo contador de intentos fallidos se incrementará.</param>
        public void IncrementarIntentosFallidos(string email_usuario)
        {
            using (var conexion = GetConnection())
            {
                string query = "UPDATE usuario SET intentos_fallidos = intentos_fallidos + 1 WHERE email_usuario = @email_usuario";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@email_usuario", email_usuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Restaura el contador de intentos fallidos de inicio de sesión a cero para el usuario especificado.
        /// </summary>
        /// <param name="email_usuario">El correo electrónico del usuario cuyo contador de intentos fallidos se restaurará a cero.</param>
        public void RestaurarQItntentosFallidos(string email_usuario)
        {
            using (var conexion = GetConnection())
            {
                string query = "UPDATE usuario SET intentos_fallidos = 0 WHERE email_usuario = @email_usuario";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@email_usuario", email_usuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Bloquea al usuario especificado, impidiendo su inicio de sesión.
        /// </summary>
        /// <param name="email_usuario">El correo electrónico del usuario que se va a bloquear.</param>
        public void BloquearUsuario(string email_usuario)
        {
            using (var conexion = GetConnection())
            {
                string query = "UPDATE usuario SET bloqueado = TRUE WHERE email_usuario = @email_usuario";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@email_usuario", email_usuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
       
    }
}