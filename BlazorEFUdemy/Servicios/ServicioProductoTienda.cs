using BlazorEFUdemy.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BlazorEFUdemy.Servicios
{
    public class ServicioProductoTienda : IServicioProductoTienda
    {
        private readonly NuestraAplicacionDbcontext basedatos;
        public ServicioProductoTienda(NuestraAplicacionDbcontext basedatos)
        {
            this.basedatos = basedatos;
        }
        public async Task<IEnumerable<TiendaProducto>> DameProductosTienda(Tienda tienda)
        {
            // Obtener los productos de la tienda y filtrar por la tienda
            var productos = await basedatos.TiendaProductos.
                Where(tp => tp.TiendaId == tienda.Id).
                Include(tp => tp.Producto).
                ToArrayAsync();

            return productos;
        }

        public async Task<TiendaProducto> GestionarProductoTienda(TiendaProducto tiendaProducto)
        {
            // Verificar si existe el producto en la tienda
            var existeTiendaProducto = await basedatos.TiendaProductos.
                FirstOrDefaultAsync(tp=> tp.TiendaId == tiendaProducto.TiendaId &&
                tp.ProductoId == tiendaProducto.ProductoId);

            if(existeTiendaProducto == null)
            {
                // Si no existe, lo agregamos
                basedatos.TiendaProductos.Add(tiendaProducto);
            }
            else
            {
                // Si existe, actualizamos el stock
                existeTiendaProducto.StockDisponible = tiendaProducto.StockDisponible;
                basedatos.TiendaProductos.Update(existeTiendaProducto);
            }
            await basedatos.SaveChangesAsync();
            // Retornamos el objeto actualizado
            return tiendaProducto;
        }
    }
}
