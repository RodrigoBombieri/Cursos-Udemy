namespace BlazorEFUdemy.Modelo
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public int TipoProductoId { get; set; }
        public TipoProducto TipoProducto { get; set; } = null!;
    }
}
