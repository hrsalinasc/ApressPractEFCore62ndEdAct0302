CREATE OR ALTER FUNCTION [dbo].[ArticulosNombresCadenaDelimBarra] (@EstaActivo bit)
RETURNS VARCHAR(2500)
AS
BEGIN
	RETURN	(
				SELECT 
					STRING_AGG(Nombre, '|')
				FROM
					Articulos
				WHERE
					EstaActivo = @EstaActivo
			)
END