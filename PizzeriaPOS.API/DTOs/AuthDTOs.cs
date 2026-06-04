using System.ComponentModel.DataAnnotations;

namespace PizzeriaPOS.API.DTOs
{
    public class RegisterRequest
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? NombreCompleto { get; set; }
    }

    public class LoginRequest
    {
        [Required]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string? NombreCompleto { get; set; }
        public DateTime Expiracion { get; set; }
    }
}
