using System.Collections.Generic;
using AgendaMedica.DAL;
using EspecialidadModelo = AgendaMedica.Modelos.Especialidad;

namespace AgendaMedica.BL
{
    public class ServicioEspecialidad
    {
        private readonly EspecialidadDAL datos = new EspecialidadDAL();
        public List<EspecialidadModelo> ObtenerEspecialidades()
        {
            return datos.ObtenerEspecialidades();
        }
    }
}