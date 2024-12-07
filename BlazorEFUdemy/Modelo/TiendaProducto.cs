using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEFUdemy.Modelo
{
    public class TiendaProducto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TiendaId { get; set; } // Clave foranea de la tabla Tienda
        public int ProductoId { get; set; } // Clave foranea de la tabla Producto
        public Tienda Tienda { get; set; } = null!;
        public Producto Producto { get; set; } = null!;
        public int StockDisponible { get; set; }
    }
}
