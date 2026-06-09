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

        // === Paleta Albatros (horneada en este Designer) ===
        private static readonly Color C_Brand = Color.FromArgb(200, 65, 43);
        private static readonly Color C_BrandHov = Color.FromArgb(174, 54, 34);
        private static readonly Color C_Amber = Color.FromArgb(184, 119, 10);
        private static readonly Color C_AmberHov = Color.FromArgb(154, 98, 7);
        private static readonly Color C_Success = Color.FromArgb(65, 124, 56);
        private static readonly Color C_SuccessHov = Color.FromArgb(53, 104, 48);
        private static readonly Color C_Danger = Color.FromArgb(217, 45, 32);
        private static readonly Color C_DangerHov = Color.FromArgb(180, 35, 24);
        private static readonly Color C_Neutral = Color.FromArgb(107, 99, 86);
        private static readonly Color C_NeutralHov = Color.FromArgb(80, 73, 63);
        private static readonly Color C_Ink = Color.FromArgb(28, 25, 23);
        private static readonly Color C_Body = Color.FromArgb(51, 47, 42);
        private static readonly Color C_Secondary = Color.FromArgb(107, 99, 86);
        private static readonly Color C_Muted = Color.FromArgb(140, 130, 115);
        private static readonly Color C_Border = Color.FromArgb(210, 202, 187);
        private static readonly Color C_BorderSub = Color.FromArgb(227, 221, 210);
        private static readonly Color C_Sunken = Color.FromArgb(251, 250, 247);
        private static readonly Color C_Soft = Color.FromArgb(252, 237, 233);

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
        private static void EstiloEtiqueta(Label l)
        {
            l.ForeColor = C_Secondary;
            l.Font = new Font("Segoe UI", 9.5F);
            l.TextAlign = ContentAlignment.MiddleLeft;
        }
        private static void EstiloCombo(ComboBox c)
        {
            c.FlatStyle = FlatStyle.Standard;   // marco visible
            c.BackColor = Color.White; c.ForeColor = C_Body;
            c.Font = new Font("Segoe UI", 10.5F);
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
            lblTituloPedidos.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloPedidos.ForeColor = C_Ink;
            lblTituloPedidos.Location = new Point(10, 5);
            lblTituloPedidos.Name = "lblTituloPedidos";
            lblTituloPedidos.Size = new Size(450, 26);
            lblTituloPedidos.TabIndex = 0;
            lblTituloPedidos.Text = "Lista de Pedidos";
            // 
            // dgvPedidos
            // 
            EstiloGrid(dgvPedidos);
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
            groupCrear.BackColor = Color.White;
            groupCrear.ForeColor = C_Ink;
            groupCrear.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            groupCrear.Location = new Point(480, 5);
            groupCrear.Name = "groupCrear";
            groupCrear.Size = new Size(450, 290);
            groupCrear.TabIndex = 2;
            groupCrear.TabStop = false;
            groupCrear.Text = "Nuevo Pedido";
            // 
            // lblCliente
            // 
            EstiloEtiqueta(lblCliente);
            lblCliente.Location = new Point(15, 32);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(60, 25);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // cmbClientes
            // 
            EstiloCombo(cmbClientes);
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.Location = new Point(80, 30);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(350, 27);
            cmbClientes.TabIndex = 1;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // lblDireccion
            // 
            EstiloEtiqueta(lblDireccion);
            lblDireccion.Location = new Point(15, 67);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(65, 25);
            lblDireccion.TabIndex = 2;
            lblDireccion.Text = "Dirección:";
            // 
            // cmbDirecciones
            // 
            EstiloCombo(cmbDirecciones);
            cmbDirecciones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDirecciones.Location = new Point(80, 65);
            cmbDirecciones.Name = "cmbDirecciones";
            cmbDirecciones.Size = new Size(350, 27);
            cmbDirecciones.TabIndex = 3;
            // 
            // lblProducto
            // 
            EstiloEtiqueta(lblProducto);
            lblProducto.Location = new Point(15, 102);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(65, 25);
            lblProducto.TabIndex = 4;
            lblProducto.Text = "Producto:";
            // 
            // cmbProductos
            // 
            EstiloCombo(cmbProductos);
            cmbProductos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductos.Location = new Point(80, 100);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(200, 27);
            cmbProductos.TabIndex = 5;
            // 
            // lblCantidad
            // 
            EstiloEtiqueta(lblCantidad);
            lblCantidad.Location = new Point(290, 102);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(40, 25);
            lblCantidad.TabIndex = 6;
            lblCantidad.Text = "Cant:";
            // 
            // nudCantidad
            // 
            nudCantidad.BorderStyle = BorderStyle.FixedSingle;
            nudCantidad.BackColor = Color.White;
            nudCantidad.ForeColor = C_Body;
            nudCantidad.Font = new Font("Segoe UI", 10.5F);
            nudCantidad.Location = new Point(330, 100);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(60, 27);
            nudCantidad.TabIndex = 7;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregarDetalle
            // 
            Solido(btnAgregarDetalle, C_Success, C_SuccessHov, Color.White);
            btnAgregarDetalle.Location = new Point(15, 140);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(415, 35);
            btnAgregarDetalle.TabIndex = 8;
            btnAgregarDetalle.Text = "Agregar Producto al Pedido";
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            // 
            // lblNotasPed
            // 
            EstiloEtiqueta(lblNotasPed);
            lblNotasPed.Location = new Point(15, 192);
            lblNotasPed.Name = "lblNotasPed";
            lblNotasPed.Size = new Size(60, 25);
            lblNotasPed.TabIndex = 9;
            lblNotasPed.Text = "Notas:";
            // 
            // txtNotasPedido
            // 
            txtNotasPedido.BorderStyle = BorderStyle.FixedSingle;
            txtNotasPedido.BackColor = Color.White;
            txtNotasPedido.ForeColor = C_Body;
            txtNotasPedido.Font = new Font("Segoe UI", 10.5F);
            txtNotasPedido.Location = new Point(80, 190);
            txtNotasPedido.Name = "txtNotasPedido";
            txtNotasPedido.Size = new Size(350, 27);
            txtNotasPedido.TabIndex = 10;
            // 
            // btnCrearPedido
            // 
            Solido(btnCrearPedido, C_Brand, C_BrandHov, Color.White);
            btnCrearPedido.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCrearPedido.Location = new Point(15, 235);
            btnCrearPedido.Name = "btnCrearPedido";
            btnCrearPedido.Size = new Size(415, 38);
            btnCrearPedido.TabIndex = 11;
            btnCrearPedido.Text = "Crear Pedido";
            btnCrearPedido.Click += btnCrearPedido_Click;
            // 
            // groupEstado
            // 
            groupEstado.Controls.Add(btnPendiente);
            groupEstado.Controls.Add(btnEnPreparacion);
            groupEstado.Controls.Add(btnEntregado);
            groupEstado.Controls.Add(btnCancelado);
            groupEstado.BackColor = Color.White;
            groupEstado.ForeColor = C_Ink;
            groupEstado.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            groupEstado.Location = new Point(480, 305);
            groupEstado.Name = "groupEstado";
            groupEstado.Size = new Size(450, 76);
            groupEstado.TabIndex = 3;
            groupEstado.TabStop = false;
            groupEstado.Text = "Cambiar Estado";
            // 
            // btnPendiente
            // 
            Solido(btnPendiente, C_Neutral, C_NeutralHov, Color.White);
            btnPendiente.Location = new Point(10, 25);
            btnPendiente.Name = "btnPendiente";
            btnPendiente.Size = new Size(98, 40);
            btnPendiente.TabIndex = 0;
            btnPendiente.Text = "Pendiente";
            btnPendiente.Click += btnPendiente_Click;
            // 
            // btnEnPreparacion
            // 
            Solido(btnEnPreparacion, C_Amber, C_AmberHov, Color.White);
            btnEnPreparacion.Location = new Point(118, 25);
            btnEnPreparacion.Name = "btnEnPreparacion";
            btnEnPreparacion.Size = new Size(108, 40);
            btnEnPreparacion.TabIndex = 1;
            btnEnPreparacion.Text = "En preparación";
            btnEnPreparacion.Click += btnEnPreparacion_Click;
            // 
            // btnEntregado
            // 
            Solido(btnEntregado, C_Success, C_SuccessHov, Color.White);
            btnEntregado.Location = new Point(236, 25);
            btnEntregado.Name = "btnEntregado";
            btnEntregado.Size = new Size(98, 40);
            btnEntregado.TabIndex = 2;
            btnEntregado.Text = "Entregado";
            btnEntregado.Click += btnEntregado_Click;
            // 
            // btnCancelado
            // 
            Solido(btnCancelado, C_Danger, C_DangerHov, Color.White);
            btnCancelado.Location = new Point(344, 25);
            btnCancelado.Name = "btnCancelado";
            btnCancelado.Size = new Size(98, 40);
            btnCancelado.TabIndex = 3;
            btnCancelado.Text = "Cancelado";
            btnCancelado.Click += btnCancelado_Click;
            // 
            // groupDetalles
            // 
            groupDetalles.Controls.Add(dgvDetalles);
            groupDetalles.Controls.Add(lblTotal);
            groupDetalles.BackColor = Color.White;
            groupDetalles.ForeColor = C_Ink;
            groupDetalles.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            groupDetalles.Location = new Point(480, 390);
            groupDetalles.Name = "groupDetalles";
            groupDetalles.Size = new Size(450, 185);
            groupDetalles.TabIndex = 4;
            groupDetalles.TabStop = false;
            groupDetalles.Text = "Detalles";
            // 
            // dgvDetalles
            // 
            EstiloGrid(dgvDetalles);
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.Location = new Point(10, 25);
            dgvDetalles.MultiSelect = false;
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(430, 115);
            dgvDetalles.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.ForeColor = C_Brand;
            lblTotal.Location = new Point(10, 148);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(430, 28);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total: L0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = C_Muted;
            lblStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatus.Location = new Point(10, 580);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(460, 25);
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
