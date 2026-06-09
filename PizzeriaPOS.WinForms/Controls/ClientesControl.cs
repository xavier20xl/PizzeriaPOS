using PizzeriaPOS.WinForms.Models;
using PizzeriaPOS.WinForms.Services;

namespace PizzeriaPOS.WinForms.Forms
{
    public partial class ClientesControl : UserControl
    {
        private readonly ApiClient _apiClient;
        private int? _clienteSeleccionadoId;
        private int? _direccionSeleccionadaId;
        private List<ClienteModel> _clientesCache = new();
        private bool _cargandoDatos;

        public ClientesControl(ApiClient apiClient)
        {
            // Estilos horneados en ClientesControl.Designer.cs — sin Theme.
            InitializeComponent();
            _apiClient = apiClient;
        }

        private void ClientesControl_Load(object sender, EventArgs e)
        {
            _ = CargarClientesAsync();
        }

        private async Task CargarClientesAsync()
        {
            try
            {
                _cargandoDatos = true;
                _clientesCache = await _apiClient.GetAsync<List<ClienteModel>>("/api/clientes") ?? new List<ClienteModel>();
                AplicarFiltroClientes();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error al cargar clientes: " + ex.Message;
            }
            finally
            {
                _cargandoDatos = false;
            }
        }

        private void AplicarFiltroClientes()
        {
            var filtro = txtNombre.Text.Trim().ToLowerInvariant();

            var filtrados = _clientesCache
                .Where(c => string.IsNullOrWhiteSpace(filtro) || c.Nombre.ToLowerInvariant().Contains(filtro))
                .ToList();

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = filtrados;

            // Ocultar columnas innecesarias
            if (dgvClientes.Columns["Id"] != null) dgvClientes.Columns["Id"].Visible = false;
            if (dgvClientes.Columns["EstaActivo"] != null) dgvClientes.Columns["EstaActivo"].Visible = false;
            if (dgvClientes.Columns["FechaCreacion"] != null) dgvClientes.Columns["FechaCreacion"].Visible = false;
            if (dgvClientes.Columns["Direcciones"] != null) dgvClientes.Columns["Direcciones"].Visible = false;

            // Ajustar tamaño de columnas
            if (dgvClientes.Columns["Nombre"] != null)
            {
                dgvClientes.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if (dgvClientes.Columns["Telefono"] != null)
            {
                dgvClientes.Columns["Telefono"].HeaderText = "Teléfono";
                dgvClientes.Columns["Telefono"].Width = 90;
                dgvClientes.Columns["Telefono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            if (dgvClientes.Columns["Email"] != null)
            {
                dgvClientes.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvClientes.ClearSelection();
            dgvClientes.CurrentCell = null;

            lblStatus.Text = filtrados.Count == 0
                ? "No hay clientes que coincidan."
                : $"Clientes: {filtrados.Count}";
        }

        private async Task CargarDireccionesAsync(int clienteId)
        {
            try
            {
                var direcciones = await _apiClient.GetAsync<List<DireccionModel>>($"/api/clientes/{clienteId}/direcciones");
                dgvDirecciones.DataSource = null;
                if (direcciones != null && direcciones.Count > 0)
                {
                    dgvDirecciones.DataSource = direcciones;

                    // Ocultar columnas innecesarias
                    if (dgvDirecciones.Columns["Id"] != null) dgvDirecciones.Columns["Id"].Visible = false;
                    if (dgvDirecciones.Columns["EstaActivo"] != null) dgvDirecciones.Columns["EstaActivo"].Visible = false;
                    if (dgvDirecciones.Columns["ClienteId"] != null) dgvDirecciones.Columns["ClienteId"].Visible = false;
                    if (dgvDirecciones.Columns["FechaCreacion"] != null) dgvDirecciones.Columns["FechaCreacion"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargandoDatos) return;
            if (dgvClientes.SelectedRows.Count == 0) return;
            if (dgvClientes.SelectedRows[0].DataBoundItem is not ClienteModel c) return;

            _cargandoDatos = true;
            try
            {
                _clienteSeleccionadoId = c.Id;
                txtNombre.Text = c.Nombre;
                txtTelefono.Text = c.Telefono ?? "";
                txtEmail.Text = c.Email ?? "";
            }
            finally
            {
                _cargandoDatos = false;
            }

            _ = CargarDireccionesAsync(c.Id);
        }

        private void dgvDirecciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDirecciones.SelectedRows.Count == 0) return;
            if (dgvDirecciones.SelectedRows[0].DataBoundItem is not DireccionModel d) return;

            _direccionSeleccionadaId = d.Id;
            txtCalle.Text = d.Calle;
            txtNumero.Text = d.Numero ?? "";
            txtColonia.Text = d.Colonia ?? "";
            txtCiudad.Text = d.Ciudad ?? "";
            txtCodigoPostal.Text = d.CodigoPostal ?? "";
            txtReferencia.Text = d.Referencia ?? "";
            chkEsPrincipal.Checked = d.EsPrincipal;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (_cargandoDatos) return;
            // Si hay un cliente seleccionado no filtramos para no interrumpir la edición
            if (_clienteSeleccionadoId.HasValue) return;
            AplicarFiltroClientes();
        }

        private async void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { lblStatus.Text = "Nombre obligatorio."; return; }
            try
            {
                await _apiClient.PostAsync<ClienteModel>("/api/clientes", new CrearClienteRequest
                {
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text
                });
                lblStatus.Text = "Cliente agregado.";
                LimpiarCliente();
                await CargarClientesAsync();
            }
            catch (Exception ex) { lblStatus.Text = "Error: " + ex.Message; }
        }

        private async void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            if (!_clienteSeleccionadoId.HasValue) { lblStatus.Text = "Seleccione cliente."; return; }
            try
            {
                await _apiClient.PutAsync($"/api/clientes/{_clienteSeleccionadoId}", new CrearClienteRequest
                {
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text
                });
                lblStatus.Text = "Cliente actualizado.";
                LimpiarCliente();
                await CargarClientesAsync();
            }
            catch (Exception ex) { lblStatus.Text = "Error: " + ex.Message; }
        }

        private async void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (!_clienteSeleccionadoId.HasValue) return;
            if (MessageBox.Show("¿Eliminar cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteAsync($"/api/clientes/{_clienteSeleccionadoId}");
                    lblStatus.Text = "Cliente eliminado.";
                    LimpiarCliente();
                    dgvDirecciones.DataSource = null;
                    await CargarClientesAsync();
                }
                catch (Exception ex) { lblStatus.Text = "Error: " + ex.Message; }
            }
        }

        private async void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            if (!_clienteSeleccionadoId.HasValue) { lblStatus.Text = "Seleccione cliente."; return; }
            if (string.IsNullOrWhiteSpace(txtCalle.Text)) { lblStatus.Text = "Calle obligatoria."; return; }
            try
            {
                await _apiClient.PostAsync<DireccionModel>($"/api/clientes/{_clienteSeleccionadoId}/direcciones", new CrearDireccionRequest
                {
                    Calle = txtCalle.Text,
                    Numero = txtNumero.Text,
                    Colonia = txtColonia.Text,
                    Ciudad = txtCiudad.Text,
                    CodigoPostal = txtCodigoPostal.Text,
                    Referencia = txtReferencia.Text,
                    EsPrincipal = chkEsPrincipal.Checked
                });
                lblStatus.Text = "Dirección agregada.";
                LimpiarDireccion();
                await CargarDireccionesAsync(_clienteSeleccionadoId.Value);
            }
            catch (Exception ex) { lblStatus.Text = "Error: " + ex.Message; }
        }

