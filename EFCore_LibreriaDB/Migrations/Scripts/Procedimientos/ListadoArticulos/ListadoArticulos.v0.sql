CREATE OR ALTER PROCEDURE dbo.ListadoArticulos
    @fechaIni datetime = '2022-01-01T00:00:00.000'
    , @fechaFin datetime = '2022-12-31T23:59:59.999'
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        art.Nombre
        , art.Descripcion
        , art.Notas
        , art.EstaActivo
        , art.EstaEliminado
        , gen.Nombre GeneroNombre
        , cat.Nombre CategoriaNombre
    FROM
        dbo.Articulos art
        LEFT JOIN dbo.ArticulosGeneros arg ON arg.ArticuloId = art.id
        LEFT JOIN dbo.Generos gen ON gen.Id = arg.GeneroId
        LEFT JOIN dbo.Categorias cat ON cat.Id = art.CategoriaId
    WHERE
        (@fechaIni IS NULL OR art.FechaCreacion >= @fechaIni)
        AND (@fechaFin IS NULL OR art.FechaCreacion <= @fechaFin)
END
GO
