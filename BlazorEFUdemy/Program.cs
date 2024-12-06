
using BlazorEFUdemy.Servicios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace BlazorEFUdemy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            // Creamos el contexto de la base de datos aqui para que sea accesible en toda la aplicacion
            builder.Services.AddDbContext<NuestraAplicacionDbcontext>(
                options => options.UseSqlServer("name=SQL")
            );

            builder.Services.AddScoped<IServicioTipoProducto, ServicioTipoProducto>();
            builder.Services.AddScoped<IServicioTienda, ServicioTienda>();
            builder.Services.AddScoped<IServicioProducto, ServicioProducto>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
