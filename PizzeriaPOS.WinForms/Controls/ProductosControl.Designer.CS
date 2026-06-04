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
            // groupBox1
            // 
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
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(600, 150);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Agregar/Editar Producto";
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(19, 29);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(70, 25);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            lblNombre.TextAlign = ContentAlignment.MiddleRight;
            lblNombre.Click += lblNombre_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(90, 30);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 25);
            txtNombre.TabIndex = 1;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // lblPrecio
            // 
            lblPrecio.Location = new Point(292, 29);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(61, 25);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "Precio:";
            lblPrecio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(355, 30);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 25);
            txtPrecio.TabIndex = 3;
            // 
            // lblCategoria
            // 
            lblCategoria.Location = new Point(7, 64);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(82, 25);
            lblCategoria.TabIndex = 4;
            lblCategoria.Text = "Categoría:";
            lblCategoria.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(90, 65);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(200, 25);
            cmbCategoria.TabIndex = 5;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(303, 64);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(50, 25);
            lblDescripcion.TabIndex = 6;
            lblDescripcion.Text = "Desc:";
            lblDescripcion.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(355, 65);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(230, 25);
            txtDescripcion.TabIndex = 7;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(0, 123, 255);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(15, 105);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 30);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(255, 193, 7);
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Location = new Point(125, 105);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 30);
            btnActualizar.TabIndex = 9;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(235, 105);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Location = new Point(345, 105);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 30);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.Location = new Point(10, 170);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(600, 350);
            dgvProductos.TabIndex = 1;
            dgvProductos.DataError += dgvProductos_DataError;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Location = new Point(10, 530);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(600, 25);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Listo";
            // 
            // ProductosControl
            // 
            BackColor = Color.White;
            Controls.Add(groupBox1);
            Controls.Add(dgvProductos);
            Controls.Add(lblStatus);
            Name = "ProductosControl";
            Size = new Size(630, 570);
            Load += ProductosControl_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }
    }
}