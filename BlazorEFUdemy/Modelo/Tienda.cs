namespace BlazorEFUdemy.Modelo
{
    public class Tienda
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string SitioWeb { get; set; } = null!;
        public DateTime FechaApertura { get; set; }
        public List<TiendaProducto> TiendaProductos { get; set; } = new List<TiendaProducto>();
        public List<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
