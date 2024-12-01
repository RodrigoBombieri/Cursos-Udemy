using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BlazorEFUdemy.Modelo.Configuracion
{
    public class TipoProductoConfiguracion : IEntityTypeConfiguration<TipoProducto>
    {
        public void Configure(EntityTypeBuilder<TipoProducto> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Tipo).HasMaxLength(500).IsRequired();
        }
    }
}
