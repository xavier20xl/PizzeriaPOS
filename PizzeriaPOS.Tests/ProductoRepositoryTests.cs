using Microsoft.EntityFrameworkCore;
using PizzeriaPOS.Data.Context;
using PizzeriaPOS.Data.Entities;
using PizzeriaPOS.Data.Repositories;

namespace PizzeriaPOS.Tests
{
    public class ProductoRepositoryTests
    {
        [Fact]
        public async Task AddAsync_GuardaProducto()
        {
            using var context = CreateContext();
            var repository = new ProductoRepository(context);
            var producto = new Producto
            {
                Nombre = "Pizza Pepperoni",
                Descripcion = "Pizza mediana con pepperoni.",
                Precio = 249.00m,
                Categoria = "Pizza"
            };

            var created = await repository.AddAsync(producto);

            Assert.True(created.Id > 0);
            Assert.Single(context.Productos);
            Assert.Equal("Pizza Pepperoni", context.Productos.Single().Nombre);
        }

        [Fact]
        public async Task GetAllAsync_RetornaSoloProductosActivosOrdenadosPorNombre()
        {
            using var context = CreateContext();
            context.Productos.AddRange(
                new Producto { Nombre = "Refresco", Precio = 55.00m, Categoria = "Bebida" },
                new Producto { Nombre = "Pizza Hawaiana", Precio = 239.00m, Categoria = "Pizza" },
                new Producto { Nombre = "Calzone", Precio = 199.00m, Categoria = "Pizza", EstaActivo = false });
            await context.SaveChangesAsync();
            var repository = new ProductoRepository(context);

            var productos = await repository.GetAllAsync();

            Assert.Equal(2, productos.Count);
            Assert.Collection(
                productos,
                producto => Assert.Equal("Pizza Hawaiana", producto.Nombre),
                producto => Assert.Equal("Refresco", producto.Nombre));
        }

        [Fact]
        public async Task GetByIdAsync_RetornaNullCuandoProductoNoExisteOEstaInactivo()
        {
            using var context = CreateContext();
            var inactive = new Producto { Nombre = "Pizza Inactiva", Precio = 100.00m, EstaActivo = false };
            context.Productos.Add(inactive);
            await context.SaveChangesAsync();
            var repository = new ProductoRepository(context);

            var inactiveResult = await repository.GetByIdAsync(inactive.Id);
            var missingResult = await repository.GetByIdAsync(999);

            Assert.Null(inactiveResult);
            Assert.Null(missingResult);
        }

        [Fact]
        public async Task UpdateAsync_ActualizaProductoExistente()
        {
            using var context = CreateContext();
            var producto = new Producto { Nombre = "Pizza Queso", Precio = 200.00m, Categoria = "Pizza" };
            context.Productos.Add(producto);
            await context.SaveChangesAsync();
            var repository = new ProductoRepository(context);

            producto.Nombre = "Pizza Extra Queso";
            producto.Precio = 225.00m;
            await repository.UpdateAsync(producto);

            var updated = await context.Productos.FindAsync(producto.Id);
            Assert.NotNull(updated);
            Assert.Equal("Pizza Extra Queso", updated.Nombre);
            Assert.Equal(225.00m, updated.Precio);
        }

        [Fact]
        public async Task DeleteAsync_DesactivaProductoExistente()
        {
            using var context = CreateContext();
            var producto = new Producto { Nombre = "Pizza Vegetariana", Precio = 230.00m, Categoria = "Pizza" };
            context.Productos.Add(producto);
            await context.SaveChangesAsync();
            var repository = new ProductoRepository(context);

            var deleted = await repository.DeleteAsync(producto.Id);

            Assert.True(deleted);
            Assert.False(producto.EstaActivo);
            Assert.Empty(await repository.GetAllAsync());
        }

        [Fact]
        public async Task DeleteAsync_RetornaFalseCuandoProductoNoExiste()
        {
            using var context = CreateContext();
            var repository = new ProductoRepository(context);

            var deleted = await repository.DeleteAsync(999);

            Assert.False(deleted);
        }

        private static PizzeriaDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<PizzeriaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new PizzeriaDbContext(options);
        }
    }
}
