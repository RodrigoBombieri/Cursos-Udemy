namespace BlazorEFUdemy.Modelo
{
    public class Venta
    {
        public int Id { get; set; }
        public int TiendaId { get; set; } 
        public int ProductoId { get; set; } 
        public Tienda Tienda { get; set; } = null!;
        public Producto Producto { get; set; } = null!;
        public decimal PrecioVenta { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}
