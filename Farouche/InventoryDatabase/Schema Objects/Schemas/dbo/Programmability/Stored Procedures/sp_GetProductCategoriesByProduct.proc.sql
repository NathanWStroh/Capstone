
/*Object: StoredProcedure [dbo].[sp_GetProductCategoriesByProduct] */
CREATE PROCEDURE [sp_GetProductCategoriesByProduct]
	(@productID int)
AS
	SELECT [ProductID], [ProductCategories].[Category]
	FROM [ProductCategories], [Categories]
	WHERE [ProductID] = @productID
		AND [ProductCategories].[Category] = [Categories].[Category]
	RETURN