using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_LibreriaDB.Migrations
{
    public partial class CreadoArticulosGenerosYRelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticulosGeneros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulosGeneros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticulosGeneros_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticulosGeneros_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosGeneros_ArticuloId",
                table: "ArticulosGeneros",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosGeneros_GeneroId",
                table: "ArticulosGeneros",
                column: "GeneroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticulosGeneros");
        }
    }
}
