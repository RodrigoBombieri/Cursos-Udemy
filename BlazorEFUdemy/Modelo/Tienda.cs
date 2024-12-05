using System.ComponentModel.DataAnnotations;

namespace BlazorEFUdemy.Modelo
{
    public class Tienda
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la tienda es obligatorio")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La dirección de la tienda es obligatoria")]
        public string Direccion { get; set; } = null!;
        [Required(ErrorMessage = "* Campo obligatorio")]
        [Url(ErrorMessage = "La dirección web no es válida")]
        public string SitioWeb { get; set; } = null!;
        public DateTime FechaApertura { get; set; }
        public List<TiendaProducto> TiendaProductos { get; set; } = new List<TiendaProducto>();
        public List<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
