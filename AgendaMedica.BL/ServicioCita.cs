using System;
using System.Collections.Generic;
using System.Linq;
using AgendaMedica.DAL;
using AgendaMedica.Modelos;

namespace AgendaMedica.BL
{
    public class ServicioCita
    {
        private readonly CitaDAL datosCita = new CitaDAL();
        private readonly HorarioMedicoDAL datosHorario = new HorarioMedicoDAL();

        private static readonly int[] DuracionesValidas = { 30, 45, 60 };

        public List<CatalogoItem> ObtenerEstados()
        {
            return datosCita.ObtenerEstados();
        }

        public List<CatalogoItem> ObtenerTipos()
        {
            return datosCita.ObtenerTipos();
        }

        public List<Cita> BuscarCitas(int? idMedico, int? idPaciente, DateTime? fecha, int? idEstado)
        {
            return datosCita.BuscarCitas(idMedico, idPaciente, fecha, idEstado);
        }

        public void RegistrarCita(Cita cita)
        {
            ValidarCita(cita);

            cita.IdEstado = ObtenerIdEstado("Programada");

            ResultadoRegistroCita resultado = datosCita.RegistrarCita(cita);
            InterpretarResultado(resultado);
        }

        public void ReprogramarCita(int idCitaOriginal, DateTime nuevaFecha, TimeSpan nuevaHora, int nuevaDuracion)
        {
            if (idCitaOriginal <= 0)
            {
                throw new ArgumentException("La cita seleccionada no es válida.");
            }

            Cita? original = datosCita.ObtenerCitaPorId(idCitaOriginal);

            if (original == null)
            {
                throw new ArgumentException("La cita seleccionada no existe.");
            }

            if (original.Estado != "Programada" && original.Estado != "Confirmada")
            {
                throw new InvalidOperationException("Solo se pueden reprogramar citas en estado Programada o Confirmada.");
            }

            if (nuevaFecha.Date == original.Fecha.Date && nuevaHora == original.Hora)
            {
                throw new InvalidOperationException("Debe elegir una fecha u hora distinta a la de la cita actual.");
            }

            Cita nueva = new Cita
            {
                IdPaciente = original.IdPaciente,
                IdMedico = original.IdMedico,
                IdTipo = original.IdTipo,
                Fecha = nuevaFecha.Date,
                Hora = nuevaHora,
                DuracionMinutos = nuevaDuracion,
                Motivo = original.Motivo,
                IdEstado = ObtenerIdEstado("Programada")
            };

            ValidarCita(nueva);

            int idReprogramada = ObtenerIdEstado("Reprogramada");

            ResultadoRegistroCita resultado = datosCita.ReprogramarCita(idCitaOriginal, nueva, idReprogramada);
            InterpretarResultado(resultado);
        }

        public string[] ObtenerEstadosPermitidos(string estadoActual)
        {
            switch (estadoActual)
            {
                case "Programada":
                    return new[] { "Confirmada", "Atendida", "No asistió", "Cancelada" };
                case "Confirmada":
                    return new[] { "Atendida", "No asistió", "Cancelada" };
                default:
                    return new string[0];
            }
        }

        public void CambiarEstado(int idCita, string nuevoEstado)
        {
            if (idCita <= 0)
            {
                throw new ArgumentException("La cita seleccionada no es válida.");
            }

            Cita? cita = datosCita.ObtenerCitaPorId(idCita);

            if (cita == null)
            {
                throw new ArgumentException("La cita seleccionada no existe.");
            }

            if (nuevoEstado == "Reprogramada")
            {
                throw new InvalidOperationException("Para reprogramar una cita use la opción Reprogramar.");
            }

            string[] permitidos = ObtenerEstadosPermitidos(cita.Estado);

            if (!permitidos.Contains(nuevoEstado))
            {
                throw new InvalidOperationException("No se puede cambiar una cita de '" + cita.Estado + "' a '" + nuevoEstado + "'.");
            }

            if ((nuevoEstado == "Atendida" || nuevoEstado == "No asistió") && cita.Fecha.Date > DateTime.Today)
            {
                throw new InvalidOperationException("No se puede marcar como '" + nuevoEstado + "' una cita de un día futuro.");
            }

            datosCita.CambiarEstado(idCita, ObtenerIdEstado(nuevoEstado));
        }

