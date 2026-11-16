using AgendaMedica.BL;
using AgendaMedica.Modelos;
using MedicoModelo = AgendaMedica.Modelos.Medico;
using PacienteModelo = AgendaMedica.Modelos.Paciente;

namespace AgendaMedica.UI
{
    public partial class FrmHistorial : Form
    {
        private readonly ServicioHistorial servicioHistorial = new ServicioHistorial();
        private readonly ServicioPaciente servicioPaciente = new ServicioPaciente();
        private readonly ServicioMedico servicioMedico = new ServicioMedico();

        public FrmHistorial()
        {
            InitializeComponent();
        }

        private void FrmHistorial_Load(object? sender, EventArgs e)
        {
            try
            {
                cmbPaciente.DataSource = servicioPaciente.ObtenerPacientes();
                cmbMedico.DataSource = servicioMedico.ObtenerMedicos();

                cmbPaciente.SelectedIndex = -1;
                cmbMedico.SelectedIndex = -1;

                dtpFecha.Value = DateTime.Today;
                dgvHistorial.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el historial médico: " + ex.Message);
            }
        }

        private void cmbPaciente_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            PacienteModelo? paciente = cmbPaciente.SelectedItem as PacienteModelo;

            if (paciente == null)
            {
                dgvHistorial.DataSource = null;
                return;
            }

            try
            {
                List<HistorialMedico> entradas = servicioHistorial.ObtenerPorPaciente(paciente.IdPaciente);

                dgvHistorial.DataSource = null;
                dgvHistorial.DataSource = entradas;

                string[] ocultas = { "IdHistorial", "IdPaciente", "IdMedico", "IdUsuario", "NombrePaciente" };

                foreach (string nombre in ocultas)
                {
                    if (dgvHistorial.Columns[nombre] != null)
                        dgvHistorial.Columns[nombre].Visible = false;
                }

                Dictionary<string, string> encabezados = new Dictionary<string, string>
                {
                    { "Fecha", "Fecha" },
                    { "NombreMedico", "Médico" },
                    { "Descripcion", "Descripción" },
                    { "Diagnostico", "Diagnóstico" },
                    { "Tratamiento", "Tratamiento" },
                    { "Observaciones", "Observaciones" },
                    { "RegistradoPor", "Registrado por" }
                };

                int posicion = 0;

                foreach (KeyValuePair<string, string> par in encabezados)
                {
                    if (dgvHistorial.Columns[par.Key] != null)
                    {
                        dgvHistorial.Columns[par.Key].HeaderText = par.Value;
                        dgvHistorial.Columns[par.Key].DisplayIndex = posicion;
                        posicion++;
                    }
                }

                if (dgvHistorial.Columns["Fecha"] != null)
                    dgvHistorial.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvHistorial.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el historial: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            cmbMedico.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Today;
            txtDescripcion.Clear();
            txtDiagnostico.Clear();
            txtTratamiento.Clear();
            txtObservaciones.Clear();
        }

        private void btnRegistrar_Click(object? sender, EventArgs e)
        {
            try
            {
                HistorialMedico entrada = new HistorialMedico
                {
                    IdPaciente = (cmbPaciente.SelectedItem as PacienteModelo)?.IdPaciente ?? 0,
                    IdMedico = (cmbMedico.SelectedItem as MedicoModelo)?.IdMedico ?? 0,
                    Fecha = dtpFecha.Value.Date,
                    Descripcion = txtDescripcion.Text,
                    Diagnostico = txtDiagnostico.Text,
                    Tratamiento = txtTratamiento.Text,
                    Observaciones = txtObservaciones.Text
                };

                servicioHistorial.RegistrarEntrada(entrada);
                MessageBox.Show("Entrada registrada correctamente en el historial.");

                LimpiarCampos();
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar la entrada: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}