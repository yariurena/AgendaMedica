
using System;
using System.Collections.Generic;
using AgendaMedica.DAL;
using PacienteModelo = AgendaMedica.Modelos.Paciente;

namespace AgendaMedica.BL
{
    public class ServicioPaciente
    {
        private readonly PacienteDAL datos = new PacienteDAL();
        public List<PacienteModelo> ObtenerPacientes()
        {
            return datos.ObtenerPacientes();
        }

        public void RegistrarPaciente(PacienteModelo paciente)
        {
            ValidarPaciente(paciente);

            if (datos.ExisteCedula(paciente.Cedula))
            {
                throw new ArgumentException("Ya existe un paciente con esa cédula.");
            }
            datos.InsertarPaciente(paciente);
        }

        public void ActualizarPaciente(PacienteModelo paciente)
        {
            ValidarPaciente(paciente);

            if (paciente.IdPaciente <= 0)
            {
                throw new ArgumentException("El paciente seleccionado no es válido.");
            }

            if (datos.ExisteCedula(paciente.Cedula, paciente.IdPaciente))
            {
                throw new ArgumentException("Otro paciente ya está registrado con esa cédula.");
            }
            datos.ActualizarPaciente(paciente);
        }

        private void ValidarPaciente(PacienteModelo paciente)
        {
            if (paciente == null)
            {
                throw new ArgumentNullException(nameof(paciente));
            }

            if (string.IsNullOrWhiteSpace(paciente.Nombre))
            {
                throw new ArgumentException("El nombre es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(paciente.Apellidos))
            {
                throw new ArgumentException("Los apellidos son obligatorios.");
            }

            if (string.IsNullOrWhiteSpace(paciente.Cedula))
            {
                throw new ArgumentException("La cédula es obligatoria.");
            }
        }
    }
}
