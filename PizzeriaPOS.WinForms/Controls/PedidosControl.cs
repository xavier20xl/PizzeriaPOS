using PizzeriaPOS.WinForms.Models;
using PizzeriaPOS.WinForms.Services;

namespace PizzeriaPOS.WinForms.Forms
{
    public partial class PedidosControl : UserControl
    {
        private readonly ApiClient _apiClient;
        private readonly List<CrearPedidoDetalleRequest> _detallesTemporales = new();
        private List<ClienteModel> _clientesCache = new();
        private List<ProductoModel> _productosCache = new();

        public PedidosControl(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private void PedidosControl_Load(object sender, EventArgs e)
        {
            _ = CargarDatosInicialesAsync();
        }

        private async Task CargarDatosInicialesAsync()
        {
            await CargarPedidosAsync();
            await CargarClientesAsync();
            await CargarProductosAsync();

            cmbDirecciones.DataSource = null;
            cmbDirecciones.Text = string.Empty;
        }

        private async Task CargarPedidosAsync()
        {
            try
            {
                var pedidos = await _apiClient.GetAsync<List<PedidoModel>>("/api/pedidos");

                if (pedidos != null && pedidos.Count > 0)
                {
                    dgvPedidos.DataSource = null;
                    dgvPedidos.DataSource = pedidos;

                    if (dgvPedidos.Columns["Detalles"] != null) dgvPedidos.Columns["Detalles"].Visible = false;
                    if (dgvPedidos.Columns["Id"] != null) dgvPedidos.Columns["Id"].Width = 40;
                    if (dgvPedidos.Columns["FechaPedido"] != null) dgvPedidos.Columns["FechaPedido"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    if (dgvPedidos.Columns["Total"] != null) dgvPedidos.Columns["Total"].DefaultCellStyle.Format = "C2";

                    lblStatus.Text = $"Pedidos: {pedidos.Count}";
                }
                else
                {
                    lblStatus.Text = "No hay pedidos.";
                    dgvPedidos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }

        private async Task CargarClientesAsync()
        {
            try
            {
                _clientesCache = await _apiClient.GetAsync<List<ClienteModel>>("/api/clientes") ?? new List<ClienteModel>();

                cmbClientes.DataSource = null;
                cmbClientes.DisplayMember = "Nombre";
                cmbClientes.ValueMember = "Id";
                cmbClientes.DataSource = _clientesCache;

                cmbClientes.SelectedIndex = -1;
                cmbClientes.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error al cargar clientes: " + ex.Message;
            }
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                _productosCache = await _apiClient.GetAsync<List<ProductoModel>>("/api/productos") ?? new List<ProductoModel>();

                cmbProductos.DataSource = null;
                cmbProductos.DisplayMember = "Nombre";
                cmbProductos.ValueMember = "Id";
                cmbProductos.DataSource = _productosCache;

                cmbProductos.SelectedIndex = -1;
                cmbProductos.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error al cargar productos: " + ex.Message;
            }
        }

        private async Task CargarDireccionesAsync(int clienteId)
        {
            try
            {
                var cliente = _clientesCache.FirstOrDefault(c => c.Id == clienteId);

                if (cliente == null)
                {
                    cmbDirecciones.DataSource = null;
                    cmbDirecciones.Text = string.Empty;
                    return;
                }

                List<DireccionModel> direcciones;

                if (cliente.Direcciones != null && cliente.Direcciones.Count > 0)
                {
                    direcciones = cliente.Direcciones.Where(d => d.EstaActivo).ToList();
                }
                else
                {
                    direcciones = await _apiClient.GetAsync<List<DireccionModel>>($"/api/clientes/{clienteId}/direcciones") ?? new List<DireccionModel>();
                }

                cmbDirecciones.DataSource = null;
                cmbDirecciones.DisplayMember = "Calle";
                cmbDirecciones.ValueMember = "Id";
                cmbDirecciones.DataSource = direcciones;

                cmbDirecciones.SelectedIndex = -1;
                cmbDirecciones.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error al cargar direcciones: " + ex.Message;
            }
        }

        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count > 0 && dgvPedidos.SelectedRows[0].DataBoundItem is PedidoModel p)
            {
                dgvDetalles.DataSource = null;
                dgvDetalles.DataSource = p.Detalles;
                lblTotal.Text = $"Total: {p.Total:C2}";
            }
        }

        private async void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem is ClienteModel c)
            {
                await CargarDireccionesAsync(c.Id);
            }
            else
            {
                cmbDirecciones.DataSource = null;
                cmbDirecciones.Text = string.Empty;
            }
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem is not ProductoModel prod)
            {
                lblStatus.Text = "Seleccione un producto.";
                return;
            }

            _detallesTemporales.Add(new CrearPedidoDetalleRequest
            {
                ProductoId = prod.Id,
                Cantidad = (int)nudCantidad.Value,
                Notas = null
            });

            ActualizarGridTemporal();
            nudCantidad.Value = 1;
        }

        private void ActualizarGridTemporal()
        {
            var detallesTemp = _detallesTemporales.Select(d =>
            {
                var prod = _productosCache.FirstOrDefault(p => p.Id == d.ProductoId);

                return new PedidoDetalleModel
                {
                    ProductoId = d.ProductoId,
                    ProductoNombre = prod?.Nombre ?? "N/A",
                    Cantidad = d.Cantidad,
                    PrecioUnitario = prod?.Precio ?? 0,
                    Subtotal = (prod?.Precio ?? 0) * d.Cantidad,
                    Notas = d.Notas
                };
            }).ToList();

            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = detallesTemp;
            lblTotal.Text = $"Total: {detallesTemp.Sum(d => d.Subtotal):C2}";
        }

        private async void btnCrearPedido_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem is not ClienteModel cliente)
            {
                lblStatus.Text = "Seleccione cliente.";
                return;
            }

            if (_detallesTemporales.Count == 0)
            {
                lblStatus.Text = "Agregue productos.";
                return;
            }

            try
            {
                int? direccionId = null;
                if (cmbDirecciones.SelectedItem is DireccionModel dir)
                {
                    direccionId = dir.Id;
                }

                await _apiClient.PostAsync<PedidoModel>("/api/pedidos", new CrearPedidoRequest
                {
                    ClienteId = cliente.Id,
                    DireccionId = direccionId,
                    Notas = txtNotasPedido.Text,
                    Detalles = _detallesTemporales
                });

                lblStatus.Text = "Pedido creado.";
                _detallesTemporales.Clear();
                dgvDetalles.DataSource = null;
                lblTotal.Text = "Total: $0.00";
                txtNotasPedido.Clear();
                cmbDirecciones.DataSource = null;
                cmbClientes.SelectedIndex = -1;
                cmbProductos.SelectedIndex = -1;
                await CargarPedidosAsync();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }
    }
}