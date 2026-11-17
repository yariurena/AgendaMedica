using System;
using System.Collections.Generic;
using AgendaMedica.Modelos;
using MySqlConnector;

namespace AgendaMedica.DAL
{
    public class CitaDAL
    {
        private const string ConsultaBase = @"SELECT c.id_cita, c.id_paciente, c.id_medico, c.id_estado, c.id_tip, c.Fecha, c.Hora, c.DuracionMinutos, c.Motivo, CONCAT(p.Nombre, ' ', p.Primer_apellido, ' ', p.Segundo_apellido) AS NombrePaciente, CONCAT(m.Nombre, ' ', m.Primer_apellido, ' ', m.Segundo_apellido) AS NombreMedico, e.Nombre AS Estado, t.Nombre AS Tipo FROM Cita c INNER JOIN Paciente p ON c.id_paciente = p.id_paciente INNER JOIN Medico m ON c.id_medico = m.id_medico INNER JOIN Estado_de_Cita e ON c.id_estado = e.id_estado INNER JOIN Tipo_de_cita t ON c.id_tip = t.id_tip";

        public List<CatalogoItem> ObtenerEstados()
        {
            return ObtenerCatalogo("SELECT id_estado AS Id, Nombre FROM Estado_de_Cita ORDER BY id_estado");
        }

        public List<CatalogoItem> ObtenerTipos()
        {
            return ObtenerCatalogo("SELECT id_tip AS Id, Nombre FROM Tipo_de_cita ORDER BY id_tip");
        }

