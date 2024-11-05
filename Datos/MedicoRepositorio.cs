using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MedicoRepositorio:Conexion
    {
        /// <summary>
        /// Inserta un nuevo médico en la base de datos.
        /// </summary>
        /// <param name="email_medico">Email del médico.</param>
        /// <param name="nombre">Nombre del médico.</param>
        /// <param name="apellido">Apellido del médico.</param>
        /// <param name="especialidad">Especialidad médica.</param>
        /// <param name="numero_matricula">Número de matrícula profesional.</param>
        /// <param name="telefono">Número de teléfono del médico.</param>
        /// <param name="creado_por">Nombre del usuario que crea el registro.</param>
        public void InsertarMedico(string email_medico, string nombre, string apellido, string especialidad, string numero_matricula, string telefono, string creado_por)
        {
            using (var conexion = GetConnection())
            {
                string query = "INSERT INTO medico (email_medico, nombre, apellido, especialidad, numero_matricula, telefono, creado_el, creado_por)" +
                    "VALUES (@email_medico, @nombre, @apellido, @especialidad, @numero_matricula, @telefono, @creado_el, @creado_por)";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@email_medico", email_medico);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@especialidad", especialidad);
                    cmd.Parameters.AddWithValue("@numero_matricula", numero_matricula);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@creado_el", DateTime.Now);
                    cmd.Parameters.AddWithValue("@creado_por", creado_por);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Obtiene todos los médicos activos (no dados de baja) de la base de datos.
        /// </summary>
        /// <returns>Un <see cref="DataTable"/> con los registros de médicos activos.</returns>
        public DataTable ObtenerTodosMedicos()
        {
            using (var conexion = GetConnection())
            {
                string query = "SELECT email_medico, nombre, apellido, especialidad, numero_matricula, telefono FROM medico WHERE bajaLogica=0;";

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
        /// Obtiene los datos de un médico específico por su email.
        /// </summary>
        /// <param name="email_medico">Email del médico a buscar.</param>
        /// <returns>Un objeto <see cref="Medico"/> con los datos del médico o <c>null</c> si no se encontró.</returns>
        public Medico ObtenerMedicoPorEmail(string email_medico)
        {
            Medico medico = null;

            using (var conexion = GetConnection())
            {
                string query = "SELECT email_medico, nombre, apellido, especialidad, numero_matricula, telefono, bajaLogica FROM medico WHERE email_medico = @email_medico AND bajaLogica = 0";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@email_medico", email_medico);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            medico = new Medico
                            {
                                email_medico = reader["email_medico"].ToString(),
                                nombre = reader["nombre"].ToString(),
                                apellido = reader["apellido"].ToString(),
                                especialidad= reader["especialidad"].ToString(),
                                numero_matricula= reader["numero_matricula"].ToString(),
                                telefono= reader["telefono"].ToString(),
                                bajaLogica = Convert.ToBoolean(reader["bajaLogica"])
                            };
                        }
                        else
                        {
                            return null; // No se encontró ningún afiliado con ese número
                        }
                    }
                }
            }

            return medico;
        }

        /// <summary>
        /// Realiza una baja lógica de un médico en la base de datos, marcándolo como inactivo.
        /// </summary>
        /// <param name="email_medico">Email del médico a dar de baja.</param>
        /// <returns><c>true</c> si la operación fue exitosa; de lo contrario, <c>false</c>.</returns>
        public bool DarBajaLogica(string email_medico)
        {
            using (var conexion = GetConnection())
            {
                string query = "UPDATE medico SET bajaLogica = 1, eliminado_el = @eliminado_el WHERE email_medico = @email_medico ";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@email_medico", email_medico);
                    cmd.Parameters.AddWithValue("@eliminado_el", DateTime.Now);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Obtiene una lista de médicos filtrada por nombre o apellido.
        /// </summary>
        /// <param name="nombre">Nombre o apellido del médico para filtrar la búsqueda (opcional).</param>
        /// <returns>Un <see cref="DataTable"/> con los registros de médicos que coinciden con el filtro especificado.</returns>
        public DataTable ObtenerMedicos(string nombre)
        {
            string query = "SELECT email_medico, nombre, apellido, especialidad, numero_matricula, telefono FROM medico WHERE bajaLogica = 0";

            if (!string.IsNullOrEmpty(nombre))
            {
                query += " AND (nombre LIKE @nombre OR apellido LIKE @nombre)";
            }

            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(nombre))
                    {
                        cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                    }

                    if (!string.IsNullOrEmpty(nombre))
                    {
                        cmd.Parameters.AddWithValue("@apellido", "%" + nombre + "%");
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los médicos de la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Medico"/> con los datos de cada médico.</returns>
        public List<Medico> ObtenerTodosLosMedicos()
        {
            List<Medico> medicos= new List<Medico>();

            using (var conexion = GetConnection())
            {
                string query = "SELECT email_medico, nombre, apellido, especialidad, numero_matricula, telefono FROM medico";

                using (var cmd = new MySqlCommand(query, conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medicos.Add(new Medico
                        {
                            email_medico = reader["email_medico"].ToString(),
                            nombre= reader["nombre"].ToString(),
                            apellido= reader["apellido"].ToString(),
                            especialidad= reader["especialidad"].ToString(),
                            numero_matricula= reader["numero_matricula"].ToString(),
                            telefono = reader["telefono"].ToString()
                        });
                    }
                }
            }

            return medicos;
        }

        /// <summary>
        /// Actualiza los datos de un médico en la base de datos.
        /// </summary>
        /// <param name="email_medico">Email del médico a actualizar.</param>
        /// <param name="nombre">Nuevo nombre del médico.</param>
        /// <param name="apellido">Nuevo apellido del médico.</param>
        /// <param name="especialidad">Nueva especialidad del médico.</param>
        /// <param name="numero_matricula">Nuevo número de matrícula del médico.</param>
        /// <param name="telefono">Nuevo teléfono del médico.</param>
        /// <returns><c>true</c> si la actualización fue exitosa; de lo contrario, <c>false</c>.</returns>
        public bool ActualizarMedico(string email_medico, string nombre, string apellido, string especialidad, string numero_matricula, string telefono)
        {
            using (MySqlConnection conexion = GetConnection())
            {
                string query = "UPDATE medico SET email_medico = @email_medico, nombre = @nombre, apellido = @apellido, especialidad = @especialidad, numero_matricula = @numero_matricula, telefono = @telefono WHERE email_medico = @email_medico AND bajaLogica = 0";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@email_medico", email_medico);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@especialidad", especialidad);
                    cmd.Parameters.AddWithValue("@numero_matricula", numero_matricula);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@actualizado_el", DateTime.Now);


                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
        }
    }
    
}
