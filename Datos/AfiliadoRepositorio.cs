﻿using MySql.Data.MySqlClient;
using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class AfiliadoRepositorio : Conexion
    {
        public void InsertarAfiliado(string nombre, string apellido, string telefono, string domicilio, string email, string numero_afiliado, string creado_por)
        {
            using (var conexion = GetConnection())
            {
                string query = "INSERT INTO afiliado (nombre, apellido, telefono, domicilio, email, numero_afiliado, creado_el, creado_por)" +
                    "VALUES (@nombre, @apellido, @telefono, @domicilio, @email, @numero_afiliado, @creado_el, @creado_por)";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    //Agregar parámetros
                    cmd.Parameters.AddWithValue("@nombre",nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@domicilio", domicilio);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@numero_afiliado", numero_afiliado);
                    cmd.Parameters.AddWithValue("@creado_el", DateTime.Now);
                    cmd.Parameters.AddWithValue("@creado_por", creado_por);

                    //Ejecutar la inserción
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Método para obtener un afiliado por su número de afiliado
        public Afiliado ObtenerAfiliadoPorNumero(string numeroAfiliado)
        {
            Afiliado afiliado = null;

            using (var conexion = GetConnection())
            {
                string query = "SELECT * FROM afiliado WHERE numero_afiliado = @numero_afiliado";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@numero_afiliado", numeroAfiliado);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            afiliado = new Afiliado
                            {
                                numero_afiliado = reader["numero_afiliado"].ToString(),
                                nombre = reader["nombre"].ToString(),
                                apellido = reader["apellido"].ToString(),
                                telefono = reader["telefono"].ToString(),
                                domicilio = reader["domicilio"].ToString(),
                                email = reader["email"].ToString(),
                                bajaLogica = Convert.ToBoolean(reader["bajaLogica"])
                            };
                        }
                        else
                        {
                            return null; // No se encontró ningún afiliado con ese número
                        }
                    }
                }
            }

            return afiliado;
        }

        // Método para dar de baja lógicamente un afiliado
        public bool DarBajaLogica(string numeroAfiliado)
        {
            using (var conexion = GetConnection())
            {
                string query = "UPDATE afiliado SET bajaLogica = 1, eliminado_el = @eliminado_el WHERE numero_afiliado = @numero_afiliado";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@numero_afiliado", numeroAfiliado);
                    cmd.Parameters.AddWithValue("@eliminado_el", DateTime.Now);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
