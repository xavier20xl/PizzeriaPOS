using Microsoft.EntityFrameworkCore;
using PizzeriaPOS.Data.Context;
using PizzeriaPOS.Data.Entities;

namespace PizzeriaPOS.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PizzeriaDbContext _context;

        public PedidoRepository(PizzeriaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> GetAllAsync()
        {
            return await _context.Pedidos
                .Where(p => p.EstaActivo)
                .Include(p => p.Cliente)
                .Include(p => p.Direccion)
                .Include(p => p.Detalles)
                    .ThenInclude(d => d.Producto)
                .OrderByDescending(p => p.FechaPedido)
                .ToListAsync();
        }

        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Direccion)
                .Include(p => p.Detalles)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(p => p.Id == id && p.EstaActivo);
        }

        public async Task<Pedido> AddAsync(Pedido pedido)
        {
            pedido.FechaPedido = DateTime.UtcNow;
            pedido.Estado = "Pendiente";

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null) return false;

            pedido.EstaActivo = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PedidoDetalle> AddDetalleAsync(int pedidoId, PedidoDetalle detalle)
        {
            detalle.PedidoId = pedidoId;
            _context.PedidoDetalles.Add(detalle);
            await _context.SaveChangesAsync();

            var pedido = await _context.Pedidos.FindAsync(pedidoId);
            if (pedido != null)
            {
                pedido.Total = await _context.PedidoDetalles
                    .Where(d => d.PedidoId == pedidoId)
                    .SumAsync(d => d.Subtotal);
                await _context.SaveChangesAsync();
            }

            return detalle;
        }

        public async Task UpdateDetalleAsync(PedidoDetalle detalle)
        {
            _context.PedidoDetalles.Update(detalle);
            await _context.SaveChangesAsync();

            var pedido = await _context.Pedidos.FindAsync(detalle.PedidoId);
            if (pedido != null)
            {
                pedido.Total = await _context.PedidoDetalles
                    .Where(d => d.PedidoId == detalle.PedidoId)
                    .SumAsync(d => d.Subtotal);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteDetalleAsync(int detalleId)
        {
            var detalle = await _context.PedidoDetalles.FindAsync(detalleId);
            if (detalle == null) return false;

            var pedidoId = detalle.PedidoId;
            _context.PedidoDetalles.Remove(detalle);
            await _context.SaveChangesAsync();

            var pedido = await _context.Pedidos.FindAsync(pedidoId);
            if (pedido != null)
            {
                pedido.Total = await _context.PedidoDetalles
                    .Where(d => d.PedidoId == pedidoId)
                    .SumAsync(d => d.Subtotal);
                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
}
