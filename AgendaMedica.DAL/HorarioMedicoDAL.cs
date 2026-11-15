using System;
using System.Collections.Generic;
using MySqlConnector;
using HorarioModelo = AgendaMedica.Modelos.HorarioMedico;

namespace AgendaMedica.DAL
{
    public class HorarioMedicoDAL
    {
        public List<HorarioModelo> ObtenerHorariosPorMedico(int idMedico)
        {
            List<HorarioModelo> horarios = new List<HorarioModelo>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"SELECT h.id_horario, h.id_medico, CONCAT(m.Nombre, ' ', m.Primer_apellido, ' ', m.Segundo_apellido) AS NombreMedico, h.Dia, h.Hora_inicio, h.Hora_fin FROM HorarioMedico h INNER JOIN Medico m ON h.id_medico = m.id_medico WHERE h.id_medico = @idMedico  ORDER BY FIELD(h.Dia, 'Lunes','Martes','Miércoles','Jueves','Viernes','Sábado','Domingo'), h.Hora_inicio";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            HorarioModelo horario = new HorarioModelo();

                            horario.IdHorario = Convert.ToInt32(lector["id_horario"]);
                            horario.IdMedico = Convert.ToInt32(lector["id_medico"]);
                            horario.NombreMedico = Convert.ToString(lector["NombreMedico"]) ?? "";
                            horario.Dia = Convert.ToString(lector["Dia"]) ?? "";
                            horario.HoraInicio = (TimeSpan)lector["Hora_inicio"];
                            horario.HoraFin = (TimeSpan)lector["Hora_fin"];

                            horarios.Add(horario);
                        }
                    }
                }
            }
            return horarios;
        }

        public void InsertarHorario(HorarioModelo horario)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"INSERT INTO HorarioMedico (id_medico, Dia, Hora_inicio, Hora_fin) VALUES (@idMedico, @dia, @horaInicio, @horaFin)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", horario.IdMedico);
                    comando.Parameters.AddWithValue("@dia", horario.Dia);
                    comando.Parameters.AddWithValue("@horaInicio", horario.HoraInicio);
                    comando.Parameters.AddWithValue("@horaFin", horario.HoraFin);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void EliminarHorario(int idHorario)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "DELETE FROM HorarioMedico WHERE id_horario = @idHorario";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idHorario", idHorario);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public bool ExisteSolapamiento(int idMedico, string dia, TimeSpan horaInicio, TimeSpan horaFin)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"SELECT COUNT(*) FROM HorarioMedico WHERE id_medico = @idMedico AND Dia = @dia AND Hora_inicio < @horaFin AND Hora_fin > @horaInicio";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);
                    comando.Parameters.AddWithValue("@dia", dia);
                    comando.Parameters.AddWithValue("@horaInicio", horaInicio);
                    comando.Parameters.AddWithValue("@horaFin", horaFin);

                    return Convert.ToInt32(comando.ExecuteScalar()) > 0;
                }
            }
        }

        public bool ExisteHorarioQueCubra(int idMedico, string dia, TimeSpan horaInicio, TimeSpan horaFin)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"SELECT COUNT(*) FROM HorarioMedico WHERE id_medico = @idMedico AND Dia = @dia AND Hora_inicio <= @horaInicio AND Hora_fin >= @horaFin";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);
                    comando.Parameters.AddWithValue("@dia", dia);
                    comando.Parameters.AddWithValue("@horaInicio", horaInicio);
                    comando.Parameters.AddWithValue("@horaFin", horaFin);

                    return Convert.ToInt32(comando.ExecuteScalar()) > 0;
                }
            }
        }
    }
}