
using System;

namespace AgendaMedica.Modelos
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; } = "";
        public string PrimerApellido { get; set; } = "";
        public string SegundoApellido { get; set; } = "";
        public string Cedula { get; set; } = "";
        public string Direccion { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; } = "";
    }
}
