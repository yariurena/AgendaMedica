using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AgendaMedica.BL;
using MedicoModelo = AgendaMedica.Modelos.Medico;
using EspecialidadModelo = AgendaMedica.Modelos.Especialidad;

namespace AgendaMedica.UI
{
    public partial class FrmMedicos : Form
    {
        public FrmMedicos()
        {
            InitializeComponent();

            this.Text = "Agenda Médica - Gestión de médicos";
            this.Width = 1000;
            this.Height = 650;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitulo = new Label();
            lblTitulo.Text = "GESTIÓN DE MÉDICOS";
            lblTitulo.Left = 20;
            lblTitulo.Top = 15;
            lblTitulo.Width = 300;
            lblTitulo.Height = 30;
            lblTitulo.Font = new System.Drawing.Font(
                "Arial", 14, System.Drawing.FontStyle.Bold);

            Button btnConsultar = new Button();
            btnConsultar.Text = "Consultar médicos";
            btnConsultar.Left = 20;
            btnConsultar.Top = 60;
            btnConsultar.Width = 160;
            btnConsultar.Height = 35;

            DataGridView tablaMedicos = new DataGridView();
            tablaMedicos.Left = 20;
            tablaMedicos.Top = 115;
            tablaMedicos.Width = 550;
            tablaMedicos.Height = 420;
            tablaMedicos.ReadOnly = true;
            tablaMedicos.AllowUserToAddRows = false;
            tablaMedicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tablaMedicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablaMedicos.MultiSelect = false;

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Left = 610;
            lblNombre.Top = 60;
            lblNombre.Width = 250;

            TextBox txtNombre = new TextBox();
            txtNombre.Left = 610;
            txtNombre.Top = 85;
            txtNombre.Width = 280;

            Label lblApellidos = new Label();
            lblApellidos.Text = "Apellidos:";
            lblApellidos.Left = 610;
            lblApellidos.Top = 125;
            lblApellidos.Width = 250;

            TextBox txtApellidos = new TextBox();
            txtApellidos.Left = 610;
            txtApellidos.Top = 150;
            txtApellidos.Width = 280;

            Label lblEspecialidad = new Label();
            lblEspecialidad.Text = "Especialidad:";
            lblEspecialidad.Left = 610;
            lblEspecialidad.Top = 190;
            lblEspecialidad.Width = 250;

            ComboBox cmbEspecialidad = new ComboBox();
            cmbEspecialidad.Left = 610;
            cmbEspecialidad.Top = 215;
            cmbEspecialidad.Width = 280;
            cmbEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;

            Label lblTelefono = new Label();
            lblTelefono.Text = "Teléfono:";
            lblTelefono.Left = 610;
            lblTelefono.Top = 255;
            lblTelefono.Width = 250;

            TextBox txtTelefono = new TextBox();
            txtTelefono.Left = 610;
            txtTelefono.Top = 280;
            txtTelefono.Width = 280;

            Label lblEmail = new Label();
            lblEmail.Text = "Correo electrónico:";
            lblEmail.Left = 610;
            lblEmail.Top = 320;
            lblEmail.Width = 250;

            TextBox txtEmail = new TextBox();
            txtEmail.Left = 610;
            txtEmail.Top = 345;
            txtEmail.Width = 280;

            Button btnRegistrar = new Button();
            btnRegistrar.Text = "Registrar médico";
            btnRegistrar.Left = 610;
            btnRegistrar.Top = 400;
            btnRegistrar.Width = 135;
            btnRegistrar.Height = 40;

            Button btnActualizar = new Button();
            btnActualizar.Text = "Actualizar médico";
            btnActualizar.Left = 755;
            btnActualizar.Top = 400;
            btnActualizar.Width = 145;
            btnActualizar.Height = 40;
            btnActualizar.Enabled = false;

            Button btnLimpiar = new Button();
            btnLimpiar.Text = "Limpiar campos";
            btnLimpiar.Left = 610;
            btnLimpiar.Top = 455;
            btnLimpiar.Width = 135;
            btnLimpiar.Height = 35;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(btnConsultar);
            this.Controls.Add(tablaMedicos);

            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(lblApellidos);
            this.Controls.Add(txtApellidos);
            this.Controls.Add(lblEspecialidad);
            this.Controls.Add(cmbEspecialidad);
            this.Controls.Add(lblTelefono);
            this.Controls.Add(txtTelefono);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);

            this.Controls.Add(btnRegistrar);
            this.Controls.Add(btnActualizar);
            this.Controls.Add(btnLimpiar);

            int idMedicoSeleccionado = 0;

