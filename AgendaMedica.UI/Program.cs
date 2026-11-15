using AgendaMedica.BL;

namespace AgendaMedica.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                ServicioUsuario servicio = new ServicioUsuario();

                if (servicio.AsegurarAdministradorInicial())
                {
                    MessageBox.Show("Es la primera vez que se abre el sistema, así que se creó el usuario administrador inicial:\n\n" + "Correo: " + ServicioUsuario.CorreoAdministradorInicial + "\n" + "Contraseña: " + ServicioUsuario.ContrasenaAdministradorInicial, "Administrador inicial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo preparar el sistema: " + ex.Message, "Error de inicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            while (true)
            {
                using (FrmLogin login = new FrmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        break;
                    }
                }

                Application.Run(new FrmPrincipal());

                if (SesionActual.HayUsuario)
                {
                    break;
                }
            }
        }
    }
}