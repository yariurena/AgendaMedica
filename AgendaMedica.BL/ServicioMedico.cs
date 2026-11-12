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

            try
            {
                MailAddress correo = new MailAddress(medico.Email.Trim());

                if (correo.Address != medico.Email.Trim())
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
                string telefono = Regex.Replace(medico.Telefono, @"[\s\-\(\)]","");

                if (!Regex.IsMatch(telefono, @"^(?:\+506)?\d{8}$"))
                {
                    throw new ArgumentException("El teléfono debe contener 8 dígitos. También puede incluir el código +506.");
                }
            }

            medico.Nombre = medico.Nombre.Trim();
            medico.Apellidos = medico.Apellidos.Trim();
            medico.Email = medico.Email.Trim();
            medico.Telefono = medico.Telefono?.Trim() ?? "";
        }
    }
}