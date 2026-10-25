using System.Data;
using AgendaMedica.DAL;

namespace AgendaMedica.BL
{
    public class ServicioPaciente
    {
        private readonly PacienteDAL datos = new PacienteDAL();
        public DataTable ObtenerPacientes()
        {
            return datos.ObtenerPacientes();
        }

        public void RegistrarPaciente(Paciente paciente)
        {
            if (paciente == null)
            {
                throw new System.ArgumentNullException(nameof(paciente));
            }
            if (string.IsNullOrWhiteSpace(paciente.Nombre))
            {
                throw new System.ArgumentException("El nombre es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(paciente.Apellidos))
            {
                throw new System.ArgumentException("Los apellidos son obligatorios.");
            }
            if (string.IsNullOrWhiteSpace(paciente.Cedula))
            {
                throw new System.ArgumentException("La cédula es obligatoria.");
            }
            if (datos.ExisteCedula(paciente.Cedula))
            {
                throw new System.ArgumentException("Ya existe un paciente con esa cédula.");
            }

            datos.InsertarPaciente(paciente);
        }
    }
}
