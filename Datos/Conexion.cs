using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public abstract class Conexion
    {
        
        private readonly string conexionString;
        private string server = "localhost";
        private string database = "obra_social_g1";
        private string user = "root";
        private string password = "ramonaypumba";


        public Conexion()
        {
            conexionString = $"Server={server}; Database={database}; Uid={user}; Pwd={password};";
        }
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
