namespace AgendaMedica.Modelos
{
    public class Cita
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdEstado { get; set; }
        public int IdTipo { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int DuracionMinutos { get; set; } = 30;
        public string Motivo { get; set; } = string.Empty;

        public TimeSpan HoraFin
        {
            get { return Hora + TimeSpan.FromMinutes(DuracionMinutos); }
        }

        public string NombrePaciente { get; set; } = string.Empty;
        public string NombreMedico { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
    }
}