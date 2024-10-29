﻿using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pqc.Crypto.Bike;
using System;


namespace Datos
{
    public class Usuario : Conexion
    {
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
        /// Consulta si el usuario está bloqueado a través de su email
        /// </summary> 
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
        // Método para obtener la cantidad de intentos fallidos
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
        // Método para incrementar los intentos fallidos
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
        // Método para bloquear un usuario
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