using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PizzeriaPOS.API.Endpoints;
using PizzeriaPOS.API.Services;
using PizzeriaPOS.Data;
using PizzeriaPOS.Data.Entities;
using PizzeriaPOS.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar JWT
var jwtKey = builder.Configuration["Jwt:Key"] ?? "PizzeriaPOS_SuperSecretKey_2024_MinLength32Chars!";
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "PizzeriaPOS";
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? "PizzeriaPOSApp";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();

// Registrar servicios
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzeriaPOS API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Registrar capa de datos
builder.Services.AddDataLayer(builder.Configuration);

// Registrar AuthService
builder.Services.AddScoped<AuthService>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

// Health check
app.MapGet("/api/health", () => Results.Ok(new { status = "OK", timestamp = DateTime.UtcNow }))
    .WithTags("Health")
    .AllowAnonymous();

// Endpoints de autenticación
app.MapAuthEndpoints();

// Categorías de productos para ComboBox
app.MapGet("/api/productos/categorias", async (IProductoRepository repo) =>
{
    var productos = await repo.GetAllAsync();
    var categorias = productos
        .Where(p => !string.IsNullOrWhiteSpace(p.Categoria))
        .Select(p => p.Categoria!)
        .Distinct()
        .OrderBy(c => c)
        .ToList();

    return Results.Ok(categorias);
})
.WithTags("Productos")
.RequireAuthorization();

// Endpoints de productos
app.MapGet("/api/productos", async (IProductoRepository repo) =>
{
    var productos = await repo.GetAllAsync();
    return Results.Ok(productos);
})
.WithTags("Productos");

app.MapGet("/api/productos/{id}", async (int id, IProductoRepository repo) =>
{
    var producto = await repo.GetByIdAsync(id);
    if (producto == null)
        return Results.NotFound(new { message = "Producto no encontrado." });
    return Results.Ok(producto);
})
.WithTags("Productos")
.RequireAuthorization();

app.MapPost("/api/productos", async (ProductoDto productoDto, IProductoRepository repo) =>
{
    var producto = new Producto
    {
        Nombre = productoDto.Nombre,
        Descripcion = productoDto.Descripcion,
        Precio = productoDto.Precio,
        Categoria = productoDto.Categoria
    };

    var result = await repo.AddAsync(producto);
    return Results.Created($"/api/productos/{result.Id}", result);
})
.WithTags("Productos")
.RequireAuthorization();

app.MapPut("/api/productos/{id}", async (int id, ProductoDto productoDto, IProductoRepository repo) =>
{
    var producto = await repo.GetByIdAsync(id);
    if (producto == null)
        return Results.NotFound(new { message = "Producto no encontrado." });

    producto.Nombre = productoDto.Nombre;
    producto.Descripcion = productoDto.Descripcion;
    producto.Precio = productoDto.Precio;
    producto.Categoria = productoDto.Categoria;

    await repo.UpdateAsync(producto);
    return Results.Ok(producto);
})
.WithTags("Productos")
.RequireAuthorization();

app.MapDelete("/api/productos/{id}", async (int id, IProductoRepository repo) =>
{
    var result = await repo.DeleteAsync(id);
    if (!result)
        return Results.NotFound(new { message = "Producto no encontrado." });
    return Results.NoContent();
})
.WithTags("Productos")
.RequireAuthorization();

// Endpoints de clientes
app.MapClientesEndpoints();

// Endpoints de pedidos
app.MapPedidosEndpoints();

app.Run();

// DTO para productos
record ProductoDto(string Nombre, string? Descripcion, decimal Precio, string? Categoria);