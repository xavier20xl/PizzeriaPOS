using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PizzeriaPOS.API.DTOs;
using PizzeriaPOS.Data.Context;
using PizzeriaPOS.Data.Entities;

namespace PizzeriaPOS.API.Services
{
    public class AuthService
    {
        private readonly PizzeriaDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(PizzeriaDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            // Verificar si el usuario ya existe
            if (await _context.Usuarios.AnyAsync(u => u.NombreUsuario == request.NombreUsuario))
            {
                throw new InvalidOperationException("El nombre de usuario ya está en uso.");
            }

            // Crear nuevo usuario
            var usuario = new Usuario
            {
                NombreUsuario = request.NombreUsuario,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                NombreCompleto = request.NombreCompleto
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Generar token
            return GenerateAuthResponse(usuario);
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == request.NombreUsuario && u.EstaActivo);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash))
            {
                throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
            }

            return GenerateAuthResponse(usuario);
        }

        private AuthResponse GenerateAuthResponse(Usuario usuario)
        {
            var token = GenerateJwtToken(usuario);
            return new AuthResponse
            {
                Token = token,
                NombreUsuario = usuario.NombreUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Expiracion = DateTime.UtcNow.AddHours(8)
            };
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "PizzeriaPOS_SuperSecretKey_2024_MinLength32Chars!"));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.GivenName, usuario.NombreCompleto ?? usuario.NombreUsuario)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"] ?? "PizzeriaPOS",
                audience: _configuration["Jwt:Audience"] ?? "PizzeriaPOSApp",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
