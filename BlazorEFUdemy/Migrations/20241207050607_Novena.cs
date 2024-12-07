using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEFUdemy.Migrations
{
    /// <inheritdoc />
    public partial class Novena : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crear una nueva tabla temporal con las columnas correctas
            migrationBuilder.CreateTable(
                name: "VentasTemp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TiendaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasTemp", x => x.Id);
                });

            // Copiar datos desde la tabla original a la nueva tabla
            migrationBuilder.Sql(@"
        INSERT INTO VentasTemp (TiendaId, ProductoId, PrecioVenta, FechaVenta) 
        SELECT TiendaId, ProductoId, PrecioVenta, FechaVenta FROM Ventas
    ");

            // Eliminar la tabla original
            migrationBuilder.DropTable(name: "Ventas");

            // Renombrar la tabla temporal a la tabla original
            migrationBuilder.RenameTable(name: "VentasTemp", newName: "Ventas");

            // Crear el índice si es necesario
            migrationBuilder.CreateIndex(
                name: "IX_Ventas_TiendaId",
                table: "Ventas",
                column: "TiendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Crear la tabla original nuevamente
            migrationBuilder.CreateTable(
                name: "VentasOriginal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TiendaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasOriginal", x => x.Id);
                });

            // Copiar los datos de vuelta a la tabla original
            migrationBuilder.Sql(@"
        INSERT INTO VentasOriginal (TiendaId, ProductoId, PrecioVenta, FechaVenta) 
        SELECT TiendaId, ProductoId, PrecioVenta, FechaVenta FROM Ventas
    ");

            // Eliminar la tabla actual
            migrationBuilder.DropTable(name: "Ventas");

            // Renombrar la tabla original
            migrationBuilder.RenameTable(name: "VentasOriginal", newName: "Ventas");
        }

    }
}