            ServicioMedico servicioMedico = new ServicioMedico();
            ServicioEspecialidad servicioEspecialidad = new ServicioEspecialidad();

            void CargarEspecialidades()
            {
                List<EspecialidadModelo> especialidades = servicioEspecialidad.ObtenerEspecialidades();

                cmbEspecialidad.DataSource = null;
                cmbEspecialidad.DataSource = especialidades;
                cmbEspecialidad.DisplayMember = "Nombre";
                cmbEspecialidad.ValueMember = "IdEspecialidad";
                cmbEspecialidad.SelectedIndex = -1;
            }

            void CargarMedicos()
            {
                List<MedicoModelo> medicos = servicioMedico.ObtenerMedicos();

                tablaMedicos.DataSource = null;
                tablaMedicos.DataSource = medicos;

                if (tablaMedicos.Columns["IdMedico"] != null)
                    tablaMedicos.Columns["IdMedico"].Visible = false;

                if (tablaMedicos.Columns["IdEspecialidad"] != null)
                    tablaMedicos.Columns["IdEspecialidad"].Visible = false;

                if (tablaMedicos.Columns["Nombre"] != null)
                    tablaMedicos.Columns["Nombre"].HeaderText = "Nombre";

                if (tablaMedicos.Columns["Apellidos"] != null)
                    tablaMedicos.Columns["Apellidos"].HeaderText = "Apellidos";

                if (tablaMedicos.Columns["NombreEspecialidad"] != null)
                    tablaMedicos.Columns["NombreEspecialidad"].HeaderText = "Especialidad";

                if (tablaMedicos.Columns["Telefono"] != null)
                    tablaMedicos.Columns["Telefono"].HeaderText = "Teléfono";

                if (tablaMedicos.Columns["Email"] != null)
                    tablaMedicos.Columns["Email"].HeaderText = "Correo";
            }

            void LimpiarFormulario()
            {
                txtNombre.Clear();
                txtApellidos.Clear();
                txtTelefono.Clear();
                txtEmail.Clear();

                cmbEspecialidad.SelectedIndex = -1;

                idMedicoSeleccionado = 0;
                btnActualizar.Enabled = false;

                tablaMedicos.ClearSelection();
            }

            try
            {
                CargarEspecialidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las especialidades: " + ex.Message);
            }

            btnConsultar.Click += (sender, e) =>
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
            };

            tablaMedicos.CellClick += (sender, e) =>
            {
                if (e.RowIndex < 0)
                    return;

                MedicoModelo medico = tablaMedicos.Rows[e.RowIndex].DataBoundItem as MedicoModelo;

                if (medico == null)
                    return;

                idMedicoSeleccionado = medico.IdMedico;

                txtNombre.Text = medico.Nombre;
                txtApellidos.Text = medico.Apellidos;
                txtTelefono.Text = medico.Telefono;
                txtEmail.Text = medico.Email;

                cmbEspecialidad.SelectedValue = medico.IdEspecialidad;

                btnActualizar.Enabled = true;
            };

            btnRegistrar.Click += (sender, e) =>
            {
                try
                {
                    if (cmbEspecialidad.SelectedValue == null)
                    {
                        MessageBox.Show("Debe seleccionar una especialidad.");
                        return;
                    }

                    MedicoModelo medico = new MedicoModelo
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Apellidos = txtApellidos.Text.Trim(),
                        IdEspecialidad = Convert.ToInt32(cmbEspecialidad.SelectedValue),
                        Telefono = txtTelefono.Text.Trim(),
                        Email = txtEmail.Text.Trim()
                    };

                    servicioMedico.RegistrarMedico(medico);

                    MessageBox.Show("Médico registrado correctamente.");

                    CargarMedicos();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo registrar el médico: " + ex.Message);
                }
            };

            btnActualizar.Click += (sender, e) =>
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

                    MedicoModelo medico = new MedicoModelo
                    {
                        IdMedico = idMedicoSeleccionado,
                        Nombre = txtNombre.Text.Trim(),
                        Apellidos = txtApellidos.Text.Trim(),
                        IdEspecialidad = Convert.ToInt32(cmbEspecialidad.SelectedValue),
                        Telefono = txtTelefono.Text.Trim(),
                        Email = txtEmail.Text.Trim()
                    };

                    servicioMedico.ActualizarMedico(medico);

                    MessageBox.Show("Médico actualizado correctamente.");

                    CargarMedicos();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo actualizar el médico: " + ex.Message);
                }
            };

            btnLimpiar.Click += (sender, e) =>
            {
                LimpiarFormulario();
            };
        }
    }
}
