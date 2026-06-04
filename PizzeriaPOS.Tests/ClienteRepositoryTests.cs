using Microsoft.EntityFrameworkCore;
using PizzeriaPOS.Data.Context;
using PizzeriaPOS.Data.Entities;
using PizzeriaPOS.Data.Repositories;

namespace PizzeriaPOS.Tests
{
    public class ClienteRepositoryTests
    {
        private PizzeriaDbContext GetInMemoryContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<PizzeriaDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new PizzeriaDbContext(options);
        }

        [Fact]
        public async Task AddAsync_GuardaClienteCorrectamente()
        {
            // Arrange
            var context = GetInMemoryContext("AddClienteTest");
            var repository = new ClienteRepository(context);
            var cliente = new Cliente
            {
                Nombre = "Ana Martínez",
                Telefono = "555-2001",
                Email = "ana.martinez@email.com"
            };

            // Act
            var result = await repository.AddAsync(cliente);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Id > 0);
            Assert.Equal("Ana Martínez", result.Nombre);
        }

        [Fact]
        public async Task GetAllAsync_RetornaSoloClientesActivos()
        {
            // Arrange
            var context = GetInMemoryContext("GetClientesTest");
            var repository = new ClienteRepository(context);

            context.Clientes.AddRange(
                new Cliente { Nombre = "Cliente Activo", EstaActivo = true },
                new Cliente { Nombre = "Cliente Inactivo", EstaActivo = false },
                new Cliente { Nombre = "Otro Activo", EstaActivo = true }
            );
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, c => Assert.True(c.EstaActivo));
        }

        [Fact]
        public async Task DeleteAsync_RealizaBajaLogica()
        {
            // Arrange
            var context = GetInMemoryContext("DeleteClienteTest");
            var repository = new ClienteRepository(context);

            var cliente = new Cliente { Nombre = "Para Eliminar", EstaActivo = true };
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.DeleteAsync(cliente.Id);

            // Assert
            Assert.True(result);
            var clienteEliminado = await context.Clientes.FindAsync(cliente.Id);
            Assert.NotNull(clienteEliminado);
            Assert.False(clienteEliminado!.EstaActivo);
        }

        [Fact]
        public async Task AddDireccionAsync_AsociaDireccionACliente()
        {
            // Arrange
            var context = GetInMemoryContext("AddDireccionTest");
            var repository = new ClienteRepository(context);

            var cliente = new Cliente { Nombre = "Con Direcciones" };
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            var direccion = new Direccion
            {
                Calle = "Calle Nueva",
                Numero = "100",
                Ciudad = "Test City",
                EsPrincipal = true
            };

            // Act
            var result = await repository.AddDireccionAsync(cliente.Id, direccion);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(cliente.Id, result.ClienteId);
            Assert.Equal("Calle Nueva", result.Calle);
        }

        [Fact]
        public async Task GetDireccionesAsync_RetornaSoloDireccionesActivasDelCliente()
        {
            // Arrange
            var context = GetInMemoryContext("GetDireccionesTest");
            var repository = new ClienteRepository(context);

            var cliente = new Cliente { Nombre = "Cliente Con Direcciones" };
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            context.Direcciones.AddRange(
                new Direccion { ClienteId = cliente.Id, Calle = "Dirección 1", EstaActivo = true },
                new Direccion { ClienteId = cliente.Id, Calle = "Dirección 2", EstaActivo = false },
                new Direccion { ClienteId = cliente.Id, Calle = "Dirección 3", EstaActivo = true }
            );
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetDireccionesAsync(cliente.Id);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, d => Assert.True(d.EstaActivo));
        }
    }
}
