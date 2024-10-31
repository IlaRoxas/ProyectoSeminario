using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
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
        

    }
}
