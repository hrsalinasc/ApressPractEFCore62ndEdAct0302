using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_LibreriaDB.Migrations
{
    public partial class ActualizadoTablaArticulos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EstaEnVenta",
                table: "Articulos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCompra",
                table: "Articulos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVenta",
                table: "Articulos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notas",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioCompra",
                table: "Articulos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioFinalOActual",
                table: "Articulos",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "EstaEnVenta",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "FechaCompra",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "FechaVenta",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Notas",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "PrecioCompra",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "PrecioFinalOActual",
                table: "Articulos");
        }
    }
}
