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
            this.groupCliente = new GroupBox();
            this.lblNombre = new Label(); this.txtNombre = new TextBox();
            this.lblTelefono = new Label(); this.txtTelefono = new TextBox();
            this.lblEmail = new Label(); this.txtEmail = new TextBox();
            this.btnAgregarCliente = new Button(); this.btnActualizarCliente = new Button();
            this.btnEliminarCliente = new Button(); this.btnLimpiarCliente = new Button();
            this.dgvClientes = new DataGridView();
            this.groupDireccion = new GroupBox();
            this.lblCalle = new Label(); this.txtCalle = new TextBox();
            this.lblNumero = new Label(); this.txtNumero = new TextBox();
            this.lblColonia = new Label(); this.txtColonia = new TextBox();
            this.lblCiudad = new Label(); this.txtCiudad = new TextBox();
            this.lblCP = new Label(); this.txtCodigoPostal = new TextBox();
            this.lblReferencia = new Label(); this.txtReferencia = new TextBox();
            this.chkEsPrincipal = new CheckBox();
            this.btnAgregarDireccion = new Button(); this.btnActualizarDireccion = new Button();
            this.btnEliminarDireccion = new Button(); this.btnLimpiarDireccion = new Button();
            this.dgvDirecciones = new DataGridView();
            this.lblStatus = new Label();

            this.groupCliente.SuspendLayout();
            this.groupDireccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirecciones)).BeginInit();
            this.SuspendLayout();

            // groupCliente
            this.groupCliente.Controls.AddRange(new Control[] { lblNombre, txtNombre, lblTelefono, txtTelefono, lblEmail, txtEmail, btnAgregarCliente, btnActualizarCliente, btnEliminarCliente, btnLimpiarCliente });
            this.groupCliente.Location = new Point(10, 10); this.groupCliente.Size = new Size(450, 160);
            this.groupCliente.Text = "Cliente"; this.groupCliente.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            lblNombre.Location = new Point(15, 30); lblNombre.Size = new Size(65, 25); lblNombre.Text = "Nombre:";
            txtNombre.Location = new Point(85, 30); txtNombre.Size = new Size(345, 25);
            lblTelefono.Location = new Point(15, 65); lblTelefono.Size = new Size(65, 25); lblTelefono.Text = "Teléfono:";
            txtTelefono.Location = new Point(85, 65); txtTelefono.Size = new Size(150, 25);
            lblEmail.Location = new Point(250, 65); lblEmail.Size = new Size(45, 25); lblEmail.Text = "Email:";
            txtEmail.Location = new Point(295, 65); txtEmail.Size = new Size(135, 25);

            btnAgregarCliente.Location = new Point(15, 110); btnAgregarCliente.Size = new Size(100, 30);
            btnAgregarCliente.Text = "Agregar"; btnAgregarCliente.BackColor = Color.FromArgb(0, 123, 255); btnAgregarCliente.ForeColor = Color.White;
            btnAgregarCliente.FlatStyle = FlatStyle.Flat; btnAgregarCliente.FlatAppearance.BorderSize = 0;
            btnAgregarCliente.Click += btnAgregarCliente_Click;

            btnActualizarCliente.Location = new Point(125, 110); btnActualizarCliente.Size = new Size(100, 30);
            btnActualizarCliente.Text = "Actualizar"; btnActualizarCliente.BackColor = Color.FromArgb(255, 193, 7);
            btnActualizarCliente.FlatStyle = FlatStyle.Flat; btnActualizarCliente.FlatAppearance.BorderSize = 0;
            btnActualizarCliente.Click += btnActualizarCliente_Click;

            btnEliminarCliente.Location = new Point(235, 110); btnEliminarCliente.Size = new Size(100, 30);
            btnEliminarCliente.Text = "Eliminar"; btnEliminarCliente.BackColor = Color.FromArgb(220, 53, 69); btnEliminarCliente.ForeColor = Color.White;
            btnEliminarCliente.FlatStyle = FlatStyle.Flat; btnEliminarCliente.FlatAppearance.BorderSize = 0;
            btnEliminarCliente.Click += btnEliminarCliente_Click;

            btnLimpiarCliente.Location = new Point(345, 110); btnLimpiarCliente.Size = new Size(90, 30);
            btnLimpiarCliente.Text = "Limpiar"; btnLimpiarCliente.FlatStyle = FlatStyle.Flat;
            btnLimpiarCliente.Click += btnLimpiarCliente_Click;

            // dgvClientes
            dgvClientes.Location = new Point(10, 180); dgvClientes.Size = new Size(450, 300);
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgvClientes.MultiSelect = false;
            dgvClientes.ReadOnly = true; dgvClientes.AllowUserToAddRows = false;
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;

            // groupDireccion
            this.groupDireccion.Controls.AddRange(new Control[] { lblCalle, txtCalle, lblNumero, txtNumero, lblColonia, txtColonia, lblCiudad, txtCiudad, lblCP, txtCodigoPostal, lblReferencia, txtReferencia, chkEsPrincipal, btnAgregarDireccion, btnActualizarDireccion, btnEliminarDireccion, btnLimpiarDireccion });
            this.groupDireccion.Location = new Point(480, 10); this.groupDireccion.Size = new Size(450, 220);
            this.groupDireccion.Text = "Dirección"; this.groupDireccion.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            lblCalle.Location = new Point(15, 30); lblCalle.Size = new Size(45, 25); lblCalle.Text = "Calle:";
            txtCalle.Location = new Point(60, 30); txtCalle.Size = new Size(370, 25);
            lblNumero.Location = new Point(15, 65); lblNumero.Size = new Size(45, 25); lblNumero.Text = "Núm:";
            txtNumero.Location = new Point(60, 65); txtNumero.Size = new Size(80, 25);
            lblColonia.Location = new Point(155, 65); lblColonia.Size = new Size(55, 25); lblColonia.Text = "Colonia:";
            txtColonia.Location = new Point(210, 65); txtColonia.Size = new Size(220, 25);
            lblCiudad.Location = new Point(15, 100); lblCiudad.Size = new Size(50, 25); lblCiudad.Text = "Ciudad:";
            txtCiudad.Location = new Point(65, 100); txtCiudad.Size = new Size(150, 25);
            lblCP.Location = new Point(230, 100); lblCP.Size = new Size(35, 25); lblCP.Text = "C.P.:";
            txtCodigoPostal.Location = new Point(265, 100); txtCodigoPostal.Size = new Size(80, 25);
            lblReferencia.Location = new Point(15, 135); lblReferencia.Size = new Size(35, 25); lblReferencia.Text = "Ref:";
            txtReferencia.Location = new Point(55, 135); txtReferencia.Size = new Size(375, 25);
            chkEsPrincipal.Location = new Point(15, 170); chkEsPrincipal.Size = new Size(150, 25); chkEsPrincipal.Text = "Principal";

            btnAgregarDireccion.Location = new Point(15, 195); btnAgregarDireccion.Size = new Size(100, 25);
            btnAgregarDireccion.Text = "Agregar"; btnAgregarDireccion.BackColor = Color.FromArgb(40, 167, 69); btnAgregarDireccion.ForeColor = Color.White;
            btnAgregarDireccion.FlatStyle = FlatStyle.Flat; btnAgregarDireccion.FlatAppearance.BorderSize = 0;
            btnAgregarDireccion.Click += btnAgregarDireccion_Click;

            btnActualizarDireccion.Location = new Point(125, 195); btnActualizarDireccion.Size = new Size(100, 25);
            btnActualizarDireccion.Text = "Actualizar"; btnActualizarDireccion.BackColor = Color.FromArgb(255, 193, 7);
            btnActualizarDireccion.FlatStyle = FlatStyle.Flat; btnActualizarDireccion.FlatAppearance.BorderSize = 0;
            btnActualizarDireccion.Click += btnActualizarDireccion_Click;

            btnEliminarDireccion.Location = new Point(235, 195); btnEliminarDireccion.Size = new Size(100, 25);
            btnEliminarDireccion.Text = "Eliminar"; btnEliminarDireccion.BackColor = Color.FromArgb(220, 53, 69); btnEliminarDireccion.ForeColor = Color.White;
            btnEliminarDireccion.FlatStyle = FlatStyle.Flat; btnEliminarDireccion.FlatAppearance.BorderSize = 0;
            btnEliminarDireccion.Click += btnEliminarDireccion_Click;

            btnLimpiarDireccion.Location = new Point(345, 195); btnLimpiarDireccion.Size = new Size(90, 25);
            btnLimpiarDireccion.Text = "Limpiar"; btnLimpiarDireccion.FlatStyle = FlatStyle.Flat;
            btnLimpiarDireccion.Click += btnLimpiarDireccion_Click;

            // dgvDirecciones
            dgvDirecciones.Location = new Point(480, 240); dgvDirecciones.Size = new Size(450, 240);
            dgvDirecciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDirecciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgvDirecciones.MultiSelect = false;
            dgvDirecciones.ReadOnly = true; dgvDirecciones.AllowUserToAddRows = false;
            dgvDirecciones.SelectionChanged += dgvDirecciones_SelectionChanged;

            // lblStatus
            lblStatus.Location = new Point(10, 490); lblStatus.Size = new Size(920, 25); lblStatus.Text = "Listo"; lblStatus.ForeColor = Color.Gray;

            // ClientesControl
            this.Controls.AddRange(new Control[] { groupCliente, dgvClientes, groupDireccion, dgvDirecciones, lblStatus });
            this.Size = new Size(950, 530); this.BackColor = Color.White;
            this.Load += ClientesControl_Load;

            this.groupCliente.ResumeLayout(false); this.groupCliente.PerformLayout();
            this.groupDireccion.ResumeLayout(false); this.groupDireccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirecciones)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
