using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BlazorEFUdemy.Modelo.Configuracion
{
    public class VentaConfiguracion : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.HasKey(v => new { v.TiendaId, v.ProductoId }); // Clave compuesta
            builder.Property(v => v.PrecioVenta).HasPrecision(10, 2);
        }
    }
}
