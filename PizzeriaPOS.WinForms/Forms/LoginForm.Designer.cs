namespace PizzeriaPOS.WinForms.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegistro;
        private Label lblStatus;
        private Label lblTitle;
        private Label lblSubtitle;

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
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnRegistro = new Button();
            lblStatus = new Label();
            lblTitle = new Label();
            lblSubtitle = new Label();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.Location = new Point(30, 130);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Usuario";
            txtUsuario.Size = new Size(340, 27);
            txtUsuario.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(30, 180);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Contraseña";
            txtPassword.Size = new Size(340, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 123, 255);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(30, 230);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(340, 40);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegistro
            // 
            btnRegistro.BackColor = Color.FromArgb(40, 167, 69);
            btnRegistro.FlatAppearance.BorderSize = 0;
            btnRegistro.FlatStyle = FlatStyle.Flat;
            btnRegistro.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegistro.ForeColor = Color.White;
            btnRegistro.Location = new Point(30, 280);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Size = new Size(340, 40);
            btnRegistro.TabIndex = 5;
            btnRegistro.Text = "Crear Nueva Cuenta";
            btnRegistro.UseVisualStyleBackColor = false;
            btnRegistro.Click += btnRegistro_Click;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(30, 330);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(340, 25);
            lblStatus.TabIndex = 6;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(360, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Pizzería Albatros";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 12F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(30, 70);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(360, 30);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Iniciar Sesión";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(404, 388);
            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);
            Controls.Add(txtUsuario);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(btnRegistro);
            Controls.Add(lblStatus);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar Sesión - Pizzería Albatros";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
