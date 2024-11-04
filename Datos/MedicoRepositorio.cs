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
