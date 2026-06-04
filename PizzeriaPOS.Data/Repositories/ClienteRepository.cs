using Microsoft.EntityFrameworkCore;
using PizzeriaPOS.Data.Context;
using PizzeriaPOS.Data.Entities;

namespace PizzeriaPOS.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PizzeriaDbContext _context;

        public ClienteRepository(PizzeriaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes
                .Where(c => c.EstaActivo)
                .OrderBy(c => c.Nombre)
                .ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == id && c.EstaActivo);
        }

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            cliente.EstaActivo = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Direccion>> GetDireccionesAsync(int clienteId)
        {
            return await _context.Direcciones
                .Where(d => d.ClienteId == clienteId && d.EstaActivo)
                .OrderByDescending(d => d.EsPrincipal)
                .ThenBy(d => d.Calle)
                .ToListAsync();
        }

        public async Task<Direccion> AddDireccionAsync(int clienteId, Direccion direccion)
        {
            direccion.ClienteId = clienteId;
            _context.Direcciones.Add(direccion);
            await _context.SaveChangesAsync();
            return direccion;
        }

        public async Task UpdateDireccionAsync(Direccion direccion)
        {
            _context.Direcciones.Update(direccion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteDireccionAsync(int direccionId)
        {
            var direccion = await _context.Direcciones.FindAsync(direccionId);
            if (direccion == null) return false;

            direccion.EstaActivo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
