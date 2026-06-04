using System.ComponentModel.DataAnnotations;

namespace PizzeriaPOS.API.DTOs
{
    public class PedidoDto
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
        public List<PedidoDetalleDto> Detalles { get; set; } = new();
    }

    public class PedidoDetalleDto
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
        [Required]
        public int ClienteId { get; set; }

        public int? DireccionId { get; set; }

        [MaxLength(500)]
        public string? Notas { get; set; }

        [Required]
        [MinLength(1)]
        public List<CrearPedidoDetalleRequest> Detalles { get; set; } = new();
    }

    public class CrearPedidoDetalleRequest
    {
        [Required]
        public int ProductoId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Cantidad { get; set; }

        [MaxLength(300)]
        public string? Notas { get; set; }
    }

    public class ActualizarPedidoRequest
    {
        [MaxLength(50)]
        public string? Estado { get; set; }

        [MaxLength(500)]
        public string? Notas { get; set; }

        public int? DireccionId { get; set; }
    }

    public class AgregarDetalleRequest
    {
        [Required]
        public int ProductoId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Cantidad { get; set; }

        [MaxLength(300)]
        public string? Notas { get; set; }
    }
}
