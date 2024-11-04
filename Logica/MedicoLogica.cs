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
    public class MedicoLogica
    {
        private MedicoRepositorio medicoDatos;

        public MedicoLogica()
        {
            medicoDatos = new MedicoRepositorio();
        }
        
    
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

        public DataTable ObtenerMedicosFiltrados(string nombre)
        {
            return medicoDatos.ObtenerMedicos(nombre);
        }

    }
}
