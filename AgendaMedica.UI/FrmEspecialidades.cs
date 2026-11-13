
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AgendaMedica.BL;
using EspecialidadModelo = AgendaMedica.Modelos.Especialidad;

namespace AgendaMedica.UI
{
    public partial class FrmEspecialidades : Form
    {
        public FrmEspecialidades()
        {
            InitializeComponent();

            this.Text = "Agenda Médica - Gestión de especialidades";
            this.Width = 850;
            this.Height = 550;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitulo = new Label();
            lblTitulo.Text = "GESTIÓN DE ESPECIALIDADES";
            lblTitulo.Left = 20;
            lblTitulo.Top = 15;
            lblTitulo.Width = 400;
            lblTitulo.Height = 30;
            lblTitulo.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);

            Button btnConsultar = new Button();
            btnConsultar.Text = "Consultar especialidades";
            btnConsultar.Left = 20;
            btnConsultar.Top = 60;
            btnConsultar.Width = 190;
            btnConsultar.Height = 35;

            DataGridView tablaEspecialidades = new DataGridView();
            tablaEspecialidades.Left = 20;
            tablaEspecialidades.Top = 115;
            tablaEspecialidades.Width = 400;
            tablaEspecialidades.Height = 330;
            tablaEspecialidades.ReadOnly = true;
            tablaEspecialidades.AllowUserToAddRows = false;
            tablaEspecialidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tablaEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablaEspecialidades.MultiSelect = false;

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre de la especialidad:";
            lblNombre.Left = 470;
            lblNombre.Top = 115;
            lblNombre.Width = 280;

            TextBox txtNombre = new TextBox();
            txtNombre.Left = 470;
            txtNombre.Top = 145;
            txtNombre.Width = 300;

            Button btnRegistrar = new Button();
            btnRegistrar.Text = "Registrar especialidad";
            btnRegistrar.Left = 470;
            btnRegistrar.Top = 205;
            btnRegistrar.Width = 145;
            btnRegistrar.Height = 40;

            Button btnActualizar = new Button();
            btnActualizar.Text = "Actualizar especialidad";
            btnActualizar.Left = 625;
            btnActualizar.Top = 205;
            btnActualizar.Width = 145;
            btnActualizar.Height = 40;
            btnActualizar.Enabled = false;

            Button btnLimpiar = new Button();
            btnLimpiar.Text = "Limpiar campos";
            btnLimpiar.Left = 470;
            btnLimpiar.Top = 260;
            btnLimpiar.Width = 145;
            btnLimpiar.Height = 35;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(btnConsultar);
            this.Controls.Add(tablaEspecialidades);
            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(btnRegistrar);
            this.Controls.Add(btnActualizar);
            this.Controls.Add(btnLimpiar);

            int idEspecialidadSeleccionada = 0;

            ServicioEspecialidad servicio = new ServicioEspecialidad();

            void CargarEspecialidades()
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
            }

            void LimpiarFormulario()
            {
                txtNombre.Clear();
                idEspecialidadSeleccionada = 0;
                btnActualizar.Enabled = false;
                tablaEspecialidades.ClearSelection();
            }

            btnConsultar.Click += (sender, e) =>
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
            };

            tablaEspecialidades.CellClick += (sender, e) =>
            {
                if (e.RowIndex < 0)
                    return;

                EspecialidadModelo especialidad = tablaEspecialidades.Rows[e.RowIndex].DataBoundItem as EspecialidadModelo;

                if (especialidad == null)
                    return;

                idEspecialidadSeleccionada = especialidad.IdEspecialidad;
                txtNombre.Text = especialidad.Nombre;
                btnActualizar.Enabled = true;
            };

            btnRegistrar.Click += (sender, e) =>
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
            };

            btnActualizar.Click += (sender, e) =>
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
                            IdEspecialidad =
                            idEspecialidadSeleccionada,
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
            };

            btnLimpiar.Click += (sender, e) =>
            {
                LimpiarFormulario();
            };
        }
    }
}
