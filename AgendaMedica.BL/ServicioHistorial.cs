using System;
using System.Collections.Generic;
using AgendaMedica.DAL;
using AgendaMedica.Modelos;

namespace AgendaMedica.BL
{
    public class ServicioHistorial
    {
        private const int LargoMaximo = 2000;

        private readonly HistorialMedicoDAL datos = new HistorialMedicoDAL();
        private readonly CitaDAL datosCita = new CitaDAL();

        public List<HistorialMedico> ObtenerPorPaciente(int idPaciente)
        {
            ExigirPermiso();

            if (idPaciente <= 0)
            {
                throw new ArgumentException("Debe seleccionar un paciente.");
            }
            return datos.ObtenerPorPaciente(idPaciente);
        }

        public void RegistrarEntrada(HistorialMedico entrada)
        {
            ExigirPermiso();

            if (entrada == null)
            {
                throw new ArgumentNullException(nameof(entrada));
            }

            if (entrada.IdPaciente <= 0)
            {
                throw new ArgumentException("Debe seleccionar un paciente.");
            }

            if (entrada.IdMedico <= 0)
            {
                throw new ArgumentException("Debe seleccionar el médico que atendió la consulta.");
            }

            entrada.Descripcion = entrada.Descripcion?.Trim() ?? "";
            entrada.Diagnostico = entrada.Diagnostico?.Trim() ?? "";
            entrada.Tratamiento = entrada.Tratamiento?.Trim() ?? "";
            entrada.Observaciones = entrada.Observaciones?.Trim() ?? "";

            if (entrada.Descripcion.Length == 0)
            {
                throw new ArgumentException("La descripción de la consulta es obligatoria.");
            }

            if (entrada.Diagnostico.Length == 0)
            {
                throw new ArgumentException("El diagnóstico es obligatorio.");
            }

            if (entrada.Descripcion.Length > LargoMaximo || entrada.Diagnostico.Length > LargoMaximo || entrada.Tratamiento.Length > LargoMaximo || entrada.Observaciones.Length > LargoMaximo)
            {
                throw new ArgumentException("Cada campo de texto puede tener como máximo " + LargoMaximo + " caracteres.");
            }

            entrada.Fecha = entrada.Fecha.Date;

            if (entrada.Fecha > DateTime.Today)
            {
                throw new InvalidOperationException("La fecha de la consulta no puede ser futura.");
            }

            if (!datosCita.ExistePacienteActivo(entrada.IdPaciente))
            {
                throw new InvalidOperationException("El paciente seleccionado no existe o está inactivo.");
            }

            if (!datosCita.ExisteMedicoActivo(entrada.IdMedico))
            {
                throw new InvalidOperationException("El médico seleccionado no existe o está inactivo.");
            }

            entrada.IdUsuario = SesionActual.Usuario?.IdUsuario;

            datos.InsertarEntrada(entrada);
        }

        private void ExigirPermiso()
        {
            if (!SesionActual.TienePermiso(Modulo.Historial))
            {
                throw new UnauthorizedAccessException("No tiene permiso para acceder al historial médico.");
            }
        }
    }
}