using AgendaMedica.BL;

namespace AgendaMedica.UI
{
    public partial class FrmLogin : Form
    {
        private readonly ServicioUsuario servicio = new ServicioUsuario();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object? sender, EventArgs e)
        {
            try
            {
                servicio.IniciarSesion(txtCorreo.Text, txtContrasena.Text);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtContrasena.Clear();
                txtContrasena.Focus();
            }
        }
    }
}