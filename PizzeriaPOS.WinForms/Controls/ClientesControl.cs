using PizzeriaPOS.WinForms.Models;
using PizzeriaPOS.WinForms.Services;

namespace PizzeriaPOS.WinForms.Forms
{
    public partial class ClientesControl : UserControl
    {
        private readonly ApiClient _apiClient;
        private int? _clienteSeleccionadoId;
        private int? _direccionSeleccionadaId;

        public ClientesControl(ApiClient apiClient)
        {
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
                var clientes = await _apiClient.GetAsync<List<ClienteModel>>("/api/clientes");
                if (clientes != null && clientes.Count > 0)
                {
                    dgvClientes.DataSource = null;
                    dgvClientes.DataSource = clientes;

                    // Ocultar columnas de forma segura
                    if (dgvClientes.Columns["Id"] != null) dgvClientes.Columns["Id"].Visible = false;
                    if (dgvClientes.Columns["EstaActivo"] != null) dgvClientes.Columns["EstaActivo"].Visible = false;
                    if (dgvClientes.Columns["FechaCreacion"] != null) dgvClientes.Columns["FechaCreacion"].Visible = false;
                    if (dgvClientes.Columns["Direcciones"] != null) dgvClientes.Columns["Direcciones"].Visible = false;

                    lblStatus.Text = $"Clientes cargados: {clientes.Count}";
                }
                else
                {
                    lblStatus.Text = "No hay clientes. Agregue uno nuevo.";
                    dgvClientes.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error al cargar clientes: " + ex.Message;
            }
        }


        private async Task CargarDireccionesAsync(int clienteId)
        {
            try
            {
                var direcciones = await _apiClient.GetAsync<List<DireccionModel>>($"/api/clientes/{clienteId}/direcciones");
                dgvDirecciones.DataSource = null;
                if (direcciones != null && direcciones.Count > 0)
                    dgvDirecciones.DataSource = direcciones;
            }
            catch (Exception ex) { lblStatus.Text = "Error: " + ex.Message; }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0 && dgvClientes.SelectedRows[0].DataBoundItem is ClienteModel c)
            {
                _clienteSeleccionadoId = c.Id;
                txtNombre.Text = c.Nombre;
                txtTelefono.Text = c.Telefono ?? "";
                txtEmail.Text = c.Email ?? "";
                _ = CargarDireccionesAsync(c.Id);
            }
        }

        private void dgvDirecciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDirecciones.SelectedRows.Count > 0 && dgvDirecciones.SelectedRows[0].DataBoundItem is DireccionModel d)
            {
                _direccionSeleccionadaId = d.Id;
                txtCalle.Text = d.Calle;
                txtNumero.Text = d.Numero ?? "";
                txtColonia.Text = d.Colonia ?? "";
                txtCiudad.Text = d.Ciudad ?? "";
                txtCodigoPostal.Text = d.CodigoPostal ?? "";
                txtReferencia.Text = d.Referencia ?? "";
                chkEsPrincipal.Checked = d.EsPrincipal;
            }
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

        private void btnLimpiarCliente_Click(object sender, EventArgs e) { LimpiarCliente(); }
        private void btnLimpiarDireccion_Click(object sender, EventArgs e) { LimpiarDireccion(); }

        private void LimpiarCliente()
        {
            _clienteSeleccionadoId = null;
            txtNombre.Clear(); txtTelefono.Clear(); txtEmail.Clear();
            dgvClientes.ClearSelection(); dgvDirecciones.DataSource = null;
        }

        private void LimpiarDireccion()
        {
            _direccionSeleccionadaId = null;
            txtCalle.Clear(); txtNumero.Clear(); txtColonia.Clear();
            txtCiudad.Clear(); txtCodigoPostal.Clear(); txtReferencia.Clear();
            chkEsPrincipal.Checked = false; dgvDirecciones.ClearSelection();
        }
    }
}
