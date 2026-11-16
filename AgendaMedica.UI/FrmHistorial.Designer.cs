namespace AgendaMedica.UI
{
    partial class FrmHistorial
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.cmbPaciente = new System.Windows.Forms.ComboBox();
            this.lblMedico = new System.Windows.Forms.Label();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.lblTratamiento = new System.Windows.Forms.Label();
            this.txtTratamiento = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 22);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "HISTORIAL MÉDICO";
 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(20, 62);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(70, 20);
            this.lblPaciente.TabIndex = 1;
            this.lblPaciente.Text = "Paciente:";

            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.FormattingEnabled = true;
            this.cmbPaciente.Location = new System.Drawing.Point(110, 58);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(330, 28);
            this.cmbPaciente.TabIndex = 2;
            this.cmbPaciente.SelectedIndexChanged += new System.EventHandler(this.cmbPaciente_SelectedIndexChanged);

            this.lblMedico.AutoSize = true;
            this.lblMedico.Location = new System.Drawing.Point(20, 105);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(150, 20);
            this.lblMedico.TabIndex = 3;
            this.lblMedico.Text = "Médico que atendió:";
 
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(20, 129);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(420, 28);
            this.cmbMedico.TabIndex = 4;
  
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(20, 170);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(154, 20);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha de la consulta:";

            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(20, 194);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(160, 27);
            this.dtpFecha.TabIndex = 6;
 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(20, 235);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(266, 20);
            this.lblDescripcion.TabIndex = 7;
            this.lblDescripcion.Text = "Motivo o descripción de la consulta:";

            this.txtDescripcion.Location = new System.Drawing.Point(20, 259);
            this.txtDescripcion.MaxLength = 2000;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(420, 65);
            this.txtDescripcion.TabIndex = 8;

            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Location = new System.Drawing.Point(20, 334);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(97, 20);
            this.lblDiagnostico.TabIndex = 9;
            this.lblDiagnostico.Text = "Diagnóstico:";
 
            this.txtDiagnostico.Location = new System.Drawing.Point(20, 358);
            this.txtDiagnostico.MaxLength = 2000;
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnostico.Size = new System.Drawing.Size(420, 65);
            this.txtDiagnostico.TabIndex = 10;
 
            this.lblTratamiento.AutoSize = true;
            this.lblTratamiento.Location = new System.Drawing.Point(20, 433);
            this.lblTratamiento.Name = "lblTratamiento";
            this.lblTratamiento.Size = new System.Drawing.Size(173, 20);
            this.lblTratamiento.TabIndex = 11;
            this.lblTratamiento.Text = "Tratamiento (opcional):";

            this.txtTratamiento.Location = new System.Drawing.Point(20, 457);
            this.txtTratamiento.MaxLength = 2000;
            this.txtTratamiento.Multiline = true;
            this.txtTratamiento.Name = "txtTratamiento";
            this.txtTratamiento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTratamiento.Size = new System.Drawing.Size(420, 65);
            this.txtTratamiento.TabIndex = 12;
 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(20, 532);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(185, 20);
            this.lblObservaciones.TabIndex = 13;
            this.lblObservaciones.Text = "Observaciones (opcional):";
 
            this.txtObservaciones.Location = new System.Drawing.Point(20, 556);
            this.txtObservaciones.MaxLength = 2000;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(420, 65);
            this.txtObservaciones.TabIndex = 14;

            this.btnRegistrar.Location = new System.Drawing.Point(20, 635);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(205, 40);
            this.btnRegistrar.TabIndex = 15;
            this.btnRegistrar.Text = "Registrar entrada";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
 
            this.btnLimpiar.Location = new System.Drawing.Point(235, 635);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(205, 40);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar campos";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(470, 58);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(610, 617);
            this.dgvHistorial.TabIndex = 17;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 695);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.txtTratamiento);
            this.Controls.Add(this.lblTratamiento);
            this.Controls.Add(this.txtDiagnostico);
            this.Controls.Add(this.lblDiagnostico);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.cmbMedico);
            this.Controls.Add(this.lblMedico);
            this.Controls.Add(this.cmbPaciente);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agenda Médica - Historial médico";
            this.Load += new System.EventHandler(this.FrmHistorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cmbPaciente;
        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label lblTratamiento;
        private System.Windows.Forms.TextBox txtTratamiento;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvHistorial;
    }
}