using System;
using System.Collections.Generic;
using MySqlConnector;
using MedicoModelo = AgendaMedica.Modelos.Medico;

namespace AgendaMedica.DAL
{
    public class MedicoDAL
    {
        public List<MedicoModelo> ObtenerMedicos()
        {
            List<MedicoModelo> medicos = new List<MedicoModelo>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"
                    SELECT
                        m.id_medico,
                        m.Nombre,
                        m.Apellidos,
                        m.id_especialidad,
                        e.Nombre AS NombreEspecialidad,
                        m.Telefono,
                        m.Email
                    FROM Medico m
                    INNER JOIN Especialidad e
                        ON m.id_especialidad = e.id_especialidad
                    ORDER BY m.Apellidos, m.Nombre";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        MedicoModelo medico = new MedicoModelo();

                        medico.IdMedico = Convert.ToInt32(lector["id_medico"]);
                        medico.Nombre = Convert.ToString(lector["Nombre"]) ?? "";
                        medico.Apellidos = Convert.ToString(lector["Apellidos"]) ?? "";
                        medico.IdEspecialidad = Convert.ToInt32(lector["id_especialidad"]);
                        medico.NombreEspecialidad = Convert.ToString(lector["NombreEspecialidad"]) ?? "";
                        medico.Telefono = lector["Telefono"] == DBNull.Value? "": Convert.ToString(lector["Telefono"]) ?? "";
                        medico.Email = lector["Email"] == DBNull.Value? "": Convert.ToString(lector["Email"]) ?? "";

                        medicos.Add(medico);
                    }
                }
            }
            return medicos;
        }

        public void InsertarMedico(MedicoModelo medico)
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

                    comando.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(medico.Telefono)? (object)DBNull.Value: medico.Telefono);

                    comando.Parameters.AddWithValue("@email", medico.Email);

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}