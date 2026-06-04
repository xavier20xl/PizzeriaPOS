using Microsoft.EntityFrameworkCore;
using PizzeriaPOS.Data.Context;
using PizzeriaPOS.Data.Entities;

namespace PizzeriaPOS.Data.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly PizzeriaDbContext _context;

        public ProductoRepository(PizzeriaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            return await _context.Productos
                .Where(producto => producto.EstaActivo)
                .OrderBy(producto => producto.Nombre)
                .ToListAsync();
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _context.Productos
                .FirstOrDefaultAsync(producto => producto.Id == id && producto.EstaActivo);
        }

        public async Task<Producto> AddAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task UpdateAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await GetByIdAsync(id);
            if (producto is null)
            {
                return false;
            }

            producto.EstaActivo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
