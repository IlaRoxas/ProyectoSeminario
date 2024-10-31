﻿using Datos;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Entidades;
using System.Collections.Generic;

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
            if (!ValidarCampos(nombre, apellido, telefono, domicilio, email, out mensaje))
            {
                return false;
            }
            if (!Regex.IsMatch(numeroAfiliado, @"^\d{12}$"))
            {
                mensaje = "El número de afiliado debe tener exactamente 12 dígitos.";
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

        // Método para obtener un afiliado por su número de afiliado para la baja lógica
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
        //Para visualizar los afiliados en el datagridview
        public DataTable ObtenerAfiliados(out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                return afiliadoDatos.ObtenerTodosAfiliados();
            }
            catch (Exception ex)
            {
                mensaje = $"Error al obtener afiliados: {ex.Message}";
                return null;
            }
        }
        public bool ActualizarAfiliado(string numero_afiliado, string nombre, string apellido, string domicilio, string telefono, string email, out string mensaje)
        {
            if (!ValidarCampos(nombre, apellido, telefono, domicilio, email, out mensaje))
            { 
                return false;
            }
            try
            {
                bool resultado = afiliadoDatos.ActualizarAfiliado(numero_afiliado, nombre, apellido, domicilio, telefono, email);
                if (resultado)
                {
                    mensaje = "Afiliado actualizado correctamente.";
                }
                else
                {
                    mensaje = "No se pudo actualizar el afiliado.";
                }
                return resultado;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al actualizar afiliado: {ex.Message}";
                return false;
            }
        }
        public List<Afiliado> ObtenerTodosLosAfiliados()
        {
            return afiliadoDatos.ObtenerTodosLosAfiliados();
        }
        // Método de validación común
        private bool ValidarCampos(string nombre, string apellido, string telefono, string domicilio, string email, out string mensaje)
        {
            if (string.IsNullOrEmpty(nombre) || !Regex.IsMatch(nombre, @"^[a-zA-Z]{3,}$"))
            {
                mensaje = "El nombre debe tener al menos 3 letras, sin números ni espacioa.";
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

            mensaje = string.Empty; // No hay errores
            return true;
        }
    }

}
