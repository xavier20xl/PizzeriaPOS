namespace PizzeriaPOS.WinForms.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Panel panelLogo;
        private Label lblLogo;
        private Label lblBrand;
        private Label lblBrandSub;

        private Label lblHeading;
        private Label lblHint;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegistro;
        private Label lblStatus;

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
            panelHeader = new Panel();
            panelLogo = new Panel();
            lblLogo = new Label();
            lblBrand = new Label();
            lblBrandSub = new Label();
            lblHeading = new Label();
            lblHint = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnRegistro = new Button();
            lblStatus = new Label();
            panelHeader.SuspendLayout();
            panelLogo.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader — barra de marca (clay-900)
            //
            panelHeader.BackColor = Color.FromArgb(28, 25, 23);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(404, 92);
            panelHeader.Controls.Add(panelLogo);
            panelHeader.Controls.Add(lblBrand);
            panelHeader.Controls.Add(lblBrandSub);
            //
            // panelLogo — cuadro terracota con la inicial
            //
            panelLogo.BackColor = Color.FromArgb(200, 65, 43);
            panelLogo.Location = new Point(30, 28);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(38, 38);
            panelLogo.Controls.Add(lblLogo);
            //
            // lblLogo
            //
            lblLogo.Dock = DockStyle.Fill;
            lblLogo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Name = "lblLogo";
            lblLogo.Text = "A";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblBrand
            //
            lblBrand.AutoSize = false;
            lblBrand.BackColor = Color.Transparent;
            lblBrand.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(82, 26);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(300, 26);
            lblBrand.Text = "Pizzería Albatros";
            lblBrand.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblBrandSub
            //
            lblBrandSub.AutoSize = false;
            lblBrandSub.BackColor = Color.Transparent;
            lblBrandSub.Font = new Font("Segoe UI", 8.5F);
            lblBrandSub.ForeColor = Color.FromArgb(179, 169, 152);
            lblBrandSub.Location = new Point(82, 52);
            lblBrandSub.Name = "lblBrandSub";
            lblBrandSub.Size = new Size(300, 18);
            lblBrandSub.Text = "SISTEMA POS";
            lblBrandSub.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblHeading
            //
            lblHeading.AutoSize = false;
            lblHeading.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblHeading.ForeColor = Color.FromArgb(28, 25, 23);
            lblHeading.Location = new Point(30, 112);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(344, 28);
            lblHeading.Text = "Iniciar sesión";
            //
            // lblHint
            //
            lblHint.AutoSize = false;
            lblHint.Font = new Font("Segoe UI", 9.5F);
            lblHint.ForeColor = Color.FromArgb(140, 130, 115);
            lblHint.Location = new Point(30, 142);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(344, 20);
            lblHint.Text = "Ingresa con tu usuario del negocio.";
            //
            // txtUsuario
            //
            txtUsuario.BackColor = Color.White;
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.ForeColor = Color.FromArgb(51, 47, 42);
            txtUsuario.Location = new Point(30, 178);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Usuario";
            txtUsuario.Size = new Size(344, 30);
            txtUsuario.TabIndex = 0;
            //
            // txtPassword
            //
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.FromArgb(51, 47, 42);
            txtPassword.Location = new Point(30, 220);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Contraseña";
            txtPassword.Size = new Size(344, 30);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            //
            // btnLogin — primario (terracota)
            //
            btnLogin.BackColor = Color.FromArgb(200, 65, 43);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(174, 54, 34);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(30, 270);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(344, 44);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            //
            // btnRegistro — éxito (basil)
            //
            btnRegistro.BackColor = Color.FromArgb(65, 124, 56);
            btnRegistro.Cursor = Cursors.Hand;
            btnRegistro.FlatAppearance.BorderSize = 0;
            btnRegistro.FlatAppearance.MouseOverBackColor = Color.FromArgb(53, 104, 48);
            btnRegistro.FlatStyle = FlatStyle.Flat;
            btnRegistro.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnRegistro.ForeColor = Color.White;
            btnRegistro.Location = new Point(30, 322);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Size = new Size(344, 44);
            btnRegistro.TabIndex = 3;
            btnRegistro.Text = "Crear Nueva Cuenta";
            btnRegistro.UseVisualStyleBackColor = false;
            btnRegistro.Click += btnRegistro_Click;
            //
            // lblStatus
            //
            lblStatus.Font = new Font("Segoe UI", 9.5F);
            lblStatus.ForeColor = Color.FromArgb(217, 45, 32);
            lblStatus.Location = new Point(30, 376);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(344, 24);
            lblStatus.TabIndex = 4;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            //
            // LoginForm
            //
            AcceptButton = btnLogin;
            BackColor = Color.White;
            ClientSize = new Size(404, 414);
            Controls.Add(lblStatus);
            Controls.Add(btnRegistro);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblHint);
            Controls.Add(lblHeading);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar Sesión - Pizzería Albatros";
            panelHeader.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
