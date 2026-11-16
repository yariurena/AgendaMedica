using AgendaMedica.BL;
using AgendaMedica.Modelos;

namespace AgendaMedica.UI
{
    public partial class FrmUsuarios : Form
    {
        private readonly ServicioUsuario servicio = new ServicioUsuario();

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object? sender, EventArgs e)
        {
            try
            {
                cmbRol.DataSource = servicio.ObtenerRoles();
                cmbRol.SelectedIndex = -1;

                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la gestión de usuarios: " + ex.Message);
            }
        }

        private void CargarUsuarios()
        {
            List<Usuario> usuarios = servicio.ObtenerUsuarios();

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarios;

            string[] ocultas = { "IdUsuario", "IdRol" };

            foreach (string nombre in ocultas)
            {
                if (dgvUsuarios.Columns[nombre] != null)
                    dgvUsuarios.Columns[nombre].Visible = false;
            }

            Dictionary<string, string> encabezados = new Dictionary<string, string>
            {
                { "Nombre", "Nombre" },
                { "PrimerApellido", "Primer apellido" },
                { "SegundoApellido", "Segundo apellido" },
                { "Email", "Correo electrónico" },
                { "Rol", "Rol" }
            };

            int posicion = 0;

            foreach (KeyValuePair<string, string> par in encabezados)
            {
                if (dgvUsuarios.Columns[par.Key] != null)
                {
                    dgvUsuarios.Columns[par.Key].HeaderText = par.Value;
                    dgvUsuarios.Columns[par.Key].DisplayIndex = posicion;
                    posicion++;
                }
            }
            dgvUsuarios.ClearSelection();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtCorreo.Clear();
            cmbRol.SelectedIndex = -1;
            txtContrasena.Clear();
            txtConfirmacion.Clear();
            txtNombre.Focus();
        }

        private void btnRegistrar_Click(object? sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario
                {
                    Nombre = txtNombre.Text,
                    PrimerApellido = txtPrimerApellido.Text,
                    SegundoApellido = txtSegundoApellido.Text,
                    Email = txtCorreo.Text,
                    IdRol = (cmbRol.SelectedItem as CatalogoItem)?.Id ?? 0
                };

                servicio.RegistrarUsuario(usuario, txtContrasena.Text, txtConfirmacion.Text);

                MessageBox.Show("Usuario registrado correctamente.");

                LimpiarFormulario();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar el usuario: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}