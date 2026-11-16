using AgendaMedica.BL;

namespace AgendaMedica.UI
{
    public partial class FrmPrincipal : Form
    {
        private readonly ServicioUsuario servicioUsuario = new ServicioUsuario();

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object? sender, EventArgs e)
        {
            if (SesionActual.Usuario != null)
            {
                lblBienvenida.Text = "Bienvenido(a), " + SesionActual.Usuario.NombreCompleto + "   |   Rol: " + SesionActual.Usuario.Rol;
            }
            AplicarPermisos();
        }

        private void AplicarPermisos()
        {
            mnuPacientes.Available = SesionActual.TienePermiso(Modulo.Pacientes);
            mnuMedicos.Available = SesionActual.TienePermiso(Modulo.Medicos);
            mnuEspecialidades.Available = SesionActual.TienePermiso(Modulo.Especialidades);
            mnuHorarios.Available = SesionActual.TienePermiso(Modulo.Horarios);
            mnuCitas.Available = SesionActual.TienePermiso(Modulo.Citas);
            mnuHistorial.Available = SesionActual.TienePermiso(Modulo.Historial);
            mnuReportes.Available = SesionActual.TienePermiso(Modulo.Reportes);
            mnuUsuarios.Available = SesionActual.TienePermiso(Modulo.Usuarios);

            mnuGestion.Available = mnuPacientes.Available || mnuMedicos.Available || mnuEspecialidades.Available || mnuHorarios.Available;
            mnuConsultas.Available = mnuHistorial.Available || mnuReportes.Available;
            mnuAdministracion.Available = mnuUsuarios.Available;
        }

        private void AbrirVentana(Form ventana, Modulo modulo)
        {
            if (!SesionActual.TienePermiso(modulo))
            {
                ventana.Dispose();
                MessageBox.Show("No tiene permiso para acceder a este módulo.");
                return;
            }

            using (ventana)
            {
                ventana.ShowDialog(this);
            }
        }

        private void mnuPacientes_Click(object? sender, EventArgs e)
        {
            AbrirVentana(new FrmPacientes(), Modulo.Pacientes);
        }

        private void mnuMedicos_Click(object? sender, EventArgs e)
        {
            AbrirVentana(new FrmMedicos(), Modulo.Medicos);
        }

        private void mnuEspecialidades_Click(object? sender, EventArgs e)
        {
            AbrirVentana(new FrmEspecialidades(), Modulo.Especialidades);
        }

        private void mnuHorarios_Click(object? sender, EventArgs e)
        {
            AbrirVentana(new FrmHorarios(), Modulo.Horarios);
        }

        private void mnuCitas_Click(object? sender, EventArgs e)
        {
            AbrirVentana(new FrmCitas(), Modulo.Citas);
        }

        private void mnuHistorial_Click(object? sender, EventArgs e)
        {
            AbrirVentana(new FrmHistorial(), Modulo.Historial);
        }

        private void mnuReportes_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Este módulo se agrega en uno de los siguientes pasos.");
        }

        private void mnuUsuarios_Click(object? sender, EventArgs e)
        {
            AbrirVentana(new FrmUsuarios(), Modulo.Usuarios);
        }

        private void mnuCerrarSesion_Click(object? sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea cerrar la sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            servicioUsuario.CerrarSesion();
            Close();
        }
    }
}