namespace PizzeriaPOS.Data.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; } = DateTime.UtcNow;
        public decimal Total { get; set; }
        public string? Estado { get; set; } = "Pendiente";
        public string? Notas { get; set; }
        public bool EstaActivo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public int ClienteId { get; set; }
        public int? DireccionId { get; set; }

        public Cliente? Cliente { get; set; }
        public Direccion? Direccion { get; set; }
        public ICollection<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();
    }
}
