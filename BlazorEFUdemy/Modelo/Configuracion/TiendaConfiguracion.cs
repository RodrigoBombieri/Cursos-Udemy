using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BlazorEFUdemy.Modelo.Configuracion
{
    public class TiendaConfiguracion : IEntityTypeConfiguration<Tienda>
    {
        public void Configure(EntityTypeBuilder<Tienda> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(200);
            builder.Property(x => x.Direccion).HasMaxLength(300);
            builder.Property(x => x.SitioWeb).HasMaxLength(1000);
            builder.Property(x => x.FechaApertura).HasColumnType("date");
        }
    }
}
