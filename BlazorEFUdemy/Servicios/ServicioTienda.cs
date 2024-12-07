using BlazorEFUdemy.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BlazorEFUdemy.Servicios
{
    public class ServicioTienda : IServicioTienda
    {
        private readonly NuestraAplicacionDbcontext basedatos;
        public ServicioTienda(NuestraAplicacionDbcontext basedatos)
        {
            this.basedatos = basedatos;
        }
        public async Task<Tienda> AltaTienda(Tienda tienda)
        {
            basedatos.Add(tienda);
            await basedatos.SaveChangesAsync();
            return tienda;
        }

        public async Task<IEnumerable<Tienda>> DameTiendas()
        {
            return await basedatos.Tiendas.ToListAsync();
        }

        public async Task<Tienda> DameTienda(int id)
        {
            return await basedatos.Tiendas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task EliminarTienda(int id)
        {
            // Primero buscamos la tienda por su id y luego la elimino
            var tiendaAux = basedatos.Tiendas.FindAsync(id);
            basedatos.Remove(tiendaAux);
            await basedatos.SaveChangesAsync();
        }

        public async Task<Tienda> ModificarTienda(Tienda tienda)
        {
            basedatos.Update(tienda);
            await basedatos.SaveChangesAsync();
            return tienda;
        }
    }
}
