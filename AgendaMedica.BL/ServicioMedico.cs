using AgendaMedica.DAL;
using MedicoModelo = AgendaMedica.Modelos.Medico;

namespace AgendaMedica.BL
{
    public class ServicioMedico
    {
        private readonly MedicoDAL datos = new MedicoDAL();
        public List<MedicoModelo> ObtenerMedicos()
        {
            return datos.ObtenerMedicos();
        }

        public void RegistrarMedico(MedicoModelo medico)
        {
            if (medico == null)
            {
                throw new ArgumentNullException(nameof(medico),"No se proporcionaron los datos del médico.");
            }

            if (string.IsNullOrWhiteSpace(medico.Nombre))
            {
                throw new ArgumentException("El nombre del médico es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(medico.Apellidos))
            {
                throw new ArgumentException("Los apellidos del médico son obligatorios.");
            }

            if (medico.IdEspecialidad <= 0)
            {
                throw new ArgumentException("Debe seleccionar una especialidad.");
            }

            if (string.IsNullOrWhiteSpace(medico.Email))
            {
                throw new ArgumentException("El correo electrónico es obligatorio.");
            }
            datos.InsertarMedico(medico);
        }
    }
}