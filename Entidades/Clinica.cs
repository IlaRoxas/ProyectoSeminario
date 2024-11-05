using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Representa una clínica dentro del sistema, con sus datos y estado de baja lógica.
    /// </summary>
    public class Clinica
    {
        public string razon_social { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string tipo_clinica { get; set; }
        public DateTime? creada_el { get; set; }
        public DateTime? actualizada_el { get; set; }
        public DateTime? eliminada_el { get; set; }
        public bool bajaLogica { get; set; }
        public Usuario creada_por { get; set; }
  
    }
}
