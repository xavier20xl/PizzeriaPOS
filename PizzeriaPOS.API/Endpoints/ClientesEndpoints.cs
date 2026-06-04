using Microsoft.AspNetCore.Authorization;
using PizzeriaPOS.API.DTOs;
using PizzeriaPOS.Data.Entities;
using PizzeriaPOS.Data.Repositories;

namespace PizzeriaPOS.API.Endpoints
{
    public static class ClientesEndpoints
    {
        public static void MapClientesEndpoints(this WebApplication app)
        {
            var clientesGroup = app.MapGroup("/api/clientes")
                .RequireAuthorization()
                .WithTags("Clientes");

            // GET: Obtener todos los clientes
            clientesGroup.MapGet("/", async (IClienteRepository repo) =>
            {
                var clientes = await repo.GetAllAsync();
                return Results.Ok(clientes.Select(c => MapToDto(c)));
            });

            // GET: Obtener cliente por ID
            clientesGroup.MapGet("/{id}", async (int id, IClienteRepository repo) =>
            {
                var cliente = await repo.GetByIdAsync(id);
                if (cliente == null)
                    return Results.NotFound(new { message = "Cliente no encontrado." });

                return Results.Ok(MapToDto(cliente));
            });

            // POST: Crear cliente
            clientesGroup.MapPost("/", async (CrearClienteRequest request, IClienteRepository repo) =>
            {
                var cliente = new Cliente
                {
                    Nombre = request.Nombre,
                    Telefono = request.Telefono,
                    Email = request.Email
                };

                var result = await repo.AddAsync(cliente);
                return Results.Created($"/api/clientes/{result.Id}", MapToDto(result));
            });

            // PUT: Actualizar cliente
            clientesGroup.MapPut("/{id}", async (int id, ActualizarClienteRequest request, IClienteRepository repo) =>
            {
                var cliente = await repo.GetByIdAsync(id);
                if (cliente == null)
                    return Results.NotFound(new { message = "Cliente no encontrado." });

                cliente.Nombre = request.Nombre;
                cliente.Telefono = request.Telefono;
                cliente.Email = request.Email;

                await repo.UpdateAsync(cliente);
                return Results.Ok(MapToDto(cliente));
            });

            // DELETE: Eliminar cliente (baja lógica)
            clientesGroup.MapDelete("/{id}", async (int id, IClienteRepository repo) =>
            {
                var result = await repo.DeleteAsync(id);
                if (!result)
                    return Results.NotFound(new { message = "Cliente no encontrado." });

                return Results.NoContent();
            });

            // Direcciones del cliente
            MapDireccionesEndpoints(clientesGroup);
        }

        private static void MapDireccionesEndpoints(RouteGroupBuilder clientesGroup)
        {
            // GET: Obtener direcciones de un cliente
            clientesGroup.MapGet("/{clienteId}/direcciones", async (int clienteId, IClienteRepository repo) =>
            {
                var cliente = await repo.GetByIdAsync(clienteId);
                if (cliente == null)
                    return Results.NotFound(new { message = "Cliente no encontrado." });

                var direcciones = await repo.GetDireccionesAsync(clienteId);
                return Results.Ok(direcciones.Select(d => MapDireccionToDto(d)));
            });

            // POST: Agregar dirección a cliente
            clientesGroup.MapPost("/{clienteId}/direcciones", async (int clienteId, CrearDireccionRequest request, IClienteRepository repo) =>
            {
                var cliente = await repo.GetByIdAsync(clienteId);
                if (cliente == null)
                    return Results.NotFound(new { message = "Cliente no encontrado." });

                var direccion = new Direccion
                {
                    Calle = request.Calle,
                    Numero = request.Numero,
                    Colonia = request.Colonia,
                    Ciudad = request.Ciudad,
                    CodigoPostal = request.CodigoPostal,
                    Referencia = request.Referencia,
                    EsPrincipal = request.EsPrincipal
                };

                var result = await repo.AddDireccionAsync(clienteId, direccion);
                return Results.Created($"/api/clientes/{clienteId}/direcciones/{result.Id}", MapDireccionToDto(result));
            });

            // PUT: Actualizar dirección
            clientesGroup.MapPut("/{clienteId}/direcciones/{direccionId}", async (int clienteId, int direccionId, ActualizarDireccionRequest request, IClienteRepository repo) =>
            {
                var direcciones = await repo.GetDireccionesAsync(clienteId);
                var direccion = direcciones.FirstOrDefault(d => d.Id == direccionId);

                if (direccion == null)
                    return Results.NotFound(new { message = "Dirección no encontrada." });

                direccion.Calle = request.Calle;
                direccion.Numero = request.Numero;
                direccion.Colonia = request.Colonia;
                direccion.Ciudad = request.Ciudad;
                direccion.CodigoPostal = request.CodigoPostal;
                direccion.Referencia = request.Referencia;
                direccion.EsPrincipal = request.EsPrincipal;

                await repo.UpdateDireccionAsync(direccion);
                return Results.Ok(MapDireccionToDto(direccion));
            });

            // DELETE: Eliminar dirección
            clientesGroup.MapDelete("/{clienteId}/direcciones/{direccionId}", async (int clienteId, int direccionId, IClienteRepository repo) =>
            {
                var result = await repo.DeleteDireccionAsync(direccionId);
                if (!result)
                    return Results.NotFound(new { message = "Dirección no encontrada." });

                return Results.NoContent();
            });
        }

        private static ClienteDto MapToDto(Cliente cliente)
        {
            return new ClienteDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                EstaActivo = cliente.EstaActivo,
                FechaCreacion = cliente.FechaCreacion,
                Direcciones = cliente.Direcciones?
                    .Where(d => d.EstaActivo)
                    .Select(d => MapDireccionToDto(d))
                    .ToList() ?? new List<DireccionDto>()
            };
        }

        private static DireccionDto MapDireccionToDto(Direccion direccion)
        {
            return new DireccionDto
            {
                Id = direccion.Id,
                Calle = direccion.Calle,
                Numero = direccion.Numero,
                Colonia = direccion.Colonia,
                Ciudad = direccion.Ciudad,
                CodigoPostal = direccion.CodigoPostal,
                Referencia = direccion.Referencia,
                EsPrincipal = direccion.EsPrincipal,
                EstaActivo = direccion.EstaActivo
            };
        }
    }
}
