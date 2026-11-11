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

                string consulta = @"
                    SELECT
                        id_especialidad,
                        nombre
                    FROM Especialidad
                    ORDER BY nombre";

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
    }
}