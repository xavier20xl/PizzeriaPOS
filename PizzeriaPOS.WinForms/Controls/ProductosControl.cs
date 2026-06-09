using PizzeriaPOS.WinForms.Models;
using PizzeriaPOS.WinForms.Services;

namespace PizzeriaPOS.WinForms.Forms
{
    public partial class ProductosControl : UserControl
    {
        private readonly ApiClient _apiClient;
        private int? _productoSeleccionadoId;
        private List<ProductoModel> _productosCache = new();
        private bool _cargandoDatos;
        private bool _evitarSeleccion;

        public ProductosControl(ApiClient apiClient)
        {
            // Estilos horneados en ProductosControl.Designer.cs — sin Theme.
            InitializeComponent();
            _apiClient = apiClient;
        }

        private void ProductosControl_Load(object sender, EventArgs e)
        {
            _ = CargarCategoriasAsync();
            _ = CargarProductosAsync();
        }

        private async Task CargarCategoriasAsync()
        {
            try
            {
                var categorias = await _apiClient.GetAsync<List<string>>("/api/productos/categorias") ?? new List<string>();

                cmbCategoria.DataSource = null;
                cmbCategoria.DataSource = categorias;
                cmbCategoria.SelectedIndex = -1;
                cmbCategoria.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error al cargar categorías: " + ex.Message;
            }
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                _cargandoDatos = true;
                _evitarSeleccion = true;

                _productosCache = await _apiClient.GetAsync<List<ProductoModel>>("/api/productos") ?? new List<ProductoModel>();
                AplicarFiltroProductos();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
            finally
            {
                _cargandoDatos = false;
                _evitarSeleccion = false;
            }
        }

        private void AplicarFiltroProductos()
        {
            var filtroNombre = txtNombre.Text.Trim().ToLowerInvariant();
            var filtroCategoria = cmbCategoria.SelectedItem?.ToString()?.Trim().ToLowerInvariant();

            var productosFiltrados = _productosCache
                .Where(p =>
                    (string.IsNullOrWhiteSpace(filtroNombre) || p.Nombre.ToLowerInvariant().Contains(filtroNombre)) &&
                    (string.IsNullOrWhiteSpace(filtroCategoria) ||
                     (!string.IsNullOrWhiteSpace(p.Categoria) && p.Categoria.ToLowerInvariant() == filtroCategoria)))
                .ToList();

            _evitarSeleccion = true;

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productosFiltrados;

            if (dgvProductos.Columns["Id"] != null) dgvProductos.Columns["Id"].Visible = false;
            if (dgvProductos.Columns["EstaActivo"] != null) dgvProductos.Columns["EstaActivo"].Visible = false;
            if (dgvProductos.Columns["FechaCreacion"] != null) dgvProductos.Columns["FechaCreacion"].Visible = false;

            if (dgvProductos.Columns["Nombre"] != null)
            {
                dgvProductos.Columns["Nombre"].HeaderText = "Nombre";
                dgvProductos.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if (dgvProductos.Columns["Descripcion"] != null)
            {
                dgvProductos.Columns["Descripcion"].HeaderText = "Descripción";
                dgvProductos.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvProductos.Columns["Descripcion"].FillWeight = 55;
            }

            if (dgvProductos.Columns["Precio"] != null)
            {
                dgvProductos.Columns["Precio"].HeaderText = "Precio";
                dgvProductos.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "C2";
            }

            if (dgvProductos.Columns["Categoria"] != null)
            {
                dgvProductos.Columns["Categoria"].HeaderText = "Categoría";
                dgvProductos.Columns["Categoria"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dgvProductos.ClearSelection();
            dgvProductos.CurrentCell = null;

            lblStatus.Text = productosFiltrados.Count == 0
                ? "No hay productos que coincidan."
                : $"Productos: {productosFiltrados.Count}";

            _evitarSeleccion = false;
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargandoDatos || _evitarSeleccion) return;
            if (dgvProductos.SelectedRows.Count == 0) return;
            if (dgvProductos.SelectedRows[0].DataBoundItem is not ProductoModel p) return;

            try
            {
                _cargandoDatos = true;

                _productoSeleccionadoId = p.Id;
                txtNombre.Text = p.Nombre;
                txtPrecio.Text = p.Precio.ToString("F2");
                txtDescripcion.Text = p.Descripcion ?? "";

                if (!string.IsNullOrWhiteSpace(p.Categoria))
                {
                    cmbCategoria.SelectedItem = p.Categoria;
                    if (cmbCategoria.SelectedItem == null)
                        cmbCategoria.Text = p.Categoria;
                }
                else
                {
                    cmbCategoria.SelectedIndex = -1;
                    cmbCategoria.Text = string.Empty;
                }
            }
            finally
            {
                _cargandoDatos = false;
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblStatus.Text = "Nombre obligatorio.";
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                lblStatus.Text = "Precio inválido.";
                return;
            }

            try
            {
                await _apiClient.PostAsync<ProductoModel>("/api/productos", new CrearProductoRequest
                {
                    Nombre = txtNombre.Text,
                    Precio = precio,
                    Categoria = cmbCategoria.SelectedItem?.ToString() ?? cmbCategoria.Text,
                    Descripcion = txtDescripcion.Text
                });

                lblStatus.Text = "Producto agregado.";
                Limpiar();
                await CargarCategoriasAsync();
                await CargarProductosAsync();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!_productoSeleccionadoId.HasValue)
            {
                lblStatus.Text = "Seleccione un producto.";
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                lblStatus.Text = "Precio inválido.";
                return;
            }

            try
            {
                await _apiClient.PutAsync($"/api/productos/{_productoSeleccionadoId}", new CrearProductoRequest
                {
                    Nombre = txtNombre.Text,
                    Precio = precio,
                    Categoria = cmbCategoria.SelectedItem?.ToString() ?? cmbCategoria.Text,
                    Descripcion = txtDescripcion.Text
                });

                lblStatus.Text = "Producto actualizado.";
                Limpiar();
                await CargarCategoriasAsync();
                await CargarProductosAsync();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!_productoSeleccionadoId.HasValue)
            {
                lblStatus.Text = "Seleccione un producto.";
                return;
            }

            if (MessageBox.Show("¿Eliminar producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteAsync($"/api/productos/{_productoSeleccionadoId}");
                    lblStatus.Text = "Producto eliminado.";
                    Limpiar();
                    await CargarCategoriasAsync();
                    await CargarProductosAsync();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error: " + ex.Message;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (_cargandoDatos) return;
            AplicarFiltroProductos();
        }

        private void dgvProductos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }

        private void Limpiar()
        {
            _productoSeleccionadoId = null;
            txtNombre.Clear();
            txtPrecio.Clear();
            txtDescripcion.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbCategoria.Text = string.Empty;

            _evitarSeleccion = true;
            dgvProductos.ClearSelection();
            dgvProductos.CurrentCell = null;
            _evitarSeleccion = false;

            AplicarFiltroProductos();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargandoDatos) return;
            AplicarFiltroProductos();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
