using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_LibreriaDB.Migrations
{
    public partial class CrearIndiceUnicoNoClusteredArticulosGeneros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ArticulosGeneros_ArticuloId",
                table: "ArticulosGeneros");

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosGeneros_ArticuloId_GeneroId",
                table: "ArticulosGeneros",
                columns: new[] { "ArticuloId", "GeneroId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ArticulosGeneros_ArticuloId_GeneroId",
                table: "ArticulosGeneros");

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosGeneros_ArticuloId",
                table: "ArticulosGeneros",
                column: "ArticuloId");
        }
    }
}
