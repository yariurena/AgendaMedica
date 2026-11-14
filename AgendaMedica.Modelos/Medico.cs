namespace AgendaMedica.Modelos
{
    public class Medico : Persona
    {
        public int IdMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public string NombreEspecialidad { get; set; } = string.Empty;
    }
}