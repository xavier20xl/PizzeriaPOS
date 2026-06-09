namespace PizzeriaPOS.WinForms.Forms
{
    partial class ProductosControl
    {
        private System.ComponentModel.IContainer components = null;
        private GroupBox groupBox1;
        private Label lblNombre;
        private Label lblPrecio;
        private Label lblCategoria;
        private Label lblDescripcion;
        public TextBox txtNombre;
        public TextBox txtPrecio;
        public ComboBox cmbCategoria;
        public TextBox txtDescripcion;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        public DataGridView dgvProductos;
        public Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            dgvProductos = new DataGridView();
            lblStatus = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // groupBox1 — panel "Agregar/Editar Producto"
            // 
            groupBox1.Dock = DockStyle.Top;
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(lblNombre);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(lblPrecio);
            groupBox1.Controls.Add(txtPrecio);
            groupBox1.Controls.Add(lblCategoria);
            groupBox1.Controls.Add(cmbCategoria);
            groupBox1.Controls.Add(lblDescripcion);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(btnActualizar);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnLimpiar);
            groupBox1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(28, 25, 23);
            groupBox1.Location = new Point(16, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(944, 170);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Agregar / Editar Producto";
            // 
            // lblNombre
            // 
            lblNombre.Font = new Font("Segoe UI", 9.5F);
            lblNombre.ForeColor = Color.FromArgb(107, 99, 86);
            lblNombre.Location = new Point(20, 40);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(80, 25);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            lblNombre.TextAlign = ContentAlignment.MiddleLeft;
            lblNombre.Click += lblNombre_Click;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 11F);
            txtNombre.ForeColor = Color.FromArgb(51, 47, 42);
            txtNombre.Location = new Point(20, 66);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Pizza Margarita";
            txtNombre.Size = new Size(340, 30);
            txtNombre.TabIndex = 1;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // lblPrecio
            // 
            lblPrecio.Font = new Font("Segoe UI", 9.5F);
            lblPrecio.ForeColor = Color.FromArgb(107, 99, 86);
            lblPrecio.Location = new Point(380, 40);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(80, 25);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "Precio (L)";
            lblPrecio.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPrecio
            // 
            txtPrecio.BackColor = Color.White;
            txtPrecio.BorderStyle = BorderStyle.FixedSingle;
            txtPrecio.Font = new Font("Segoe UI", 11F);
            txtPrecio.ForeColor = Color.FromArgb(51, 47, 42);
            txtPrecio.Location = new Point(380, 66);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "0.00";
            txtPrecio.Size = new Size(160, 30);
            txtPrecio.TabIndex = 2;
            // 
            // lblCategoria
            // 
            lblCategoria.Font = new Font("Segoe UI", 9.5F);
            lblCategoria.ForeColor = Color.FromArgb(107, 99, 86);
            lblCategoria.Location = new Point(560, 40);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(90, 25);
            lblCategoria.TabIndex = 4;
            lblCategoria.Text = "Categoría";
            lblCategoria.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbCategoria
            // 
            cmbCategoria.BackColor = Color.White;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FlatStyle = FlatStyle.Standard;
            cmbCategoria.Font = new Font("Segoe UI", 11F);
            cmbCategoria.ForeColor = Color.FromArgb(51, 47, 42);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(560, 66);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(360, 30);
            cmbCategoria.TabIndex = 3;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Font = new Font("Segoe UI", 9.5F);
            lblDescripcion.ForeColor = Color.FromArgb(107, 99, 86);
            lblDescripcion.Location = new Point(20, 102);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(90, 25);
            lblDescripcion.TabIndex = 6;
            lblDescripcion.Text = "Descripción";
            lblDescripcion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDescripcion
            // 
            txtDescripcion.BackColor = Color.White;
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 11F);
            txtDescripcion.ForeColor = Color.FromArgb(51, 47, 42);
            txtDescripcion.Location = new Point(20, 128);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "Ingredientes y notas…";
            txtDescripcion.Size = new Size(520, 30);
            txtDescripcion.TabIndex = 4;
            // 
            // btnAgregar — primario (terracota)
            // 
            btnAgregar.BackColor = Color.FromArgb(200, 65, 43);
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatAppearance.MouseOverBackColor = Color.FromArgb(174, 54, 34);
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(560, 122);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(110, 38);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar — ámbar (warning)
            // 
            btnActualizar.BackColor = Color.FromArgb(184, 119, 10);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(154, 98, 7);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(678, 122);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 38);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar — rojo (danger)
            // 
            btnEliminar.BackColor = Color.FromArgb(217, 45, 32);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 35, 24);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(796, 122);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(48, 38);
            btnEliminar.TabIndex = 7;
            btnEliminar.Font = new Font("Segoe UI Emoji", 11F);
            btnEliminar.Text = "🗑";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar — contorno (secundario)
            // 
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(210, 202, 187);
            btnLimpiar.FlatAppearance.BorderSize = 1;
            btnLimpiar.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 250, 247);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI Emoji", 11F);
            btnLimpiar.ForeColor = Color.FromArgb(28, 25, 23);
            btnLimpiar.Location = new Point(852, 122);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(48, 38);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "🧹";
            // Tip: un ToolTip ayuda a aclarar el ícono
            new ToolTip().SetToolTip(btnLimpiar, "Limpiar formulario");
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvProductos — tabla estilizada
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvProductos.ColumnHeadersHeight = 42;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(227, 221, 210);
            dgvProductos.Location = new Point(16, 200);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowTemplate.Height = 40;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(944, 328);
            dgvProductos.TabIndex = 1;
            dgvProductos.DataError += dgvProductos_DataError;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // encabezados
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(251, 250, 247);
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(140, 130, 115);
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvProductos.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 10, 0);
            dgvProductos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            // celdas
            dgvProductos.DefaultCellStyle.BackColor = Color.White;
            dgvProductos.DefaultCellStyle.ForeColor = Color.FromArgb(51, 47, 42);
            dgvProductos.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvProductos.DefaultCellStyle.Padding = new Padding(10, 0, 10, 0);
            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 237, 233);
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(28, 25, 23);
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(251, 250, 247);
            dgvProductos.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 237, 233);
            dgvProductos.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(28, 25, 23);
            // 
            // lblStatus — contador "Productos: N"
            // 
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblStatus.Padding = new Padding(4, 4, 0, 0);
            lblStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(140, 130, 115);
            lblStatus.Location = new Point(16, 536);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(944, 25);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Listo";
            // 
            // ProductosControl
            // 
            BackColor = Color.White;
            Controls.Add(dgvProductos);
            Controls.Add(lblStatus);
            Controls.Add(groupBox1);
            Name = "ProductosControl";
            Padding = new Padding(16, 16, 16, 8);
            Size = new Size(976, 569);
            Load += ProductosControl_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }
    }
}
