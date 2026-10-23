using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace AgendaMedica.DAL
{
    public class EspecialidadDAL
    {
        public List<string> ObtenerEspecialidades()
        {
            List<string> especialidades = new List<string>();
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT nombre FROM Especialidad ORDER BY nombre";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        especialidades.Add(lector.GetString("nombre"));
                    }
                }
            }
            return especialidades;
        }
    }
}

