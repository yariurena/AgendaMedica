using System;
using System.Collections.Generic;
using System.Linq;
using AgendaMedica.DAL;
using AgendaMedica.Modelos;

namespace AgendaMedica.BL
{
    public class ServicioReporte
    {
        private readonly CitaDAL datos = new CitaDAL();

        public List<Cita> CitasPorDiaYMedico(DateTime desde, DateTime hasta, int? idMedico)
        {
            Validar(desde, hasta);
            return datos.ObtenerCitasPorRango(desde, hasta, idMedico, null);
        }

        public List<Cita> CitasCanceladas(DateTime desde, DateTime hasta, int? idMedico)
        {
            Validar(desde, hasta);
            return datos.ObtenerCitasPorRango(desde, hasta, idMedico, "Cancelada");
        }

        public List<Cita> PacientesAtendidos(DateTime desde, DateTime hasta, int? idMedico)
        {
            Validar(desde, hasta);
            return datos.ObtenerCitasPorRango(desde, hasta, idMedico, "Atendida");
        }

        public int ContarPacientesDistintos(List<Cita> citas)
        {
            return citas.Select(c => c.IdPaciente).Distinct().Count();
        }

        private void Validar(DateTime desde, DateTime hasta)
        {
            if (!SesionActual.TienePermiso(Modulo.Reportes))
            {
                throw new UnauthorizedAccessException("No tiene permiso para consultar los reportes.");
            }

            if (desde.Date > hasta.Date)
            {
                throw new ArgumentException("La fecha inicial no puede ser posterior a la fecha final.");
            }
        }
    }
}