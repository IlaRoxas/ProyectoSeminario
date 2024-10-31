using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    /// <summary>
    /// Excepción personalizada que representa un error de conexión a la base de datos.
    /// </summary>
    public class DbConnectionException:Exception
    {
        /// <summary>
        /// Constructor por defecto que inicializa una nueva instancia de la clase <see cref="DbConnectionException"/>
        /// con un mensaje predeterminado.
        /// </summary>
        public DbConnectionException()
            : base("Error al conectar con la base de datos.")
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DbConnectionException"/> 
        /// con un mensaje de error especificado.
        /// </summary>
        /// <param name="message">El mensaje que describe el error.</param>
        public DbConnectionException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DbConnectionException"/> 
        /// con un mensaje de error especificado y una excepción interna.
        /// </summary>
        /// <param name="message">El mensaje que describe el error.</param>
        /// <param name="innerException">La excepción interna que causó esta excepción.</param>
        public DbConnectionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
