using System;
using System.Windows.Forms;

namespace AgendaMedica.UI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();

            this.Text = "Agenda Médica - Sistema de gestión";
            this.Width = 750;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitulo = new Label();
            lblTitulo.Text = "SISTEMA DE GESTIÓN - AGENDA MÉDICA";
            lblTitulo.Left = 100;
            lblTitulo.Top = 55;
            lblTitulo.Width = 550;
            lblTitulo.Height = 40;
            lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitulo.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);

            Button btnPacientes = new Button();
            btnPacientes.Text = "Gestión de pacientes";
            btnPacientes.Left = 80;
            btnPacientes.Top = 150;
            btnPacientes.Width = 180;
            btnPacientes.Height = 60;

            Button btnMedicos = new Button();
            btnMedicos.Text = "Gestión de médicos";
            btnMedicos.Left = 285;
            btnMedicos.Top = 150;
            btnMedicos.Width = 180;
            btnMedicos.Height = 60;

            Button btnEspecialidades = new Button();
            btnEspecialidades.Text = "Gestión de especialidades";
            btnEspecialidades.Left = 490;
            btnEspecialidades.Top = 150;
            btnEspecialidades.Width = 180;
            btnEspecialidades.Height = 60;

            Button btnHorarios = new Button();
            btnHorarios.Text = "Horarios de médicos";
            btnHorarios.Left = 285;
            btnHorarios.Top = 235;
            btnHorarios.Width = 180;
            btnHorarios.Height = 60;

            Button btnCitas = new Button();
            btnCitas.Text = "Gestión de citas";
            btnCitas.Left = 490;
            btnCitas.Top = 235;
            btnCitas.Width = 180;
            btnCitas.Height = 60;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(btnPacientes);
            this.Controls.Add(btnMedicos);
            this.Controls.Add(btnEspecialidades);
            this.Controls.Add(btnHorarios);
            this.Controls.Add(btnCitas);

            btnPacientes.Click += (sender, e) =>
            {
                FrmPacientes ventana = new FrmPacientes();
                ventana.ShowDialog();
            };

            btnMedicos.Click += (sender, e) =>
            {
                FrmMedicos ventana = new FrmMedicos();
                ventana.ShowDialog();
            };

            btnEspecialidades.Click += (sender, e) =>
            {
                FrmEspecialidades ventana = new FrmEspecialidades();
                ventana.ShowDialog();
            };

            btnHorarios.Click += (sender, e) =>
            {
                FrmHorarios ventana = new FrmHorarios();
                ventana.ShowDialog();
            };

            btnCitas.Click += (sender, e) =>
            {
                FrmCitas ventana = new FrmCitas();
                ventana.ShowDialog();
            };
        }
    }
}
