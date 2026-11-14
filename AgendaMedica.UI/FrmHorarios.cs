using AgendaMedica.BL;
using HorarioModelo = AgendaMedica.Modelos.HorarioMedico;
using MedicoModelo = AgendaMedica.Modelos.Medico;

namespace AgendaMedica.UI
{
    public partial class FrmHorarios : Form
    {
        private readonly ServicioMedico servicioMedico = new ServicioMedico();
        private readonly ServicioHorarioMedico servicioHorario = new ServicioHorarioMedico();
        private int idHorarioSeleccionado = 0;

        public FrmHorarios()
        {
            InitializeComponent();
        }

        private void FrmHorarios_Load(object? sender, EventArgs e)
        {
            dtpHoraInicio.Value = DateTime.Today.AddHours(8);
            dtpHoraFin.Value = DateTime.Today.AddHours(12);
            cmbDia.SelectedIndex = 0;

            CargarMedicos();
        }

        private void CargarMedicos()
        {
            try
            {
                List<MedicoModelo> medicos = servicioMedico.ObtenerMedicos();

                cmbMedico.DataSource = null;
                cmbMedico.DataSource = medicos;
                cmbMedico.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los médicos: " + ex.Message);
            }
        }

        private void CargarHorarios()
        {
            idHorarioSeleccionado = 0;
            btnEliminar.Enabled = false;

            MedicoModelo? medico = cmbMedico.SelectedItem as MedicoModelo;

            if (medico == null)
            {
                dgvHorarios.DataSource = null;
                return;
            }

            try
            {
                List<HorarioModelo> horarios = servicioHorario.ObtenerHorariosPorMedico(medico.IdMedico);

                dgvHorarios.DataSource = null;
                dgvHorarios.DataSource = horarios;

                if (dgvHorarios.Columns["IdHorario"] != null)
                    dgvHorarios.Columns["IdHorario"].Visible = false;

                if (dgvHorarios.Columns["IdMedico"] != null)
                    dgvHorarios.Columns["IdMedico"].Visible = false;

                if (dgvHorarios.Columns["NombreMedico"] != null)
                    dgvHorarios.Columns["NombreMedico"].Visible = false;

                if (dgvHorarios.Columns["Dia"] != null)
                    dgvHorarios.Columns["Dia"].HeaderText = "Día";

                if (dgvHorarios.Columns["HoraInicio"] != null)
                {
                    dgvHorarios.Columns["HoraInicio"].HeaderText = "Hora de inicio";
                    dgvHorarios.Columns["HoraInicio"].DefaultCellStyle.Format = @"hh\:mm";
                }

                if (dgvHorarios.Columns["HoraFin"] != null)
                {
                    dgvHorarios.Columns["HoraFin"].HeaderText = "Hora de fin";
                    dgvHorarios.Columns["HoraFin"].DefaultCellStyle.Format = @"hh\:mm";
                }

                dgvHorarios.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los horarios: " + ex.Message);
            }
        }

        private void cmbMedico_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CargarHorarios();
        }

        private void dgvHorarios_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            HorarioModelo? horario = dgvHorarios.Rows[e.RowIndex].DataBoundItem as HorarioModelo;

            if (horario == null)
                return;

            idHorarioSeleccionado = horario.IdHorario;
            btnEliminar.Enabled = true;
        }

        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            try
            {
                MedicoModelo? medico = cmbMedico.SelectedItem as MedicoModelo;

                if (medico == null)
                {
                    MessageBox.Show("Primero debe seleccionar un médico.");
                    return;
                }

                HorarioModelo horario = new HorarioModelo
                {
                    IdMedico = medico.IdMedico,
                    Dia = cmbDia.SelectedItem?.ToString() ?? "",
                    HoraInicio = new TimeSpan(dtpHoraInicio.Value.Hour, dtpHoraInicio.Value.Minute, 0),
                    HoraFin = new TimeSpan(dtpHoraFin.Value.Hour, dtpHoraFin.Value.Minute, 0)
                };

                servicioHorario.RegistrarHorario(horario);
                MessageBox.Show("Horario registrado correctamente.");

                CargarHorarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar el horario: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idHorarioSeleccionado <= 0)
                {
                    MessageBox.Show("Primero debe seleccionar un horario de la tabla.");
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea eliminar este horario?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                servicioHorario.EliminarHorario(idHorarioSeleccionado);
                MessageBox.Show("Horario eliminado correctamente.");

                CargarHorarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el horario: " + ex.Message);
            }
        }
    }
}