namespace PizzeriaPOS.WinForms.Forms
{
    partial class ClientesControl
    {
        private System.ComponentModel.IContainer components = null;
        private GroupBox groupCliente, groupDireccion;
        private Label lblNombre, lblTelefono, lblEmail;
        private Label lblCalle, lblNumero, lblColonia, lblCiudad, lblCP, lblReferencia;
        public TextBox txtNombre, txtTelefono, txtEmail;
        public TextBox txtCalle, txtNumero, txtColonia, txtCiudad, txtCodigoPostal, txtReferencia;
        public CheckBox chkEsPrincipal;
        private Button btnAgregarCliente, btnActualizarCliente, btnEliminarCliente, btnLimpiarCliente;
        private Button btnAgregarDireccion, btnActualizarDireccion, btnEliminarDireccion, btnLimpiarDireccion;
        public DataGridView dgvClientes, dgvDirecciones;
        public Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            groupCliente = new GroupBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnAgregarCliente = new Button();
            btnActualizarCliente = new Button();
            btnEliminarCliente = new Button();
            btnLimpiarCliente = new Button();
            dgvClientes = new DataGridView();
            groupDireccion = new GroupBox();
            txtCodigoPostal = new TextBox();
            txtCalle = new TextBox();
            txtNumero = new TextBox();
            txtCiudad = new TextBox();
            txtReferencia = new TextBox();
            lblCalle = new Label();
            lblNumero = new Label();
            lblColonia = new Label();
            txtColonia = new TextBox();
            lblCiudad = new Label();
            lblCP = new Label();
            lblReferencia = new Label();
            chkEsPrincipal = new CheckBox();
            btnAgregarDireccion = new Button();
            btnActualizarDireccion = new Button();
            btnEliminarDireccion = new Button();
            btnLimpiarDireccion = new Button();
            dgvDirecciones = new DataGridView();
            lblStatus = new Label();
            groupCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            groupDireccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDirecciones).BeginInit();
            SuspendLayout();
            // 
            // groupCliente
            // 
            groupCliente.Controls.Add(txtNombre);
            groupCliente.Controls.Add(txtTelefono);
            groupCliente.Controls.Add(lblNombre);
            groupCliente.Controls.Add(lblTelefono);
            groupCliente.Controls.Add(lblEmail);
            groupCliente.Controls.Add(txtEmail);
            groupCliente.Controls.Add(btnAgregarCliente);
            groupCliente.Controls.Add(btnActualizarCliente);
            groupCliente.Controls.Add(btnEliminarCliente);
            groupCliente.Controls.Add(btnLimpiarCliente);
            groupCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupCliente.Location = new Point(10, 10);
            groupCliente.Name = "groupCliente";
            groupCliente.Size = new Size(472, 160);
            groupCliente.TabIndex = 0;
            groupCliente.TabStop = false;
            groupCliente.Text = "Cliente";
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(12, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(77, 25);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(85, 30);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(381, 25);
            txtNombre.TabIndex = 1;
            // 
            // lblTelefono
            // 
            lblTelefono.Location = new Point(12, 65);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(77, 25);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(85, 65);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(150, 25);
            txtTelefono.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(250, 65);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(45, 25);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(295, 65);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(171, 25);
            txtEmail.TabIndex = 5;
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.BackColor = Color.FromArgb(0, 123, 255);
            btnAgregarCliente.FlatAppearance.BorderSize = 0;
            btnAgregarCliente.FlatStyle = FlatStyle.Flat;
            btnAgregarCliente.ForeColor = Color.White;
            btnAgregarCliente.Location = new Point(15, 110);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(100, 30);
            btnAgregarCliente.TabIndex = 6;
            btnAgregarCliente.Text = "Agregar";
            btnAgregarCliente.UseVisualStyleBackColor = false;
            btnAgregarCliente.Click += btnAgregarCliente_Click;
            // 
            // btnActualizarCliente
            // 
            btnActualizarCliente.BackColor = Color.FromArgb(255, 193, 7);
            btnActualizarCliente.FlatAppearance.BorderSize = 0;
            btnActualizarCliente.FlatStyle = FlatStyle.Flat;
            btnActualizarCliente.Location = new Point(125, 110);
            btnActualizarCliente.Name = "btnActualizarCliente";
            btnActualizarCliente.Size = new Size(100, 30);
            btnActualizarCliente.TabIndex = 7;
            btnActualizarCliente.Text = "Actualizar";
            btnActualizarCliente.UseVisualStyleBackColor = false;
            btnActualizarCliente.Click += btnActualizarCliente_Click;
            // 
            // btnEliminarCliente
            // 
            btnEliminarCliente.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminarCliente.FlatAppearance.BorderSize = 0;
            btnEliminarCliente.FlatStyle = FlatStyle.Flat;
            btnEliminarCliente.ForeColor = Color.White;
            btnEliminarCliente.Location = new Point(235, 110);
            btnEliminarCliente.Name = "btnEliminarCliente";
            btnEliminarCliente.Size = new Size(100, 30);
            btnEliminarCliente.TabIndex = 8;
            btnEliminarCliente.Text = "Eliminar";
            btnEliminarCliente.UseVisualStyleBackColor = false;
            btnEliminarCliente.Click += btnEliminarCliente_Click;
            // 
            // btnLimpiarCliente
            // 
            btnLimpiarCliente.FlatStyle = FlatStyle.Flat;
            btnLimpiarCliente.Location = new Point(345, 110);
            btnLimpiarCliente.Name = "btnLimpiarCliente";
            btnLimpiarCliente.Size = new Size(98, 30);
            btnLimpiarCliente.TabIndex = 9;
            btnLimpiarCliente.Text = "Limpiar";
            btnLimpiarCliente.Click += btnLimpiarCliente_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.Location = new Point(10, 188);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(472, 300);
            dgvClientes.TabIndex = 1;
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
            // 
            // groupDireccion
            // 
            groupDireccion.Controls.Add(txtColonia);
            groupDireccion.Controls.Add(txtCodigoPostal);
            groupDireccion.Controls.Add(txtCalle);
            groupDireccion.Controls.Add(txtNumero);
            groupDireccion.Controls.Add(txtCiudad);
            groupDireccion.Controls.Add(txtReferencia);
            groupDireccion.Controls.Add(lblCalle);
            groupDireccion.Controls.Add(lblNumero);
            groupDireccion.Controls.Add(lblColonia);
            groupDireccion.Controls.Add(lblCiudad);
            groupDireccion.Controls.Add(lblCP);
            groupDireccion.Controls.Add(lblReferencia);
            groupDireccion.Controls.Add(chkEsPrincipal);
            groupDireccion.Controls.Add(btnAgregarDireccion);
            groupDireccion.Controls.Add(btnActualizarDireccion);
            groupDireccion.Controls.Add(btnEliminarDireccion);
            groupDireccion.Controls.Add(btnLimpiarDireccion);
            groupDireccion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupDireccion.Location = new Point(503, 10);
            groupDireccion.Name = "groupDireccion";
            groupDireccion.Size = new Size(450, 232);
            groupDireccion.TabIndex = 2;
            groupDireccion.TabStop = false;
            groupDireccion.Text = "Dirección";
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.Location = new Point(326, 100);
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(80, 25);
            txtCodigoPostal.TabIndex = 9;
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(67, 30);
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(370, 25);
            txtCalle.TabIndex = 1;
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(67, 65);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(80, 25);
            txtNumero.TabIndex = 3;
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(72, 100);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(150, 25);
            txtCiudad.TabIndex = 7;
            // 
            // txtReferencia
            // 
            txtReferencia.Location = new Point(62, 135);
            txtReferencia.Name = "txtReferencia";
            txtReferencia.Size = new Size(375, 25);
            txtReferencia.TabIndex = 11;
            // 
            // lblCalle
            // 
            lblCalle.Location = new Point(15, 30);
            lblCalle.Name = "lblCalle";
            lblCalle.Size = new Size(57, 25);
            lblCalle.TabIndex = 0;
            lblCalle.Text = "Calle:";
            // 
            // lblNumero
            // 
            lblNumero.Location = new Point(15, 65);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(45, 25);
            lblNumero.TabIndex = 2;
            lblNumero.Text = "Núm:";
            // 
            // lblColonia
            // 
            lblColonia.Location = new Point(154, 65);
            lblColonia.Name = "lblColonia";
            lblColonia.Size = new Size(68, 25);
            lblColonia.TabIndex = 4;
            lblColonia.Text = "Colonia:";
            // 
            // txtColonia
            // 
            txtColonia.Location = new Point(217, 65);
            txtColonia.Name = "txtColonia";
            txtColonia.Size = new Size(220, 25);
            txtColonia.TabIndex = 5;
            // 
            // lblCiudad
            // 
            lblCiudad.Location = new Point(15, 100);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(65, 25);
            lblCiudad.TabIndex = 6;
            lblCiudad.Text = "Ciudad:";
            // 
            // lblCP
            // 
            lblCP.BackColor = Color.Transparent;
            lblCP.Location = new Point(240, 101);
            lblCP.Name = "lblCP";
            lblCP.Size = new Size(98, 25);
            lblCP.TabIndex = 8;
            lblCP.Text = "Cog. Postal:";
            // 
            // lblReferencia
            // 
            lblReferencia.Location = new Point(15, 135);
            lblReferencia.Name = "lblReferencia";
            lblReferencia.Size = new Size(45, 25);
            lblReferencia.TabIndex = 10;
            lblReferencia.Text = "Ref:";
            // 
            // chkEsPrincipal
            // 
            chkEsPrincipal.Location = new Point(15, 170);
            chkEsPrincipal.Name = "chkEsPrincipal";
            chkEsPrincipal.Size = new Size(150, 25);
            chkEsPrincipal.TabIndex = 12;
            chkEsPrincipal.Text = "Principal";
            // 
            // btnAgregarDireccion
            // 
            btnAgregarDireccion.BackColor = Color.FromArgb(40, 167, 69);
            btnAgregarDireccion.FlatAppearance.BorderSize = 0;
            btnAgregarDireccion.FlatStyle = FlatStyle.Flat;
            btnAgregarDireccion.ForeColor = Color.White;
            btnAgregarDireccion.Location = new Point(15, 195);
            btnAgregarDireccion.Name = "btnAgregarDireccion";
            btnAgregarDireccion.Size = new Size(100, 31);
            btnAgregarDireccion.TabIndex = 13;
            btnAgregarDireccion.Text = "Agregar";
            btnAgregarDireccion.UseVisualStyleBackColor = false;
            btnAgregarDireccion.Click += btnAgregarDireccion_Click;
            // 
            // btnActualizarDireccion
            // 
            btnActualizarDireccion.BackColor = Color.FromArgb(255, 193, 7);
            btnActualizarDireccion.FlatAppearance.BorderSize = 0;
            btnActualizarDireccion.FlatStyle = FlatStyle.Flat;
            btnActualizarDireccion.Location = new Point(125, 195);
            btnActualizarDireccion.Name = "btnActualizarDireccion";
            btnActualizarDireccion.Size = new Size(100, 31);
            btnActualizarDireccion.TabIndex = 14;
            btnActualizarDireccion.Text = "Actualizar";
            btnActualizarDireccion.UseVisualStyleBackColor = false;
            btnActualizarDireccion.Click += btnActualizarDireccion_Click;
            // 
            // btnEliminarDireccion
            // 
            btnEliminarDireccion.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminarDireccion.FlatAppearance.BorderSize = 0;
            btnEliminarDireccion.FlatStyle = FlatStyle.Flat;
            btnEliminarDireccion.ForeColor = Color.White;
            btnEliminarDireccion.Location = new Point(235, 195);
            btnEliminarDireccion.Name = "btnEliminarDireccion";
            btnEliminarDireccion.Size = new Size(100, 31);
            btnEliminarDireccion.TabIndex = 15;
            btnEliminarDireccion.Text = "Eliminar";
            btnEliminarDireccion.UseVisualStyleBackColor = false;
            btnEliminarDireccion.Click += btnEliminarDireccion_Click;
            // 
            // btnLimpiarDireccion
            // 
            btnLimpiarDireccion.FlatStyle = FlatStyle.Flat;
            btnLimpiarDireccion.Location = new Point(345, 195);
            btnLimpiarDireccion.Name = "btnLimpiarDireccion";
            btnLimpiarDireccion.Size = new Size(90, 31);
            btnLimpiarDireccion.TabIndex = 16;
            btnLimpiarDireccion.Text = "Limpiar";
            btnLimpiarDireccion.Click += btnLimpiarDireccion_Click;
            // 
            // dgvDirecciones
            // 
            dgvDirecciones.AllowUserToAddRows = false;
            dgvDirecciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDirecciones.Location = new Point(503, 248);
            dgvDirecciones.MultiSelect = false;
            dgvDirecciones.Name = "dgvDirecciones";
            dgvDirecciones.ReadOnly = true;
            dgvDirecciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDirecciones.Size = new Size(450, 240);
            dgvDirecciones.TabIndex = 3;
            dgvDirecciones.SelectionChanged += dgvDirecciones_SelectionChanged;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Location = new Point(10, 490);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(920, 25);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Listo";
            // 
            // ClientesControl
            // 
            BackColor = Color.White;
            Controls.Add(groupCliente);
            Controls.Add(dgvClientes);
            Controls.Add(groupDireccion);
            Controls.Add(dgvDirecciones);
            Controls.Add(lblStatus);
            Name = "ClientesControl";
            Size = new Size(986, 530);
            Load += ClientesControl_Load;
            groupCliente.ResumeLayout(false);
            groupCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            groupDireccion.ResumeLayout(false);
            groupDireccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDirecciones).EndInit();
            ResumeLayout(false);
        }
    }
}
