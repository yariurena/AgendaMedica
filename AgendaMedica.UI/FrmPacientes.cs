
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AgendaMedica.BL;
using PacienteModelo = AgendaMedica.Modelos.Paciente;

namespace AgendaMedica.UI
{
    public partial class FrmPacientes : Form
    {
        public FrmPacientes()
        {
            InitializeComponent();

            this.Text = "Agenda Médica - Gestión de pacientes";
            this.Width = 1100;
            this.Height = 700;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitulo = new Label();
            lblTitulo.Text = "GESTIÓN DE PACIENTES";
            lblTitulo.Left = 20;
            lblTitulo.Top = 15;
            lblTitulo.Width = 350;
            lblTitulo.Height = 30;
            lblTitulo.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);

            Button btnConsultar = new Button();
            btnConsultar.Text = "Consultar pacientes";
            btnConsultar.Left = 20;
            btnConsultar.Top = 55;
            btnConsultar.Width = 170;
            btnConsultar.Height = 35;

            DataGridView tablaPacientes = new DataGridView();
            tablaPacientes.Left = 20;
            tablaPacientes.Top = 105;
            tablaPacientes.Width = 570;
            tablaPacientes.Height = 480;
            tablaPacientes.ReadOnly = true;
            tablaPacientes.AllowUserToAddRows = false;
            tablaPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tablaPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablaPacientes.MultiSelect = false;

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Left = 620;
            lblNombre.Top = 45;
            lblNombre.Width = 250;

            TextBox txtNombre = new TextBox();
            txtNombre.Left = 620;
            txtNombre.Top = 70;
            txtNombre.Width = 350;

            Label lblApellidos = new Label();
            lblApellidos.Text = "Apellidos:";
            lblApellidos.Left = 620;
            lblApellidos.Top = 110;
            lblApellidos.Width = 250;

            TextBox txtApellidos = new TextBox();
            txtApellidos.Left = 620;
            txtApellidos.Top = 135;
            txtApellidos.Width = 350;

            Label lblCedula = new Label();
            lblCedula.Text = "Cédula:";
            lblCedula.Left = 620;
            lblCedula.Top = 175;
            lblCedula.Width = 250;

            TextBox txtCedula = new TextBox();
            txtCedula.Left = 620;
            txtCedula.Top = 200;
            txtCedula.Width = 350;

            Label lblDireccion = new Label();
            lblDireccion.Text = "Dirección:";
            lblDireccion.Left = 620;
            lblDireccion.Top = 240;
            lblDireccion.Width = 250;

            TextBox txtDireccion = new TextBox();
            txtDireccion.Left = 620;
            txtDireccion.Top = 265;
            txtDireccion.Width = 350;

            Label lblEmail = new Label();
            lblEmail.Text = "Correo electrónico:";
            lblEmail.Left = 620;
            lblEmail.Top = 305;
            lblEmail.Width = 250;

            TextBox txtEmail = new TextBox();
            txtEmail.Left = 620;
            txtEmail.Top = 330;
            txtEmail.Width = 350;

            Label lblFecha = new Label();
            lblFecha.Text = "Fecha de nacimiento:";
            lblFecha.Left = 620;
            lblFecha.Top = 370;
            lblFecha.Width = 250;

            DateTimePicker dtpFechaNacimiento = new DateTimePicker();
            dtpFechaNacimiento.Left = 620;
            dtpFechaNacimiento.Top = 395;
            dtpFechaNacimiento.Width = 350;
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.ShowCheckBox = true;
            dtpFechaNacimiento.Checked = false;

            Label lblTelefono = new Label();
            lblTelefono.Text = "Teléfono:";
            lblTelefono.Left = 620;
            lblTelefono.Top = 435;
            lblTelefono.Width = 250;

            TextBox txtTelefono = new TextBox();
            txtTelefono.Left = 620;
            txtTelefono.Top = 460;
            txtTelefono.Width = 350;

            Button btnRegistrar = new Button();
            btnRegistrar.Text = "Registrar paciente";
            btnRegistrar.Left = 620;
            btnRegistrar.Top = 510;
            btnRegistrar.Width = 165;
            btnRegistrar.Height = 40;

            Button btnActualizar = new Button();
            btnActualizar.Text = "Actualizar paciente";
            btnActualizar.Left = 800;
            btnActualizar.Top = 510;
            btnActualizar.Width = 170;
            btnActualizar.Height = 40;
            btnActualizar.Enabled = false;

            Button btnLimpiar = new Button();
            btnLimpiar.Text = "Limpiar campos";
            btnLimpiar.Left = 620;
            btnLimpiar.Top = 560;
            btnLimpiar.Width = 165;
            btnLimpiar.Height = 35;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(btnConsultar);
            this.Controls.Add(tablaPacientes);

            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(lblApellidos);
            this.Controls.Add(txtApellidos);
            this.Controls.Add(lblCedula);
            this.Controls.Add(txtCedula);
            this.Controls.Add(lblDireccion);
            this.Controls.Add(txtDireccion);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblFecha);
            this.Controls.Add(dtpFechaNacimiento);
            this.Controls.Add(lblTelefono);
            this.Controls.Add(txtTelefono);

