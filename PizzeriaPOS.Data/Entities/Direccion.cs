using System.Text.Json.Serialization;

namespace PizzeriaPOS.Data.Entities
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; } = string.Empty;
        public string? Numero { get; set; }
        public string? Colonia { get; set; }
        public string? Ciudad { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Referencia { get; set; }
        public bool EsPrincipal { get; set; } = false;
        public bool EstaActivo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public int ClienteId { get; set; }

        [JsonIgnore]
        public Cliente? Cliente { get; set; }
    }
}
