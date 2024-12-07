using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BlazorEFUdemy.Modelo.Configuracion
{
    public class VentaConfiguracion : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.Property(v => v.PrecioVenta).HasPrecision(10, 2);

            // Restriccion para que no se pueda eliminar un producto si tiene ventas asociadas
            // Una tienda puede tener N ventas
            builder.HasOne(v => v.Tienda)
                .WithMany(t => t.Ventas)
                .HasForeignKey(v => v.TiendaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Un producto puede tener N ventas
            builder.HasOne(v => v.Producto)
                .WithMany(p => p.Ventas)
                .HasForeignKey(v => v.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
