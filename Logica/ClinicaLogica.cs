using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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
            if (string.IsNullOrEmpty(razonSocial) || razonSocial.Length < 3)
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
        public DataTable ObtenerClinicas(out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                return clinicaDatos.ObtenerTodasClinicas();
            }
            catch (Exception ex)
            {
                mensaje = $"Error al obtener clíncas: {ex.Message}";
                return null;
            }
        }
        public bool ActualizarClinica(string razon_social, string direccion, string telefono, string tipo_clinica, out string mensaje)
        {
            if (!ValidarCampos(razon_social, direccion, telefono, tipo_clinica, out mensaje))
            {
                return false;
            }
            try
            {
                bool resultado = clinicaDatos.ActualizarClinica(razon_social, direccion, telefono, tipo_clinica);
                if (resultado)
                {
                    mensaje = "Clínica actualizada correctamente.";
                }
                else
                {
                    mensaje = "No se pudo actualizar la clínica.";
                }
                return resultado;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al actualizar la clínica: {ex.Message}";
                return false;
            }
        }
        public List<Clinica> ObtenerTodasLasClinicas()
        {
            return clinicaDatos.ObtenerTodasLasClinicas();
        }
        public DataTable ObtenerClinicasFiltradas(string razonSocial, string tipoClinica)
        {
            return clinicaDatos.ObtenerClinicas(razonSocial, tipoClinica);
        }
    }
}
