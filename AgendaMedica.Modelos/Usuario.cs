using System.ComponentModel;

namespace AgendaMedica.Modelos
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string PrimerApellido { get; set; } = string.Empty;
        public string SegundoApellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [Browsable(false)]
        public string Contrasena { get; set; } = string.Empty;

        public int IdRol { get; set; }
        public string Rol { get; set; } = string.Empty;

        [Browsable(false)]
        public string NombreCompleto
        {
            get { return (Nombre + " " + PrimerApellido + " " + SegundoApellido).Trim(); }
        }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}