using BlazorEFUdemy.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BlazorEFUdemy.Servicios
{
    public class ServicioProducto : IServicioProducto
    {
        private readonly NuestraAplicacionDbcontext basedatos;
        public ServicioProducto(NuestraAplicacionDbcontext basedatos)
        {
            this.basedatos = basedatos;
        }
        public async Task<Producto> AltaProducto(Producto producto)
        {
            basedatos.Add(producto);
            await basedatos.SaveChangesAsync();
            return producto;
        }

        public async Task<Producto> DameProducto(int id)
        {
            return await basedatos.Productos.Include(p => p.TipoProducto).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Producto>> DameProductos()
        {
            return await basedatos.Productos.Include(p => p.TipoProducto).ToListAsync();
        }

        public async Task EliminarProducto(int id)
        {
            // Buscamos el producto por id
            var productoAux = await basedatos.Productos.FindAsync(id);
            basedatos.Remove(productoAux);
            await basedatos.SaveChangesAsync();
        }

        public async Task<Producto> ModificarProducto(Producto producto)
        {
            basedatos.Update(producto);
            await basedatos.SaveChangesAsync();
            return producto;
        }
    }
}
