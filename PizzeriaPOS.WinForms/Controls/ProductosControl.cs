using PizzeriaPOS.WinForms.Models;
using PizzeriaPOS.WinForms.Services;

namespace PizzeriaPOS.WinForms.Forms
{
    public partial class ProductosControl : UserControl
    {
        private readonly ApiClient _apiClient;
        private int? _productoSeleccionadoId;

        public ProductosControl(ApiClient apiClient)
        {
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
                var productos = await _apiClient.GetAsync<List<ProductoModel>>("/api/productos");
                if (productos != null && productos.Count > 0)
                {
                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = productos;

                    if (dgvProductos.Columns["Id"] != null) dgvProductos.Columns["Id"].Visible = false;
                    if (dgvProductos.Columns["EstaActivo"] != null) dgvProductos.Columns["EstaActivo"].Visible = false;
                    if (dgvProductos.Columns["FechaCreacion"] != null) dgvProductos.Columns["FechaCreacion"].Visible = false;
                    if (dgvProductos.Columns["Precio"] != null) dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "C2";
                    if (dgvProductos.Columns["Categoria"] != null) dgvProductos.Columns["Categoria"].HeaderText = "Categoría";

                    lblStatus.Text = $"Productos: {productos.Count}";
                }
                else
                {
                    lblStatus.Text = "No hay productos.";
                    dgvProductos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0 && dgvProductos.SelectedRows[0].DataBoundItem is ProductoModel p)
            {
                _productoSeleccionadoId = p.Id;
                txtNombre.Text = p.Nombre;
                txtPrecio.Text = p.Precio.ToString("F2");
                txtDescripcion.Text = p.Descripcion ?? "";

                if (!string.IsNullOrWhiteSpace(p.Categoria))
                {
                    cmbCategoria.SelectedItem = p.Categoria;
                    if (cmbCategoria.SelectedItem == null)
                    {
                        cmbCategoria.Text = p.Categoria;
                    }
                }
                else
                {
                    cmbCategoria.SelectedIndex = -1;
                    cmbCategoria.Text = string.Empty;
                }
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

        private void Limpiar()
        {
            _productoSeleccionadoId = null;
            txtNombre.Clear();
            txtPrecio.Clear();
            txtDescripcion.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbCategoria.Text = string.Empty;
            dgvProductos.ClearSelection();
        }
    }
}