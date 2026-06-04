using System.ComponentModel.DataAnnotations;

namespace PizzeriaPOS.API.DTOs
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<DireccionDto> Direcciones { get; set; } = new();
    }

    public class CrearClienteRequest
    {
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Telefono { get; set; }

        [MaxLength(200)]
        [EmailAddress]
        public string? Email { get; set; }
    }

    public class ActualizarClienteRequest
    {
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Telefono { get; set; }

        [MaxLength(200)]
        [EmailAddress]
        public string? Email { get; set; }
    }

    public class DireccionDto
    {
        public int Id { get; set; }
        public string Calle { get; set; } = string.Empty;
        public string? Numero { get; set; }
        public string? Colonia { get; set; }
        public string? Ciudad { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Referencia { get; set; }
        public bool EsPrincipal { get; set; }
        public bool EstaActivo { get; set; }
    }

    public class CrearDireccionRequest
    {
        [Required]
        [MaxLength(200)]
        public string Calle { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Numero { get; set; }

        [MaxLength(200)]
        public string? Colonia { get; set; }

        [MaxLength(100)]
        public string? Ciudad { get; set; }

        [MaxLength(10)]
        public string? CodigoPostal { get; set; }

        [MaxLength(500)]
        public string? Referencia { get; set; }

        public bool EsPrincipal { get; set; } = false;
    }

    public class ActualizarDireccionRequest
    {
        [Required]
        [MaxLength(200)]
        public string Calle { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Numero { get; set; }

        [MaxLength(200)]
        public string? Colonia { get; set; }

        [MaxLength(100)]
        public string? Ciudad { get; set; }

        [MaxLength(10)]
        public string? CodigoPostal { get; set; }

        [MaxLength(500)]
        public string? Referencia { get; set; }

        public bool EsPrincipal { get; set; } = false;
    }
}

