using System;
using System.Collections.Generic;
using AgendaMedica.DAL;
using EspecialidadModelo = AgendaMedica.Modelos.Especialidad;

namespace AgendaMedica.BL
{
    public class ServicioEspecialidad
    {
        private readonly EspecialidadDAL datos = new EspecialidadDAL();
        private readonly MedicoDAL datosMedico = new MedicoDAL();

        public List<EspecialidadModelo> ObtenerEspecialidades()
        {
            return datos.ObtenerEspecialidades();
        }

        public void RegistrarEspecialidad(EspecialidadModelo especialidad)
        {
            ValidarEspecialidad(especialidad);

            if (datos.ExisteNombre(especialidad.Nombre))
            {
                throw new ArgumentException("Ya existe una especialidad con ese nombre.");
            }
            datos.InsertarEspecialidad(especialidad);
        }

        public void ActualizarEspecialidad(EspecialidadModelo especialidad)
        {
            ValidarEspecialidad(especialidad);

            if (especialidad.IdEspecialidad <= 0)
            {
                throw new ArgumentException("La especialidad seleccionada no es válida.");
            }

            if (datos.ExisteNombre(especialidad.Nombre, especialidad.IdEspecialidad))
            {
                throw new ArgumentException("Otra especialidad ya tiene ese nombre.");
            }
            datos.ActualizarEspecialidad(especialidad);
        }

        public void DesactivarEspecialidad(int idEspecialidad)
        {
            if (idEspecialidad <= 0)
            {
                throw new ArgumentException("La especialidad seleccionada no es válida.");
            }

            int medicosActivos = datosMedico.ContarMedicosActivosPorEspecialidad(idEspecialidad);

            if (medicosActivos > 0)
            {
                throw new InvalidOperationException(
                    "No se puede desactivar la especialidad porque tiene " + medicosActivos +
                    " médico(s) activo(s). Reasigne o desactive primero a esos médicos.");
            }
            datos.DesactivarEspecialidad(idEspecialidad);
        }

        private void ValidarEspecialidad(EspecialidadModelo especialidad)
        {
            if (especialidad == null)
            {
                throw new ArgumentNullException(nameof(especialidad), "No se proporcionaron los datos de la especialidad.");
            }

            if (string.IsNullOrWhiteSpace(especialidad.Nombre))
            {
                throw new ArgumentException("El nombre de la especialidad es obligatorio.");
            }

            if (especialidad.Nombre.Trim().Length > 100)
            {
                throw new ArgumentException("El nombre de la especialidad no puede superar los 100 caracteres.");
            }
            especialidad.Nombre = especialidad.Nombre.Trim();
        }
    }
}