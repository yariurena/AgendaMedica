
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
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

            paciente.Nombre = paciente.Nombre?.Trim() ?? "";
            paciente.PrimerApellido = paciente.PrimerApellido?.Trim() ?? "";
            paciente.SegundoApellido = paciente.SegundoApellido?.Trim() ?? "";
            paciente.Cedula = paciente.Cedula?.Trim() ?? "";
            paciente.Direccion = paciente.Direccion?.Trim() ?? "";
            paciente.Email = paciente.Email?.Trim() ?? "";
            paciente.Telefono = paciente.Telefono?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(paciente.Nombre))
            {
                throw new ArgumentException("El nombre es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(paciente.PrimerApellido))
            {
                throw new ArgumentException("El primer apellido es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(paciente.SegundoApellido))
            {
                throw new ArgumentException("El segundo apellido es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(paciente.Cedula))
            {
                throw new ArgumentException("La cédula es obligatoria.");
            }

            if (!Regex.IsMatch(paciente.Cedula, @"^\d{9}$"))
            {
                throw new ArgumentException("La cédula debe contener exactamente 9 dígitos.");
            }

            if (!string.IsNullOrWhiteSpace(paciente.Email))
            {
                try
                {
                    MailAddress correo = new MailAddress(paciente.Email);

                    if (correo.Address != paciente.Email)
                    {
                        throw new ArgumentException("El correo electrónico no tiene un formato válido.");
                    }
                }
                catch (FormatException)
                {
                    throw new ArgumentException("El correo electrónico no tiene un formato válido.");
                }
            }

            if (!string.IsNullOrWhiteSpace(paciente.Telefono))
            {
                string telefono = Regex.Replace(paciente.Telefono, @"[\s\-()]", "");

                if (!Regex.IsMatch(telefono, @"^(?:\+506)?\d{8}$"))
                {
                    throw new ArgumentException("El teléfono debe contener 8 dígitos. También puede incluir el código +506.");
                }
            }

            if (paciente.FechaNacimiento.HasValue)
            {
                DateTime fecha = paciente.FechaNacimiento.Value.Date;
                DateTime hoy = DateTime.Today;

                if (fecha > hoy)
                {
                    throw new ArgumentException("La fecha de nacimiento no puede ser futura.");
                }

                if (fecha < hoy.AddYears(-120))
                {
                    throw new ArgumentException("La fecha de nacimiento no es razonable.");
                }
            }
        }
    }
}
