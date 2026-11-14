namespace AgendaMedica.Modelos
{
    public class HorarioMedico
    {
        public int IdHorario { get; set; }
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; } = string.Empty;
        public string Dia { get; set; } = string.Empty;
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}