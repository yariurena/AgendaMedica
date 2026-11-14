using System;

namespace AgendaMedica.Modelos
{
    public class Paciente : Persona
    {
        public int IdPaciente { get; set; }
        public string Cedula { get; set; } = "";
        public string Direccion { get; set; } = "";
        public DateTime? FechaNacimiento { get; set; }
    }
}