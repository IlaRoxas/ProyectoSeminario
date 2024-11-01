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


    }
}
