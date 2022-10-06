using EFCore_LibreriaDB.Migrations.Scripts;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_LibreriaDB.Migrations
{
    public partial class CrearFuncionArticulosValorTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlRecurso("EFCore_LibreriaDB.Migrations.Scripts.Funciones.ArticulosValorTotal.ArticulosValorTotal.v0.sql");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS dbo.ArticulosValorTotal");
        }
    }
}
