using EFCore_LibreriaDB.Migrations.Scripts;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_LibreriaDB.Migrations
{
    public partial class ModifProcListadoArticulosEliminadoGeneros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlRecurso("EFCore_LibreriaDB.Migrations.Scripts.Procedimientos.ListadoArticulos.ListadoArticulos.v1.sql");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlRecurso("EFCore_LibreriaDB.Migrations.Scripts.Procedimientos.ListadoArticulos.ListadoArticulos.v0.sql");
        }
    }
}
