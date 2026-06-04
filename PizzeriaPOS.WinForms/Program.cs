using PizzeriaPOS.WinForms.Forms;
using PizzeriaPOS.WinForms.Services;

namespace PizzeriaPOS.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var apiClient = new ApiClient("https://localhost:7057");

            // Mostrar login
            var loginForm = new LoginForm(apiClient);

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Login exitoso, mostrar formulario principal
                Application.Run(new MainForm(apiClient, "Usuario"));
            }
        }
    }
}
