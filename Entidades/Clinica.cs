using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clinica
    {
        public string razon_social { get; }
        public string tipo_clinica { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public DateTime? creada_el { get; set; }
        public DateTime? actualizada_el { get; set; }
        public DateTime? eliminada_el { get; set; }
        public Usuario creada_por { get; set; }
  
    }
}
