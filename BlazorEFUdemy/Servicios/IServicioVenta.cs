using BlazorEFUdemy.Modelo;

namespace BlazorEFUdemy.Servicios
{
    public interface IServicioVenta
    {
        Task<IEnumerable<Venta>> DameVentas(Tienda tienda);
        Task AnularVenta(int idVenta);
        Task<Venta> GestionarVentas(Venta venta);
    }
}
