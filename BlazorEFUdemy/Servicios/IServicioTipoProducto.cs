using BlazorEFUdemy.Modelo;

namespace BlazorEFUdemy.Servicios
{
    public interface IServicioTipoProducto
    {
        // Usamos Task porque es una operación asincrona, es decir que no se bloquea el hilo principal
        Task<IEnumerable<TipoProducto>> DameTiposProductos();
        Task<TipoProducto> AltaTipoProducto(TipoProducto tipoProducto);
        Task<TipoProducto> ModificarTipoProducto(TipoProducto tipoProducto);
        Task<TipoProducto> DameTipoProducto(int id);
        Task BorrarTipoProducto(int id);
    }
}
