using System.Text.Json.Serialization;

namespace PizzeriaPOS.WinForms.Models
{
    // Modelos de Autenticación
    public class LoginRequest
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterRequest
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? NombreCompleto { get; set; }
    }

    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string? NombreCompleto { get; set; }
        public DateTime Expiracion { get; set; }
    }

    // Modelos de Producto
    public class ProductoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Categoria { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class CrearProductoRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Categoria { get; set; }
    }

    // Modelos de Cliente
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<DireccionModel> Direcciones { get; set; } = new();
    }

    public class CrearClienteRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }

    public class DireccionModel
    {
        public int Id { get; set; }
        public string Calle { get; set; } = string.Empty;
        public string? Numero { get; set; }
        public string? Colonia { get; set; }
        public string? Ciudad { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Referencia { get; set; }
        public bool EsPrincipal { get; set; }
        public bool EstaActivo { get; set; }
    }

    public class CrearDireccionRequest
    {
        public string Calle { get; set; } = string.Empty;
        public string? Numero { get; set; }
        public string? Colonia { get; set; }
        public string? Ciudad { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Referencia { get; set; }
        public bool EsPrincipal { get; set; }
    }

    // Modelos de Pedido
    public class PedidoModel
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal Total { get; set; }
        public string? Estado { get; set; }
        public string? Notas { get; set; }
        public int ClienteId { get; set; }
        public string? ClienteNombre { get; set; }
        public int? DireccionId { get; set; }
        public string? DireccionCompleta { get; set; }
        public List<PedidoDetalleModel> Detalles { get; set; } = new();
    }

    public class PedidoDetalleModel
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public string? Notas { get; set; }
        public int ProductoId { get; set; }
        public string? ProductoNombre { get; set; }
    }

    public class CrearPedidoRequest
    {
        public int ClienteId { get; set; }
        public int? DireccionId { get; set; }
        public string? Notas { get; set; }
        public List<CrearPedidoDetalleRequest> Detalles { get; set; } = new();
    }

    public class CrearPedidoDetalleRequest
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public string? Notas { get; set; }
    }
}
