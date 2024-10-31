using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa a un afiliado en el sistema.
    /// Contiene información personal y de contacto del afiliado,
    /// así como detalles sobre su estado en el sistema.
    /// </summary>
    public class Afiliado
    {
        public string numero_afiliado{ get; set;  }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string domicilio { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public DateTime? creado_el { get; set; }
        public DateTime? actualizado_el { get; set; }
        public DateTime? eliminado_el { get; set; }
        public Usuario creado_por { get; set; }
        public bool bajaLogica { get; set; }
        
    }
}

