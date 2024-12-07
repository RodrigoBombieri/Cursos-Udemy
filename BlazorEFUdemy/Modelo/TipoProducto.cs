using System.ComponentModel.DataAnnotations;

namespace BlazorEFUdemy.Modelo
{
    public class TipoProducto
    {
        // Usamos DataAnnotations para definir las restricciones de la base de datos
        // [Key]
        public int Id { get; set; }
        // [Required]
        // [StringLength(maximumLength:300)]
        public string Tipo { get; set; } = null!;
    }
}
