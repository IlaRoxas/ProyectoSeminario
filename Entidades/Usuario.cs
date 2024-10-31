using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa a un usuario en el sistema.
    /// Contiene información personal y de autenticación del usuario,
    /// así como detalles sobre su estado de acceso.
    /// </summary>
    public class Usuario
    {
            public string email_usuario { get; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string contrasenia { get; set; }
            public int intentos_fallidos { get; set; }
            public bool bloqueado { get; set; }
            public DateTime? fecha_bloqueo { get; set; }

    }
}
