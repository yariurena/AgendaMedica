using AgendaMedica.BL;
using EspecialidadModelo = AgendaMedica.Modelos.Especialidad;
using MedicoModelo = AgendaMedica.Modelos.Medico;

namespace AgendaMedica.UI
{
    public partial class FrmMedicos : Form
    {
        private readonly ServicioMedico servicioMedico = new ServicioMedico();
        private readonly ServicioEspecialidad servicioEspecialidad = new ServicioEspecialidad();
        private int idMedicoSeleccionado = 0;

        public FrmMedicos()
        {
            InitializeComponent();
        }

        private void FrmMedicos_Load(object? sender, EventArgs e)
        {
            try
            {
                CargarEspecialidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las especialidades: " + ex.Message);
            }
        }

        private void CargarEspecialidades()
        {
            List<EspecialidadModelo> especialidades = servicioEspecialidad.ObtenerEspecialidades();

            cmbEspecialidad.DataSource = null;
            cmbEspecialidad.DataSource = especialidades;
            cmbEspecialidad.DisplayMember = "Nombre";
            cmbEspecialidad.ValueMember = "IdEspecialidad";
            cmbEspecialidad.SelectedIndex = -1;
        }

        private void CargarMedicos()
        {
            List<MedicoModelo> medicos = servicioMedico.ObtenerMedicos();

            dgvMedicos.DataSource = null;
            dgvMedicos.DataSource = medicos;

            string[] ocultas = { "IdMedico", "IdEspecialidad", "Activo" };

            foreach (string nombre in ocultas)
            {
                if (dgvMedicos.Columns[nombre] != null)
                    dgvMedicos.Columns[nombre].Visible = false;
            }

            Dictionary<string, string> encabezados = new Dictionary<string, string>
            {
                { "Nombre", "Nombre" },
                { "PrimerApellido", "Primer apellido" },
                { "SegundoApellido", "Segundo apellido" },
                { "NombreEspecialidad", "Especialidad" },
                { "Telefono", "Teléfono" },
                { "Email", "Correo" }
            };

            int posicion = 0;

            foreach (KeyValuePair<string, string> par in encabezados)
            {
                if (dgvMedicos.Columns[par.Key] != null)
                {
                    dgvMedicos.Columns[par.Key].HeaderText = par.Value;
                    dgvMedicos.Columns[par.Key].DisplayIndex = posicion;
                    posicion++;
                }
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();

            cmbEspecialidad.SelectedIndex = -1;

            idMedicoSeleccionado = 0;
            btnActualizar.Enabled = false;
            btnDesactivar.Enabled = false;

            dgvMedicos.ClearSelection();
        }

        private MedicoModelo ArmarMedico()
        {
            return new MedicoModelo
            {
                IdMedico = idMedicoSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                PrimerApellido = txtPrimerApellido.Text.Trim(),
                SegundoApellido = txtSegundoApellido.Text.Trim(),
                IdEspecialidad = Convert.ToInt32(cmbEspecialidad.SelectedValue),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };
        }

        private void btnConsultar_Click(object? sender, EventArgs e)
        {
            try
            {
                CargarMedicos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los médicos: " + ex.Message);
            }
        }

        private void dgvMedicos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            MedicoModelo? medico = dgvMedicos.Rows[e.RowIndex].DataBoundItem as MedicoModelo;

            if (medico == null)
                return;

            idMedicoSeleccionado = medico.IdMedico;

            txtNombre.Text = medico.Nombre;
            txtPrimerApellido.Text = medico.PrimerApellido;
            txtSegundoApellido.Text = medico.SegundoApellido;
            txtTelefono.Text = medico.Telefono;
            txtEmail.Text = medico.Email;

            cmbEspecialidad.SelectedValue = medico.IdEspecialidad;

            btnActualizar.Enabled = true;
            btnDesactivar.Enabled = true;
        }

        private void btnRegistrar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (cmbEspecialidad.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una especialidad.");
                    return;
                }

                MedicoModelo medico = ArmarMedico();
                medico.IdMedico = 0;

                servicioMedico.RegistrarMedico(medico);
                MessageBox.Show("Médico registrado correctamente.");

                CargarMedicos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar el médico: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idMedicoSeleccionado <= 0)
                {
                    MessageBox.Show("Primero debe seleccionar un médico.");
                    return;
                }

                if (cmbEspecialidad.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una especialidad.");
                    return;
                }

                servicioMedico.ActualizarMedico(ArmarMedico());
                MessageBox.Show("Médico actualizado correctamente.");

                CargarMedicos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el médico: " + ex.Message);
            }
        }

        private void btnDesactivar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idMedicoSeleccionado <= 0)
                {
                    MessageBox.Show("Primero debe seleccionar un médico de la tabla.");
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea desactivar a este médico? Dejará de aparecer en la lista, pero su información se conserva.",
                    "Confirmar desactivación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                servicioMedico.DesactivarMedico(idMedicoSeleccionado);
                MessageBox.Show("Médico desactivado correctamente.");

                CargarMedicos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo desactivar el médico: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}