using PizzeriaPOS.WinForms.Services;

namespace PizzeriaPOS.WinForms.Forms
{
    public partial class MainForm : Form
    {
        private readonly ApiClient _apiClient;

        // === Paleta Albatros (horneada en este formulario, sin Theme) ===
        private static readonly Color C_Card = Color.White;                 // superficie
        private static readonly Color C_Brand = Color.FromArgb(200, 65, 43); // terracota
        private static readonly Color C_Ink = Color.FromArgb(28, 25, 23);  // texto activo
        private static readonly Color C_Muted = Color.FromArgb(140, 130, 115); // texto apagado
        private static readonly Color C_TabIdle = Color.FromArgb(241, 238, 232); // pestaña inactiva

        public MainForm(ApiClient apiClient, string nombreUsuario)
        {
            InitializeComponent();
            _apiClient = apiClient;
            this.Text = $"Pizzería Albatros - {nombreUsuario}";
            CargarControles();
        }

        private void CargarControles()
        {
            var tabProductos = new TabPage("Productos") { BackColor = C_Card };
            tabProductos.Controls.Add(new ProductosControl(_apiClient) { Dock = DockStyle.Fill });

            var tabClientes = new TabPage("Clientes") { BackColor = C_Card };
            tabClientes.Controls.Add(new ClientesControl(_apiClient) { Dock = DockStyle.Fill });

            var tabPedidos = new TabPage("Pedidos") { BackColor = C_Card };
            tabPedidos.Controls.Add(new PedidosControl(_apiClient) { Dock = DockStyle.Fill });

            tabControl.TabPages.Add(tabProductos);
            tabControl.TabPages.Add(tabClientes);
            tabControl.TabPages.Add(tabPedidos);
        }

        // Dibuja cada pestaña con el estilo del design system:
        // activa = blanca con indicador terracota; inactiva = clay con texto apagado.
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tab = tabControl.TabPages[e.Index];
            var rect = tabControl.GetTabRect(e.Index);
            bool selected = (e.Index == tabControl.SelectedIndex);

            var bg = selected ? C_Card : C_TabIdle;
            using (var b = new SolidBrush(bg))
                e.Graphics.FillRectangle(b, rect);

            // Indicador terracota arriba de la pestaña activa
            if (selected)
            {
                using var accent = new SolidBrush(C_Brand);
                e.Graphics.FillRectangle(accent, rect.X, rect.Y, rect.Width, 3);
            }

            // Texto
            var fg = selected ? C_Ink : C_Muted;
            TextRenderer.DrawText(
                e.Graphics, tab.Text, tabControl.Font, rect, fg,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            _apiClient.ClearToken();
            this.Close();
        }
    }
}
