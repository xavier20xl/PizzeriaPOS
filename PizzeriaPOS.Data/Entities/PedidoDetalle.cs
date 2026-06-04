using System.Text.Json.Serialization;

namespace PizzeriaPOS.Data.Entities
{
    public class PedidoDetalle
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public string? Notas { get; set; }

        public int PedidoId { get; set; }
        public int ProductoId { get; set; }

        [JsonIgnore]
        public Pedido? Pedido { get; set; }

        public Producto? Producto { get; set; }
    }
}