            this.Controls.Add(btnRegistrar);
            this.Controls.Add(btnActualizar);
            this.Controls.Add(btnLimpiar);

            int idPacienteSeleccionado = 0;

            ServicioPaciente servicio = new ServicioPaciente();

            void CargarPacientes()
            {
                List<PacienteModelo> pacientes = servicio.ObtenerPacientes();

                tablaPacientes.DataSource = null;
                tablaPacientes.DataSource = pacientes;

                if (tablaPacientes.Columns["IdPaciente"] != null)
                    tablaPacientes.Columns["IdPaciente"].Visible = false;

                if (tablaPacientes.Columns["Nombre"] != null)
                    tablaPacientes.Columns["Nombre"].HeaderText = "Nombre";

                if (tablaPacientes.Columns["Apellidos"] != null)
                    tablaPacientes.Columns["Apellidos"].HeaderText = "Apellidos";

                if (tablaPacientes.Columns["Cedula"] != null)
                    tablaPacientes.Columns["Cedula"].HeaderText = "Cédula";

                if (tablaPacientes.Columns["Direccion"] != null)
                    tablaPacientes.Columns["Direccion"].HeaderText = "Dirección";

                if (tablaPacientes.Columns["Email"] != null)
                    tablaPacientes.Columns["Email"].HeaderText = "Correo";

                if (tablaPacientes.Columns["FechaNacimiento"] != null)
                    tablaPacientes.Columns["FechaNacimiento"].HeaderText =
                        "Fecha de nacimiento";

                if (tablaPacientes.Columns["Telefono"] != null)
                    tablaPacientes.Columns["Telefono"].HeaderText = "Teléfono";
            }

            void LimpiarFormulario()
            {
                txtNombre.Clear();
                txtApellidos.Clear();
                txtCedula.Clear();
                txtDireccion.Clear();
                txtEmail.Clear();
                txtTelefono.Clear();

                dtpFechaNacimiento.Checked = false;

                idPacienteSeleccionado = 0;
                btnActualizar.Enabled = false;

                tablaPacientes.ClearSelection();
            }

            btnConsultar.Click += (sender, e) =>
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
            };

            tablaPacientes.CellClick += (sender, e) =>
            {
                if (e.RowIndex < 0)
                    return;

                PacienteModelo paciente = tablaPacientes.Rows[e.RowIndex].DataBoundItem as PacienteModelo;

                if (paciente == null)
                    return;

                idPacienteSeleccionado = paciente.IdPaciente;

                txtNombre.Text = paciente.Nombre;
                txtApellidos.Text = paciente.Apellidos;
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
            };

            btnRegistrar.Click += (sender, e) =>
            {
                try
                {
                    PacienteModelo paciente = new PacienteModelo
                        {
                            Nombre = txtNombre.Text.Trim(),
                            Apellidos = txtApellidos.Text.Trim(),
                            Cedula = txtCedula.Text.Trim(),
                            Direccion = txtDireccion.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            Telefono = txtTelefono.Text.Trim(),
                            FechaNacimiento = dtpFechaNacimiento.Checked? dtpFechaNacimiento.Value.Date: (DateTime?)null
                        };

                    servicio.RegistrarPaciente(paciente);
                    MessageBox.Show("Paciente registrado correctamente.");

                    CargarPacientes();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo registrar el paciente: " + ex.Message);
                }
            };

            btnActualizar.Click += (sender, e) =>
            {
                try
                {
                    if (idPacienteSeleccionado <= 0)
                    {
                        MessageBox.Show("Primero debe seleccionar un paciente de la tabla.");
                        return;
                    }

                    PacienteModelo paciente = new PacienteModelo
                        {
                            IdPaciente = idPacienteSeleccionado,
                            Nombre = txtNombre.Text.Trim(),
                            Apellidos = txtApellidos.Text.Trim(),
                            Cedula = txtCedula.Text.Trim(),
                            Direccion = txtDireccion.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            Telefono = txtTelefono.Text.Trim(),

                            FechaNacimiento = dtpFechaNacimiento.Checked? dtpFechaNacimiento.Value.Date: (DateTime?)null
                        };

                    servicio.ActualizarPaciente(paciente);
                    MessageBox.Show("Paciente actualizado correctamente.");

                    CargarPacientes();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo actualizar el paciente: " + ex.Message);
                }
            };

            btnLimpiar.Click += (sender, e) =>
            {
                LimpiarFormulario();
            };
        }
    }
}
