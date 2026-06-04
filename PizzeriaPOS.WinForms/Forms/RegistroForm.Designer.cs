namespace PizzeriaPOS.WinForms.Forms
{
    partial class RegistroForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNombreCompleto;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private TextBox txtConfirmar;
        private Button btnRegistro;
        private Button btnCancelar;
        private Label lblStatus;
        private Label lblTitle;

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
            this.lblTitle = new Label();
            this.txtNombreCompleto = new TextBox();
            this.txtUsuario = new TextBox();
            this.txtPassword = new TextBox();
            this.txtConfirmar = new TextBox();
            this.btnRegistro = new Button();
            this.btnCancelar = new Button();
            this.lblStatus = new Label();
            this.SuspendLayout();

            // RegistroForm
            this.Text = "Registro - Pizzería Albatros";
            this.Size = new Size(420, 430);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // lblTitle
            this.lblTitle.Text = "Crear Nueva Cuenta";
            this.lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblTitle.Size = new Size(360, 40);
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // txtNombreCompleto
            this.txtNombreCompleto.Location = new Point(30, 80);
            this.txtNombreCompleto.Size = new Size(340, 30);
            this.txtNombreCompleto.PlaceholderText = "Nombre Completo";

            // txtUsuario
            this.txtUsuario.Location = new Point(30, 130);
            this.txtUsuario.Size = new Size(340, 30);
            this.txtUsuario.PlaceholderText = "Usuario";

            // txtPassword
            this.txtPassword.Location = new Point(30, 180);
            this.txtPassword.Size = new Size(340, 30);
            this.txtPassword.PlaceholderText = "Contraseña";
            this.txtPassword.UseSystemPasswordChar = true;

            // txtConfirmar
            this.txtConfirmar.Location = new Point(30, 230);
            this.txtConfirmar.Size = new Size(340, 30);
            this.txtConfirmar.PlaceholderText = "Confirmar Contraseña";
            this.txtConfirmar.UseSystemPasswordChar = true;

            // btnRegistro
            this.btnRegistro.Text = "Registrarse";
            this.btnRegistro.Location = new Point(30, 280);
            this.btnRegistro.Size = new Size(340, 40);
            this.btnRegistro.BackColor = Color.FromArgb(40, 167, 69);
            this.btnRegistro.ForeColor = Color.White;
            this.btnRegistro.FlatStyle = FlatStyle.Flat;
            this.btnRegistro.FlatAppearance.BorderSize = 0;
            this.btnRegistro.Click += new EventHandler(this.btnRegistro_Click);

            // btnCancelar
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new Point(30, 330);
            this.btnCancelar.Size = new Size(340, 35);
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            // lblStatus
            this.lblStatus.Text = "";
            this.lblStatus.Location = new Point(30, 375);
            this.lblStatus.Size = new Size(340, 25);
            this.lblStatus.ForeColor = Color.Red;
            this.lblStatus.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtNombreCompleto);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtConfirmar);
            this.Controls.Add(this.btnRegistro);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblStatus);

            this.ResumeLayout(false);
        }
    }
}
