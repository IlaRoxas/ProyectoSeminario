using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Afiliado : Conexion
    {
        public void InsertarAfiliado(string nombre, string apellido, string telefono, string domicilio, string email, string numero_afiliado, string creado_por)
        {
            using (var conexion = GetConnection())
            {
                string query = "INSERT INTO afiliado (nombre, apellido, telefono, domicilio, email, numero_afiliado, creado_el, creado_por)" +
                    "VALUES (@nombre, @apellido, @telefono, @domicilio, @email, @numero_afiliado, @creado_el, @creado_por)";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    //Agregar parámetros
                    cmd.Parameters.AddWithValue("@nombre",nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@domicilio", domicilio);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@numero_afiliado", numero_afiliado);
                    cmd.Parameters.AddWithValue("@creado_el", DateTime.Now);
                    cmd.Parameters.AddWithValue("@creado_por", creado_por);

                    //Ejecutar la inserción
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
