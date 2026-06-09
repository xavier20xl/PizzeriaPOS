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

        // === Paleta Albatros (horneada en este Designer) ===
        private static readonly Color C_Brand = Color.FromArgb(200, 65, 43);
        private static readonly Color C_BrandHov = Color.FromArgb(174, 54, 34);
        private static readonly Color C_Amber = Color.FromArgb(184, 119, 10);
        private static readonly Color C_AmberHov = Color.FromArgb(154, 98, 7);
        private static readonly Color C_Success = Color.FromArgb(65, 124, 56);
        private static readonly Color C_SuccessHov = Color.FromArgb(53, 104, 48);
        private static readonly Color C_Danger = Color.FromArgb(217, 45, 32);
        private static readonly Color C_DangerHov = Color.FromArgb(180, 35, 24);
        private static readonly Color C_Ink = Color.FromArgb(28, 25, 23);
        private static readonly Color C_Body = Color.FromArgb(51, 47, 42);
        private static readonly Color C_Secondary = Color.FromArgb(107, 99, 86);
        private static readonly Color C_Muted = Color.FromArgb(140, 130, 115);
        private static readonly Color C_Border = Color.FromArgb(210, 202, 187);
        private static readonly Color C_BorderSub = Color.FromArgb(227, 221, 210);
        private static readonly Color C_Sunken = Color.FromArgb(251, 250, 247);
        private static readonly Color C_Soft = Color.FromArgb(252, 237, 233);

        // Estiliza un botón sólido por color (helper local, sin dependencias externas)
        private static void Solido(Button b, Color bg, Color hov, Color fg)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = hov;
            b.BackColor = bg; b.ForeColor = fg;
            b.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.UseVisualStyleBackColor = false;
        }
        private static void Contorno(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = C_Border;
            b.FlatAppearance.MouseOverBackColor = C_Sunken;
            b.BackColor = Color.White; b.ForeColor = C_Ink;
            b.Cursor = Cursors.Hand;
            b.UseVisualStyleBackColor = false;
        }
        private static void EstiloInput(TextBox t)
        {
            t.BorderStyle = BorderStyle.FixedSingle;
            t.BackColor = Color.White; t.ForeColor = C_Body;
            t.Font = new Font("Segoe UI", 10.5F);
        }
        private static void EstiloEtiqueta(Label l)
        {
            l.ForeColor = C_Secondary;
            l.Font = new Font("Segoe UI", 9.5F);
            l.TextAlign = ContentAlignment.MiddleLeft;
        }
        private static void EstiloGrid(DataGridView g)
        {
            g.BackgroundColor = Color.White;
            g.BorderStyle = BorderStyle.None;
            g.EnableHeadersVisualStyles = false;
            g.GridColor = C_BorderSub;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            g.RowHeadersVisible = false;
            g.AllowUserToResizeRows = false;
            g.ColumnHeadersHeight = 38;
            g.RowTemplate.Height = 34;
            g.ColumnHeadersDefaultCellStyle.BackColor = C_Sunken;
            g.ColumnHeadersDefaultCellStyle.ForeColor = C_Muted;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            g.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            g.DefaultCellStyle.BackColor = Color.White;
            g.DefaultCellStyle.ForeColor = C_Body;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            g.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            g.DefaultCellStyle.SelectionBackColor = C_Soft;
            g.DefaultCellStyle.SelectionForeColor = C_Ink;
            g.AlternatingRowsDefaultCellStyle.BackColor = C_Sunken;
            g.AlternatingRowsDefaultCellStyle.SelectionBackColor = C_Soft;
            g.AlternatingRowsDefaultCellStyle.SelectionForeColor = C_Ink;
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
            groupCliente.BackColor = Color.White;
            groupCliente.ForeColor = C_Ink;
            groupCliente.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            groupCliente.Location = new Point(10, 10);
            groupCliente.Name = "groupCliente";
            groupCliente.Size = new Size(472, 160);
            groupCliente.TabIndex = 0;
            groupCliente.TabStop = false;
            groupCliente.Text = "Cliente";
            // 
            // lblNombre
            // 
            EstiloEtiqueta(lblNombre);
            lblNombre.Location = new Point(12, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(77, 25);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            EstiloInput(txtNombre);
            txtNombre.Location = new Point(85, 28);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(381, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblTelefono
            // 
            EstiloEtiqueta(lblTelefono);
            lblTelefono.Location = new Point(12, 65);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(77, 25);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            EstiloInput(txtTelefono);
            txtTelefono.Location = new Point(85, 63);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(150, 27);
            txtTelefono.TabIndex = 3;
            // 
            // lblEmail
            // 
            EstiloEtiqueta(lblEmail);
            lblEmail.Location = new Point(250, 65);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(45, 25);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            EstiloInput(txtEmail);
            txtEmail.Location = new Point(295, 63);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(171, 27);
            txtEmail.TabIndex = 5;
            // 
            // btnAgregarCliente
            // 
            Solido(btnAgregarCliente, C_Brand, C_BrandHov, Color.White);
            btnAgregarCliente.Location = new Point(15, 110);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(100, 32);
            btnAgregarCliente.TabIndex = 6;
            btnAgregarCliente.Text = "Agregar";
            btnAgregarCliente.Click += btnAgregarCliente_Click;
            // 
            // btnActualizarCliente
            // 
            Solido(btnActualizarCliente, C_Amber, C_AmberHov, Color.White);
            btnActualizarCliente.Location = new Point(125, 110);
            btnActualizarCliente.Name = "btnActualizarCliente";
            btnActualizarCliente.Size = new Size(100, 32);
            btnActualizarCliente.TabIndex = 7;
            btnActualizarCliente.Text = "Actualizar";
            btnActualizarCliente.Click += btnActualizarCliente_Click;
            // 
            // btnEliminarCliente  (ícono basura)
            // 
            Solido(btnEliminarCliente, C_Danger, C_DangerHov, Color.White);
            btnEliminarCliente.Font = new Font("Segoe UI Emoji", 11F);
            btnEliminarCliente.Location = new Point(235, 110);
            btnEliminarCliente.Name = "btnEliminarCliente";
            btnEliminarCliente.Size = new Size(44, 32);
            btnEliminarCliente.TabIndex = 8;
            btnEliminarCliente.Text = "🗑";
            btnEliminarCliente.Click += btnEliminarCliente_Click;
            // 
            // btnLimpiarCliente  (ícono escoba)
            // 
            Contorno(btnLimpiarCliente);
            btnLimpiarCliente.Font = new Font("Segoe UI Emoji", 11F);
            btnLimpiarCliente.Location = new Point(287, 110);
            btnLimpiarCliente.Name = "btnLimpiarCliente";
            btnLimpiarCliente.Size = new Size(44, 32);
            btnLimpiarCliente.TabIndex = 9;
            btnLimpiarCliente.Text = "🧹";
            btnLimpiarCliente.Click += btnLimpiarCliente_Click;
            // 
            // dgvClientes
            // 
            EstiloGrid(dgvClientes);
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.Location = new Point(10, 182);
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
            groupDireccion.BackColor = Color.White;
            groupDireccion.ForeColor = C_Ink;
            groupDireccion.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            groupDireccion.Location = new Point(503, 10);
            groupDireccion.Name = "groupDireccion";
            groupDireccion.Size = new Size(450, 232);
            groupDireccion.TabIndex = 2;
            groupDireccion.TabStop = false;
            groupDireccion.Text = "Dirección";
            // 
            // txtCodigoPostal
            // 
            EstiloInput(txtCodigoPostal);
            txtCodigoPostal.Location = new Point(326, 98);
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(80, 27);
            txtCodigoPostal.TabIndex = 9;
            // 
            // txtCalle
            // 
            EstiloInput(txtCalle);
            txtCalle.Location = new Point(67, 28);
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(370, 27);
            txtCalle.TabIndex = 1;
            // 
            // txtNumero
            // 
            EstiloInput(txtNumero);
            txtNumero.Location = new Point(67, 63);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(80, 27);
            txtNumero.TabIndex = 3;
            // 
            // txtCiudad
            // 
            EstiloInput(txtCiudad);
            txtCiudad.Location = new Point(72, 98);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(150, 27);
            txtCiudad.TabIndex = 7;
            // 
            // txtReferencia
            // 
            EstiloInput(txtReferencia);
            txtReferencia.Location = new Point(62, 133);
            txtReferencia.Name = "txtReferencia";
            txtReferencia.Size = new Size(375, 27);
            txtReferencia.TabIndex = 11;
            // 
            // lblCalle
            // 
            EstiloEtiqueta(lblCalle);
            lblCalle.Location = new Point(15, 30);
            lblCalle.Name = "lblCalle";
            lblCalle.Size = new Size(57, 25);
            lblCalle.TabIndex = 0;
            lblCalle.Text = "Calle:";
            // 
            // lblNumero
            // 
            EstiloEtiqueta(lblNumero);
            lblNumero.Location = new Point(15, 65);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(45, 25);
            lblNumero.TabIndex = 2;
            lblNumero.Text = "Núm:";
            // 
            // lblColonia
            // 
            EstiloEtiqueta(lblColonia);
            lblColonia.Location = new Point(154, 65);
            lblColonia.Name = "lblColonia";
            lblColonia.Size = new Size(68, 25);
            lblColonia.TabIndex = 4;
            lblColonia.Text = "Colonia:";
            // 
            // txtColonia
            // 
            EstiloInput(txtColonia);
            txtColonia.Location = new Point(217, 63);
            txtColonia.Name = "txtColonia";
            txtColonia.Size = new Size(220, 27);
            txtColonia.TabIndex = 5;
            // 
            // lblCiudad
            // 
            EstiloEtiqueta(lblCiudad);
            lblCiudad.Location = new Point(15, 100);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(65, 25);
            lblCiudad.TabIndex = 6;
            lblCiudad.Text = "Ciudad:";
            // 
            // lblCP
            // 
            EstiloEtiqueta(lblCP);
            lblCP.BackColor = Color.Transparent;
            lblCP.Location = new Point(240, 101);
            lblCP.Name = "lblCP";
            lblCP.Size = new Size(86, 25);
            lblCP.TabIndex = 8;
            lblCP.Text = "Cod. Postal:";
            // 
            // lblReferencia
            // 
            EstiloEtiqueta(lblReferencia);
            lblReferencia.Location = new Point(15, 135);
            lblReferencia.Name = "lblReferencia";
            lblReferencia.Size = new Size(45, 25);
            lblReferencia.TabIndex = 10;
            lblReferencia.Text = "Ref:";
            // 
            // chkEsPrincipal
            // 
            chkEsPrincipal.ForeColor = C_Body;
            chkEsPrincipal.Font = new Font("Segoe UI", 9.5F);
            chkEsPrincipal.Location = new Point(15, 168);
            chkEsPrincipal.Name = "chkEsPrincipal";
            chkEsPrincipal.Size = new Size(150, 25);
            chkEsPrincipal.TabIndex = 12;
            chkEsPrincipal.Text = "Principal";
            // 
            // btnAgregarDireccion
            // 
            Solido(btnAgregarDireccion, C_Success, C_SuccessHov, Color.White);
            btnAgregarDireccion.Location = new Point(15, 195);
            btnAgregarDireccion.Name = "btnAgregarDireccion";
            btnAgregarDireccion.Size = new Size(100, 32);
            btnAgregarDireccion.TabIndex = 13;
            btnAgregarDireccion.Text = "Agregar";
            btnAgregarDireccion.Click += btnAgregarDireccion_Click;
            // 
            // btnActualizarDireccion
            // 
            Solido(btnActualizarDireccion, C_Amber, C_AmberHov, Color.White);
            btnActualizarDireccion.Location = new Point(125, 195);
            btnActualizarDireccion.Name = "btnActualizarDireccion";
            btnActualizarDireccion.Size = new Size(100, 32);
            btnActualizarDireccion.TabIndex = 14;
            btnActualizarDireccion.Text = "Actualizar";
            btnActualizarDireccion.Click += btnActualizarDireccion_Click;
            // 
            // btnEliminarDireccion  (ícono basura)
            // 
            Solido(btnEliminarDireccion, C_Danger, C_DangerHov, Color.White);
            btnEliminarDireccion.Font = new Font("Segoe UI Emoji", 11F);
            btnEliminarDireccion.Location = new Point(235, 195);
            btnEliminarDireccion.Name = "btnEliminarDireccion";
            btnEliminarDireccion.Size = new Size(44, 32);
            btnEliminarDireccion.TabIndex = 15;
            btnEliminarDireccion.Text = "🗑";
            btnEliminarDireccion.Click += btnEliminarDireccion_Click;
            // 
            // btnLimpiarDireccion  (ícono escoba)
            // 
            Contorno(btnLimpiarDireccion);
            btnLimpiarDireccion.Font = new Font("Segoe UI Emoji", 11F);
            btnLimpiarDireccion.Location = new Point(287, 195);
            btnLimpiarDireccion.Name = "btnLimpiarDireccion";
            btnLimpiarDireccion.Size = new Size(44, 32);
            btnLimpiarDireccion.TabIndex = 16;
            btnLimpiarDireccion.Text = "🧹";
            btnLimpiarDireccion.Click += btnLimpiarDireccion_Click;
            // 
            // dgvDirecciones
            // 
            EstiloGrid(dgvDirecciones);
            dgvDirecciones.AllowUserToAddRows = false;
            dgvDirecciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDirecciones.Location = new Point(503, 248);
            dgvDirecciones.MultiSelect = false;
            dgvDirecciones.Name = "dgvDirecciones";
            dgvDirecciones.ReadOnly = true;
            dgvDirecciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDirecciones.Size = new Size(450, 234);
            dgvDirecciones.TabIndex = 3;
            dgvDirecciones.SelectionChanged += dgvDirecciones_SelectionChanged;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = C_Muted;
            lblStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
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
