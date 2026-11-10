using System;
using System.Data;
using AgendaMedica.DAL;

namespace AgendaMedica.BL
{
    public class ServicioMedico
    {
        public DataTable ObtenerMedicos()
        {
            MedicoDAL datos = new MedicoDAL();

            return datos.ObtenerMedicos();
        }

        public void RegistrarMedico(Medico medico)
        {
            if (medico == null)
            {
                throw new Exception("No se proporcionaron los datos del médico.");
            }

            if (string.IsNullOrWhiteSpace(medico.Nombre))
            {
                throw new Exception("El nombre del médico es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(medico.Apellidos))
            {
                throw new Exception("Los apellidos del médico son obligatorios.");
            }

            if (medico.IdEspecialidad <= 0)
            {
                throw new Exception("Debe seleccionar una especialidad.");
            }

            if (string.IsNullOrWhiteSpace(medico.Email))
            {
                throw new Exception("El correo electrónico es obligatorio.");
            }

            MedicoDAL datos = new MedicoDAL();

            datos.InsertarMedico(medico);
        }
    }
}