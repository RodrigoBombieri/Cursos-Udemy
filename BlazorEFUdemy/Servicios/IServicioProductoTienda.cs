using BlazorEFUdemy.Modelo;

namespace BlazorEFUdemy.Servicios
{
    public interface IServicioProductoTienda
    {
        Task<IEnumerable<TiendaProducto>> DameProductosTienda(Tienda tienda);
        Task<TiendaProducto> GestionarProductoTienda(TiendaProducto tiendaProducto);
    }
}
