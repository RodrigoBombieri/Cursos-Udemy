using BlazorEFUdemy.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BlazorEFUdemy.Servicios
{
    public class ServicioTipoProducto : IServicioTipoProducto
    {
        private readonly NuestraAplicacionDbcontext basedatos;
        public ServicioTipoProducto(NuestraAplicacionDbcontext basedatos)
        {
            this.basedatos = basedatos;
        }
        public async Task<TipoProducto> AltaTipoProducto(TipoProducto tipoProducto)
        {
            // Add() es un método de Entity Framework Core que añade una entidad a la base de datos
            // Es decir, que cuando se haga un SaveChangesAsync() se inserte la entidad en la base de datos
            basedatos.Add(tipoProducto);
            // SaveChangesAsync() guarda los cambios en la base de datos, es async
            // porque es una operación que puede tardar y no queremos bloquear el hilo principal
            await basedatos.SaveChangesAsync();
            return tipoProducto;
        }

        public async Task BorrarTipoProducto(int id)
        {
            // FirstOrDefaultAsync() devuelve el primer elemento que cumple la condición
            // o null si no hay ninguno
            Task<TipoProducto> tipoProducto = basedatos.TipoProducto.FirstOrDefaultAsync(x => x.Id == id);
            // Remove() es un método de Entity Framework Core que elimina una entidad de la base de datos
            // Es decir, que cuando se haga un SaveChangesAsync() se elimine la entidad de la base de datos
            if (tipoProducto != null)
            {
                basedatos.TipoProducto.Remove(tipoProducto.Result);
                await basedatos.SaveChangesAsync();
            }
        }

        public async Task<TipoProducto> DameTipoProducto(int id)
        {
            return await basedatos.TipoProducto.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TipoProducto>> DameTiposProductos()
        {
            // ToListAsync() devuelve una lista de tipo IEnumerable
            return await basedatos.TipoProducto.ToListAsync();
        }

        public async Task<TipoProducto> ModificarTipoProducto(TipoProducto tipoProducto)
        {
            // El método Update() es de Entity Framework Core y se encarga de marcar la entidad como modificada
            // Es decir, que cuando se haga un SaveChangesAsync() se actualice la entidad en la base de datos
            basedatos.Update(tipoProducto);
            // SaveChangesAsync() guarda los cambios en la base de datos
            await basedatos.SaveChangesAsync();
            return tipoProducto;
        }
    }
}
