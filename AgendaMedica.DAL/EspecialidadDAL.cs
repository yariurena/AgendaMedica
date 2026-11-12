using System;
using System.Collections.Generic;
using MySqlConnector;
using EspecialidadModelo = AgendaMedica.Modelos.Especialidad;

namespace AgendaMedica.DAL
{
    public class EspecialidadDAL
    {
        public List<EspecialidadModelo> ObtenerEspecialidades()
        {
            List<EspecialidadModelo> especialidades = new List<EspecialidadModelo>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                string consulta = @"SELECT id_especialidad, nombre FROM Especialidad ORDER BY nombre";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        EspecialidadModelo especialidad = new EspecialidadModelo();
                        especialidad.IdEspecialidad = Convert.ToInt32(lector["id_especialidad"]);
                        especialidad.Nombre = Convert.ToString(lector["nombre"]) ?? "";

                        especialidades.Add(especialidad);
                    }
                }
            }
            return especialidades;
        }

        public void InsertarEspecialidad(EspecialidadModelo especialidad)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"INSERT INTO Especialidad (nombre) VALUES (@nombre)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", especialidad.Nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarEspecialidad(EspecialidadModelo especialidad)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"UPDATE Especialidad SET nombre = @nombre WHERE id_especialidad = @idEspecialidad";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", especialidad.Nombre);
                    comando.Parameters.AddWithValue("@idEspecialidad", especialidad.IdEspecialidad);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public bool ExisteNombre(string nombre)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"SELECT COUNT(*) FROM Especialidad WHERE nombre = @nombre";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);

                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }

        public bool ExisteNombre(string nombre, int idEspecialidadExcluir)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"SELECT COUNT(*) FROM Especialidad WHERE nombre = @nombre AND id_especialidad <> @idEspecialidad";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@idEspecialidad", idEspecialidadExcluir);

                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }
    }
}