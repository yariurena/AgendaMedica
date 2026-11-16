namespace AgendaMedica.Modelos
{
    public class HistorialMedico
    {
        public int IdHistorial { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Diagnostico { get; set; } = string.Empty;
        public string Tratamiento { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public string NombrePaciente { get; set; } = string.Empty;
        public string NombreMedico { get; set; } = string.Empty;
        public string RegistradoPor { get; set; } = string.Empty;
    }
}