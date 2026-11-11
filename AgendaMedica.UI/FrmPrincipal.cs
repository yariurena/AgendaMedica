using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AgendaMedica.BL;
using PacienteModelo = AgendaMedica.Modelos.Paciente;
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
            tablaEspecialidades.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            this.Controls.Add(btnEspecialidades);
            this.Controls.Add(tablaEspecialidades);

            Button btnPacientes = new Button();
            btnPacientes.Text = "Ver pacientes";
            btnPacientes.Width = 180;
            btnPacientes.Height = 35;
            btnPacientes.Left = 220;
            btnPacientes.Top = 20;

            DataGridView tablaPacientes = new DataGridView();
            tablaPacientes.Left = 20;
            tablaPacientes.Top = 310;
            tablaPacientes.Width = 600;
            tablaPacientes.Height = 220;
            tablaPacientes.ReadOnly = true;
            tablaPacientes.AllowUserToAddRows = false;
            tablaPacientes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            this.Controls.Add(btnPacientes);
            this.Controls.Add(tablaPacientes);

            Button btnRegistrarPaciente = new Button();
            btnRegistrarPaciente.Text = "Registrar paciente";
            btnRegistrarPaciente.Width = 180;
            btnRegistrarPaciente.Height = 35;
            btnRegistrarPaciente.Left = 420;
            btnRegistrarPaciente.Top = 20;

            this.Controls.Add(btnRegistrarPaciente);

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Left = 650;
            lblNombre.Top = 70;
            lblNombre.Width = 120;

            TextBox txtNombre = new TextBox();
            txtNombre.Left = 650;
            txtNombre.Top = 90;
            txtNombre.Width = 220;

            Label lblApellidos = new Label();
            lblApellidos.Text = "Apellidos:";
            lblApellidos.Left = 650;
            lblApellidos.Top = 120;
            lblApellidos.Width = 120;

            TextBox txtApellidos = new TextBox();
            txtApellidos.Left = 650;
            txtApellidos.Top = 140;
            txtApellidos.Width = 220;

            Label lblCedula = new Label();
            lblCedula.Text = "Cédula:";
            lblCedula.Left = 650;
            lblCedula.Top = 170;
            lblCedula.Width = 120;

            TextBox txtCedula = new TextBox();
            txtCedula.Left = 650;
            txtCedula.Top = 190;
            txtCedula.Width = 220;

            Label lblDireccion = new Label();
            lblDireccion.Text = "Dirección:";
            lblDireccion.Left = 650;
            lblDireccion.Top = 220;
            lblDireccion.Width = 120;

            TextBox txtDireccion = new TextBox();
            txtDireccion.Left = 650;
            txtDireccion.Top = 240;
            txtDireccion.Width = 220;

            Label lblEmail = new Label();
            lblEmail.Text = "Correo electrónico:";
            lblEmail.Left = 650;
            lblEmail.Top = 270;
            lblEmail.Width = 150;

            TextBox txtEmail = new TextBox();
            txtEmail.Left = 650;
            txtEmail.Top = 290;
            txtEmail.Width = 220;

            Label lblFecha = new Label();
            lblFecha.Text = "Fecha de nacimiento:";
            lblFecha.Left = 650;
            lblFecha.Top = 320;
            lblFecha.Width = 150;

            DateTimePicker dtpFechaNacimiento = new DateTimePicker();
            dtpFechaNacimiento.Left = 650;
            dtpFechaNacimiento.Top = 340;
            dtpFechaNacimiento.Width = 220;
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.ShowCheckBox = true;
            dtpFechaNacimiento.Checked = false;

            Label lblTelefono = new Label();
            lblTelefono.Text = "Teléfono:";
            lblTelefono.Left = 650;
            lblTelefono.Top = 370;
            lblTelefono.Width = 120;

            TextBox txtTelefono = new TextBox();
            txtTelefono.Left = 650;
            txtTelefono.Top = 390;
            txtTelefono.Width = 220;

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

            btnEspecialidades.Click += (sender, e) =>
            {
                try
                {
                    ServicioEspecialidad servicio = new ServicioEspecialidad();

                    List<EspecialidadModelo> especialidades = servicio.ObtenerEspecialidades();

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
                catch (Exception ex)
                {
                    MessageBox.Show( "No se pudieron cargar las especialidades: " + ex.Message);
                }
            };

            btnPacientes.Click += (sender, e) =>
            {
                try
                {
                    ServicioPaciente servicio = new ServicioPaciente();

                    List<PacienteModelo> pacientes = servicio.ObtenerPacientes();

                    tablaPacientes.DataSource = pacientes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudieron cargar los pacientes: " + ex.Message);
                }
            };

            btnRegistrarPaciente.Click += (sender, e) =>
            {
                try
                {
                    ServicioPaciente servicio = new ServicioPaciente();

                    PacienteModelo paciente = new PacienteModelo
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Apellidos = txtApellidos.Text.Trim(),
                        Cedula = txtCedula.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),

                        FechaNacimiento = dtpFechaNacimiento.Checked ? dtpFechaNacimiento.Value.Date: (DateTime?)null
                    };

                    servicio.RegistrarPaciente(paciente);

                    MessageBox.Show("Paciente registrado correctamente.");

                    tablaPacientes.DataSource = servicio.ObtenerPacientes();

                    txtNombre.Clear();
                    txtApellidos.Clear();
                    txtCedula.Clear();
                    txtDireccion.Clear();
                    txtEmail.Clear();
                    txtTelefono.Clear();

                    dtpFechaNacimiento.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo registrar el paciente: " +ex.Message);
                }
            };
        }
    }
}