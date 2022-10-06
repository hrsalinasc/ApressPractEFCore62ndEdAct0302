CREATE OR ALTER FUNCTION [dbo].[ArticulosValorTotal] (@EstaActivo bit)
RETURNS TABLE
AS
RETURN	(
			SELECT 
				Id
				, Nombre
				, Descripcion
				, Cantidad
				, PrecioCompra
				, Cantidad * PrecioCompra AS ValorTotal
			FROM
				Articulos
			WHERE
				EstaActivo = @EstaActivo
		)