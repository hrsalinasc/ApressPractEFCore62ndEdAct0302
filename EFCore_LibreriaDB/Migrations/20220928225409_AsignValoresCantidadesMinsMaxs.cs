using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_LibreriaDB.Migrations
{
    public partial class AsignValoresCantidadesMinsMaxs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Articulos SET Cantidad = 0 WHERE Cantidad < 0");
            migrationBuilder.Sql("UPDATE Articulos SET Cantidad = 1000 WHERE Cantidad > 1000");
            migrationBuilder.Sql(@"
                IF NOT EXISTS(  SELECT * 
                                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                                WHERE CONSTRAINT_NAME = 'CK_Articulos_Cantidad_Minima'
                            )
                BEGIN
                    ALTER TABLE [dbo].[Articulos] ADD CONSTRAINT CK_Articulos_Cantidad_Minima CHECK (Cantidad >= 0)
                END
                IF NOT EXISTS(  SELECT * 
                                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                                WHERE CONSTRAINT_NAME = 'CK_Articulos_Cantidad_Maxima'
                            )
                BEGIN
                    ALTER TABLE [dbo].[Articulos] ADD CONSTRAINT CK_Articulos_Cantidad_Maxima CHECK (Cantidad <= 1000)
                END"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF EXISTS(  SELECT * 
                            FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                            WHERE CONSTRAINT_NAME = 'CK_Articulos_Cantidad_Minima'
                         )
                BEGIN
                    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT CK_Articulos_Cantidad_Minima
                END");
            migrationBuilder.Sql(@"
                IF EXISTS(  SELECT * 
                            FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                            WHERE CONSTRAINT_NAME = 'CK_Articulos_Cantidad_Maxima'
                         )
                BEGIN
                    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT CK_Articulos_Cantidad_Maxima
                END"
            );
        }
    }
}
