using EFCore_LibreriaDB.Migrations.Scripts;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_LibreriaDB.Migrations
{
    public partial class CreadoVistaArticulosDetalles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlRecurso("EFCore_LibreriaDB.Migrations.Scripts.Vistas.ArticulosDetalles.ArticulosDetalles.v0.sql");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS [dbo].[vwArticulosDetalles]");
        }
    }
}
