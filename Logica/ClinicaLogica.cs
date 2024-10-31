﻿using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logica
{
    public class ClinicaLogica
    {
        private ClinicaRepositorio clinicaDatos;
        public ClinicaLogica()
        {
            clinicaDatos = new ClinicaRepositorio();
        }
        public bool AgregarClinica(string razonSocial, string direccion, string telefono, string tipoClinica, string creado_por, out string mensaje)
        {
            if (!ValidarCampos(razonSocial, direccion, telefono, tipoClinica, out mensaje))
            {
                return false;
            }
            // Llamar al método de la capa de datos para guardar la clínica
            try
            {
                clinicaDatos.InsertarClinica(razonSocial, direccion, telefono, tipoClinica, creado_por);
                mensaje = "Clínica agregada correctamente";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al agregar clínica: {ex.Message}";
                return false;

            }
        }
        private bool ValidarCampos(string razonSocial, string direccion, string telefono, string tipoClinica, out string mensaje)
        {
            if (string.IsNullOrEmpty(razonSocial) || !Regex.IsMatch(razonSocial, @"^[a-zA-Z\s]{3,}$"))
            {
                mensaje = "La razón Social debe tener al menos 3 letras";
                return false;
            }
            if (string.IsNullOrEmpty(direccion) || direccion.Length < 3)
            {
                mensaje = "La dirección debe tener al menos 3 caracteres.";
                return false;
            }
            if (string.IsNullOrEmpty(telefono) || !Regex.IsMatch(telefono, @"^\d+$"))
            {
                mensaje = "El teléfono debe contener solo números.";
                return false;
            }
            if (string.IsNullOrEmpty(tipoClinica))
            {
                mensaje = "Seleccione un tipo de clínica";
                return false;
            }

            mensaje = string.Empty; // No hay errores
            return true;
        }
    }
}