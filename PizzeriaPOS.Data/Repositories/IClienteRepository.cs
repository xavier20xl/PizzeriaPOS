using PizzeriaPOS.Data.Entities;

namespace PizzeriaPOS.Data.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task<Cliente> AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task<bool> DeleteAsync(int id);

        // Métodos para direcciones
        Task<List<Direccion>> GetDireccionesAsync(int clienteId);
        Task<Direccion> AddDireccionAsync(int clienteId, Direccion direccion);
        Task UpdateDireccionAsync(Direccion direccion);
        Task<bool> DeleteDireccionAsync(int direccionId);
    }
}
