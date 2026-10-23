using System;
using System.Text;
using System.Collections.Generic;
using AgendaMedica.DAL;

namespace AgendaMedica.BL
{
    public class ServicioEspecialidad
    {
        public List<string> ObtenerEspecialidades()
        {
            EspecialidadDAL datos = new EspecialidadDAL();

            return datos.ObtenerEspecialidades();
        }
    }
}
