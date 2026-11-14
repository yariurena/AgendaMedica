using System.ComponentModel;

namespace AgendaMedica.Modelos
{
    public class Persona
    {
        public string Nombre { get; set; } = string.Empty;
        public string PrimerApellido { get; set; } = string.Empty;
        public string SegundoApellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

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