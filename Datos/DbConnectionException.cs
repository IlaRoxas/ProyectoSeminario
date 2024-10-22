using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DbConnectionException:Exception
    {
        // Constructor por defecto
        public DbConnectionException()
            : base("Error al conectar con la base de datos.")
        {
        }

        // Constructor que recibe un mensaje personalizado
        public DbConnectionException(string message)
            : base(message)
        {
        }

        // Constructor que recibe un mensaje y una excepción interna
        public DbConnectionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
