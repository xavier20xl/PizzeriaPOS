using Microsoft.AspNetCore.Authorization;
using PizzeriaPOS.API.DTOs;
using PizzeriaPOS.Data.Entities;
using PizzeriaPOS.Data.Repositories;

namespace PizzeriaPOS.API.Endpoints
{
    public static class PedidosEndpoints
    {
        public static void MapPedidosEndpoints(this WebApplication app)
        {
            var pedidosGroup = app.MapGroup("/api/pedidos")
                .RequireAuthorization()
                .WithTags("Pedidos");

            // GET: Obtener todos los pedidos
            pedidosGroup.MapGet("/", async (IPedidoRepository repo) =>
            {
                var pedidos = await repo.GetAllAsync();
                return Results.Ok(pedidos.Select(p => MapToDto(p)));
            });

            // GET: Obtener pedido por ID
            pedidosGroup.MapGet("/{id}", async (int id, IPedidoRepository repo) =>
            {
                var pedido = await repo.GetByIdAsync(id);
                if (pedido == null)
                    return Results.NotFound(new { message = "Pedido no encontrado." });

                return Results.Ok(MapToDto(pedido));
            });

            // POST: Crear pedido
            pedidosGroup.MapPost("/", async (CrearPedidoRequest request, IPedidoRepository repo, IProductoRepository productoRepo) =>
            {
                var pedido = new Pedido
                {
                    ClienteId = request.ClienteId,
                    DireccionId = request.DireccionId,
                    Notas = request.Notas,
                    Total = 0
                };

                var result = await repo.AddAsync(pedido);

                // Agregar detalles
                foreach (var detalleRequest in request.Detalles)
                {
                    var producto = await productoRepo.GetByIdAsync(detalleRequest.ProductoId);
                    if (producto == null)
                        continue;

                    var detalle = new PedidoDetalle
                    {
                        ProductoId = detalleRequest.ProductoId,
                        Cantidad = detalleRequest.Cantidad,
                        PrecioUnitario = producto.Precio,
                        Subtotal = producto.Precio * detalleRequest.Cantidad,
                        Notas = detalleRequest.Notas
                    };

                    await repo.AddDetalleAsync(result.Id, detalle);
                }

                // Recargar pedido con detalles
                var pedidoCompleto = await repo.GetByIdAsync(result.Id);
                return Results.Created($"/api/pedidos/{result.Id}", MapToDto(pedidoCompleto!));
            });

            // PUT: Actualizar pedido
            pedidosGroup.MapPut("/{id}", async (int id, ActualizarPedidoRequest request, IPedidoRepository repo) =>
            {
                var pedido = await repo.GetByIdAsync(id);
                if (pedido == null)
                    return Results.NotFound(new { message = "Pedido no encontrado." });

                if (request.Estado != null)
                    pedido.Estado = request.Estado;

                if (request.Notas != null)
                    pedido.Notas = request.Notas;

                if (request.DireccionId.HasValue)
                    pedido.DireccionId = request.DireccionId;

                await repo.UpdateAsync(pedido);
                return Results.Ok(MapToDto(pedido));
            });

            // DELETE: Eliminar pedido (baja lógica)
            pedidosGroup.MapDelete("/{id}", async (int id, IPedidoRepository repo) =>
            {
                var result = await repo.DeleteAsync(id);
                if (!result)
                    return Results.NotFound(new { message = "Pedido no encontrado." });

                return Results.NoContent();
            });

            // POST: Agregar detalle a pedido
            pedidosGroup.MapPost("/{id}/detalles", async (int id, AgregarDetalleRequest request, IPedidoRepository repo, IProductoRepository productoRepo) =>
            {
                var pedido = await repo.GetByIdAsync(id);
                if (pedido == null)
                    return Results.NotFound(new { message = "Pedido no encontrado." });

                var producto = await productoRepo.GetByIdAsync(request.ProductoId);
                if (producto == null)
                    return Results.NotFound(new { message = "Producto no encontrado." });

                var detalle = new PedidoDetalle
                {
                    ProductoId = request.ProductoId,
                    Cantidad = request.Cantidad,
                    PrecioUnitario = producto.Precio,
                    Subtotal = producto.Precio * request.Cantidad,
                    Notas = request.Notas
                };

                await repo.AddDetalleAsync(id, detalle);

                var pedidoActualizado = await repo.GetByIdAsync(id);
                return Results.Ok(MapToDto(pedidoActualizado!));
            });

            // DELETE: Eliminar detalle de pedido
            pedidosGroup.MapDelete("/{pedidoId}/detalles/{detalleId}", async (int pedidoId, int detalleId, IPedidoRepository repo) =>
            {
                var result = await repo.DeleteDetalleAsync(detalleId);
                if (!result)
                    return Results.NotFound(new { message = "Detalle no encontrado." });

                return Results.NoContent();
            });
        }

        private static PedidoDto MapToDto(Pedido pedido)
        {
            return new PedidoDto
            {
                Id = pedido.Id,
                FechaPedido = pedido.FechaPedido,
                Total = pedido.Total,
                Estado = pedido.Estado,
                Notas = pedido.Notas,
                ClienteId = pedido.ClienteId,
                ClienteNombre = pedido.Cliente?.Nombre,
                DireccionId = pedido.DireccionId,
                DireccionCompleta = pedido.Direccion != null
                    ? $"{pedido.Direccion.Calle} {pedido.Direccion.Numero}, {pedido.Direccion.Colonia}, {pedido.Direccion.Ciudad}"
                    : null,
                Detalles = pedido.Detalles?.Select(d => new PedidoDetalleDto
                {
                    Id = d.Id,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    Subtotal = d.Subtotal,
                    Notas = d.Notas,
                    ProductoId = d.ProductoId,
                    ProductoNombre = d.Producto?.Nombre
                }).ToList() ?? new List<PedidoDetalleDto>()
            };
        }
    }
}
