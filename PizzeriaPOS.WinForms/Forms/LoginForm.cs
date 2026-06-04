using PizzeriaPOS.WinForms.Models;
using PizzeriaPOS.WinForms.Services;

namespace PizzeriaPOS.WinForms.Forms
{
    public partial class LoginForm : Form
    {
        private readonly ApiClient _apiClient;

        public LoginForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";

            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblStatus.Text = "Complete todos los campos.";
                return;
            }

            try
            {
                var loginData = new LoginRequest
                {
                    NombreUsuario = txtUsuario.Text,
                    Password = txtPassword.Text
                };

                var response = await _apiClient.PostAuthAsync<AuthResponse>("/api/auth/login", loginData);

                if (response != null && !string.IsNullOrEmpty(response.Token))
                {
                    _apiClient.SetToken(response.Token);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch
            {
                lblStatus.Text = "Usuario o contraseña incorrectos.";
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            var registroForm = new RegistroForm(_apiClient);
            registroForm.ShowDialog(this);
        }
    }
}
