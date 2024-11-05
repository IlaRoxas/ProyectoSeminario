using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Logica
{
    /// <summary>
    /// Clase MedicoLogica que representa la lógica de negocios para la gestión de médicos.
    /// </summary>
    public class MedicoLogica
    {
        private MedicoRepositorio medicoDatos;

        /// <summary>
        /// Inicializa una nueva instancia de la clase MedicoLogica.
        /// </summary>
        public MedicoLogica()
        {
            medicoDatos = new MedicoRepositorio();
        }

        /// <summary>
        /// Agrega un nuevo médico después de validar sus datos.
        /// </summary>
        /// <param name="email_medico">El email del médico.</param>
        /// <param name="nombre">El nombre del médico.</param>
        /// <param name="apellido">El apellido del médico.</param>
        /// <param name="especialidad">La especialidad del médico.</param>
        /// <param name="numero_matricula">El número de matrícula del médico.</param>
        /// <param name="telefono">El número de teléfono del médico.</param>
        /// <param name="creadoPor">Nombre del usuario que creó el registro.</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>True si el médico se agregó correctamente; de lo contrario, False.</returns>
        public bool AgregarMedico(string email_medico, string nombre, string apellido, string especialidad, string numero_matricula, string telefono, string creadoPor, out string mensaje)
        {
            if (!ValidarCampos(email_medico, nombre, apellido, especialidad, numero_matricula, telefono, out mensaje))
            {
                return false;
            }
           
            try
            {
                medicoDatos.InsertarMedico(email_medico, nombre, apellido, especialidad, numero_matricula, telefono, creadoPor);
                mensaje = "Médico agregado correctamente";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al agregar médico: {ex.Message}";
                return false;

            }
        }

        /// <summary>
        /// Obtiene todos los médicos almacenados en la base de datos.
        /// </summary>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>Un DataTable con todos los médicos, o null si ocurre un error.</returns>
        public DataTable ObtenerMedicos(out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                return medicoDatos.ObtenerTodosMedicos();
            }
            catch (Exception ex)
            {
                mensaje = $"Error al obtener médicos: {ex.Message}";
                return null;
            }
        }

        /// <summary>
        /// Valida los campos de datos de un médico antes de realizar operaciones en la base de datos.
        /// </summary>
        /// <param name="email_medico">El email del médico.</param>
        /// <param name="nombre">El nombre del médico.</param>
        /// <param name="apellido">El apellido del médico.</param>
        /// <param name="especialidad">La especialidad del médico.</param>
        /// <param name="numero_matricula">El número de matrícula del médico.</param>
        /// <param name="telefono">El número de teléfono del médico.</param>
        /// <param name="mensaje">Mensaje de salida que indica si los datos son válidos o contiene el motivo de error.</param>
        /// <returns>True si todos los datos son válidos; de lo contrario, False.</returns>
        private bool ValidarCampos(string email_medico, string nombre, string apellido, string especialidad, string numero_matricula, string telefono, out string mensaje)
        {
            if (string.IsNullOrEmpty(nombre) || !Regex.IsMatch(nombre, @"^[a-zA-Z]{3,}$"))
            {
                mensaje = "El nombre debe tener al menos 3 letras, sin números ni espacios.";
                return false;
            }
            if (string.IsNullOrEmpty(apellido) || !Regex.IsMatch(apellido, @"^[a-zA-Z]{3,}$"))
            {
                mensaje = "El apellido debe tener al menos 3 letras, sin números ni espacios.";
                return false;
            }
            if (string.IsNullOrEmpty(telefono) || !Regex.IsMatch(telefono, @"^\d+$"))
            {
                mensaje = "El teléfono debe contener solo números.";
                return false;
            }
            if (string.IsNullOrEmpty(especialidad) || especialidad.Length < 3)
            {
                mensaje = "La especialidad debe tener al menos 3 caracteres.";
                return false;
            }
            if (string.IsNullOrEmpty(email_medico) || !Regex.IsMatch(email_medico, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                mensaje = "El email debe tener un formato válido (ejemplo: usuario@dominio.com).";
                return false;
            }
            if (string.IsNullOrEmpty(numero_matricula) || !Regex.IsMatch(numero_matricula, @"^[a-zA-Z0-9]{3,}$"))
            {
                mensaje = "El número de matrícula debe tener al menos 3 caracteres alfanuméricos.";
                return false;
            }

            mensaje = string.Empty; // No hay errores
            return true;
        }

        /// <summary>
        /// Obtiene un médico específico a partir de su email.
        /// </summary>
        /// <param name="email_medico">El email del médico a buscar.</param>
        /// <param name="mensaje">Mensaje de salida que indica si el médico fue encontrado o si ocurrió un error.</param>
        /// <returns>El objeto Medico si se encuentra; null si no existe o si ocurre un error.</returns>
        public Medico ObtenerMedico(string email_medico, out string mensaje)
        {
            try
            {
                var medico = medicoDatos.ObtenerMedicoPorEmail(email_medico);
                if (medico != null)
                {
                    mensaje = "Médico encontrado.";
                    return medico;
                }
                else
                {
                    mensaje = "El médico no existe en la base de datos.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al obtener el médico: {ex.Message}";
                return null;
            }
        }

        /// <summary>
        /// Realiza una baja lógica de un médico específico.
        /// </summary>
        /// <param name="email_medico">El email del médico a dar de baja.</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>True si el médico se dio de baja correctamente; de lo contrario, False.</returns>
        public bool DarDeBajaMedico(string email_medico, out string mensaje)
        {
            try
            {
                var medico = medicoDatos.ObtenerMedicoPorEmail(email_medico);
                if (medico == null)
                {
                    mensaje = "El médico no existe en la base de datos.";
                    return false;
                }

                if (medico.bajaLogica)
                {
                    mensaje = "El médico ya está dado de baja.";
                    return false;
                }

                bool exito = medicoDatos.DarBajaLogica(email_medico);
                if (exito)
                {
                    mensaje = "Médico dado de baja correctamente.";

                    return true;
                }
                else
                {
                    mensaje = "No se pudo dar de baja el médico.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al dar de baja médico: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// Obtiene un listado de médicos que coinciden con el filtro de nombre.
        /// </summary>
        /// <param name="nombre">El nombre del médico para filtrar.</param>
        /// <returns>Un DataTable con los registros de médicos que cumplen el filtro especificado.</returns>
        public DataTable ObtenerMedicosFiltrados(string nombre)
        {
            return medicoDatos.ObtenerMedicos(nombre);
        }

        /// <summary>
        /// Actualiza la información de un médico existente.
        /// </summary>
        /// <param name="email_medico">El email del médico a actualizar.</param>
        /// <param name="nombre">El nombre del médico.</param>
        /// <param name="apellido">El apellido del médico.</param>
        /// <param name="especialidad">La especialidad del médico.</param>
        /// <param name="numero_matricula">El número de matrícula del médico.</param>
        /// <param name="telefono">El número de teléfono del médico.</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación.</param>
        /// <returns>True si el médico se actualiza correctamente; de lo contrario, False.</returns>
        public bool ActualizarMedico(string email_medico, string nombre, string apellido, string especialidad, string numero_matricula, string telefono, out string mensaje)
        {
            if (!ValidarCampos(email_medico, nombre, apellido, especialidad, numero_matricula, telefono, out mensaje))
            {
                return false;
            }
            try
            {
                bool resultado = medicoDatos.ActualizarMedico(email_medico, nombre, apellido, especialidad, numero_matricula, telefono);
                if (resultado)
                {
                    mensaje = "Médico actualizado correctamente.";
                }
                else
                {
                    mensaje = "No se pudo actualizar el médico.";
                }
                return resultado;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al actualizar el médico: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// Obtiene todos los médicos como una lista de objetos Medico.
        /// </summary>
        /// <returns>Una lista de objetos Medico que representa todos los médicos.</returns>
        public List<Medico> ObtenerTodosLosMedicos()
        {
            return medicoDatos.ObtenerTodosLosMedicos();
        }

    }
}
