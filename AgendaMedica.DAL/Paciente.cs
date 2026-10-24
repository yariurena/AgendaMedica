using System;

namespace AgendaMedica.DAL
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; } = "";
        public string Apellidos { get; set; } = "";
        public string Cedula { get; set; } = "";
        public string Direccion { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; } = "";
    }
}
