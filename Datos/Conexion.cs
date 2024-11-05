using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    /// <summary>
    /// Clase base abstracta para manejar la conexión a la base de datos.
    /// </summary>
    public abstract class Conexion
    {   
        private readonly string conexionString;
        private string server = "localhost";
        private string database = "obra_social_g1";
        private string user = "root";
        private string password = "ramonaypumba";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Conexion"/> y configura la cadena de conexión.
        /// </summary>
        public Conexion()
        {
            conexionString = $"Server={server}; Database={database}; Uid={user}; Pwd={password};";
        }

        /// <summary>
        /// Obtiene una conexión abierta a la base de datos.
        /// </summary>
        /// <returns>Una instancia abierta de <see cref="MySqlConnection"/>.</returns>
        /// <exception cref="DbConnectionException">
        /// Se lanza si ocurre un error al intentar abrir la conexión.
        /// </exception>
        protected MySqlConnection GetConnection()
        {
            MySqlConnection conexion = new MySqlConnection(conexionString);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (MySqlException ex)
            {
                // Lanza la excepción personalizada si ocurre un error al conectar
                throw new DbConnectionException("No se pudo establecer la conexión con la base de datos.", ex);
            }
        }
    }
}
