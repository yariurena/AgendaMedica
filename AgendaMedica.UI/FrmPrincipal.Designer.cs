namespace AgendaMedica.UI
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMedicos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHorarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCitas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistorial = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();

            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGestion,
            this.mnuCitas,
            this.mnuConsultas,
            this.mnuAdministracion,
            this.mnuCerrarSesion});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(900, 28);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuPrincipal";

            this.mnuGestion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPacientes,
            this.mnuMedicos,
            this.mnuEspecialidades,
            this.mnuHorarios});
            this.mnuGestion.Name = "mnuGestion";
            this.mnuGestion.Size = new System.Drawing.Size(78, 24);
            this.mnuGestion.Text = "Gestión";
 
            this.mnuPacientes.Name = "mnuPacientes";
            this.mnuPacientes.Size = new System.Drawing.Size(224, 26);
            this.mnuPacientes.Text = "Pacientes";
            this.mnuPacientes.Click += new System.EventHandler(this.mnuPacientes_Click);
 
            this.mnuMedicos.Name = "mnuMedicos";
            this.mnuMedicos.Size = new System.Drawing.Size(224, 26);
            this.mnuMedicos.Text = "Médicos";
            this.mnuMedicos.Click += new System.EventHandler(this.mnuMedicos_Click);
 
            this.mnuEspecialidades.Name = "mnuEspecialidades";
            this.mnuEspecialidades.Size = new System.Drawing.Size(224, 26);
            this.mnuEspecialidades.Text = "Especialidades";
            this.mnuEspecialidades.Click += new System.EventHandler(this.mnuEspecialidades_Click);

            this.mnuHorarios.Name = "mnuHorarios";
            this.mnuHorarios.Size = new System.Drawing.Size(224, 26);
            this.mnuHorarios.Text = "Horarios de médicos";
            this.mnuHorarios.Click += new System.EventHandler(this.mnuHorarios_Click);
  
            this.mnuCitas.Name = "mnuCitas";
            this.mnuCitas.Size = new System.Drawing.Size(60, 24);
            this.mnuCitas.Text = "Citas";
            this.mnuCitas.Click += new System.EventHandler(this.mnuCitas_Click);
 
            this.mnuConsultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHistorial,
            this.mnuReportes});
            this.mnuConsultas.Name = "mnuConsultas";
            this.mnuConsultas.Size = new System.Drawing.Size(89, 24);
            this.mnuConsultas.Text = "Consultas";
 
            this.mnuHistorial.Name = "mnuHistorial";
            this.mnuHistorial.Size = new System.Drawing.Size(224, 26);
            this.mnuHistorial.Text = "Historial médico";
            this.mnuHistorial.Click += new System.EventHandler(this.mnuHistorial_Click);

            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Size = new System.Drawing.Size(224, 26);
            this.mnuReportes.Text = "Reportes";
            this.mnuReportes.Click += new System.EventHandler(this.mnuReportes_Click);
 
            this.mnuAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.mnuUsuarios});
            this.mnuAdministracion.Name = "mnuAdministracion";
            this.mnuAdministracion.Size = new System.Drawing.Size(124, 24);
            this.mnuAdministracion.Text = "Administración";

            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(224, 26);
            this.mnuUsuarios.Text = "Usuarios";
            this.mnuUsuarios.Click += new System.EventHandler(this.mnuUsuarios_Click);

            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Size = new System.Drawing.Size(109, 24);
            this.mnuCerrarSesion.Text = "Cerrar sesión";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click);
 
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(50, 150);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(800, 50);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "SISTEMA DE GESTIÓN - AGENDA MÉDICA";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
 
            this.lblBienvenida.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBienvenida.Location = new System.Drawing.Point(50, 215);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(800, 30);
            this.lblBienvenida.TabIndex = 2;
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.menuPrincipal);
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agenda Médica - Sistema de gestión";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuGestion;
        private System.Windows.Forms.ToolStripMenuItem mnuPacientes;
        private System.Windows.Forms.ToolStripMenuItem mnuMedicos;
        private System.Windows.Forms.ToolStripMenuItem mnuEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem mnuHorarios;
        private System.Windows.Forms.ToolStripMenuItem mnuCitas;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultas;
        private System.Windows.Forms.ToolStripMenuItem mnuHistorial;
        private System.Windows.Forms.ToolStripMenuItem mnuReportes;
        private System.Windows.Forms.ToolStripMenuItem mnuAdministracion;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarSesion;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBienvenida;
    }
}