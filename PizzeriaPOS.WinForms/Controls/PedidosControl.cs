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
        private int? _pedidoSeleccionadoId;

        public PedidosControl(ApiClient apiClient)
        {
            // Estilos horneados en PedidosControl.Designer.cs — sin Theme.
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
                    pedidos = pedidos.OrderByDescending(p => p.FechaPedido).ToList();

                    dgvPedidos.DataSource = null;
                    dgvPedidos.DataSource = pedidos;

                    if (dgvPedidos.Columns["Detalles"] != null) dgvPedidos.Columns["Detalles"].Visible = false;
                    if (dgvPedidos.Columns["ClienteId"] != null) dgvPedidos.Columns["ClienteId"].Visible = false;
                    if (dgvPedidos.Columns["ClienteNombre"] != null) dgvPedidos.Columns["ClienteNombre"].Visible = false;
                    if (dgvPedidos.Columns["DireccionId"] != null) dgvPedidos.Columns["DireccionId"].Visible = false;
                    if (dgvPedidos.Columns["DireccionCompleta"] != null) dgvPedidos.Columns["DireccionCompleta"].Visible = false;
                    if (dgvPedidos.Columns["EstaActivo"] != null) dgvPedidos.Columns["EstaActivo"].Visible = false;
                    if (dgvPedidos.Columns["FechaCreacion"] != null) dgvPedidos.Columns["FechaCreacion"].Visible = false;

                    if (dgvPedidos.Columns["Id"] != null)
                    {
                        dgvPedidos.Columns["Id"].HeaderText = "ID";
                        dgvPedidos.Columns["Id"].Width = 45;
                    }

                    if (dgvPedidos.Columns["FechaPedido"] != null)
                    {
                        dgvPedidos.Columns["FechaPedido"].HeaderText = "Fecha";
                        dgvPedidos.Columns["FechaPedido"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dgvPedidos.Columns["FechaPedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    if (dgvPedidos.Columns["Total"] != null)
                    {
                        dgvPedidos.Columns["Total"].HeaderText = "Total";
                        dgvPedidos.Columns["Total"].DefaultCellStyle.Format = "C2";
                        dgvPedidos.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    if (dgvPedidos.Columns["Estado"] != null)
                    {
                        dgvPedidos.Columns["Estado"].HeaderText = "Estado";
                        dgvPedidos.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    if (dgvPedidos.Columns["Notas"] != null)
                    {
                        dgvPedidos.Columns["Notas"].HeaderText = "Notas";
                        dgvPedidos.Columns["Notas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    dgvPedidos.ClearSelection();
                    dgvPedidos.CurrentCell = null;

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
                    direcciones = cliente.Direcciones.Where(d => d.EstaActivo).ToList();
                else
                    direcciones = await _apiClient.GetAsync<List<DireccionModel>>($"/api/clientes/{clienteId}/direcciones") ?? new List<DireccionModel>();

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
            if (dgvPedidos.SelectedRows.Count == 0) return;
            if (dgvPedidos.SelectedRows[0].DataBoundItem is not PedidoModel p) return;

            _pedidoSeleccionadoId = p.Id;

            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = p.Detalles;
            lblTotal.Text = $"Total: {p.Total:C2}";

            var cliente = _clientesCache.FirstOrDefault(c => c.Id == p.ClienteId);
            if (cliente != null)
                cmbClientes.SelectedItem = cliente;

            _ = CargarYSeleccionarDireccionAsync(p.ClienteId, p.DireccionId);
        }

        private async Task CargarYSeleccionarDireccionAsync(int clienteId, int? direccionId)
        {
            await CargarDireccionesAsync(clienteId);

            if (direccionId.HasValue)
            {
                var dir = (cmbDirecciones.DataSource as List<DireccionModel>)
                    ?.FirstOrDefault(d => d.Id == direccionId.Value);
                if (dir != null)
                    cmbDirecciones.SelectedItem = dir;
            }
        }

        private async void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem is ClienteModel c)
                await CargarDireccionesAsync(c.Id);
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
                    direccionId = dir.Id;

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
                _pedidoSeleccionadoId = null;
                await CargarPedidosAsync();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }

        // ── Cambio de estado ────────────────────────────────────────────
        private async void btnPendiente_Click(object sender, EventArgs e)
            => await CambiarEstadoAsync("Pendiente");

        private async void btnEnPreparacion_Click(object sender, EventArgs e)
            => await CambiarEstadoAsync("En preparación");

        private async void btnEntregado_Click(object sender, EventArgs e)
            => await CambiarEstadoAsync("Entregado");

        private async void btnCancelado_Click(object sender, EventArgs e)
            => await CambiarEstadoAsync("Cancelado");

        private async Task CambiarEstadoAsync(string nuevoEstado)
        {
            if (!_pedidoSeleccionadoId.HasValue)
            {
                lblStatus.Text = "Seleccione un pedido primero.";
                return;
            }

            try
            {
                await _apiClient.PutAsync(
                    $"/api/pedidos/{_pedidoSeleccionadoId}",
                    new { Estado = nuevoEstado, Notas = (string?)null, DireccionId = (int?)null }
                );
                lblStatus.Text = $"Estado actualizado a: {nuevoEstado}";
                await CargarPedidosAsync();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }
    }
}
