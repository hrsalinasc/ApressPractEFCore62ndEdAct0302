using EFCore_LibreriaDB.Migrations.Scripts;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_LibreriaDB.Migrations
{
    public partial class CreaFuncionArticulosNombresCadenaDelimBarra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlRecurso("EFCore_LibreriaDB.Migrations.Scripts.Funciones.ArticulosNombresCadenaDelimBarra.ArticulosNombresCadenaDelimBarra.v0.sql");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS dbo.ArticulosNombresCadenaDelimBarra");
        }
    }
}
