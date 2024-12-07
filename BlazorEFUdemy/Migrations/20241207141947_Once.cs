using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEFUdemy.Migrations
{
    /// <inheritdoc />
    public partial class Once : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TiendaProductos_Productos_ProductoId",
                table: "TiendaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_TiendaProductos_Tiendas_TiendaId",
                table: "TiendaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Productos_ProductoId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Tiendas_TiendaId",
                table: "Ventas");

            migrationBuilder.AddForeignKey(
                name: "FK_TiendaProductos_Productos_ProductoId",
                table: "TiendaProductos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TiendaProductos_Tiendas_TiendaId",
                table: "TiendaProductos",
                column: "TiendaId",
                principalTable: "Tiendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Productos_ProductoId",
                table: "Ventas",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Tiendas_TiendaId",
                table: "Ventas",
                column: "TiendaId",
                principalTable: "Tiendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TiendaProductos_Productos_ProductoId",
                table: "TiendaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_TiendaProductos_Tiendas_TiendaId",
                table: "TiendaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Productos_ProductoId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Tiendas_TiendaId",
                table: "Ventas");

            migrationBuilder.AddForeignKey(
                name: "FK_TiendaProductos_Productos_ProductoId",
                table: "TiendaProductos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TiendaProductos_Tiendas_TiendaId",
                table: "TiendaProductos",
                column: "TiendaId",
                principalTable: "Tiendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Productos_ProductoId",
                table: "Ventas",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Tiendas_TiendaId",
                table: "Ventas",
                column: "TiendaId",
                principalTable: "Tiendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
