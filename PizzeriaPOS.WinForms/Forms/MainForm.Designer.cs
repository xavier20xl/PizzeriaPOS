namespace PizzeriaPOS.WinForms.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl;
        private Button btnCerrarSesion;
        private Label lblTitulo;
        private Panel topPanel;
        private Panel panelLogo;
        private Label lblLogo;

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
            topPanel = new Panel();
            panelLogo = new Panel();
            lblLogo = new Label();
            lblTitulo = new Label();
            btnCerrarSesion = new Button();
            tabControl = new TabControl();
            topPanel.SuspendLayout();
            panelLogo.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel — barra superior (clay-900)
            // 
            topPanel.BackColor = Color.FromArgb(28, 25, 23);
            topPanel.Controls.Add(panelLogo);
            topPanel.Controls.Add(lblTitulo);
            topPanel.Controls.Add(btnCerrarSesion);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(984, 64);
            topPanel.TabIndex = 1;
            // 
            // panelLogo — cuadro terracota
            // 
            panelLogo.BackColor = Color.FromArgb(200, 65, 43);
            panelLogo.Controls.Add(lblLogo);
            panelLogo.Location = new Point(20, 14);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(36, 36);
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Fill;
            lblLogo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Name = "lblLogo";
            lblLogo.Text = "A";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(68, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(600, 36);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Pizzería Albatros · Sistema POS";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCerrarSesion — ghost sobre la barra oscura
            // 
            btnCerrarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrarSesion.BackColor = Color.FromArgb(46, 42, 38);
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.FlatAppearance.BorderColor = Color.FromArgb(78, 72, 64);
            btnCerrarSesion.FlatAppearance.BorderSize = 1;
            btnCerrarSesion.FlatAppearance.MouseOverBackColor = Color.FromArgb(217, 45, 32);
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(824, 15);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(140, 36);
            btnCerrarSesion.TabIndex = 1;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // tabControl — pestañas con dibujo personalizado (ver MainForm.cs)
            // 
            tabControl.Appearance = TabAppearance.Normal;
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            tabControl.ItemSize = new Size(150, 40);
            tabControl.Location = new Point(0, 64);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(0, 0);
            tabControl.SelectedIndex = 0;
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.Size = new Size(984, 597);
            tabControl.TabIndex = 0;
            tabControl.DrawItem += tabControl_DrawItem;
            // 
            // MainForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(984, 661);
            Controls.Add(tabControl);
            Controls.Add(topPanel);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            topPanel.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
