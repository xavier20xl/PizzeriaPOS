namespace PizzeriaPOS.WinForms.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl;
        private Button btnCerrarSesion;
        private Label lblTitulo;
        private Panel topPanel;

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
            lblTitulo = new Label();
            btnCerrarSesion = new Button();
            tabControl = new TabControl();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(52, 58, 64);
            topPanel.Controls.Add(lblTitulo);
            topPanel.Controls.Add(btnCerrarSesion);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(984, 60);
            topPanel.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(500, 40);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Pizzería Albatros - Sistema POS";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrarSesion.BackColor = Color.FromArgb(220, 53, 69);
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(784, 0);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(120, 35);
            btnCerrarSesion.TabIndex = 1;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // tabControl
            // 
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 60);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(984, 601);
            tabControl.TabIndex = 0;
            // 
            // MainForm
            // 
            ClientSize = new Size(984, 661);
            Controls.Add(tabControl);
            Controls.Add(topPanel);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            topPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
