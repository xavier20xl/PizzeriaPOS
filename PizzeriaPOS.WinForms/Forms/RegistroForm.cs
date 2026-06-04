using PizzeriaPOS.WinForms.Models;
using PizzeriaPOS.WinForms.Services;

namespace PizzeriaPOS.WinForms.Forms
{
    public partial class RegistroForm : Form
    {
        private readonly ApiClient _apiClient;

        public RegistroForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private async void btnRegistro_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";

            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblStatus.Text = "Usuario y contraseña son obligatorios.";
                return;
            }

            if (txtPassword.Text != txtConfirmar.Text)
            {
                lblStatus.Text = "Las contraseñas no coinciden.";
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                lblStatus.Text = "La contraseña debe tener al menos 6 caracteres.";
                return;
            }

            try
            {
                var registerData = new RegisterRequest
                {
                    NombreUsuario = txtUsuario.Text,
                    Password = txtPassword.Text,
                    NombreCompleto = txtNombreCompleto.Text
                };

                await _apiClient.PostAuthAsync<AuthResponse>("/api/auth/register", registerData);
                MessageBox.Show("Registro exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
