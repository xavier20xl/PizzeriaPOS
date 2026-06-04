using Microsoft.EntityFrameworkCore;
using PizzeriaPOS.Data.Context;
using PizzeriaPOS.Data.Entities;
using PizzeriaPOS.Data.Repositories;

namespace PizzeriaPOS.Tests
{
    public class PedidoRepositoryTests
    {
        private PizzeriaDbContext GetInMemoryContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<PizzeriaDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new PizzeriaDbContext(options);
        }

        private async Task SeedTestData(PizzeriaDbContext context)
        {
            var cliente = new Cliente { Nombre = "Cliente Test", Telefono = "555-0001" };
            var producto = new Producto { Nombre = "Producto Test", Precio = 100.00m };

            context.Clientes.Add(cliente);
            context.Productos.Add(producto);
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task AddAsync_CreaPedidoConEstadoPendiente()
        {
            // Arrange
            var context = GetInMemoryContext("AddPedidoTest");
            await SeedTestData(context);
            var repository = new PedidoRepository(context);

            var cliente = await context.Clientes.FirstAsync();
            var pedido = new Pedido
            {
                ClienteId = cliente.Id,
                Notas = "Pedido de prueba"
            };

            // Act
            var result = await repository.AddAsync(pedido);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Id > 0);
            Assert.Equal("Pendiente", result.Estado);
            Assert.Equal(cliente.Id, result.ClienteId);
        }

        [Fact]
        public async Task AddDetalleAsync_ActualizaTotalDelPedido()
        {
            // Arrange
            var context = GetInMemoryContext("AddDetalleTest");
            await SeedTestData(context);
            var repository = new PedidoRepository(context);

            var cliente = await context.Clientes.FirstAsync();
            var producto = await context.Productos.FirstAsync();

            var pedido = new Pedido { ClienteId = cliente.Id };
            await repository.AddAsync(pedido);

            var detalle = new PedidoDetalle
            {
                ProductoId = producto.Id,
                Cantidad = 2,
                PrecioUnitario = producto.Precio,
                Subtotal = producto.Precio * 2
            };

            // Act
            var result = await repository.AddDetalleAsync(pedido.Id, detalle);

            // Assert
            Assert.NotNull(result);
            var pedidoActualizado = await context.Pedidos.FindAsync(pedido.Id);
            Assert.Equal(200.00m, pedidoActualizado!.Total);
        }

        [Fact]
        public async Task GetByIdAsync_RetornaPedidoConDetallesYRelaciones()
        {
            // Arrange
            var context = GetInMemoryContext("GetPedidoDetalleTest");
            await SeedTestData(context);
            var repository = new PedidoRepository(context);

            var cliente = await context.Clientes.FirstAsync();
            var producto = await context.Productos.FirstAsync();

            var pedido = new Pedido { ClienteId = cliente.Id, Total = 150.00m };
            context.Pedidos.Add(pedido);
            await context.SaveChangesAsync();

            var detalle = new PedidoDetalle
            {
                PedidoId = pedido.Id,
                ProductoId = producto.Id,
                Cantidad = 1,
                PrecioUnitario = 150.00m,
                Subtotal = 150.00m
            };
            context.PedidoDetalles.Add(detalle);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetByIdAsync(pedido.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(cliente.Nombre, result.Cliente?.Nombre);
            Assert.Single(result.Detalles);
            Assert.Equal(producto.Nombre, result.Detalles.First().Producto?.Nombre);
        }

        [Fact]
        public async Task GetAllAsync_RetornaSoloPedidosActivos()
        {
            // Arrange
            var context = GetInMemoryContext("GetAllPedidosTest");
            await SeedTestData(context);
            var repository = new PedidoRepository(context);

            var cliente = await context.Clientes.FirstAsync();

            context.Pedidos.AddRange(
                new Pedido { ClienteId = cliente.Id, EstaActivo = true },
                new Pedido { ClienteId = cliente.Id, EstaActivo = false },
                new Pedido { ClienteId = cliente.Id, EstaActivo = true }
            );
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, p => Assert.True(p.EstaActivo));
        }

        [Fact]
        public async Task DeleteAsync_RealizaBajaLogica()
        {
            // Arrange
            var context = GetInMemoryContext("DeletePedidoTest");
            await SeedTestData(context);
            var repository = new PedidoRepository(context);

            var cliente = await context.Clientes.FirstAsync();
            var pedido = new Pedido { ClienteId = cliente.Id, EstaActivo = true };
            context.Pedidos.Add(pedido);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.DeleteAsync(pedido.Id);

            // Assert
            Assert.True(result);
            var pedidoEliminado = await context.Pedidos.FindAsync(pedido.Id);
            Assert.False(pedidoEliminado!.EstaActivo);
        }
    }
}
