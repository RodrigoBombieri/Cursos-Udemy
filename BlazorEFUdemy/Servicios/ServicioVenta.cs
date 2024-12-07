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

        public async Task AnularVenta(int idVenta)
        {
            var venta = await basedatos.Ventas.SingleOrDefaultAsync(venta => venta.Id == idVenta);
            if (venta != null)
            {
                // Anulamos la venta
                venta.FechaCancelacion = DateTime.Now;
                basedatos.Update(venta);
                // Actualizamos el stock del producto en la tienda
                var tiendaProducto = basedatos.TiendaProductos.SingleOrDefault(tp => tp.ProductoId == venta.ProductoId
                && tp.TiendaId == venta.TiendaId);
                if (tiendaProducto != null)
                {
                    // Actualizamos el stock
                    tiendaProducto.StockDisponible += venta.Cantidad;
                    basedatos.TiendaProductos.Update(tiendaProducto);
                }
                await basedatos.SaveChangesAsync();
            }
            else
            {
                throw new ApplicationException("No se encontró la venta");
            }   
        }

        public async Task<IEnumerable<Venta>> DameVentas(Tienda tienda)
        {
            // Nos traemos las ventas de la tienda que no han sido canceladas
            return await basedatos.Ventas.
                Where(v => v.TiendaId == tienda.Id && v.FechaCancelacion==null).
                Include(v => v.Producto).ToListAsync();
        }

        public async Task<Venta> GestionarVentas(Venta venta)
        {
            // Verificar si hay stock del producto en la tienda para el pedido
            var hayStock = await basedatos.TiendaProductos.AnyAsync(tp => tp.TiendaId == venta.TiendaId
            && tp.ProductoId == venta.ProductoId && tp.StockDisponible >= venta.Cantidad
            && tp.StockDisponible > 0);

            if (hayStock)
            {
                basedatos.Add(venta);
                // Localizamos el producto en la tienda y actualizamos el stock
                var tiendaProducto = basedatos.TiendaProductos.SingleOrDefault(tp => tp.ProductoId == venta.ProductoId 
                && tp.TiendaId == venta.TiendaId);
                if(tiendaProducto != null)
                {
                    // Actualizamos el stock
                    tiendaProducto.StockDisponible -= venta.Cantidad;
                    basedatos.TiendaProductos.Update(tiendaProducto);
                }
                await basedatos.SaveChangesAsync();
            }
            else
            {
                throw new ApplicationException("No hay stock disponible para el producto en la tienda");
            }
            return venta;
        }
    }
}
