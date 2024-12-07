using System.ComponentModel.DataAnnotations;

namespace BlazorEFUdemy.Modelo
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* Campo Obligatorio")]
        public string Descripcion { get; set; } = null!;
        [Required(ErrorMessage = "* Campo Obligatorio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "* Campo Obligatorio")]
        public int TipoProductoId { get; set; }
        public TipoProducto TipoProducto { get; set; } = null!;
        public ICollection<Venta> Ventas { get; set; }
        public ICollection<TiendaProducto> tiendasProducto { get; set; }
    }
}
