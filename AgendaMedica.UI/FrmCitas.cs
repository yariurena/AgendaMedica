using AgendaMedica.BL;
using AgendaMedica.Modelos;
using MedicoModelo = AgendaMedica.Modelos.Medico;
using PacienteModelo = AgendaMedica.Modelos.Paciente;

namespace AgendaMedica.UI
{
    public partial class FrmCitas : Form
    {
        private readonly ServicioCita servicioCita = new ServicioCita();
        private readonly ServicioMedico servicioMedico = new ServicioMedico();
        private readonly ServicioPaciente servicioPaciente = new ServicioPaciente();

        private Cita? citaSeleccionada = null;

        public FrmCitas()
        {
            InitializeComponent();

            Load += FrmCitas_Load;
            chkFiltroFecha.CheckedChanged += chkFiltroFecha_CheckedChanged;
            btnAgendar.Click += btnAgendar_Click;
            btnReprogramar.Click += btnReprogramar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            dgvCitas.CellClick += dgvCitas_CellClick;

            btnConfirmar.Click += (sender, e) => CambiarEstadoSeleccionada("Confirmada");
            btnAtendida.Click += (sender, e) => CambiarEstadoSeleccionada("Atendida");
            btnNoAsistio.Click += (sender, e) => CambiarEstadoSeleccionada("No asistió");
            btnCancelar.Click += (sender, e) => CambiarEstadoSeleccionada("Cancelada");
        }

        private void FrmCitas_Load(object? sender, EventArgs e)
        {
            try
            {
                CargarListas();
                LimpiarCamposCita();
                CargarCitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la gestión de citas: " + ex.Message);
            }
        }

        private void CargarListas()
        {
            List<MedicoModelo> medicos = servicioMedico.ObtenerMedicos();
            List<PacienteModelo> pacientes = servicioPaciente.ObtenerPacientes();
            List<CatalogoItem> tipos = servicioCita.ObtenerTipos();
            List<CatalogoItem> estados = servicioCita.ObtenerEstados();

            cmbMedico.DataSource = medicos;
            cmbPaciente.DataSource = pacientes;
            cmbTipo.DataSource = tipos;

            List<object> filtroMedicos = new List<object> { "(Todos)" };
            filtroMedicos.AddRange(medicos);
            cmbFiltroMedico.DataSource = filtroMedicos;

            List<object> filtroPacientes = new List<object> { "(Todos)" };
            filtroPacientes.AddRange(pacientes);
            cmbFiltroPaciente.DataSource = filtroPacientes;

            List<object> filtroEstados = new List<object> { "(Todos)" };
            filtroEstados.AddRange(estados);
            cmbFiltroEstado.DataSource = filtroEstados;

            cmbFiltroMedico.SelectedIndex = 0;
            cmbFiltroPaciente.SelectedIndex = 0;
            cmbFiltroEstado.SelectedIndex = 0;
        }

        private void LimpiarCamposCita()
        {
            cmbPaciente.SelectedIndex = -1;
            cmbMedico.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            cmbDuracion.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Today;
            dtpHora.Value = DateTime.Today.AddHours(8);
            txtMotivo.Clear();
        }

        private void CargarCitas()
        {
            try
            {
                int? idMedico = (cmbFiltroMedico.SelectedItem as MedicoModelo)?.IdMedico;
                int? idPaciente = (cmbFiltroPaciente.SelectedItem as PacienteModelo)?.IdPaciente;
                int? idEstado = (cmbFiltroEstado.SelectedItem as CatalogoItem)?.Id;
                DateTime? fecha = chkFiltroFecha.Checked ? dtpFiltroFecha.Value.Date : null;

                List<Cita> citas = servicioCita.BuscarCitas(idMedico, idPaciente, fecha, idEstado);

                dgvCitas.DataSource = null;
                dgvCitas.DataSource = citas;

                ConfigurarTabla();

                dgvCitas.ClearSelection();
                citaSeleccionada = null;
                ActualizarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las citas: " + ex.Message);
            }
        }

        private void ConfigurarTabla()
        {
            string[] ocultas = { "IdCita", "IdPaciente", "IdMedico", "IdEstado", "IdTipo" };

            foreach (string nombre in ocultas)
            {
                if (dgvCitas.Columns[nombre] != null)
                    dgvCitas.Columns[nombre].Visible = false;
            }

            Dictionary<string, string> encabezados = new Dictionary<string, string>
            {
                { "Fecha", "Fecha" },
                { "Hora", "Hora" },
                { "HoraFin", "Hora de fin" },
                { "DuracionMinutos", "Duración (min)" },
                { "NombrePaciente", "Paciente" },
                { "NombreMedico", "Médico" },
                { "Tipo", "Tipo" },
                { "Estado", "Estado" },
                { "Motivo", "Motivo" }
            };

            int posicion = 0;

            foreach (KeyValuePair<string, string> par in encabezados)
            {
                if (dgvCitas.Columns[par.Key] != null)
                {
                    dgvCitas.Columns[par.Key].HeaderText = par.Value;
                    dgvCitas.Columns[par.Key].DisplayIndex = posicion;
                    posicion++;
                }
            }

            if (dgvCitas.Columns["Fecha"] != null)
                dgvCitas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvCitas.Columns["Hora"] != null)
                dgvCitas.Columns["Hora"].DefaultCellStyle.Format = @"hh\:mm";

