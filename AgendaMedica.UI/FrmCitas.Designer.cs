namespace AgendaMedica.UI
{
    partial class FrmCitas
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
            this.grpNueva = new System.Windows.Forms.GroupBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.cmbPaciente = new System.Windows.Forms.ComboBox();
            this.lblMedico = new System.Windows.Forms.Label();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.cmbDuracion = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.btnReprogramar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblFMedico = new System.Windows.Forms.Label();
            this.cmbFiltroMedico = new System.Windows.Forms.ComboBox();
            this.lblFPaciente = new System.Windows.Forms.Label();
            this.cmbFiltroPaciente = new System.Windows.Forms.ComboBox();
            this.chkFiltroFecha = new System.Windows.Forms.CheckBox();
            this.dtpFiltroFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFEstado = new System.Windows.Forms.Label();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnAtendida = new System.Windows.Forms.Button();
            this.btnNoAsistio = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpNueva.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.SuspendLayout();

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 22);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "GESTIÓN DE CITAS";

            this.grpNueva.Controls.Add(this.lblPaciente);
            this.grpNueva.Controls.Add(this.cmbPaciente);
            this.grpNueva.Controls.Add(this.lblMedico);
            this.grpNueva.Controls.Add(this.cmbMedico);
            this.grpNueva.Controls.Add(this.lblTipo);
            this.grpNueva.Controls.Add(this.cmbTipo);
            this.grpNueva.Controls.Add(this.lblDuracion);
            this.grpNueva.Controls.Add(this.cmbDuracion);
            this.grpNueva.Controls.Add(this.lblFecha);
            this.grpNueva.Controls.Add(this.dtpFecha);
            this.grpNueva.Controls.Add(this.lblHora);
            this.grpNueva.Controls.Add(this.dtpHora);
            this.grpNueva.Controls.Add(this.lblMotivo);
            this.grpNueva.Controls.Add(this.txtMotivo);
            this.grpNueva.Controls.Add(this.btnAgendar);
            this.grpNueva.Controls.Add(this.btnReprogramar);
            this.grpNueva.Controls.Add(this.btnLimpiar);
            this.grpNueva.Location = new System.Drawing.Point(20, 50);
            this.grpNueva.Name = "grpNueva";
            this.grpNueva.Size = new System.Drawing.Size(1160, 180);
            this.grpNueva.TabIndex = 1;
            this.grpNueva.TabStop = false;
            this.grpNueva.Text = "Agendar o reprogramar cita";

            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(15, 28);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(65, 20);
            this.lblPaciente.TabIndex = 0;
            this.lblPaciente.Text = "Paciente:";

            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.FormattingEnabled = true;
            this.cmbPaciente.Location = new System.Drawing.Point(15, 52);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(260, 28);
            this.cmbPaciente.TabIndex = 1;

            this.lblMedico.AutoSize = true;
            this.lblMedico.Location = new System.Drawing.Point(295, 28);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(60, 20);
            this.lblMedico.TabIndex = 2;
            this.lblMedico.Text = "Médico:";

            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(295, 52);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(260, 28);
            this.cmbMedico.TabIndex = 3;

            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(575, 28);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(88, 20);
            this.lblTipo.TabIndex = 4;
            this.lblTipo.Text = "Tipo de cita:";

            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(575, 52);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(160, 28);
            this.cmbTipo.TabIndex = 5;

            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(755, 28);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(114, 20);
            this.lblDuracion.TabIndex = 6;
            this.lblDuracion.Text = "Duración (min):";

            this.cmbDuracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuracion.FormattingEnabled = true;
            this.cmbDuracion.Items.AddRange(new object[] {"30", "45", "60"});
            this.cmbDuracion.Location = new System.Drawing.Point(755, 52);
            this.cmbDuracion.Name = "cmbDuracion";
            this.cmbDuracion.Size = new System.Drawing.Size(120, 28);
            this.cmbDuracion.TabIndex = 7;

            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(15, 95);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(52, 20);
            this.lblFecha.TabIndex = 8;
            this.lblFecha.Text = "Fecha:";

            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(15, 119);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(160, 27);
            this.dtpFecha.TabIndex = 9;

            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(195, 95);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(47, 20);
            this.lblHora.TabIndex = 10;
            this.lblHora.Text = "Hora:";

            this.dtpHora.CustomFormat = "HH:mm";
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHora.Location = new System.Drawing.Point(195, 119);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(100, 27);
            this.dtpHora.TabIndex = 11;

            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(315, 95);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(61, 20);
            this.lblMotivo.TabIndex = 12;
            this.lblMotivo.Text = "Motivo:";

            this.txtMotivo.Location = new System.Drawing.Point(315, 119);
            this.txtMotivo.MaxLength = 255;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(560, 27);
            this.txtMotivo.TabIndex = 13;

            this.btnAgendar.Location = new System.Drawing.Point(900, 45);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(240, 36);
            this.btnAgendar.TabIndex = 14;
            this.btnAgendar.Text = "Agendar cita";
            this.btnAgendar.UseVisualStyleBackColor = true;

            this.btnReprogramar.Enabled = false;
            this.btnReprogramar.Location = new System.Drawing.Point(900, 90);
            this.btnReprogramar.Name = "btnReprogramar";
            this.btnReprogramar.Size = new System.Drawing.Size(240, 36);
            this.btnReprogramar.TabIndex = 15;
            this.btnReprogramar.Text = "Reprogramar cita seleccionada";
            this.btnReprogramar.UseVisualStyleBackColor = true;

            this.btnLimpiar.Location = new System.Drawing.Point(900, 135);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(240, 32);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar campos";
            this.btnLimpiar.UseVisualStyleBackColor = true;

            this.grpFiltros.Controls.Add(this.lblFMedico);
            this.grpFiltros.Controls.Add(this.cmbFiltroMedico);
            this.grpFiltros.Controls.Add(this.lblFPaciente);
            this.grpFiltros.Controls.Add(this.cmbFiltroPaciente);
            this.grpFiltros.Controls.Add(this.chkFiltroFecha);
            this.grpFiltros.Controls.Add(this.dtpFiltroFecha);
            this.grpFiltros.Controls.Add(this.lblFEstado);
            this.grpFiltros.Controls.Add(this.cmbFiltroEstado);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.grpFiltros.Location = new System.Drawing.Point(20, 240);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1160, 90);
            this.grpFiltros.TabIndex = 2;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Buscar en la agenda";

            this.lblFMedico.AutoSize = true;
            this.lblFMedico.Location = new System.Drawing.Point(15, 22);
            this.lblFMedico.Name = "lblFMedico";
            this.lblFMedico.Size = new System.Drawing.Size(60, 20);
            this.lblFMedico.TabIndex = 0;
            this.lblFMedico.Text = "Médico:";
 
            this.cmbFiltroMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroMedico.FormattingEnabled = true;
            this.cmbFiltroMedico.Location = new System.Drawing.Point(15, 46);
            this.cmbFiltroMedico.Name = "cmbFiltroMedico";
            this.cmbFiltroMedico.Size = new System.Drawing.Size(260, 28);
            this.cmbFiltroMedico.TabIndex = 1;

            this.lblFPaciente.AutoSize = true;
            this.lblFPaciente.Location = new System.Drawing.Point(295, 22);
            this.lblFPaciente.Name = "lblFPaciente";
            this.lblFPaciente.Size = new System.Drawing.Size(65, 20);
            this.lblFPaciente.TabIndex = 2;
            this.lblFPaciente.Text = "Paciente:";

            this.cmbFiltroPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroPaciente.FormattingEnabled = true;
            this.cmbFiltroPaciente.Location = new System.Drawing.Point(295, 46);
            this.cmbFiltroPaciente.Name = "cmbFiltroPaciente";
            this.cmbFiltroPaciente.Size = new System.Drawing.Size(260, 28);
            this.cmbFiltroPaciente.TabIndex = 3;
 
            this.chkFiltroFecha.AutoSize = true;
            this.chkFiltroFecha.Location = new System.Drawing.Point(575, 48);
            this.chkFiltroFecha.Name = "chkFiltroFecha";
            this.chkFiltroFecha.Size = new System.Drawing.Size(70, 24);
            this.chkFiltroFecha.TabIndex = 4;
            this.chkFiltroFecha.Text = "Fecha:";
            this.chkFiltroFecha.UseVisualStyleBackColor = true;

            this.dtpFiltroFecha.Enabled = false;
            this.dtpFiltroFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroFecha.Location = new System.Drawing.Point(650, 47);
            this.dtpFiltroFecha.Name = "dtpFiltroFecha";
            this.dtpFiltroFecha.Size = new System.Drawing.Size(140, 27);
            this.dtpFiltroFecha.TabIndex = 5;
 
            this.lblFEstado.AutoSize = true;
            this.lblFEstado.Location = new System.Drawing.Point(810, 22);
            this.lblFEstado.Name = "lblFEstado";
            this.lblFEstado.Size = new System.Drawing.Size(59, 20);
            this.lblFEstado.TabIndex = 6;
            this.lblFEstado.Text = "Estado:";
 
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.FormattingEnabled = true;
            this.cmbFiltroEstado.Location = new System.Drawing.Point(810, 46);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(130, 28);
            this.cmbFiltroEstado.TabIndex = 7;

            this.btnBuscar.Location = new System.Drawing.Point(955, 40);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 35);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;

            this.btnLimpiarFiltros.Location = new System.Drawing.Point(1050, 40);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(95, 35);
            this.btnLimpiarFiltros.TabIndex = 9;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = true;

            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.AllowUserToDeleteRows = false;
            this.dgvCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Location = new System.Drawing.Point(20, 340);
            this.dgvCitas.MultiSelect = false;
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.RowHeadersVisible = false;
            this.dgvCitas.RowHeadersWidth = 51;
            this.dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitas.Size = new System.Drawing.Size(1160, 270);
            this.dgvCitas.TabIndex = 3;
 
            this.btnConfirmar.Enabled = false;
            this.btnConfirmar.Location = new System.Drawing.Point(20, 620);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(180, 40);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "Confirmar cita";
            this.btnConfirmar.UseVisualStyleBackColor = true;

            this.btnAtendida.Enabled = false;
            this.btnAtendida.Location = new System.Drawing.Point(210, 620);
            this.btnAtendida.Name = "btnAtendida";
            this.btnAtendida.Size = new System.Drawing.Size(180, 40);
            this.btnAtendida.TabIndex = 5;
            this.btnAtendida.Text = "Marcar como atendida";
            this.btnAtendida.UseVisualStyleBackColor = true;

            this.btnNoAsistio.Enabled = false;
            this.btnNoAsistio.Location = new System.Drawing.Point(400, 620);
            this.btnNoAsistio.Name = "btnNoAsistio";
            this.btnNoAsistio.Size = new System.Drawing.Size(180, 40);
            this.btnNoAsistio.TabIndex = 6;
            this.btnNoAsistio.Text = "Marcar no asistió";
            this.btnNoAsistio.UseVisualStyleBackColor = true;

            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(590, 620);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(180, 40);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar cita";
            this.btnCancelar.UseVisualStyleBackColor = true;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNoAsistio);
            this.Controls.Add(this.btnAtendida);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dgvCitas);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.grpNueva);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmCitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agenda Médica - Gestión de citas";
            this.grpNueva.ResumeLayout(false);
            this.grpNueva.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpNueva;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cmbPaciente;
        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.ComboBox cmbDuracion;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.Button btnReprogramar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblFMedico;
        private System.Windows.Forms.ComboBox cmbFiltroMedico;
        private System.Windows.Forms.Label lblFPaciente;
        private System.Windows.Forms.ComboBox cmbFiltroPaciente;
        private System.Windows.Forms.CheckBox chkFiltroFecha;
        private System.Windows.Forms.DateTimePicker dtpFiltroFecha;
        private System.Windows.Forms.Label lblFEstado;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnAtendida;
        private System.Windows.Forms.Button btnNoAsistio;
        private System.Windows.Forms.Button btnCancelar;
    }
}