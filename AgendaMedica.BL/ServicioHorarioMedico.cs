using System;
using System.Collections.Generic;
using AgendaMedica.DAL;
using HorarioModelo = AgendaMedica.Modelos.HorarioMedico;

namespace AgendaMedica.BL
{
    public class ServicioHorarioMedico
    {
        private readonly HorarioMedicoDAL datos = new HorarioMedicoDAL();
        private static readonly string[] DiasValidos = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };

        public List<HorarioModelo> ObtenerHorariosPorMedico(int idMedico)
        {
            if (idMedico <= 0)
            {
                throw new ArgumentException("Debe seleccionar un médico.");
            }
            return datos.ObtenerHorariosPorMedico(idMedico);
        }

        public void RegistrarHorario(HorarioModelo horario)
        {
            if (horario == null)
            {
                throw new ArgumentNullException(nameof(horario));
            }

            if (horario.IdMedico <= 0)
            {
                throw new ArgumentException("Debe seleccionar un médico.");
            }

            if (Array.IndexOf(DiasValidos, horario.Dia) < 0)
            {
                throw new ArgumentException("Debe seleccionar un día válido.");
            }

            if (horario.HoraInicio >= horario.HoraFin)
            {
                throw new ArgumentException("La hora de inicio debe ser menor que la hora de fin.");
            }

            if (datos.ExisteSolapamiento(horario.IdMedico, horario.Dia, horario.HoraInicio, horario.HoraFin))
            {
                throw new InvalidOperationException("Ese horario se cruza con otro ya registrado para el médico ese día.");
            }

            datos.InsertarHorario(horario);
        }

        public void EliminarHorario(int idHorario)
        {
            if (idHorario <= 0)
            {
                throw new ArgumentException("El horario seleccionado no es válido.");
            }
            datos.EliminarHorario(idHorario);
        }
    }
}