            if (dgvCitas.Columns["HoraFin"] != null)
                dgvCitas.Columns["HoraFin"].DefaultCellStyle.Format = @"hh\:mm";
        }

        private void dgvCitas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            citaSeleccionada = dgvCitas.Rows[e.RowIndex].DataBoundItem as Cita;
            ActualizarBotones();
        }

        private void ActualizarBotones()
        {
            if (citaSeleccionada == null)
            {
                btnReprogramar.Enabled = false;
                btnConfirmar.Enabled = false;
                btnAtendida.Enabled = false;
                btnNoAsistio.Enabled = false;
                btnCancelar.Enabled = false;
                return;
            }

            string[] permitidos = servicioCita.ObtenerEstadosPermitidos(citaSeleccionada.Estado);

            btnConfirmar.Enabled = permitidos.Contains("Confirmada");
            btnAtendida.Enabled = permitidos.Contains("Atendida");
            btnNoAsistio.Enabled = permitidos.Contains("No asistió");
            btnCancelar.Enabled = permitidos.Contains("Cancelada");
            btnReprogramar.Enabled = citaSeleccionada.Estado == "Programada" || citaSeleccionada.Estado == "Confirmada";
        }

        private TimeSpan ObtenerHoraElegida()
        {
            return new TimeSpan(dtpHora.Value.Hour, dtpHora.Value.Minute, 0);
        }

        private int ObtenerDuracionElegida()
        {
            return int.TryParse(cmbDuracion.SelectedItem?.ToString(), out int duracion) ? duracion : 0;
        }

        private void btnAgendar_Click(object? sender, EventArgs e)
        {
            try
            {
                Cita cita = new Cita
                {
                    IdPaciente = (cmbPaciente.SelectedItem as PacienteModelo)?.IdPaciente ?? 0,
                    IdMedico = (cmbMedico.SelectedItem as MedicoModelo)?.IdMedico ?? 0,
                    IdTipo = (cmbTipo.SelectedItem as CatalogoItem)?.Id ?? 0,
                    Fecha = dtpFecha.Value.Date,
                    Hora = ObtenerHoraElegida(),
                    DuracionMinutos = ObtenerDuracionElegida(),
                    Motivo = txtMotivo.Text
                };

                servicioCita.RegistrarCita(cita);
                MessageBox.Show("Cita agendada correctamente.");

                LimpiarCamposCita();
                CargarCitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agendar la cita: " + ex.Message);
            }
        }

        private void btnReprogramar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (citaSeleccionada == null)
                {
                    MessageBox.Show("Primero debe seleccionar una cita de la tabla.");
                    return;
                }

                DateTime nuevaFecha = dtpFecha.Value.Date;
                TimeSpan nuevaHora = ObtenerHoraElegida();

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea reprogramar la cita para el " + nuevaFecha.ToString("dd/MM/yyyy") +
                    " a las " + nuevaHora.ToString(@"hh\:mm") + "?\n\nLa cita actual quedará en estado 'Reprogramada'.",
                    "Confirmar reprogramación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                servicioCita.ReprogramarCita(citaSeleccionada.IdCita, nuevaFecha, nuevaHora, ObtenerDuracionElegida());
                MessageBox.Show("Cita reprogramada correctamente.");

                LimpiarCamposCita();
                CargarCitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo reprogramar la cita: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarCamposCita();
        }

        private void CambiarEstadoSeleccionada(string nuevoEstado)
        {
            try
            {
                if (citaSeleccionada == null)
                {
                    MessageBox.Show("Primero debe seleccionar una cita de la tabla.");
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea cambiar el estado de la cita a '" + nuevoEstado + "'?",
                    "Confirmar cambio de estado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                servicioCita.CambiarEstado(citaSeleccionada.IdCita, nuevoEstado);
                MessageBox.Show("El estado de la cita ahora es '" + nuevoEstado + "'.");

                CargarCitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cambiar el estado: " + ex.Message);
            }
        }

        private void chkFiltroFecha_CheckedChanged(object? sender, EventArgs e)
        {
            dtpFiltroFecha.Enabled = chkFiltroFecha.Checked;
        }

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            CargarCitas();
        }

        private void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            cmbFiltroMedico.SelectedIndex = 0;
            cmbFiltroPaciente.SelectedIndex = 0;
            cmbFiltroEstado.SelectedIndex = 0;
            chkFiltroFecha.Checked = false;
            dtpFiltroFecha.Value = DateTime.Today;

            CargarCitas();
        }
    }
}