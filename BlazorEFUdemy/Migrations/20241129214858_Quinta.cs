using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEFUdemy.Migrations
{
    /// <inheritdoc />
    public partial class Quinta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_TipoProducto_TipoProductoId",
                table: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producto",
                table: "Producto");

            migrationBuilder.RenameTable(
                name: "Producto",
                newName: "Productos");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_TipoProductoId",
                table: "Productos",
                newName: "IX_Productos_TipoProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tiendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SitioWeb = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FechaApertura = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiendas", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_TipoProducto_TipoProductoId",
                table: "Productos",
                column: "TipoProductoId",
                principalTable: "TipoProducto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_TipoProducto_TipoProductoId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Tiendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Producto");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_TipoProductoId",
                table: "Producto",
                newName: "IX_Producto_TipoProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producto",
                table: "Producto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_TipoProducto_TipoProductoId",
                table: "Producto",
                column: "TipoProductoId",
                principalTable: "TipoProducto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
