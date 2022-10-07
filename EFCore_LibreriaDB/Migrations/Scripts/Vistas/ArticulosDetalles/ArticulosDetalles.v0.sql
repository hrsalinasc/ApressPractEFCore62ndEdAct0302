CREATE OR ALTER VIEW [dbo].[vwArticulosDetalles]
AS
SELECT
	arti.Id
	, arti.Nombre ArticuloNombre
	, arti.Descripcion ArticuloDescripcion
	, arti.EstaActivo
	, arti.EstaEliminado
	, arti.Notas
	, arti.PrecioFinalOActual
	, arti.EstaEnVenta
	, arti.FechaCompra
	, arti.PrecioCompra
	, arti.Cantidad
	, arti.FechaVenta
	, cate.Nombre CategoriaNombre
	, cate.EstaActivo CategoriaEstaActivo
	, cate.EstaEliminado CategoriaEstaEliminado
	, cateDet.ColorNombre CategoriaDetalleColorNombre
	, cateDet.ColorValor CategoriaDetalleColorValor
	, parti.Nombre ParticipanteNombre
	, parti.Descripcion ParticipanteDescripcion
	, parti.EstaActivo ParticipanteEstaActivo
	, parti.EstaEliminado ParticipanteEstaEliminado
	, gene.Nombre GeneroNombre
	, gene.EstaActivo GeneroEstaActivo
	, gene.EstaEliminado GeneroEstaEliminado
FROM
	Articulos arti
	LEFT JOIN Categorias cate ON arti.CategoriaId = cate.Id
	LEFT JOIN CategoriaDetalles cateDet ON cate.Id = cateDet.Id
	LEFT JOIN ArticulosParticipantes arpar ON arti.Id = arpar.ArticuloId
	LEFT JOIN Participantes parti ON arpar.ParticipanteId = parti.Id
	LEFT JOIN ArticulosGeneros argen ON arti.Id = argen.ArticuloId
	LEFT JOIN Generos gene ON argen.GeneroId = gene.Id