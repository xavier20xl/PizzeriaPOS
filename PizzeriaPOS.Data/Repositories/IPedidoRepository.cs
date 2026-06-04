using PizzeriaPOS.Data.Entities;

namespace PizzeriaPOS.Data.Repositories
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> GetAllAsync();
        Task<Pedido?> GetByIdAsync(int id);
        Task<Pedido> AddAsync(Pedido pedido);
        Task UpdateAsync(Pedido pedido);
        Task<bool> DeleteAsync(int id);

        // Métodos para detalles
        Task<PedidoDetalle> AddDetalleAsync(int pedidoId, PedidoDetalle detalle);
        Task UpdateDetalleAsync(PedidoDetalle detalle);
        Task<bool> DeleteDetalleAsync(int detalleId);
    }
}
