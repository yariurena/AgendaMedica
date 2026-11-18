using AgendaMedica.BL;
using EspecialidadModelo = AgendaMedica.Modelos.Especialidad;

namespace AgendaMedica.UI
{
    public partial class FrmEspecialidades : Form
    {
        private readonly ServicioEspecialidad servicio = new ServicioEspecialidad();
        private int idEspecialidadSeleccionada = 0;

        public FrmEspecialidades()
        {
            InitializeComponent();
        }

        private void CargarEspecialidades()
        {
            List<EspecialidadModelo> especialidades = servicio.ObtenerEspecialidades();

            dgvEspecialidades.DataSource = null;
            dgvEspecialidades.DataSource = especialidades;

            string[] ocultas = { "IdEspecialidad", "Activo" };

            foreach (string nombre in ocultas)
            {
                if (dgvEspecialidades.Columns[nombre] != null)
                    dgvEspecialidades.Columns[nombre].Visible = false;
            }

            if (dgvEspecialidades.Columns["Nombre"] != null)
                dgvEspecialidades.Columns["Nombre"].HeaderText = "Especialidad";
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();

            idEspecialidadSeleccionada = 0;
            btnActualizar.Enabled = false;
            btnDesactivar.Enabled = false;

            dgvEspecialidades.ClearSelection();
        }

        private void btnConsultar_Click(object? sender, EventArgs e)
        {
            try
            {
                CargarEspecialidades();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las especialidades: " + ex.Message);
            }
        }

        private void dgvEspecialidades_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            EspecialidadModelo? especialidad = dgvEspecialidades.Rows[e.RowIndex].DataBoundItem as EspecialidadModelo;

            if (especialidad == null)
                return;

            idEspecialidadSeleccionada = especialidad.IdEspecialidad;
            txtNombre.Text = especialidad.Nombre;

            btnActualizar.Enabled = true;
            btnDesactivar.Enabled = true;
        }

        private void btnRegistrar_Click(object? sender, EventArgs e)
        {
            try
            {
                EspecialidadModelo especialidad = new EspecialidadModelo
                {
                    Nombre = txtNombre.Text.Trim()
                };

                servicio.RegistrarEspecialidad(especialidad);
                MessageBox.Show("Especialidad registrada correctamente.");

                CargarEspecialidades();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar la especialidad: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idEspecialidadSeleccionada <= 0)
                {
                    MessageBox.Show("Primero debe seleccionar una especialidad.");
                    return;
                }

                EspecialidadModelo especialidad = new EspecialidadModelo
                {
                    IdEspecialidad = idEspecialidadSeleccionada,
                    Nombre = txtNombre.Text.Trim()
                };

                servicio.ActualizarEspecialidad(especialidad);
                MessageBox.Show("Especialidad actualizada correctamente.");

                CargarEspecialidades();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar la especialidad: " + ex.Message);
            }
        }

        private void btnDesactivar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idEspecialidadSeleccionada <= 0)
                {
                    MessageBox.Show("Primero debe seleccionar una especialidad.");
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea desactivar esta especialidad? Dejará de aparecer en la lista, pero su información se conserva.",
                    "Confirmar desactivación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                servicio.DesactivarEspecialidad(idEspecialidadSeleccionada);
                MessageBox.Show("Especialidad desactivada correctamente.");

                CargarEspecialidades();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo desactivar la especialidad: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}