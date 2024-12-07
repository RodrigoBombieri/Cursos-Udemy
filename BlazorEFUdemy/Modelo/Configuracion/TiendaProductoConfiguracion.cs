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
            // Restriccion para que no se pueda eliminar un producto si tiene ventas asociadas
            // Un producto puede estar en varias tiendas
            builder.HasOne(tp => tp.Producto).WithMany(tp => tp.tiendasProducto)
                .HasForeignKey(tp => tp.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Restriccion para que no se pueda eliminar una tienda si tiene ventas asociadas
            // Una tienda puede tener varios productos
            builder.HasOne(tp => tp.Tienda).WithMany(t => t.TiendaProductos)
                .HasForeignKey(tp => tp.TiendaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
