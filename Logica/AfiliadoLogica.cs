using Datos;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Entidades;
namespace Logica
{
    public class AfiliadoLogica
    {
        private AfiliadoRepositorio afiliadoDatos;

        public AfiliadoLogica()
        {
            afiliadoDatos = new AfiliadoRepositorio();
        }

        public bool AgregarAfiliado(string nombre, string apellido, string telefono, string domicilio, string email, string numeroAfiliado, string creadoPor, out string mensaje)
        {
            if (string.IsNullOrEmpty(nombre) || !Regex.IsMatch(nombre, @"^[a-zA-Z]{3,}$"))
            {
                mensaje = "El nombre debe tener al menos 3 caracteres";
                return false;
            }
            if (string.IsNullOrEmpty(apellido) || !Regex.IsMatch(apellido, @"^[a-zA-Z]{3,}$"))
            {
                mensaje = "El apellido debe tener al menos 3 letras y no contener números ni caracteres especiales.";
                return false;
            }
            if (!Regex.IsMatch(telefono, @"^\d+$"))
            {
                mensaje = "El teléfono debe contener solo números.";
                return false;
            }
            if (string.IsNullOrEmpty(domicilio) || domicilio.Length < 3)
            {
                mensaje = "El domicilio debe tener al menos 3 caracteres.";
                return false;
            }
            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                mensaje = "El email debe tener un formato válido (ejemplo: usuario@dominio.com).";
                return false;
            }
            if (!Regex.IsMatch(numeroAfiliado, @"^\d{12}$"))
            {
                mensaje = "El número de afiliado debe tener exactamente 12 dígitos.";
                return false;
            }
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(telefono) ||
                string.IsNullOrEmpty(domicilio) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(numeroAfiliado))
            {
                mensaje = "Todos los campos son obligatorios";
                return false;
            }
            // Llamar al método de la capa de datos para guardar el afiliado
            try
            {
                afiliadoDatos.InsertarAfiliado(nombre, apellido, telefono, domicilio, email, numeroAfiliado, creadoPor);
                mensaje = "Afiliado agregado correctamente";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al agregar afiliado: {ex.Message}";
                return false;

            }
        }
        // Método para dar de baja lógica a un afiliado
        public bool DarDeBajaAfiliado(string numeroAfiliado, out string mensaje)
        {
            try
            {
                var afiliado = afiliadoDatos.ObtenerAfiliadoPorNumero(numeroAfiliado);
                if (afiliado == null)
                {
                    mensaje = "El afiliado no existe en la base de datos.";
                    return false;
                }

                if (afiliado.bajaLogica)
                {
                    mensaje = "El afiliado ya está dado de baja.";
                    return false;
                }

                bool exito = afiliadoDatos.DarBajaLogica(numeroAfiliado);
                if (exito)
                {
                    mensaje = "Afiliado dado de baja correctamente.";
                    return true;
                }
                else
                {
                    mensaje = "No se pudo dar de baja el afiliado.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al dar de baja afiliado: {ex.Message}";
                return false;
            }
        }

        // Método para obtener un afiliado por su número de afiliado
        public Afiliado ObtenerAfiliado(string numeroAfiliado, out string mensaje)
        {
            try
            {
                var afiliado = afiliadoDatos.ObtenerAfiliadoPorNumero(numeroAfiliado);
                if (afiliado != null)
                {
                    mensaje = "Afiliado encontrado.";
                    return afiliado;
                }
                else
                {
                    mensaje = "El afiliado no existe en la base de datos.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al obtener afiliado: {ex.Message}";
                return null;
            }
        }
    }

}
