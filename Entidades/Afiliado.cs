﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public  class Afiliado
    {
        public int numero_afiliado{ get; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string domicilio { get; set; }
        public int teléfono { get; set; }
        public string email { get; set; }
        public DateTime? creado_el { get; set; }
        public DateTime? actualizado_el { get; set; }
        public DateTime? eliminado_el { get; set; }
        public Usuario creado_por { get; set; }
        
    }
}

