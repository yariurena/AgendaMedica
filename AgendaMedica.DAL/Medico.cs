using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaMedica.DAL
{
    public class Medico
    {
        public int IdMedico { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public int IdEspecialidad { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
