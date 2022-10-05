using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_LibreriaDB.Migrations
{
    public partial class ActualizadoArticulosCampoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModificadoPorUserId",
                table: "Articulos",
                newName: "ModificadoPorUsuarioId");

            migrationBuilder.RenameColumn(
                name: "CreadoPorUserId",
                table: "Articulos",
                newName: "CreadoPorUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModificadoPorUsuarioId",
                table: "Articulos",
                newName: "ModificadoPorUserId");

            migrationBuilder.RenameColumn(
                name: "CreadoPorUsuarioId",
                table: "Articulos",
                newName: "CreadoPorUserId");
        }
    }
}
