using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa a un médico dentro del sistema.
    /// </summary>
    public class Medico
    {
        public string email_medico { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string especialidad { get; set; }
        public string numero_matricula { get; set; }
        public string telefono { get; set; }
        public DateTime? creado_el { get; set; }
        public DateTime? actualizado_el { get; set; }
        public DateTime? eliminado_el { get; set; }
        public Usuario creado_por { get; set; }
        public bool bajaLogica { get; set; }
    }
}
