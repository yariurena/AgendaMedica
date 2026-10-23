using AgendaMedica.DAL;

namespace AgendaMedica.BL
{
    public class ServicioConexion
    {
        public static string ProbarConexion()
        {
            return ConexionBD.ProbarConexion();
        }
    }
}