        private List<CatalogoItem> ObtenerCatalogo(string consulta)
        {
            List<CatalogoItem> items = new List<CatalogoItem>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        CatalogoItem item = new CatalogoItem();
                        item.Id = Convert.ToInt32(lector["Id"]);
                        item.Nombre = Convert.ToString(lector["Nombre"]) ?? "";
                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public List<Cita> BuscarCitas(int? idMedico, int? idPaciente, DateTime? fecha, int? idEstado)
        {
            List<Cita> citas = new List<Cita>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = ConsultaBase + " WHERE (@idMedico IS NULL OR c.id_medico = @idMedico)" + " AND (@idPaciente IS NULL OR c.id_paciente = @idPaciente)" + " AND (@fecha IS NULL OR c.Fecha = @fecha)" + " AND (@idEstado IS NULL OR c.id_estado = @idEstado)" + " ORDER BY c.Fecha, c.Hora";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico.HasValue ? (object)idMedico.Value : DBNull.Value);
                    comando.Parameters.AddWithValue("@idPaciente", idPaciente.HasValue ? (object)idPaciente.Value : DBNull.Value);
                    comando.Parameters.AddWithValue("@fecha", fecha.HasValue ? (object)fecha.Value.Date : DBNull.Value);
                    comando.Parameters.AddWithValue("@idEstado", idEstado.HasValue ? (object)idEstado.Value : DBNull.Value);

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            citas.Add(LeerCita(lector));
                        }
                    }
                }
            }
            return citas;
        }

        public List<Cita> ObtenerCitasPorRango(DateTime desde, DateTime hasta, int? idMedico, string? estado)
        {
            List<Cita> citas = new List<Cita>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = ConsultaBase + " WHERE c.Fecha >= @desde AND c.Fecha <= @hasta" + " AND (@idMedico IS NULL OR c.id_medico = @idMedico)" + " AND (@estado IS NULL OR e.Nombre = @estado)" + " ORDER BY c.Fecha, c.Hora, NombreMedico";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@desde", desde.Date);
                    comando.Parameters.AddWithValue("@hasta", hasta.Date);
                    comando.Parameters.AddWithValue("@idMedico", idMedico.HasValue ? (object)idMedico.Value : DBNull.Value);
                    comando.Parameters.AddWithValue("@estado", estado == null ? DBNull.Value : (object)estado);

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            citas.Add(LeerCita(lector));
                        }
                    }
                }
            }
            return citas;
        }

        public Cita? ObtenerCitaPorId(int idCita)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = ConsultaBase + " WHERE c.id_cita = @idCita";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idCita", idCita);

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return LeerCita(lector);
                        }
                    }
                }
            }
            return null;
        }

        private Cita LeerCita(MySqlDataReader lector)
        {
            Cita cita = new Cita();

            cita.IdCita = Convert.ToInt32(lector["id_cita"]);
            cita.IdPaciente = Convert.ToInt32(lector["id_paciente"]);
            cita.IdMedico = Convert.ToInt32(lector["id_medico"]);
            cita.IdEstado = Convert.ToInt32(lector["id_estado"]);
            cita.IdTipo = Convert.ToInt32(lector["id_tip"]);
            cita.Fecha = Convert.ToDateTime(lector["Fecha"]);
            cita.Hora = (TimeSpan)lector["Hora"];
            cita.DuracionMinutos = Convert.ToInt32(lector["DuracionMinutos"]);
            cita.Motivo = lector["Motivo"] == DBNull.Value ? "" : Convert.ToString(lector["Motivo"]) ?? "";
            cita.NombrePaciente = Convert.ToString(lector["NombrePaciente"]) ?? "";
            cita.NombreMedico = Convert.ToString(lector["NombreMedico"]) ?? "";
            cita.Estado = Convert.ToString(lector["Estado"]) ?? "";
            cita.Tipo = Convert.ToString(lector["Tipo"]) ?? "";

            return cita;
        }

        public bool ExistePacienteActivo(int idPaciente)
        {
            return EjecutarConteo("SELECT COUNT(*) FROM Paciente WHERE id_paciente = @id AND Activo = 1", idPaciente) > 0;
        }

        public bool ExisteMedicoActivo(int idMedico)
        {
            return EjecutarConteo("SELECT COUNT(*) FROM Medico WHERE id_medico = @id AND Activo = 1", idMedico) > 0;
        }

        public int ContarCitasPendientesPorPaciente(int idPaciente)
        {
            return EjecutarConteo(@"SELECT COUNT(*) FROM Cita c INNER JOIN Estado_de_Cita e ON c.id_estado = e.id_estado WHERE c.id_paciente = @id AND c.Fecha >= CURDATE() AND e.Nombre IN ('Programada', 'Confirmada')", idPaciente);
        }

        public int ContarCitasPendientesPorMedico(int idMedico)
        {
            return EjecutarConteo(@"SELECT COUNT(*) FROM Cita c INNER JOIN Estado_de_Cita e ON c.id_estado = e.id_estado WHERE c.id_medico = @id AND c.Fecha >= CURDATE() AND e.Nombre IN ('Programada', 'Confirmada')", idMedico);
        }

        private int EjecutarConteo(string consulta, int id)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }

        public void CambiarEstado(int idCita, int idEstado)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "UPDATE Cita SET id_estado = @idEstado WHERE id_cita = @idCita";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idEstado", idEstado);
                    comando.Parameters.AddWithValue("@idCita", idCita);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public ResultadoRegistroCita RegistrarCita(Cita cita)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                using (MySqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        BloquearMedicoYPaciente(conexion, transaccion, cita.IdMedico, cita.IdPaciente);

                        if (ExisteCruceMedico(conexion, transaccion, cita, 0))
                        {
                            transaccion.Rollback();
                            return ResultadoRegistroCita.ConflictoMedico;
                        }

                        if (ExisteCrucePaciente(conexion, transaccion, cita, 0))
                        {
                            transaccion.Rollback();
                            return ResultadoRegistroCita.ConflictoPaciente;
                        }

                        InsertarCita(conexion, transaccion, cita);

                        transaccion.Commit();
                        return ResultadoRegistroCita.Registrada;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        public ResultadoRegistroCita ReprogramarCita(int idCitaOriginal, Cita citaNueva, int idEstadoReprogramada)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                using (MySqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        BloquearMedicoYPaciente(conexion, transaccion, citaNueva.IdMedico, citaNueva.IdPaciente);

                        if (ExisteCruceMedico(conexion, transaccion, citaNueva, idCitaOriginal))
                        {
                            transaccion.Rollback();
                            return ResultadoRegistroCita.ConflictoMedico;
                        }

                        if (ExisteCrucePaciente(conexion, transaccion, citaNueva, idCitaOriginal))
                        {
                            transaccion.Rollback();
                            return ResultadoRegistroCita.ConflictoPaciente;
                        }

                        string consulta = "UPDATE Cita SET id_estado = @idEstado WHERE id_cita = @idCita";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion, transaccion))
                        {
                            comando.Parameters.AddWithValue("@idEstado", idEstadoReprogramada);
                            comando.Parameters.AddWithValue("@idCita", idCitaOriginal);
                            comando.ExecuteNonQuery();
                        }

                        InsertarCita(conexion, transaccion, citaNueva);

                        transaccion.Commit();
                        return ResultadoRegistroCita.Registrada;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        private void BloquearMedicoYPaciente(MySqlConnection conexion, MySqlTransaction transaccion, int idMedico, int idPaciente)
        {
            using (MySqlCommand comando = new MySqlCommand("SELECT id_medico FROM Medico WHERE id_medico = @id FOR UPDATE", conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@id", idMedico);
                comando.ExecuteScalar();
            }

            using (MySqlCommand comando = new MySqlCommand("SELECT id_paciente FROM Paciente WHERE id_paciente = @id FOR UPDATE", conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@id", idPaciente);
                comando.ExecuteScalar();
            }
        }

        private bool ExisteCruceMedico(MySqlConnection conexion, MySqlTransaction transaccion, Cita cita, int idCitaExcluir)
        {
            string consulta = @"SELECT COUNT(*) FROM Cita c INNER JOIN Estado_de_Cita e ON c.id_estado = e.id_estado WHERE c.id_medico = @idMedico AND c.Fecha = @fecha AND c.Hora < @horaFin AND c.HoraFin > @hora AND e.Nombre NOT IN ('Cancelada', 'Reprogramada') AND c.id_cita <> @idExcluir";

            using (MySqlCommand comando = new MySqlCommand(consulta, conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@idMedico", cita.IdMedico);
                comando.Parameters.AddWithValue("@fecha", cita.Fecha.Date);
                comando.Parameters.AddWithValue("@hora", cita.Hora);
                comando.Parameters.AddWithValue("@horaFin", cita.HoraFin);
                comando.Parameters.AddWithValue("@idExcluir", idCitaExcluir);

                return Convert.ToInt32(comando.ExecuteScalar()) > 0;
            }
        }

        private bool ExisteCrucePaciente(MySqlConnection conexion, MySqlTransaction transaccion, Cita cita, int idCitaExcluir)
        {
            string consulta = @"SELECT COUNT(*) FROM Cita c INNER JOIN Estado_de_Cita e ON c.id_estado = e.id_estado WHERE c.id_paciente = @idPaciente AND c.Fecha = @fecha AND c.Hora < @horaFin AND c.HoraFin > @hora AND e.Nombre NOT IN ('Cancelada', 'Reprogramada') AND c.id_cita <> @idExcluir";

            using (MySqlCommand comando = new MySqlCommand(consulta, conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@idPaciente", cita.IdPaciente);
                comando.Parameters.AddWithValue("@fecha", cita.Fecha.Date);
                comando.Parameters.AddWithValue("@hora", cita.Hora);
                comando.Parameters.AddWithValue("@horaFin", cita.HoraFin);
                comando.Parameters.AddWithValue("@idExcluir", idCitaExcluir);

                return Convert.ToInt32(comando.ExecuteScalar()) > 0;
            }
        }

        private void InsertarCita(MySqlConnection conexion, MySqlTransaction transaccion, Cita cita)
        {
            string consulta = @"INSERT INTO Cita (id_paciente, id_medico, id_estado, id_tip, Fecha, Hora, DuracionMinutos, Motivo) VALUES (@idPaciente, @idMedico, @idEstado, @idTipo, @fecha, @hora, @duracion, @motivo)";

            using (MySqlCommand comando = new MySqlCommand(consulta, conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@idPaciente", cita.IdPaciente);
                comando.Parameters.AddWithValue("@idMedico", cita.IdMedico);
                comando.Parameters.AddWithValue("@idEstado", cita.IdEstado);
                comando.Parameters.AddWithValue("@idTipo", cita.IdTipo);
                comando.Parameters.AddWithValue("@fecha", cita.Fecha.Date);
                comando.Parameters.AddWithValue("@hora", cita.Hora);
                comando.Parameters.AddWithValue("@duracion", cita.DuracionMinutos);
                comando.Parameters.AddWithValue("@motivo", string.IsNullOrWhiteSpace(cita.Motivo) ? (object)DBNull.Value : cita.Motivo);

                comando.ExecuteNonQuery();
            }
        }
    }
}