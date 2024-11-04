using MySql.Data.MySqlClient;
using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Datos
{
    public class AfiliadoRepositorio : Conexion
    {
        /// <summary>
        /// Inserta un nuevo afiliado en la base de datos con los datos proporcionados.
        /// </summary>
        /// <param name="nombre">Nombre del afiliado.</param>
        /// <param name="apellido">Apellido del afiliado.</param>
        /// <param name="telefono">Teléfono del afiliado. Debe contener solo números.</param>
        /// <param name="domicilio">Domicilio del afiliado.</param>
        /// <param name="email">Correo electrónico del afiliado en un formato válido.</param>
        /// <param name="numero_afiliado">Número único del afiliado de 12 dígitos.</param>
        /// <param name="creado_por">Usuario que creó el registro.</param>
        /// <exception cref="MySqlException">Lanza una excepción si ocurre un error de conexión con la base de datos.</exception>
        /// <remarks>
        /// El campo <c>creado_el</c> se establece automáticamente con la fecha y hora actuales.
        /// </remarks>
        public void InsertarAfiliado(string nombre, string apellido, string telefono, string domicilio, string email, string numero_afiliado, string creado_por)
        {
            using (var conexion = GetConnection())
            {
                string query = "INSERT INTO afiliado (nombre, apellido, telefono, domicilio, email, numero_afiliado, creado_el, creado_por)" +
                    "VALUES (@nombre, @apellido, @telefono, @domicilio, @email, @numero_afiliado, @creado_el, @creado_por)";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre",nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@domicilio", domicilio);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@numero_afiliado", numero_afiliado);
                    cmd.Parameters.AddWithValue("@creado_el", DateTime.Now);
                    cmd.Parameters.AddWithValue("@creado_por", creado_por);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Obtiene un afiliado de la base de datos según su número de afiliado.
        /// </summary>
        /// <param name="numeroAfiliado">El número de afiliado único para identificar al afiliado.</param>
        /// <returns>
        /// Un objeto <see cref="Afiliado"/> con los datos del afiliado correspondiente si se encuentra en la base de datos;
        /// de lo contrario, retorna <c>null</c>.
        /// </returns>
        /// <exception cref="MySqlException">Lanza una excepción si ocurre un error al conectar con la base de datos.</exception>
        /// <remarks>
        /// Este método busca el afiliado en la tabla <c>afiliado</c> utilizando el <paramref name="numeroAfiliado"/> como filtro.
        /// La propiedad <c>bajaLogica</c> indica si el afiliado ha sido dado de baja.
        /// </remarks>
        public Afiliado ObtenerAfiliadoPorNumero(string numeroAfiliado)
        {
            Afiliado afiliado = null;

            using (var conexion = GetConnection())
            {
                string query = "SELECT * FROM afiliado WHERE numero_afiliado = @numero_afiliado";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@numero_afiliado", numeroAfiliado);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            afiliado = new Afiliado
                            {
                                numero_afiliado = reader["numero_afiliado"].ToString(),
                                nombre = reader["nombre"].ToString(),
                                apellido = reader["apellido"].ToString(),
                                telefono = reader["telefono"].ToString(),
                                domicilio = reader["domicilio"].ToString(),
                                email = reader["email"].ToString(),
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

            return afiliado;
        }

        /// <summary>
        /// Realiza una baja lógica de un afiliado en la base de datos, marcando el campo <c>bajaLogica</c> como <c>1</c> y estableciendo la fecha de eliminación.
        /// </summary>
        /// <param name="numeroAfiliado">El número de afiliado que se dará de baja.</param>
        /// <returns>
        /// <c>true</c> si la baja lógica se realiza correctamente (es decir, si se actualiza al menos una fila); 
        /// de lo contrario, <c>false</c>.
        /// </returns>
        /// <exception cref="MySqlException">Lanza una excepción si ocurre un error al conectar o actualizar la base de datos.</exception>
        /// <remarks>
        /// Este método marca el registro del afiliado como dado de baja al actualizar el campo <c>bajaLogica</c> a <c>1</c> 
        /// y establece el campo <c>eliminado_el</c> con la fecha y hora actuales.
        /// </remarks>
        public bool DarBajaLogica(string numeroAfiliado)
        {
            using (var conexion = GetConnection())
            {
                string query = "UPDATE afiliado SET bajaLogica = 1, eliminado_el = @eliminado_el WHERE numero_afiliado = @numero_afiliado";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@numero_afiliado", numeroAfiliado);
                    cmd.Parameters.AddWithValue("@eliminado_el", DateTime.Now);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Obtiene un <c>DataTable</c> con la información de todos los afiliados activos (no dados de baja) de la base de datos.
        /// </summary>
        /// <returns>
        /// Un <c>DataTable</c> que contiene los datos de afiliados activos, incluyendo los campos: <c>numero_afiliado</c>, <c>nombre</c>, <c>apellido</c>, <c>domicilio</c>, <c>telefono</c>, y <c>email</c>.
        /// </returns>
        /// <exception cref="MySqlException">Lanza una excepción si ocurre un error al conectar o consultar la base de datos.</exception>
        /// <remarks>
        /// Este método filtra solo aquellos afiliados que tienen el campo <c>bajaLogica</c> establecido en <c>0</c>, 
        /// indicando que están activos.
        /// </remarks>
        public DataTable ObtenerTodosAfiliados()
        {
            using (var conexion = GetConnection())
            {
                string query = "SELECT numero_afiliado, nombre, apellido, domicilio, telefono, email FROM afiliado WHERE bajaLogica=0;";  

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
        /// Actualiza la información de un afiliado en la base de datos.
        /// </summary>
        /// <param name="numero_afiliado">El número de afiliado que se va a actualizar.</param>
        /// <param name="nombre">El nuevo nombre del afiliado.</param>
        /// <param name="apellido">El nuevo apellido del afiliado.</param>
        /// <param name="domicilio">El nuevo domicilio del afiliado.</param>
        /// <param name="telefono">El nuevo número de teléfono del afiliado.</param>
        /// <param name="email">El nuevo correo electrónico del afiliado.</param>
        /// <returns>
        /// <c>true</c> si la actualización fue exitosa; de lo contrario, <c>false</c>.
        /// </returns>
        /// <exception cref="MySqlException">Lanza una excepción si ocurre un error al conectar o actualizar la base de datos.</exception>
        /// <remarks>
        /// Este método actualiza los campos <c>nombre</c>, <c>apellido</c>, <c>domicilio</c>, <c>telefono</c> y <c>email</c> 
        /// del afiliado especificado por <c>numero_afiliado</c>. Si la actualización es exitosa, se devuelve <c>true</c>, 
        /// de lo contrario, se devuelve <c>false</c>.
        /// </remarks>
        public bool ActualizarAfiliado(string numero_afiliado, string nombre, string apellido, string domicilio, string telefono, string email)
        {
            using (MySqlConnection conexion =GetConnection())
            {
                string query = "UPDATE afiliado SET nombre = @nombre, apellido = @apellido, domicilio = @domicilio, telefono = @telefono, email = @email WHERE numero_afiliado = @numero_afiliado and bajaLogica = 0";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@numero_afiliado", numero_afiliado);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@domicilio", domicilio);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@actualizado_el", DateTime.Now);

                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los afiliados desde la base de datos.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="Afiliado"/> que representan a todos los afiliados.
        /// </returns>
        /// <exception cref="MySqlException">Lanza una excepción si ocurre un error al conectar a la base de datos o al ejecutar la consulta.</exception>
        /// <remarks>
        /// Este método recupera todos los afiliados de la tabla <c>afiliado</c> en la base de datos, 
        /// incluyendo su <c>numero_afiliado</c>, <c>nombre</c>, <c>apellido</c>, <c>domicilio</c>, 
        /// <c>telefono</c> y <c>email</c>. Si no se encuentran afiliados, se devuelve una lista vacía.
        /// </remarks>
        public List<Afiliado> ObtenerTodosLosAfiliados()
        {
            List<Afiliado> afiliados = new List<Afiliado>();

            using (var conexion = GetConnection())
            {
                string query = "SELECT numero_afiliado, nombre, apellido, domicilio, telefono, email FROM afiliado WHERE bajaLogica = 0";

                using (var cmd = new MySqlCommand(query, conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        afiliados.Add(new Afiliado
                        {
                            numero_afiliado = reader["numero_afiliado"].ToString(),
                            nombre = reader["nombre"].ToString(),
                            apellido = reader["apellido"].ToString(),
                            domicilio = reader["domicilio"].ToString(),
                            telefono = reader["telefono"].ToString(),
                            email = reader["email"].ToString(),
                        });
                    }
                }
            }

            return afiliados;
        }


        public DataTable ObtenerAfiliados(string nombre)
        {
            string query = "SELECT numero_afiliado, nombre, apellido, domicilio, telefono, email FROM afiliado WHERE bajaLogica = 0";

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
    }
}
