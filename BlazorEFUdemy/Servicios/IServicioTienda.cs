using BlazorEFUdemy.Modelo;

namespace BlazorEFUdemy.Servicios
{
    public interface IServicioTienda
    {
        Task<IEnumerable<Tienda>> DameTiendas();
        Task<Tienda> AltaTienda(Tienda tienda);
        Task<Tienda> ModificarTienda(Tienda tienda);
        Task<Tienda> DameTienda(int id);
        Task EliminarTienda(int id);
    }
}
