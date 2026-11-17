using AgendaMedica.BL;
using AgendaMedica.Modelos;
using MedicoModelo = AgendaMedica.Modelos.Medico;

namespace AgendaMedica.UI
{
    public partial class FrmReportes : Form
    {
        private readonly ServicioReporte servicioReporte = new ServicioReporte();
        private readonly ServicioMedico servicioMedico = new ServicioMedico();

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object? sender, EventArgs e)
        {
            try
            {
                List<object> medicos = new List<object> { "(Todos)" };
                medicos.AddRange(servicioMedico.ObtenerMedicos());

                cmbMedico.DataSource = medicos;
                cmbMedico.SelectedIndex = 0;

                cmbReporte.SelectedIndex = 0;

                dtpDesde.Value = DateTime.Today;
                dtpHasta.Value = DateTime.Today;

                lblResumen.Text = "Elija el reporte y los filtros, y presione Generar.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la ventana de reportes: " + ex.Message);
            }
        }

        private void btnGenerar_Click(object? sender, EventArgs e)
        {
            try
            {
                int? idMedico = (cmbMedico.SelectedItem as MedicoModelo)?.IdMedico;
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date;

                List<Cita> resultado;
                string resumen;

                switch (cmbReporte.SelectedIndex)
                {
                    case 0:
                        resultado = servicioReporte.CitasPorDiaYMedico(desde, hasta, idMedico);
                        resumen = "Total de citas: " + resultado.Count;
                        break;
                    case 1:
                        resultado = servicioReporte.CitasCanceladas(desde, hasta, idMedico);
                        resumen = "Total de citas canceladas: " + resultado.Count;
                        break;
                    case 2:
                        resultado = servicioReporte.PacientesAtendidos(desde, hasta, idMedico);
                        resumen = "Citas atendidas: " + resultado.Count + "   |   Pacientes distintos atendidos: " + servicioReporte.ContarPacientesDistintos(resultado);
                        break;
                    default:
                        MessageBox.Show("Debe seleccionar un tipo de reporte.");
                        return;
                }

                MostrarResultado(resultado);

                lblResumen.Text = resultado.Count == 0? "No hay resultados para los filtros elegidos.": resumen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el reporte: " + ex.Message);
            }
        }

        private void MostrarResultado(List<Cita> citas)
        {
            dgvReporte.DataSource = null;
            dgvReporte.DataSource = citas;

            string[] ocultas = { "IdCita", "IdPaciente", "IdMedico", "IdEstado", "IdTipo", "HoraFin" };

            foreach (string nombre in ocultas)
            {
                if (dgvReporte.Columns[nombre] != null)
                    dgvReporte.Columns[nombre].Visible = false;
            }

            Dictionary<string, string> encabezados = new Dictionary<string, string>
            {
                { "Fecha", "Fecha" },
                { "Hora", "Hora" },
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
                if (dgvReporte.Columns[par.Key] != null)
                {
                    dgvReporte.Columns[par.Key].HeaderText = par.Value;
                    dgvReporte.Columns[par.Key].DisplayIndex = posicion;
                    posicion++;
                }
            }

            if (dgvReporte.Columns["Fecha"] != null)
                dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvReporte.Columns["Hora"] != null)
                dgvReporte.Columns["Hora"].DefaultCellStyle.Format = @"hh\:mm";

            dgvReporte.ClearSelection();
        }
    }
}