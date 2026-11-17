namespace AgendaMedica.UI
{
    partial class FrmReportes
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
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblReporte = new System.Windows.Forms.Label();
            this.cmbReporte = new System.Windows.Forms.ComboBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblMedico = new System.Windows.Forms.Label();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.lblResumen = new System.Windows.Forms.Label();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(100, 22);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "REPORTES";

            this.grpFiltros.Controls.Add(this.lblReporte);
            this.grpFiltros.Controls.Add(this.cmbReporte);
            this.grpFiltros.Controls.Add(this.lblDesde);
            this.grpFiltros.Controls.Add(this.dtpDesde);
            this.grpFiltros.Controls.Add(this.lblHasta);
            this.grpFiltros.Controls.Add(this.dtpHasta);
            this.grpFiltros.Controls.Add(this.lblMedico);
            this.grpFiltros.Controls.Add(this.cmbMedico);
            this.grpFiltros.Controls.Add(this.btnGenerar);
            this.grpFiltros.Location = new System.Drawing.Point(20, 50);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1060, 95);
            this.grpFiltros.TabIndex = 1;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros del reporte";

            this.lblReporte.AutoSize = true;
            this.lblReporte.Location = new System.Drawing.Point(15, 25);
            this.lblReporte.Name = "lblReporte";
            this.lblReporte.Size = new System.Drawing.Size(66, 20);
            this.lblReporte.TabIndex = 0;
            this.lblReporte.Text = "Reporte:";
 
            this.cmbReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReporte.FormattingEnabled = true;
            this.cmbReporte.Items.AddRange(new object[] {"Citas por día y médico", "Citas canceladas", "Pacientes atendidos"});
            this.cmbReporte.Location = new System.Drawing.Point(15, 49);
            this.cmbReporte.Name = "cmbReporte";
            this.cmbReporte.Size = new System.Drawing.Size(280, 28);
            this.cmbReporte.TabIndex = 1;

            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(315, 25);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(55, 20);
            this.lblDesde.TabIndex = 2;
            this.lblDesde.Text = "Desde:";
 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(315, 50);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(130, 27);
            this.dtpDesde.TabIndex = 3;
 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(465, 25);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(51, 20);
            this.lblHasta.TabIndex = 4;
            this.lblHasta.Text = "Hasta:";
 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(465, 50);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(130, 27);
            this.dtpHasta.TabIndex = 5;
 
            this.lblMedico.AutoSize = true;
            this.lblMedico.Location = new System.Drawing.Point(615, 25);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(60, 20);
            this.lblMedico.TabIndex = 6;
            this.lblMedico.Text = "Médico:";
 
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(615, 49);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(280, 28);
            this.cmbMedico.TabIndex = 7;
 
            this.btnGenerar.Location = new System.Drawing.Point(915, 43);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(130, 38);
            this.btnGenerar.TabIndex = 8;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(20, 160);
            this.dgvReporte.MultiSelect = false;
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.RowHeadersVisible = false;
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporte.Size = new System.Drawing.Size(1060, 395);
            this.dgvReporte.TabIndex = 2;
 
            this.lblResumen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResumen.Location = new System.Drawing.Point(20, 570);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(1060, 30);
            this.lblResumen.TabIndex = 3;
 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 615);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agenda Médica - Reportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblReporte;
        private System.Windows.Forms.ComboBox cmbReporte;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Label lblResumen;
    }
}