        private async void btnActualizarDireccion_Click(object sender, EventArgs e)
        {
            if (!_clienteSeleccionadoId.HasValue || !_direccionSeleccionadaId.HasValue) { lblStatus.Text = "Seleccione dirección."; return; }
            try
            {
                await _apiClient.PutAsync($"/api/clientes/{_clienteSeleccionadoId}/direcciones/{_direccionSeleccionadaId}", new CrearDireccionRequest
                {
                    Calle = txtCalle.Text,
                    Numero = txtNumero.Text,
                    Colonia = txtColonia.Text,
                    Ciudad = txtCiudad.Text,
                    CodigoPostal = txtCodigoPostal.Text,
                    Referencia = txtReferencia.Text,
                    EsPrincipal = chkEsPrincipal.Checked
                });
                lblStatus.Text = "Dirección actualizada.";
                await CargarDireccionesAsync(_clienteSeleccionadoId.Value);
            }
            catch (Exception ex) { lblStatus.Text = "Error: " + ex.Message; }
        }

        private async void btnEliminarDireccion_Click(object sender, EventArgs e)
        {
            if (!_clienteSeleccionadoId.HasValue || !_direccionSeleccionadaId.HasValue) return;
            if (MessageBox.Show("¿Eliminar dirección?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteAsync($"/api/clientes/{_clienteSeleccionadoId}/direcciones/{_direccionSeleccionadaId}");
                    lblStatus.Text = "Dirección eliminada.";
                    LimpiarDireccion();
                    await CargarDireccionesAsync(_clienteSeleccionadoId.Value);
                }
                catch (Exception ex) { lblStatus.Text = "Error: " + ex.Message; }
            }
        }

        private void btnLimpiarCliente_Click(object sender, EventArgs e) => LimpiarCliente();
        private void btnLimpiarDireccion_Click(object sender, EventArgs e) => LimpiarDireccion();

        private void LimpiarCliente()
        {
            _clienteSeleccionadoId = null;
            _cargandoDatos = true;
            txtNombre.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            _cargandoDatos = false;
            dgvClientes.ClearSelection();
            dgvClientes.CurrentCell = null;
            dgvDirecciones.DataSource = null;
            LimpiarDireccion();
        }

        private void LimpiarDireccion()
        {
            _direccionSeleccionadaId = null;
            txtCalle.Clear();
            txtNumero.Clear();
            txtColonia.Clear();
            txtCiudad.Clear();
            txtCodigoPostal.Clear();
            txtReferencia.Clear();
            chkEsPrincipal.Checked = false;
            dgvDirecciones.ClearSelection();
        }
    }
}
