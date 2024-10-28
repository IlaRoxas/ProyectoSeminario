using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logica
{
    public class Afiliado
    {
        private Datos.Afiliado afiliadoDatos;

        public Afiliado()
        {
            afiliadoDatos = new Datos.Afiliado();
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
    }

}
