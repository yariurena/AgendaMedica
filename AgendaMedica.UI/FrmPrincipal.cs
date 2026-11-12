
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AgendaMedica.BL;
using EspecialidadModelo = AgendaMedica.Modelos.Especialidad;

namespace AgendaMedica.UI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();

            this.Text = "Agenda Médica - Sistema de gestión";
            this.Width = 1100;
            this.Height = 650;
            this.StartPosition = FormStartPosition.CenterScreen;

            Button btnAbrirPacientes = new Button();
            btnAbrirPacientes.Text = "Gestión de pacientes";
            btnAbrirPacientes.Width = 180;
            btnAbrirPacientes.Height = 35;
            btnAbrirPacientes.Left = 220;
            btnAbrirPacientes.Top = 20;

            this.Controls.Add(btnAbrirPacientes);

            btnAbrirPacientes.Click += (sender, e) =>
            {
                FrmPacientes ventanaPacientes = new FrmPacientes();
                ventanaPacientes.ShowDialog();
            };

            Button btnAbrirMedicos = new Button();
            btnAbrirMedicos.Text = "Gestión de médicos";
            btnAbrirMedicos.Width = 180;
            btnAbrirMedicos.Height = 35;
            btnAbrirMedicos.Left = 420;
            btnAbrirMedicos.Top = 20;

            this.Controls.Add(btnAbrirMedicos);

            btnAbrirMedicos.Click += (sender, e) =>
            {
                FrmMedicos ventanaMedicos = new FrmMedicos();
                ventanaMedicos.ShowDialog();
            };

            Button btnEspecialidades = new Button();
            btnEspecialidades.Text = "Ver especialidades";
            btnEspecialidades.Width = 180;
            btnEspecialidades.Height = 35;
            btnEspecialidades.Left = 20;
            btnEspecialidades.Top = 20;

            DataGridView tablaEspecialidades = new DataGridView();

            tablaEspecialidades.Left = 20;
            tablaEspecialidades.Top = 70;
            tablaEspecialidades.Width = 400;
            tablaEspecialidades.Height = 220;
            tablaEspecialidades.ReadOnly = true;
            tablaEspecialidades.AllowUserToAddRows = false;
            tablaEspecialidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tablaEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablaEspecialidades.MultiSelect = false;

            this.Controls.Add(btnEspecialidades);
            this.Controls.Add(tablaEspecialidades);

            Label lblNombreEspecialidad = new Label();
            lblNombreEspecialidad.Text ="Nombre de la especialidad:";

            lblNombreEspecialidad.Left = 440;
            lblNombreEspecialidad.Top = 70;
            lblNombreEspecialidad.Width = 200;

            TextBox txtNombreEspecialidad = new TextBox();
            txtNombreEspecialidad.Left = 440;
            txtNombreEspecialidad.Top = 95;
            txtNombreEspecialidad.Width = 170;

            this.Controls.Add(lblNombreEspecialidad);
            this.Controls.Add(txtNombreEspecialidad);

            Button btnRegistrarEspecialidad = new Button();
            btnRegistrarEspecialidad.Text = "Registrar especialidad";

            btnRegistrarEspecialidad.Width = 180;
            btnRegistrarEspecialidad.Height = 35;
            btnRegistrarEspecialidad.Left = 440;
            btnRegistrarEspecialidad.Top = 135;

            this.Controls.Add(btnRegistrarEspecialidad);

            Button btnActualizarEspecialidad = new Button();
            btnActualizarEspecialidad.Text = "Actualizar especialidad";

            btnActualizarEspecialidad.Width = 180;
            btnActualizarEspecialidad.Height = 35;
            btnActualizarEspecialidad.Left = 440;
            btnActualizarEspecialidad.Top = 180;
            btnActualizarEspecialidad.Enabled = false;

            this.Controls.Add(btnActualizarEspecialidad);

            int idEspecialidadSeleccionada = 0;

            ServicioEspecialidad servicio = new ServicioEspecialidad();

            void LimpiarEspecialidad()
            {
                txtNombreEspecialidad.Clear();
                idEspecialidadSeleccionada = 0;
                btnActualizarEspecialidad.Enabled = false;
                tablaEspecialidades.ClearSelection();
            }

            btnEspecialidades.Click += (sender, e) =>
            {
                try
                {
                    List<EspecialidadModelo> especialidades = servicio.ObtenerEspecialidades();

                    tablaEspecialidades.DataSource = null;
                    tablaEspecialidades.DataSource = especialidades;

                    if (tablaEspecialidades.Columns["IdEspecialidad"] != null)
                    {
                        tablaEspecialidades.Columns["IdEspecialidad"].Visible = false;
                    }

                    if (tablaEspecialidades.Columns["Nombre"] != null)
                    {
                        tablaEspecialidades.Columns["Nombre"].HeaderText = "Especialidad";
                    }
                    LimpiarEspecialidad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudieron cargar las especialidades: " + ex.Message);
                }
            };

            tablaEspecialidades.CellClick += (sender, e) =>
            {
                if (e.RowIndex < 0)
                    return;

                EspecialidadModelo especialidad = tablaEspecialidades.Rows[e.RowIndex].DataBoundItem as EspecialidadModelo;

                if (especialidad == null)
                    return;

                idEspecialidadSeleccionada = especialidad.IdEspecialidad;
                txtNombreEspecialidad.Text = especialidad.Nombre;
                btnActualizarEspecialidad.Enabled = true;
            };

            btnRegistrarEspecialidad.Click += (sender, e) =>
            {
                try
                {
                    EspecialidadModelo especialidad = new EspecialidadModelo
                        {
                            Nombre = txtNombreEspecialidad.Text.Trim()
                        };

                    servicio.RegistrarEspecialidad(especialidad);
                    MessageBox.Show("Especialidad registrada correctamente.");

                    tablaEspecialidades.DataSource = null;
                    tablaEspecialidades.DataSource = servicio.ObtenerEspecialidades();

                    LimpiarEspecialidad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo registrar la especialidad: " + ex.Message);
                }
            };

            btnActualizarEspecialidad.Click += (sender, e) =>
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
                            Nombre = txtNombreEspecialidad.Text.Trim()
                        };
                    
                    servicio.ActualizarEspecialidad(especialidad);
                    MessageBox.Show("Especialidad actualizada correctamente.");

                    tablaEspecialidades.DataSource = null;
                    tablaEspecialidades.DataSource = servicio.ObtenerEspecialidades();

                    LimpiarEspecialidad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo actualizar la especialidad: " + ex.Message);
                }
            };
        }
    }
}
