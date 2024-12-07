namespace BlazorEFUdemy.Modelo
{
    public class Venta
    {
        public int Id { get; set; }
        public int TiendaId { get; set; } 
        public Tienda Tienda { get; set; } = null!;
        public int ProductoId { get; set; } 
        public Producto Producto { get; set; } = null!;
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}
