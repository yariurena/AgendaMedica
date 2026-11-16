namespace AgendaMedica.UI
{
    partial class FrmUsuarios
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblPrimerApellido = new System.Windows.Forms.Label();
            this.txtPrimerApellido = new System.Windows.Forms.TextBox();
            this.lblSegundoApellido = new System.Windows.Forms.Label();
            this.txtSegundoApellido = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblConfirmacion = new System.Windows.Forms.Label();
            this.txtConfirmacion = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 22);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "GESTIÓN DE USUARIOS";

            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 60);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(67, 20);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";

            this.txtNombre.Location = new System.Drawing.Point(20, 84);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(360, 27);
            this.txtNombre.TabIndex = 2;

            this.lblPrimerApellido.AutoSize = true;
            this.lblPrimerApellido.Location = new System.Drawing.Point(20, 120);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.Size = new System.Drawing.Size(117, 20);
            this.lblPrimerApellido.TabIndex = 3;
            this.lblPrimerApellido.Text = "Primer apellido:";

            this.txtPrimerApellido.Location = new System.Drawing.Point(20, 144);
            this.txtPrimerApellido.MaxLength = 100;
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(360, 27);
            this.txtPrimerApellido.TabIndex = 4;

            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Location = new System.Drawing.Point(20, 180);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(132, 20);
            this.lblSegundoApellido.TabIndex = 5;
            this.lblSegundoApellido.Text = "Segundo apellido:";

            this.txtSegundoApellido.Location = new System.Drawing.Point(20, 204);
            this.txtSegundoApellido.MaxLength = 100;
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(360, 27);
            this.txtSegundoApellido.TabIndex = 6;
 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(20, 240);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(143, 20);
            this.lblCorreo.TabIndex = 7;
            this.lblCorreo.Text = "Correo electrónico:";
 
            this.txtCorreo.Location = new System.Drawing.Point(20, 264);
            this.txtCorreo.MaxLength = 150;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(360, 27);
            this.txtCorreo.TabIndex = 8;

            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(20, 300);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(34, 20);
            this.lblRol.TabIndex = 9;
            this.lblRol.Text = "Rol:";

            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(20, 324);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(360, 28);
            this.cmbRol.TabIndex = 10;

            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(20, 360);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(329, 20);
            this.lblContrasena.TabIndex = 11;
            this.lblContrasena.Text = "Contraseña (mínimo 8, con letras y números):";
 
            this.txtContrasena.Location = new System.Drawing.Point(20, 384);
            this.txtContrasena.MaxLength = 100;
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(360, 27);
            this.txtContrasena.TabIndex = 12;
            this.txtContrasena.UseSystemPasswordChar = true;
 
            this.lblConfirmacion.AutoSize = true;
            this.lblConfirmacion.Location = new System.Drawing.Point(20, 420);
            this.lblConfirmacion.Name = "lblConfirmacion";
            this.lblConfirmacion.Size = new System.Drawing.Size(165, 20);
            this.lblConfirmacion.TabIndex = 13;
            this.lblConfirmacion.Text = "Confirmar contraseña:";
 
            this.txtConfirmacion.Location = new System.Drawing.Point(20, 444);
            this.txtConfirmacion.MaxLength = 100;
            this.txtConfirmacion.Name = "txtConfirmacion";
            this.txtConfirmacion.Size = new System.Drawing.Size(360, 27);
            this.txtConfirmacion.TabIndex = 14;
            this.txtConfirmacion.UseSystemPasswordChar = true;
 
            this.btnRegistrar.Location = new System.Drawing.Point(20, 485);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(175, 40);
            this.btnRegistrar.TabIndex = 15;
            this.btnRegistrar.Text = "Registrar usuario";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
 
            this.btnLimpiar.Location = new System.Drawing.Point(205, 485);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(175, 40);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar campos";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(420, 60);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(560, 465);
            this.dgvUsuarios.TabIndex = 17;
 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 545);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtConfirmacion);
            this.Controls.Add(this.lblConfirmacion);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.txtSegundoApellido);
            this.Controls.Add(this.lblSegundoApellido);
            this.Controls.Add(this.txtPrimerApellido);
            this.Controls.Add(this.lblPrimerApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agenda Médica - Gestión de usuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblPrimerApellido;
        private System.Windows.Forms.TextBox txtPrimerApellido;
        private System.Windows.Forms.Label lblSegundoApellido;
        private System.Windows.Forms.TextBox txtSegundoApellido;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblConfirmacion;
        private System.Windows.Forms.TextBox txtConfirmacion;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
    }
}