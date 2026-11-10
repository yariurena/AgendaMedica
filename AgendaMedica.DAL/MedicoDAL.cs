using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;

namespace AgendaMedica.DAL
{
    public class MedicoDAL
    {
        public DataTable ObtenerMedicos()
        {
            DataTable tabla = new DataTable();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"
                    SELECT
                        m.id_medico,
                        m.Nombre,
                        m.Apellidos,
                        e.Nombre AS Especialidad,
                        m.Telefono,
                        m.Email
                    FROM Medico m
                    INNER JOIN Especialidad e
                        ON m.id_especialidad = e.id_especialidad
                    ORDER BY m.Apellidos, m.Nombre";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }

        public void InsertarMedico(Medico medico)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"
                    INSERT INTO Medico
                    (Nombre, Apellidos, id_especialidad, Telefono, Email)
                    VALUES
                    (@nombre, @apellidos, @idEspecialidad, @telefono, @email)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", medico.Nombre);
                    comando.Parameters.AddWithValue("@apellidos", medico.Apellidos);
                    comando.Parameters.AddWithValue("@idEspecialidad", medico.IdEspecialidad);
                    comando.Parameters.AddWithValue("@telefono",
                        string.IsNullOrWhiteSpace(medico.Telefono)
                            ? (object)DBNull.Value
                            : medico.Telefono);
                    comando.Parameters.AddWithValue("@email", medico.Email);

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}