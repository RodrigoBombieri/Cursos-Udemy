using BlazorEFUdemy.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BlazorEFUdemy
{
    public class NuestraAplicacionDbcontext : DbContext
    {
        public NuestraAplicacionDbcontext(DbContextOptions<NuestraAplicacionDbcontext> options) : base(options)
        {

        }

        // API de Fluent para agregar restricciones a la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Pasamos la configuraciones de las entidades a sus respectivas clases (Modelo/Configuracion)

            // FORMA 1
            //modelBuilder.Entity<TipoProducto>().HasKey(t => t.Id);
            //modelBuilder.Entity<TipoProducto>().Property(t => t.Tipo).HasMaxLength(500).IsRequired();

            //modelBuilder.Entity<Producto>().Property(x =>x.Descripcion).HasMaxLength(500);
            //modelBuilder.Entity<Producto>().Property(x => x.Precio).HasPrecision(10,2);

            //modelBuilder.Entity<Tienda>().Property(x => x.Nombre).HasMaxLength(200);
            //modelBuilder.Entity<Tienda>().Property(x => x.Direccion).HasMaxLength(300);
            //modelBuilder.Entity<Tienda>().Property(x => x.SitioWeb).HasMaxLength(1000);
            //modelBuilder.Entity<Tienda>().Property(x => x.FechaApertura).HasColumnType("date");

            //modelBuilder.Entity<Venta>().HasKey(v=> new {v.TiendaId, v.ProductoId}); // Clave compuesta
            //modelBuilder.Entity<Venta>().Property(v => v.PrecioVenta).HasPrecision(10, 2);

            // FORMA 2
            // Para enlazar con las configuraciones de las entidades de la carpeta Configuracion
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NuestraAplicacionDbcontext).Assembly);
        }

        public DbSet<TipoProducto> TipoProducto => Set<TipoProducto>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Tienda> Tiendas => Set<Tienda>();
        public DbSet<TiendaProducto> TiendaProductos => Set<TiendaProducto>();
        public DbSet<Venta> Ventas => Set<Venta>();

    }
}
