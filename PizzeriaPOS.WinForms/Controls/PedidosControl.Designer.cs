namespace PizzeriaPOS.WinForms.Forms
{
    partial class PedidosControl
    {
        private System.ComponentModel.IContainer components = null;
        private GroupBox groupCrear, groupDetalles, groupEstado;
        private Label lblTituloPedidos;
        private Label lblCliente, lblDireccion, lblProducto, lblCantidad, lblNotasPed;
        public ComboBox cmbClientes, cmbDirecciones, cmbProductos;
        public NumericUpDown nudCantidad;
        public TextBox txtNotasPedido;
        private Button btnAgregarDetalle, btnCrearPedido;
        private Button btnPendiente, btnEnPreparacion, btnEntregado, btnCancelado;
        public DataGridView dgvPedidos, dgvDetalles;
        public Label lblStatus, lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTituloPedidos = new Label();
            dgvPedidos = new DataGridView();
            groupCrear = new GroupBox();
            lblCliente = new Label();
            cmbClientes = new ComboBox();
            lblDireccion = new Label();
            cmbDirecciones = new ComboBox();
            lblProducto = new Label();
            cmbProductos = new ComboBox();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            btnAgregarDetalle = new Button();
            lblNotasPed = new Label();
            txtNotasPedido = new TextBox();
            btnCrearPedido = new Button();
            groupDetalles = new GroupBox();
            dgvDetalles = new DataGridView();
            lblTotal = new Label();
            groupEstado = new GroupBox();
            btnPendiente = new Button();
            btnEnPreparacion = new Button();
            btnEntregado = new Button();
            btnCancelado = new Button();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            groupCrear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            groupDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            groupEstado.SuspendLayout();
            SuspendLayout();
            // 
            // lblTituloPedidos
            // 
            lblTituloPedidos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTituloPedidos.Location = new Point(10, 5);
            lblTituloPedidos.Name = "lblTituloPedidos";
            lblTituloPedidos.Size = new Size(450, 25);
            lblTituloPedidos.TabIndex = 0;
            lblTituloPedidos.Text = "Lista de Pedidos";
            // 
            // dgvPedidos
            // 
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidos.Location = new Point(10, 35);
            dgvPedidos.MultiSelect = false;
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.ReadOnly = true;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.Size = new Size(450, 530);
            dgvPedidos.TabIndex = 1;
            dgvPedidos.SelectionChanged += dgvPedidos_SelectionChanged;
            // 
            // groupCrear
            // 
            groupCrear.Controls.Add(lblCliente);
            groupCrear.Controls.Add(cmbClientes);
            groupCrear.Controls.Add(lblDireccion);
            groupCrear.Controls.Add(cmbDirecciones);
            groupCrear.Controls.Add(lblProducto);
            groupCrear.Controls.Add(cmbProductos);
            groupCrear.Controls.Add(lblCantidad);
            groupCrear.Controls.Add(nudCantidad);
            groupCrear.Controls.Add(btnAgregarDetalle);
            groupCrear.Controls.Add(lblNotasPed);
            groupCrear.Controls.Add(txtNotasPedido);
            groupCrear.Controls.Add(btnCrearPedido);
            groupCrear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupCrear.Location = new Point(480, 5);
            groupCrear.Name = "groupCrear";
            groupCrear.Size = new Size(450, 290);
            groupCrear.TabIndex = 2;
            groupCrear.TabStop = false;
            groupCrear.Text = "Nuevo Pedido";
            // 
            // lblCliente
            // 
            lblCliente.Location = new Point(15, 30);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(60, 25);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // cmbClientes
            // 
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.Location = new Point(80, 30);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(350, 25);
            cmbClientes.TabIndex = 1;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // lblDireccion
            // 
            lblDireccion.Location = new Point(15, 65);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(65, 25);
            lblDireccion.TabIndex = 2;
            lblDireccion.Text = "Dirección:";
            // 
            // cmbDirecciones
            // 
            cmbDirecciones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDirecciones.Location = new Point(80, 65);
            cmbDirecciones.Name = "cmbDirecciones";
            cmbDirecciones.Size = new Size(350, 25);
            cmbDirecciones.TabIndex = 3;
            // 
            // lblProducto
            // 
            lblProducto.Location = new Point(15, 100);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(65, 25);
            lblProducto.TabIndex = 4;
            lblProducto.Text = "Producto:";
            // 
            // cmbProductos
            // 
            cmbProductos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductos.Location = new Point(80, 100);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(200, 25);
            cmbProductos.TabIndex = 5;
            // 
            // lblCantidad
            // 
            lblCantidad.Location = new Point(290, 100);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(40, 25);
            lblCantidad.TabIndex = 6;
            lblCantidad.Text = "Cant:";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(330, 100);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(60, 25);
            nudCantidad.TabIndex = 7;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.BackColor = Color.FromArgb(40, 167, 69);
            btnAgregarDetalle.FlatAppearance.BorderSize = 0;
            btnAgregarDetalle.FlatStyle = FlatStyle.Flat;
            btnAgregarDetalle.ForeColor = Color.White;
            btnAgregarDetalle.Location = new Point(15, 140);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(415, 35);
            btnAgregarDetalle.TabIndex = 8;
            btnAgregarDetalle.Text = "Agregar Producto al Pedido";
            btnAgregarDetalle.UseVisualStyleBackColor = false;
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            // 
            // lblNotasPed
            // 
            lblNotasPed.Location = new Point(15, 190);
            lblNotasPed.Name = "lblNotasPed";
            lblNotasPed.Size = new Size(60, 25);
            lblNotasPed.TabIndex = 9;
            lblNotasPed.Text = "Notas:";
            // 
            // txtNotasPedido
            // 
            txtNotasPedido.Location = new Point(80, 190);
            txtNotasPedido.Name = "txtNotasPedido";
            txtNotasPedido.Size = new Size(350, 25);
            txtNotasPedido.TabIndex = 10;
            // 
            // btnCrearPedido
            // 
            btnCrearPedido.BackColor = Color.FromArgb(0, 123, 255);
            btnCrearPedido.FlatAppearance.BorderSize = 0;
            btnCrearPedido.FlatStyle = FlatStyle.Flat;
            btnCrearPedido.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCrearPedido.ForeColor = Color.White;
            btnCrearPedido.Location = new Point(15, 235);
            btnCrearPedido.Name = "btnCrearPedido";
            btnCrearPedido.Size = new Size(415, 35);
            btnCrearPedido.TabIndex = 11;
            btnCrearPedido.Text = "Crear Pedido";
            btnCrearPedido.UseVisualStyleBackColor = false;
            btnCrearPedido.Click += btnCrearPedido_Click;
            // 
            // groupDetalles
            // 
            groupDetalles.Controls.Add(dgvDetalles);
            groupDetalles.Controls.Add(lblTotal);
            groupDetalles.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupDetalles.Location = new Point(480, 380);
            groupDetalles.Name = "groupDetalles";
            groupDetalles.Size = new Size(450, 185);
            groupDetalles.TabIndex = 4;
            groupDetalles.TabStop = false;
            groupDetalles.Text = "Detalles";
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.Location = new Point(10, 25);
            dgvDetalles.MultiSelect = false;
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(430, 120);
            dgvDetalles.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(0, 123, 255);
            lblTotal.Location = new Point(10, 150);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(430, 25);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total: $0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupEstado
            // 
            groupEstado.Controls.Add(btnPendiente);
            groupEstado.Controls.Add(btnEnPreparacion);
            groupEstado.Controls.Add(btnEntregado);
            groupEstado.Controls.Add(btnCancelado);
            groupEstado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupEstado.Location = new Point(480, 305);
            groupEstado.Name = "groupEstado";
            groupEstado.Size = new Size(450, 76);
            groupEstado.TabIndex = 3;
            groupEstado.TabStop = false;
            groupEstado.Text = "Cambiar Estado";
            // 
            // btnPendiente
            // 
            btnPendiente.BackColor = Color.FromArgb(108, 117, 125);
            btnPendiente.FlatAppearance.BorderSize = 0;
            btnPendiente.FlatStyle = FlatStyle.Flat;
            btnPendiente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPendiente.ForeColor = Color.White;
            btnPendiente.Location = new Point(10, 25);
            btnPendiente.Name = "btnPendiente";
            btnPendiente.Size = new Size(98, 44);
            btnPendiente.TabIndex = 0;
            btnPendiente.Text = "Pendiente";
            btnPendiente.UseVisualStyleBackColor = false;
            btnPendiente.Click += btnPendiente_Click;
            // 
            // btnEnPreparacion
            // 
            btnEnPreparacion.BackColor = Color.FromArgb(255, 153, 0);
            btnEnPreparacion.FlatAppearance.BorderSize = 0;
            btnEnPreparacion.FlatStyle = FlatStyle.Flat;
            btnEnPreparacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEnPreparacion.ForeColor = Color.White;
            btnEnPreparacion.Location = new Point(118, 25);
            btnEnPreparacion.Name = "btnEnPreparacion";
            btnEnPreparacion.Size = new Size(108, 44);
            btnEnPreparacion.TabIndex = 1;
            btnEnPreparacion.Text = "En preparación";
            btnEnPreparacion.UseVisualStyleBackColor = false;
            btnEnPreparacion.Click += btnEnPreparacion_Click;
            // 
            // btnEntregado
            // 
            btnEntregado.BackColor = Color.FromArgb(40, 167, 69);
            btnEntregado.FlatAppearance.BorderSize = 0;
            btnEntregado.FlatStyle = FlatStyle.Flat;
            btnEntregado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEntregado.ForeColor = Color.White;
            btnEntregado.Location = new Point(236, 25);
            btnEntregado.Name = "btnEntregado";
            btnEntregado.Size = new Size(98, 44);
            btnEntregado.TabIndex = 2;
            btnEntregado.Text = "Entregado";
            btnEntregado.UseVisualStyleBackColor = false;
            btnEntregado.Click += btnEntregado_Click;
            // 
            // btnCancelado
            // 
            btnCancelado.BackColor = Color.FromArgb(220, 53, 69);
            btnCancelado.FlatAppearance.BorderSize = 0;
            btnCancelado.FlatStyle = FlatStyle.Flat;
            btnCancelado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelado.ForeColor = Color.White;
            btnCancelado.Location = new Point(344, 25);
            btnCancelado.Name = "btnCancelado";
            btnCancelado.Size = new Size(98, 44);
            btnCancelado.TabIndex = 3;
            btnCancelado.Text = "Cancelado";
            btnCancelado.UseVisualStyleBackColor = false;
            btnCancelado.Click += btnCancelado_Click;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Location = new Point(10, 575);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(920, 25);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Listo";
            // 
            // PedidosControl
            // 
            BackColor = Color.White;
            Controls.Add(lblTituloPedidos);
            Controls.Add(dgvPedidos);
            Controls.Add(groupCrear);
            Controls.Add(groupEstado);
            Controls.Add(groupDetalles);
            Controls.Add(lblStatus);
            Name = "PedidosControl";
            Size = new Size(950, 610);
            Load += PedidosControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            groupCrear.ResumeLayout(false);
            groupCrear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            groupDetalles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            groupEstado.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}