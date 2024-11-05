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
    /// <summary>
    /// La clase ClinicaLogica representa la capa de lógica de negocios para la gestión de clínicas.
    /// </summary>
    public class ClinicaLogica
    {
        private ClinicaRepositorio clinicaDatos;

        /// <summary>
        /// Inicializa una nueva instancia de la clase ClinicaLogica.
        /// </summary>
        public ClinicaLogica()
        {
            clinicaDatos = new ClinicaRepositorio();
        }

        /// <summary>
        /// Agrega una nueva clínica después de validar sus datos.
        /// </summary>
        /// <param name="razonSocial">La razón social de la clínica.</param>
        /// <param name="direccion">La dirección de la clínica.</param>
        /// <param name="telefono">El número de teléfono de la clínica.</param>
        /// <param name="tipoClinica">El tipo de clínica.</param>
        /// <param name="creado_por">Nombre del usuario que creó el registro.</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>True si la clínica se agregó correctamente; de lo contrario, False.</returns>
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

        /// <summary>
        /// Valida los campos de datos de la clínica antes de realizar operaciones en la base de datos.
        /// </summary>
        /// <param name="razonSocial">La razón social de la clínica.</param>
        /// <param name="direccion">La dirección de la clínica.</param>
        /// <param name="telefono">El número de teléfono de la clínica.</param>
        /// <param name="tipoClinica">El tipo de clínica.</param>
        /// <param name="mensaje">Mensaje de salida que indica si los datos son válidos o contiene el motivo de error.</param>
        /// <returns>True si todos los datos son válidos; de lo contrario, False.</returns>
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

        /// <summary>
        /// Obtiene todas las clínicas almacenadas en la base de datos.
        /// </summary>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>Un DataTable con todas las clínicas, o null si ocurre un error.</returns>
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

        /// <summary>
        /// Actualiza la información de una clínica existente.
        /// </summary>
        /// <param name="razon_social">La razón social de la clínica.</param>
        /// <param name="direccion">La dirección de la clínica.</param>
        /// <param name="telefono">El número de teléfono de la clínica.</param>
        /// <param name="tipo_clinica">El tipo de clínica.</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>True si la clínica se actualiza correctamente; de lo contrario, False.</returns>
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

        /// <summary>
        /// Obtiene una lista de todas las clínicas como una lista de objetos Clinica.
        /// </summary>
        /// <returns>Una lista de objetos Clinica que representa todas las clínicas.</returns>
        public List<Clinica> ObtenerTodasLasClinicas()
        {
            return clinicaDatos.ObtenerTodasLasClinicas();
        }

        /// <summary>
        /// Obtiene un listado de clínicas que coinciden con los filtros de razón social y tipo de clínica.
        /// </summary>
        /// <param name="razonSocial">La razón social de la clínica para filtrar.</param>
        /// <param name="tipoClinica">El tipo de clínica para filtrar.</param>
        /// <returns>Un DataTable con los registros de clínicas que cumplen los filtros especificados.</returns>
        public DataTable ObtenerClinicasFiltradas(string razonSocial, string tipoClinica)
        {
            return clinicaDatos.ObtenerClinicas(razonSocial, tipoClinica);
        }

        /// <summary>
        /// Obtiene una clínica específica con base en su razón social.
        /// </summary>
        /// <param name="razon_social">La razón social de la clínica a buscar.</param>
        /// <param name="mensaje">Mensaje de salida que indica si la clínica fue encontrada o si ocurrió un error.</param>
        /// <returns>El objeto Clinica si se encuentra; null si no existe o si ocurre un error.</returns>
        public Clinica ObtenerClinica(string razon_social, out string mensaje)
        {
            try
            {
                var clinica = clinicaDatos.ObtenerClinicaPorRS(razon_social);
                if (clinica != null)
                {
                    mensaje = "Clínica encontrada.";
                    return clinica;
                }
                else
                {
                    mensaje = "La clínica no existe en la base de datos.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al obtener clínica: {ex.Message}";
                return null;
            }
        }

        /// <summary>
        /// Realiza una baja lógica de una clínica específica.
        /// </summary>
        /// <param name="razon_social">La razón social de la clínica a dar de baja.</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>True si la clínica se dio de baja correctamente; de lo contrario, False.</returns>
        public bool DarDeBajaClinica(string razon_social, out string mensaje)
        {
            try
            {
                var clinica = clinicaDatos.ObtenerClinicaPorRS(razon_social);
                if (clinica == null)
                {
                    mensaje = "La clinica no existe en la base de datos.";
                    return false;
                }

                if (clinica.bajaLogica)
                {
                    mensaje = "La clinica ya está dado de baja.";
                    return false;
                }

                bool exito = clinicaDatos.DarBajaLogica(razon_social);
                if (exito)
                {
                    mensaje = "Clínica dada de baja correctamente.";

                    return true;
                }
                else
                {
                    mensaje = "No se pudo dar de baja la clínica.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al dar de baja a la clínica: {ex.Message}";
                return false;
            }
        }
    }
}
