using System;
using System.Collections.Generic;
using AgendaMedica.Modelos;
using MySqlConnector;

namespace AgendaMedica.DAL
{
    public class HistorialMedicoDAL
    {
        public List<HistorialMedico> ObtenerPorPaciente(int idPaciente)
        {
            List<HistorialMedico> entradas = new List<HistorialMedico>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT h.id_historial, h.id_paciente, h.id_medico, h.id_usuario, h.Fecha, " + "h.Descripcion, h.Diagnostico, h.Tratamiento, h.Observaciones, " + "CONCAT(p.Nombre, ' ', p.Primer_apellido, ' ', p.Segundo_apellido) AS NombrePaciente, " + "CONCAT(m.Nombre, ' ', m.Primer_apellido, ' ', m.Segundo_apellido) AS NombreMedico, " + "COALESCE(CONCAT(u.Nombre, ' ', u.Primer_apellido, ' ', u.Segundo_apellido), '') AS RegistradoPor " + "FROM HistorialMedico h " + "INNER JOIN Paciente p ON h.id_paciente = p.id_paciente " + "INNER JOIN Medico m ON h.id_medico = m.id_medico " + "LEFT JOIN Usuario u ON h.id_usuario = u.id_usuario " + "WHERE h.id_paciente = @idPaciente " + "ORDER BY h.Fecha DESC, h.id_historial DESC";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idPaciente", idPaciente);

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            HistorialMedico entrada = new HistorialMedico();

                            entrada.IdHistorial = Convert.ToInt32(lector["id_historial"]);
                            entrada.IdPaciente = Convert.ToInt32(lector["id_paciente"]);
                            entrada.IdMedico = Convert.ToInt32(lector["id_medico"]);
                            entrada.IdUsuario = lector["id_usuario"] == DBNull.Value ? null : Convert.ToInt32(lector["id_usuario"]);
                            entrada.Fecha = Convert.ToDateTime(lector["Fecha"]);
                            entrada.Descripcion = Texto(lector, "Descripcion");
                            entrada.Diagnostico = Texto(lector, "Diagnostico");
                            entrada.Tratamiento = Texto(lector, "Tratamiento");
                            entrada.Observaciones = Texto(lector, "Observaciones");
                            entrada.NombrePaciente = Texto(lector, "NombrePaciente");
                            entrada.NombreMedico = Texto(lector, "NombreMedico");
                            entrada.RegistradoPor = Texto(lector, "RegistradoPor");

                            entradas.Add(entrada);
                        }
                    }
                }
            }
            return entradas;
        }

        public void InsertarEntrada(HistorialMedico entrada)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "INSERT INTO HistorialMedico (id_paciente, id_medico, id_usuario, Fecha, Descripcion, Diagnostico, Tratamiento, Observaciones) " + "VALUES (@idPaciente, @idMedico, @idUsuario, @fecha, @descripcion, @diagnostico, @tratamiento, @observaciones)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idPaciente", entrada.IdPaciente);
                    comando.Parameters.AddWithValue("@idMedico", entrada.IdMedico);
                    comando.Parameters.AddWithValue("@idUsuario", entrada.IdUsuario.HasValue ? (object)entrada.IdUsuario.Value : DBNull.Value);
                    comando.Parameters.AddWithValue("@fecha", entrada.Fecha.Date);
                    comando.Parameters.AddWithValue("@descripcion", entrada.Descripcion);
                    comando.Parameters.AddWithValue("@diagnostico", entrada.Diagnostico);
                    comando.Parameters.AddWithValue("@tratamiento", string.IsNullOrWhiteSpace(entrada.Tratamiento) ? (object)DBNull.Value : entrada.Tratamiento);
                    comando.Parameters.AddWithValue("@observaciones", string.IsNullOrWhiteSpace(entrada.Observaciones) ? (object)DBNull.Value : entrada.Observaciones);

                    comando.ExecuteNonQuery();
                }
            }
        }

        private static string Texto(MySqlDataReader lector, string columna)
        {
            return lector[columna] == DBNull.Value ? "" : Convert.ToString(lector[columna]) ?? "";
        }
    }
}