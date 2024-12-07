using BlazorEFUdemy.Modelo;

namespace BlazorEFUdemy.Servicios
{
    public interface IServicioProducto
    {
        Task<Producto> AltaProducto(Producto producto);
        Task<IEnumerable<Producto>> DameProductos();
        Task<Producto> DameProducto(int id);
        Task EliminarProducto(int id);
        Task<Producto> ModificarProducto(Producto producto);
    }
}
