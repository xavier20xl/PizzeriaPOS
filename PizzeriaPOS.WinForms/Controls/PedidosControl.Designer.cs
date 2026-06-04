namespace PizzeriaPOS.WinForms.Forms
{
    partial class PedidosControl
    {
        private System.ComponentModel.IContainer components = null;
        private GroupBox groupCrear, groupDetalles;
        private Label lblTituloPedidos;
        private Label lblCliente, lblDireccion, lblProducto, lblCantidad, lblNotasPed;
        public ComboBox cmbClientes, cmbDirecciones, cmbProductos;
        public NumericUpDown nudCantidad;
        public TextBox txtNotasPedido;
        private Button btnAgregarDetalle, btnCrearPedido;
        public DataGridView dgvPedidos, dgvDetalles;
        public Label lblStatus, lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTituloPedidos = new Label();
            this.dgvPedidos = new DataGridView();
            this.groupCrear = new GroupBox();
            this.lblCliente = new Label();
            this.cmbClientes = new ComboBox();
            this.lblDireccion = new Label();
            this.cmbDirecciones = new ComboBox();
            this.lblProducto = new Label();
            this.cmbProductos = new ComboBox();
            this.lblCantidad = new Label();
            this.nudCantidad = new NumericUpDown();
            this.btnAgregarDetalle = new Button();
            this.lblNotasPed = new Label();
            this.txtNotasPedido = new TextBox();
            this.btnCrearPedido = new Button();
            this.groupDetalles = new GroupBox();
            this.dgvDetalles = new DataGridView();
            this.lblTotal = new Label();
            this.lblStatus = new Label();

            this.groupCrear.SuspendLayout();
            this.groupDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();

            // lblTituloPedidos
            lblTituloPedidos.Location = new Point(10, 5);
            lblTituloPedidos.Size = new Size(450, 25);
            lblTituloPedidos.Text = "Lista de Pedidos";
            lblTituloPedidos.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // dgvPedidos
            dgvPedidos.Location = new Point(10, 35);
            dgvPedidos.Size = new Size(450, 530);
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.MultiSelect = false;
            dgvPedidos.ReadOnly = true;
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.SelectionChanged += dgvPedidos_SelectionChanged;

            // groupCrear
            this.groupCrear.Controls.AddRange(new Control[] { lblCliente, cmbClientes, lblDireccion, cmbDirecciones, lblProducto, cmbProductos, lblCantidad, nudCantidad, btnAgregarDetalle, lblNotasPed, txtNotasPedido, btnCrearPedido });
            this.groupCrear.Location = new Point(480, 5);
            this.groupCrear.Size = new Size(450, 300);
            this.groupCrear.Text = "Nuevo Pedido";
            this.groupCrear.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            lblCliente.Location = new Point(15, 30);
            lblCliente.Size = new Size(60, 25);
            lblCliente.Text = "Cliente:";

            cmbClientes.Location = new Point(80, 30);
            cmbClientes.Size = new Size(350, 25);
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;

            lblDireccion.Location = new Point(15, 65);
            lblDireccion.Size = new Size(65, 25);
            lblDireccion.Text = "Dirección:";

            cmbDirecciones.Location = new Point(80, 65);
            cmbDirecciones.Size = new Size(350, 25);
            cmbDirecciones.DropDownStyle = ComboBoxStyle.DropDownList;

            lblProducto.Location = new Point(15, 100);
            lblProducto.Size = new Size(65, 25);
            lblProducto.Text = "Producto:";

            cmbProductos.Location = new Point(80, 100);
            cmbProductos.Size = new Size(200, 25);
            cmbProductos.DropDownStyle = ComboBoxStyle.DropDownList;

            lblCantidad.Location = new Point(290, 100);
            lblCantidad.Size = new Size(40, 25);
            lblCantidad.Text = "Cant:";

            nudCantidad.Location = new Point(330, 100);
            nudCantidad.Size = new Size(60, 25);
            nudCantidad.Minimum = 1;
            nudCantidad.Maximum = 100;
            nudCantidad.Value = 1;

            btnAgregarDetalle.Location = new Point(15, 140);
            btnAgregarDetalle.Size = new Size(415, 35);
            btnAgregarDetalle.Text = "Agregar Producto al Pedido";
            btnAgregarDetalle.BackColor = Color.FromArgb(40, 167, 69);
            btnAgregarDetalle.ForeColor = Color.White;
            btnAgregarDetalle.FlatStyle = FlatStyle.Flat;
            btnAgregarDetalle.FlatAppearance.BorderSize = 0;
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;

            lblNotasPed.Location = new Point(15, 190);
            lblNotasPed.Size = new Size(90, 25);
            lblNotasPed.Text = "Notas:";

            txtNotasPedido.Location = new Point(105, 190);
            txtNotasPedido.Size = new Size(325, 25);

            btnCrearPedido.Location = new Point(15, 235);
            btnCrearPedido.Size = new Size(415, 35);
            btnCrearPedido.Text = "Crear Pedido";
            btnCrearPedido.BackColor = Color.FromArgb(0, 123, 255);
            btnCrearPedido.ForeColor = Color.White;
            btnCrearPedido.FlatStyle = FlatStyle.Flat;
            btnCrearPedido.FlatAppearance.BorderSize = 0;
            btnCrearPedido.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnCrearPedido.Click += btnCrearPedido_Click;

            // groupDetalles
            this.groupDetalles.Controls.AddRange(new Control[] { dgvDetalles, lblTotal });
            this.groupDetalles.Location = new Point(480, 315);
            this.groupDetalles.Size = new Size(450, 220);
            this.groupDetalles.Text = "Detalles";
            this.groupDetalles.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvDetalles.Location = new Point(10, 25);
            dgvDetalles.Size = new Size(430, 155);
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.MultiSelect = false;
            dgvDetalles.ReadOnly = true;
            dgvDetalles.AllowUserToAddRows = false;

            lblTotal.Location = new Point(10, 185);
            lblTotal.Size = new Size(430, 25);
            lblTotal.Text = "Total: $0.00";
            lblTotal.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(0, 123, 255);
            lblTotal.TextAlign = ContentAlignment.MiddleRight;

            // lblStatus
            lblStatus.Location = new Point(10, 545);
            lblStatus.Size = new Size(920, 25);
            lblStatus.Text = "Listo";
            lblStatus.ForeColor = Color.Gray;

            // PedidosControl
            this.Controls.AddRange(new Control[] { lblTituloPedidos, dgvPedidos, groupCrear, groupDetalles, lblStatus });
            this.Size = new Size(950, 580);
            this.BackColor = Color.White;
            this.Load += PedidosControl_Load;

            this.groupCrear.ResumeLayout(false);
            this.groupCrear.PerformLayout();
            this.groupDetalles.ResumeLayout(false);
            this.groupDetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);
        }
    }
}