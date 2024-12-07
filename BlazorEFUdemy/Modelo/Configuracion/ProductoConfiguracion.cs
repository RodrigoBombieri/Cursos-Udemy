using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BlazorEFUdemy.Modelo.Configuracion
{
    public class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(501);
            builder.Property(x => x.Precio).HasPrecision(10, 2);
            // Restriccion para que no se pueda eliminar un tipo de producto si tiene productos asociados
           
        }
    }
}
