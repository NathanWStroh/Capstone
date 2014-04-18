
/*Object: StoredProcedure [dbo].[proc_GetProductCategoriesByProduct] */
CREATE PROCEDURE [proc_GetProductCategoriesByProduct]
	(@productID int)
AS
	SELECT [ProductID], [ProductCategories].[Category]
	FROM [ProductCategories], [Categories]
	WHERE [ProductID] = @productID
		AND [ProductCategories].[Category] = [Categories].[Category]
	RETURN