using AgendaMedica.BL;
using PacienteModelo = AgendaMedica.Modelos.Paciente;

namespace AgendaMedica.UI
{
    public partial class FrmPacientes : Form
    {
        private readonly ServicioPaciente servicio = new ServicioPaciente();
        private int idPacienteSeleccionado = 0;

        public FrmPacientes()
        {
            InitializeComponent();
        }

        private void CargarPacientes()
        {
            List<PacienteModelo> pacientes = servicio.ObtenerPacientes();

            dgvPacientes.DataSource = null;
            dgvPacientes.DataSource = pacientes;

            string[] ocultas = { "IdPaciente", "Activo" };

            foreach (string nombre in ocultas)
            {
                if (dgvPacientes.Columns[nombre] != null)
                    dgvPacientes.Columns[nombre].Visible = false;
            }

            Dictionary<string, string> encabezados = new Dictionary<string, string>
            {
                { "Nombre", "Nombre" },
                { "PrimerApellido", "Primer apellido" },
                { "SegundoApellido", "Segundo apellido" },
                { "Cedula", "Cédula" },
                { "Direccion", "Dirección" },
                { "Email", "Correo" },
                { "FechaNacimiento", "Fecha de nacimiento" },
                { "Telefono", "Teléfono" }
            };

            int posicion = 0;

            foreach (KeyValuePair<string, string> par in encabezados)
            {
                if (dgvPacientes.Columns[par.Key] != null)
                {
                    dgvPacientes.Columns[par.Key].HeaderText = par.Value;
                    dgvPacientes.Columns[par.Key].DisplayIndex = posicion;
                    posicion++;
                }
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtCedula.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();

            dtpFechaNacimiento.Checked = false;

            idPacienteSeleccionado = 0;
            btnActualizar.Enabled = false;
            btnDesactivar.Enabled = false;

            dgvPacientes.ClearSelection();
        }

        private PacienteModelo ArmarPaciente()
        {
            return new PacienteModelo
            {
                IdPaciente = idPacienteSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                PrimerApellido = txtPrimerApellido.Text.Trim(),
                SegundoApellido = txtSegundoApellido.Text.Trim(),
                Cedula = txtCedula.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Checked ? dtpFechaNacimiento.Value.Date : null
            };
        }

        private void btnConsultar_Click(object? sender, EventArgs e)
        {
            try
            {
                CargarPacientes();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los pacientes: " + ex.Message);
            }
        }

        private void dgvPacientes_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            PacienteModelo? paciente = dgvPacientes.Rows[e.RowIndex].DataBoundItem as PacienteModelo;
            if (paciente == null)
                return;

            idPacienteSeleccionado = paciente.IdPaciente;

            txtNombre.Text = paciente.Nombre;
            txtPrimerApellido.Text = paciente.PrimerApellido;
            txtSegundoApellido.Text = paciente.SegundoApellido;
            txtCedula.Text = paciente.Cedula;
            txtDireccion.Text = paciente.Direccion;
            txtEmail.Text = paciente.Email;
            txtTelefono.Text = paciente.Telefono;

            if (paciente.FechaNacimiento.HasValue)
            {
                dtpFechaNacimiento.Value = paciente.FechaNacimiento.Value;
                dtpFechaNacimiento.Checked = true;
            }
            else
            {
                dtpFechaNacimiento.Checked = false;
            }
            btnActualizar.Enabled = true;
            btnDesactivar.Enabled = true;
        }

        private void btnRegistrar_Click(object? sender, EventArgs e)
        {
            try
            {
                PacienteModelo paciente = ArmarPaciente();
                paciente.IdPaciente = 0;

                servicio.RegistrarPaciente(paciente);
                MessageBox.Show("Paciente registrado correctamente.");

                CargarPacientes();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar el paciente: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idPacienteSeleccionado <= 0)
                {
                    MessageBox.Show("Primero debe seleccionar un paciente de la tabla.");
                    return;
                }

                servicio.ActualizarPaciente(ArmarPaciente());
                MessageBox.Show("Paciente actualizado correctamente.");

                CargarPacientes();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el paciente: " + ex.Message);
            }
        }

        private void btnDesactivar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idPacienteSeleccionado <= 0)
                {
                    MessageBox.Show("Primero debe seleccionar un paciente de la tabla.");
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea desactivar a este paciente? Dejará de aparecer en la lista, pero su información se conserva.",
                    "Confirmar desactivación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                servicio.DesactivarPaciente(idPacienteSeleccionado);
                MessageBox.Show("Paciente desactivado correctamente.");

                CargarPacientes();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo desactivar el paciente: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}