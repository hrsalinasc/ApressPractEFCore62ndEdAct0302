using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_LibreriaDB.Migrations
{
    public partial class AgregadoCategoriaDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ColorValor = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ColorNombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriaDetalles_Categorias_Id",
                        column: x => x.Id,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaDetalles");
        }
    }
}
