using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClinicaRepositorio:Conexion
    {
        /// <summary>
        /// Inserta una nueva clínica en la base de datos.
        /// </summary>
        /// <param name="razon_social">Razón social de la clínica.</param>
        /// <param name="direccion">Dirección de la clínica.</param>
        /// <param name="telefono">Número de teléfono de la clínica.</param>
        /// <param name="tipo_clinica">Tipo de clínica.</param>
        /// <param name="creado_por">Nombre del usuario que crea la clínica.</param>
        public void InsertarClinica(string razon_social, string direccion, string telefono, string tipo_clinica, string creado_por)
        {
            using (var conexion=GetConnection())
            {
                string query = "INSERT INTO clinica (razon_social, direccion, telefono, tipo_clinica, creado_por)"
                    + "VALUES (@razon_social, @direccion, @telefono, @tipo_clinica, @creado_por)";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@razon_social", razon_social);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@tipo_clinica", tipo_clinica);
                    cmd.Parameters.AddWithValue("@creado_por", creado_por);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Obtiene todas las clínicas activas (no dadas de baja) de la base de datos.
        /// </summary>
        /// <returns>Un <see cref="DataTable"/> con los registros de clínicas activas.</returns>
        public DataTable ObtenerTodasClinicas()
        {
            using (var conexion = GetConnection())
            {
                string query = "SELECT razon_social, direccion, telefono, tipo_clinica FROM clinica WHERE bajaLogica=0;";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        /// <summary>
        /// Actualiza los datos de una clínica en la base de datos.
        /// </summary>
        /// <param name="razon_social">Razón social de la clínica a actualizar.</param>
        /// <param name="direccion">Nueva dirección de la clínica.</param>
        /// <param name="telefono">Nuevo número de teléfono de la clínica.</param>
        /// <param name="tipo_clinica">Nuevo tipo de clínica.</param>
        /// <returns><c>true</c> si la actualización fue exitosa; de lo contrario, <c>false</c>.</returns>
        public bool ActualizarClinica(string razon_social, string direccion, string telefono, string tipo_clinica)
        {
            using (MySqlConnection conexion = GetConnection())
            {
                string query = "UPDATE clinica SET razon_social = @razon_social, direccion = @direccion, telefono = @telefono, tipo_clinica = @tipo_clinica WHERE razon_social = @razon_social";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@razon_social", razon_social);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@tipo_clinica", tipo_clinica);
                    cmd.Parameters.AddWithValue("@actualizada_el", DateTime.Now);

                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
        }

        /// <summary>
        /// Obtiene una lista de todas las clínicas de la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Clinica"/> con los datos de cada clínica.</returns>
        public List<Clinica> ObtenerTodasLasClinicas()
        {
            List<Clinica> clinicas = new List<Clinica>();

            using (var conexion = GetConnection())
            {
                string query = "SELECT razon_social, direccion, telefono, tipo_clinica FROM clinica";

                using (var cmd = new MySqlCommand(query, conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clinicas.Add(new Clinica
                        {
                            razon_social= reader["razon_social"].ToString(),
                            direccion = reader["direccion"].ToString(),
                            telefono = reader["telefono"].ToString(),
                            tipo_clinica = reader["tipo_clinica"].ToString()
                        });
                    }
                }
            }

            return clinicas;
        }

        /// <summary>
        /// Obtiene una lista de clínicas filtradas por razón social y/o tipo de clínica.
        /// </summary>
        /// <param name="razon_social">Razón social de la clínica para filtrar la búsqueda (opcional).</param>
        /// <param name="tipo_clinica">Tipo de clínica para filtrar la búsqueda (opcional).</param>
        /// <returns>Un <see cref="DataTable"/> con los registros de clínicas que coinciden con el filtro especificado.</returns>
        public DataTable ObtenerClinicas(string razon_social, string tipo_clinica)
        {
            string query = "SELECT razon_social, direccion, telefono, tipo_clinica FROM clinica WHERE bajaLogica = 0";
            List<string> condiciones = new List<string>();

            if (!string.IsNullOrEmpty(razon_social))
            {
                condiciones.Add("razon_social LIKE @razon_social");
            }

            if (!string.IsNullOrEmpty(tipo_clinica))
            {
                condiciones.Add("tipo_clinica LIKE @tipo_clinica");
            }

            if (condiciones.Count > 0)
            {
                query += " AND " + string.Join(" OR ", condiciones);
            }

            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(razon_social))
                    {
                        cmd.Parameters.AddWithValue("@razon_social", "%" + razon_social + "%");
                    }

                    if (!string.IsNullOrEmpty(tipo_clinica))
                    {
                        cmd.Parameters.AddWithValue("@tipo_clinica", "%" + tipo_clinica + "%");
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Obtiene los datos de una clínica específica por razón social.
        /// </summary>
        /// <param name="razon_social">Razón social de la clínica a buscar.</param>
        /// <returns>Un objeto <see cref="Clinica"/> con los datos de la clínica encontrada o <c>null</c> si no se encontró.</returns>
        public Clinica ObtenerClinicaPorRS(string razon_social)
        {
            Clinica clinica = null;

            using (var conexion = GetConnection())
            {
                string query = "SELECT razon_social, direccion, telefono, tipo_clinica, bajaLogica FROM clinica WHERE razon_social = @razon_social AND bajaLogica = 0";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@razon_social", razon_social);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            clinica = new Clinica
                            {
                                razon_social = reader["razon_social"].ToString(),
                                direccion = reader["direccion"].ToString(),
                                telefono = reader["telefono"].ToString(),
                                tipo_clinica = reader["tipo_clinica"].ToString(),
                                bajaLogica = Convert.ToBoolean(reader["bajaLogica"])
                            };
                        }
                        else
                        {
                            return null; // No se encontró ninguna clinica con esa razon social
                        }
                    }
                }
            }

            return clinica;
        }

        /// <summary>
        /// Realiza una baja lógica de una clínica en la base de datos, marcándola como inactiva.
        /// </summary>
        /// <param name="razon_social">Razón social de la clínica a dar de baja.</param>
        /// <returns><c>true</c> si la operación fue exitosa; de lo contrario, <c>false</c>.</returns>
        public bool DarBajaLogica(string razon_social)
        {
            using (var conexion = GetConnection())
            {
                string query = "UPDATE clinica SET bajaLogica = 1, eliminada_el = @eliminada_el WHERE razon_social = @razon_social";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@razon_social", razon_social);
                    cmd.Parameters.AddWithValue("@eliminada_el", DateTime.Now);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
