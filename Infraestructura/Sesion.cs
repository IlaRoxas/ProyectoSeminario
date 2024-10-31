using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    /// <summary>
    /// Clase estática que representa la sesión del usuario activo en la aplicación.
    /// </summary>
    public static class Sesion
    {
        public static string UsuarioActivo { get; set; }
    }
}
