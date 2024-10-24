﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
{
        public string email_medico { get; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string especialidad { get; set; }
        public string numero_matricula { get; set; }
        public int telefono { get; set; }
        public DateTime? creado_el { get; set; }
        public DateTime? actualizado_el { get; set; }
        public DateTime? eliminado_el { get; set; }
        public Usuario creado_por { get; set; }
    }
}
