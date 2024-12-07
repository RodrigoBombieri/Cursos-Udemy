using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorEFUdemy.Modelo.Configuracion
{
    public class TiendaProductoConfiguracion : IEntityTypeConfiguration<TiendaProducto>
    {
        public void Configure(EntityTypeBuilder<TiendaProducto> builder)
        {
            builder.HasKey(tp => tp.Id);
            // Para que la clave primaria se genere automaticamente
            builder.Property(tp => tp.Id).ValueGeneratedOnAdd();
        }
    }
}