        private void ValidarCita(Cita cita)
        {
            if (cita == null)
            {
                throw new ArgumentNullException(nameof(cita));
            }

            if (cita.IdPaciente <= 0)
            {
                throw new ArgumentException("Debe seleccionar un paciente.");
            }

            if (cita.IdMedico <= 0)
            {
                throw new ArgumentException("Debe seleccionar un médico.");
            }

            if (cita.IdTipo <= 0)
            {
                throw new ArgumentException("Debe seleccionar el tipo de cita.");
            }

            cita.Motivo = cita.Motivo?.Trim() ?? "";

            if (cita.Motivo.Length > 255)
            {
                throw new ArgumentException("El motivo no puede superar los 255 caracteres.");
            }

            if (!DuracionesValidas.Contains(cita.DuracionMinutos))
            {
                throw new ArgumentException("La duración de la cita debe ser de 30, 45 o 60 minutos.");
            }

            cita.Fecha = cita.Fecha.Date;

            if (cita.Fecha + cita.Hora < DateTime.Now)
            {
                throw new InvalidOperationException("No se puede agendar una cita en una fecha y hora que ya pasaron.");
            }

            if (!datosCita.ExistePacienteActivo(cita.IdPaciente))
            {
                throw new InvalidOperationException("El paciente seleccionado no existe o está inactivo.");
            }

            if (!datosCita.ExisteMedicoActivo(cita.IdMedico))
            {
                throw new InvalidOperationException("El médico seleccionado no existe o está inactivo.");
            }

            if (!datosCita.ObtenerTipos().Any(t => t.Id == cita.IdTipo))
            {
                throw new ArgumentException("El tipo de cita seleccionado no es válido.");
            }

            string dia = ObtenerNombreDia(cita.Fecha);

            if (!datosHorario.ExisteHorarioQueCubra(cita.IdMedico, dia, cita.Hora, cita.HoraFin))
            {
                throw new InvalidOperationException("El médico no atiende el " + dia.ToLower() + " de " + cita.Hora.ToString(@"hh\:mm") + " a " + cita.HoraFin.ToString(@"hh\:mm") + ". La cita debe quedar completa dentro de su horario de atención.");
            }
        }

        private void InterpretarResultado(ResultadoRegistroCita resultado)
        {
            if (resultado == ResultadoRegistroCita.ConflictoMedico)
            {
                throw new InvalidOperationException("El médico ya tiene una cita que se cruza con ese horario.");
            }

            if (resultado == ResultadoRegistroCita.ConflictoPaciente)
            {
                throw new InvalidOperationException("El paciente ya tiene una cita que se cruza con ese horario.");
            }
        }

        private int ObtenerIdEstado(string nombre)
        {
            CatalogoItem? estado = datosCita.ObtenerEstados().FirstOrDefault(e => string.Equals(e.Nombre, nombre, StringComparison.OrdinalIgnoreCase));

            if (estado == null)
            {
                throw new InvalidOperationException("No existe el estado '" + nombre + "' en la base de datos.");
            }

            return estado.Id;
        }

        private static string ObtenerNombreDia(DateTime fecha)
        {
            return fecha.DayOfWeek switch
            {
                DayOfWeek.Monday => "Lunes",
                DayOfWeek.Tuesday => "Martes",
                DayOfWeek.Wednesday => "Miércoles",
                DayOfWeek.Thursday => "Jueves",
                DayOfWeek.Friday => "Viernes",
                DayOfWeek.Saturday => "Sábado",
                _ => "Domingo"
            };
        }
    }
}