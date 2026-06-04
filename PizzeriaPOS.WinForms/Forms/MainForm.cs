using PizzeriaPOS.WinForms.Services;

namespace PizzeriaPOS.WinForms.Forms
{
    public partial class MainForm : Form
    {
        private readonly ApiClient _apiClient;

        public MainForm(ApiClient apiClient, string nombreUsuario)
        {
            InitializeComponent();
            _apiClient = apiClient;
            this.Text = $"Pizzería Albatros - {nombreUsuario}";
            CargarControles();
        }

        private void CargarControles()
        {
            var tabProductos = new TabPage("Productos");
            tabProductos.Controls.Add(new ProductosControl(_apiClient) { Dock = DockStyle.Fill });

            var tabClientes = new TabPage("Clientes");
            tabClientes.Controls.Add(new ClientesControl(_apiClient) { Dock = DockStyle.Fill });

            var tabPedidos = new TabPage("Pedidos");
            tabPedidos.Controls.Add(new PedidosControl(_apiClient) { Dock = DockStyle.Fill });

            tabControl.TabPages.Add(tabProductos);
            tabControl.TabPages.Add(tabClientes);
            tabControl.TabPages.Add(tabPedidos);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            _apiClient.ClearToken();
            this.Close();
        }
    }
}
