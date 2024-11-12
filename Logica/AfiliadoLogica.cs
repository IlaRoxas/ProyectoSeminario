using Datos;
using System;
using System.Data;
using System.Text.RegularExpressions;
using Entidades;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace Logica
{
    public class AfiliadoLogica
    {
        private AfiliadoRepositorio afiliadoDatos;
        private readonly HttpClient _httpClient;

        public AfiliadoLogica()
        {
            afiliadoDatos = new AfiliadoRepositorio();
            _httpClient = new HttpClient();

        }
        /// <summary>
        /// Agrega un nuevo afiliado a la base de datos después de validar los campos requeridos.
        /// </summary>
        /// <param name="nombre">El nombre del afiliado. Debe tener al menos 3 caracteres.</param>
        /// <param name="apellido">El apellido del afiliado. Debe tener al menos 3 caracteres.</param>
        /// <param name="telefono">El teléfono del afiliado. Debe contener solo números.</param>
        /// <param name="domicilio">El domicilio del afiliado. Debe tener al menos 3 caracteres.</param>
        /// <param name="email">El email del afiliado. Debe estar en formato válido (ejemplo: usuario@dominio.com).</param>
        /// <param name="numeroAfiliado">El número de afiliado. Debe tener exactamente 12 dígitos numéricos.</param>
        /// <param name="creadoPor">El usuario que crea el afiliado.</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación, ya sea exitoso o con error.</param>
        /// <returns>
        /// Devuelve <c>true</c> si el afiliado se agregó correctamente; de lo contrario, <c>false</c>.
        /// </returns>
        /// <exception cref="Exception">Si ocurre un error al intentar agregar el afiliado en la base de datos.</exception>
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

            bool afiliadoVinculadoAlTerrorismo = false;
            // Llamar al método de la capa de datos para guardar el afiliado
            try
            {
                afiliadoVinculadoAlTerrorismo = consultarListadoTerrorismo(nombre, apellido);
                if (afiliadoVinculadoAlTerrorismo)
                {
                    mensaje = "El usuario se encuentra sospechoso de terrorismo. Por favor contactarse con el administrador de sistemas.";
                    return false;
                }
                
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


        /// <summary>
        /// Verifica si una persona, identificada por su nombre y apellido, se encuentra en una lista de personas relacionadas con el terrorismo.
        /// </summary>
        /// <param name="nombre">El primer nombre de la persona a verificar.</param>
        /// <param name="apellido">El segundo nombre o apellido de la persona a verificar.</param>
        /// <returns>
        /// Devuelve `true` si la persona está en la lista de personas relacionadas con el terrorismo; de lo contrario, devuelve `false`.
        /// </returns>
        /// <remarks>
        /// El método realiza una solicitud HTTP a una API que devuelve un archivo JSON con el listado de personas.
        /// La API se consulta en la URL especificada y se espera que la respuesta sea un arreglo JSON donde cada elemento
        /// contiene los campos "FIRST_NAME" y "SECOND_NAME".
        ///
        /// En caso de que ocurra un error (por ejemplo, si la API no responde), el método captura la excepción y simplemente retorna `false`.
        /// </remarks>
        /// <exception cref="Exception">Captura cualquier excepción que pueda ocurrir durante la solicitud HTTP o el procesamiento JSON.</exception>
        protected bool consultarListadoTerrorismo(string nombre, string apellido)
        {
            try
            {
                string url = "https://repet.jus.gob.ar/xml/personas.json";
                var response = _httpClient.GetStringAsync(url).Result;

                JArray personas = JArray.Parse(response);

                //normalizar los datos de entrada
                nombre = nombre.Trim().ToUpper();
                apellido = apellido.Trim().ToUpper();

                foreach (var persona in personas)
                {
                    string firstName = persona["FIRST_NAME"]?.ToString();
                    string secondName = persona["SECOND_NAME"]?.ToString();

                    if (firstName == nombre && secondName == apellido)
                    {
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                //do nothing
            }

            return false;
        }

        /// <summary>
        /// Realiza una baja lógica de un afiliado en la base de datos, verificando que el afiliado exista y no esté previamente dado de baja.
        /// </summary>
        /// <param name="numeroAfiliado">Número único que identifica al afiliado en la base de datos.</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación, ya sea exitoso o con error.</param>
        /// <returns>
        /// Devuelve <c>true</c> si el afiliado se dio de baja correctamente; de lo contrario, <c>false</c>.
        /// </returns>
        /// <exception cref="Exception">Si ocurre un error al intentar dar de baja el afiliado en la base de datos.</exception>
        /// <remarks>
        /// La baja lógica no elimina el registro del afiliado de la base de datos, solo marca el campo correspondiente para indicar que ya no está activo.
        /// </remarks>
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

        /// <summary>
        /// Obtiene un afiliado de la base de datos en función de su número de afiliado.
        /// </summary>
        /// <param name="numeroAfiliado">Número único que identifica al afiliado en la base de datos.</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación, como "Afiliado encontrado" o detalles de cualquier error.</param>
        /// <returns>
        /// Una instancia de <see cref="Afiliado"/> si el afiliado existe en la base de datos; de lo contrario, <c>null</c>.
        /// </returns>
        /// <exception cref="Exception">Si ocurre un error al intentar obtener el afiliado de la base de datos.</exception>
        /// <remarks>
        /// Este método busca un afiliado específico en la base de datos a través de su número de afiliado. Si no existe, devuelve <c>null</c>.
        /// </remarks>
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

        /// <summary>
        /// Obtiene todos los afiliados activos de la base de datos.
        /// </summary>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación. En caso de error, proporciona detalles del mismo.</param>
        /// <returns>
        /// Un objeto <see cref="DataTable"/> que contiene los datos de todos los afiliados activos. 
        /// Retorna <c>null</c> si ocurre algún error.
        /// </returns>
        /// <exception cref="Exception">Si ocurre un error durante la obtención de los datos de los afiliados desde la base de datos.</exception>
        /// <remarks>
        /// Este método obtiene todos los afiliados activos (sin baja lógica) desde la capa de datos. 
        /// En caso de error, el mensaje de salida incluirá los detalles del error.
        /// </remarks>
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

        /// <summary>
        /// Actualiza los datos de un afiliado en la base de datos.
        /// </summary>
        /// <param name="numero_afiliado">Número único del afiliado que se actualizará.</param>
        /// <param name="nombre">Nombre del afiliado.</param>
        /// <param name="apellido">Apellido del afiliado.</param>
        /// <param name="domicilio">Domicilio del afiliado.</param>
        /// <param name="telefono">Número de teléfono del afiliado, que debe contener solo números.</param>
        /// <param name="email">Correo electrónico del afiliado en un formato válido.</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación. En caso de error, proporciona detalles del mismo.</param>
        /// <returns>
        /// Un valor <c>true</c> si la actualización se realiza con éxito; de lo contrario, <c>false</c>.
        /// </returns>
        /// <exception cref="Exception">Si ocurre un error durante la actualización del afiliado en la base de datos.</exception>
        /// <remarks>
        /// Este método valida los datos de entrada antes de intentar la actualización. 
        /// Si los datos no son válidos, el método retorna <c>false</c> y establece un mensaje de error en el parámetro <paramref name="mensaje"/>.
        /// En caso de éxito o error durante la actualización, el parámetro <paramref name="mensaje"/> se ajustará con un mensaje correspondiente.
        /// </remarks>
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

        /// <summary>
        /// Obtiene una lista de todos los afiliados almacenados en la base de datos.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="Afiliado"/> que representa todos los afiliados registrados.
        /// Si no existen afiliados, retorna una lista vacía.
        /// </returns>
        /// <exception cref="Exception">Si ocurre un error durante la obtención de los afiliados en la base de datos.</exception>
        /// <remarks>
        /// Este método interactúa con la capa de datos para obtener la lista completa de afiliados.
        /// </remarks>
        public List<Afiliado> ObtenerTodosLosAfiliados()
        {
            return afiliadoDatos.ObtenerTodosLosAfiliados();
        }

        /// <summary>
        /// Valida los campos de un afiliado para asegurarse de que cumplan con los requisitos de formato y longitud.
        /// </summary>
        /// <param name="nombre">El nombre del afiliado, debe contener al menos 3 letras sin números ni espacios.</param>
        /// <param name="apellido">El apellido del afiliado, debe contener al menos 3 letras sin números ni espacios.</param>
        /// <param name="telefono">El número de teléfono del afiliado, debe contener solo dígitos.</param>
        /// <param name="domicilio">El domicilio del afiliado, debe tener al menos 3 caracteres.</param>
        /// <param name="email">La dirección de correo electrónico del afiliado, debe tener un formato válido (por ejemplo, usuario@dominio.com).</param>
        /// <param name="mensaje">Salida que contiene el mensaje de error si alguno de los campos no es válido; vacío si todos los campos son válidos.</param>
        /// <returns>
        /// <c>true</c> si todos los campos son válidos; <c>false</c> si uno o más campos no cumplen con los requisitos.
        /// </returns>
        /// <remarks>
        /// Este método verifica que los campos de texto no estén vacíos y que sigan el formato especificado
        /// utilizando expresiones regulares para los campos <paramref name="nombre"/>, <paramref name="apellido"/>,
        /// <paramref name="telefono"/> y <paramref name="email"/>.
        /// </remarks>
        private bool ValidarCampos(string nombre, string apellido, string telefono, string domicilio, string email, out string mensaje)
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

        /// <summary>
        /// Obtiene un listado de afiliados filtrado por nombre.
        /// </summary>
        /// <param name="nombre">Nombre del afiliado por el cual se desea filtrar.</param>
        /// <returns>
        /// Un <see cref="DataTable"/> que contiene los registros de afiliados cuyo nombre coincide con el filtro especificado.
        /// </returns>
        /// <remarks>
        /// Este método utiliza una capa de datos para ejecutar la consulta de afiliados basada en el nombre proporcionado,
        /// retornando los resultados en formato de tabla.
        /// </remarks>
        public DataTable ObtenerAfiliadosFiltrados(string nombre)
        {
            return afiliadoDatos.ObtenerAfiliados(nombre);
        }
    }
        
   
}
