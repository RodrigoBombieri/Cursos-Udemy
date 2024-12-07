using BlazorEFUdemy.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BlazorEFUdemy.Servicios
{
    
    public class ServicioVenta : IServicioVenta
    {
        private readonly NuestraAplicacionDbcontext basedatos;
        public ServicioVenta(NuestraAplicacionDbcontext basedatos)
        {
            this.basedatos = basedatos;
        }
        public async Task<IEnumerable<Venta>> DameVentas(Tienda tienda)
        {
            // Nos traemos las ventas de la tienda
            return await basedatos.Ventas.Include(v=> v.Producto).Where(tp => tp.TiendaId == tienda.Id).ToListAsync();
        }

        public async Task<Venta> GestionarVentas(Venta venta)
        {
            basedatos.Add(venta);
            await basedatos.SaveChangesAsync();
            return venta;
        }
    }
}
