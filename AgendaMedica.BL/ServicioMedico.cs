
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
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
            ValidarMedico(medico);
            datos.InsertarMedico(medico);
        }

        public void ActualizarMedico(MedicoModelo medico)
        {
            ValidarMedico(medico);

            if (medico.IdMedico <= 0)
            {
                throw new ArgumentException("El médico seleccionado no es válido.");
            }
            datos.ActualizarMedico(medico);
        }

        private void ValidarMedico(MedicoModelo medico)
        {
            if (medico == null)
            {
                throw new ArgumentNullException(nameof(medico), "No se proporcionaron los datos del médico.");
            }

            medico.Nombre = medico.Nombre?.Trim() ?? "";
            medico.PrimerApellido = medico.PrimerApellido?.Trim() ?? "";
            medico.SegundoApellido = medico.SegundoApellido?.Trim() ?? "";
            medico.Email = medico.Email?.Trim() ?? "";
            medico.Telefono = medico.Telefono?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(medico.Nombre))
            {
                throw new ArgumentException("El nombre del médico es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(medico.PrimerApellido))
            {
                throw new ArgumentException("El primer apellido del médico es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(medico.SegundoApellido))
            {
                throw new ArgumentException("El segundo apellido del médico es obligatorio.");
            }

            if (medico.IdEspecialidad <= 0)
            {
                throw new ArgumentException("Debe seleccionar una especialidad.");
            }

            if (!datos.ExisteEspecialidad(medico.IdEspecialidad))
            {
                throw new ArgumentException("La especialidad seleccionada no existe.");
            }

            if (string.IsNullOrWhiteSpace(medico.Email))
            {
                throw new ArgumentException("El correo electrónico es obligatorio.");
            }

            try
            {
                MailAddress correo = new MailAddress(medico.Email);

                if (correo.Address != medico.Email)
                {
                    throw new ArgumentException("El correo electrónico no tiene un formato válido.");
                }
            }
            catch (FormatException)
            {
                throw new ArgumentException("El correo electrónico no tiene un formato válido.");
            }

            if (!string.IsNullOrWhiteSpace(medico.Telefono))
            {
                string telefono = Regex.Replace(medico.Telefono, @"[\s\-()]", "");

                if (!Regex.IsMatch(telefono, @"^(?:\+506)?\d{8}$"))
                {
                    throw new ArgumentException("El teléfono debe contener 8 dígitos. También puede incluir el código +506.");
                }
            }
        }
    }
}