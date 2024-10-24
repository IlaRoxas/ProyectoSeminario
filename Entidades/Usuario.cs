using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
            public string email_usuario { get; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string contrasenia { get; set; }
            public int intentos_fallidos { get; set; }
            public bool bloqueado { get; set; }
            public DateTime? fecha_bloqueo { get; set; }
        
        /*
            public int IdUsuario { get; }
            public DateTime FechaAlta { get; set; }
            public string NombreUsuario { get; set; }
            public string Password { get; set; }
            public int IdPersona { get; set; }
            public DateTime FechaCaducidadPassword { get; set; }
            public DateTime? FechaBaja { get; set; }
            public bool FlagBloqueado { get; set; }
            public int QIntentosFallidosLogin { get; set; }
            public bool FlagBajaLogica { get; set; }

            public Roles Rol { get; set; }
        */

    }
}
