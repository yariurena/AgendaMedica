using AgendaMedica.Modelos;

namespace AgendaMedica.BL
{
    public static class SesionActual
    {
        public static Usuario? Usuario { get; private set; }

        public static bool HayUsuario
        {
            get { return Usuario != null; }
        }

        public static bool EsAdministrador
        {
            get { return Usuario != null && Usuario.Rol == "Administrador"; }
        }

        public static void Iniciar(Usuario usuario)
        {
            usuario.Contrasena = string.Empty;
            Usuario = usuario;
        }

        public static void Cerrar()
        {
            Usuario = null;
        }

        public static bool TienePermiso(Modulo modulo)
        {
            if (Usuario == null)
            {
                return false;
            }

            if (Usuario.Rol == "Administrador")
            {
                return true;
            }

            if (Usuario.Rol == "Recepción")
            {
                return modulo == Modulo.Pacientes || modulo == Modulo.Citas || modulo == Modulo.Reportes;
            }
            return false;
        }
    }
}