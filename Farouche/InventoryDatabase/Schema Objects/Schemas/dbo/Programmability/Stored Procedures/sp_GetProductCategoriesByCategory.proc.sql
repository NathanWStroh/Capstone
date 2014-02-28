
/*Object: StoredProcedure [dbo].[sp_GetProductCategoriesByCategory] */
CREATE PROCEDURE [sp_GetProductCategoriesByCategory]
	(@category varchar(50))
AS
	SELECT [Category], [ProductCategories].[ProductID], [Products].[ShortDesc] 
	FROM [ProductCategories], [Products]
	WHERE [Category] = @category
		AND [ProductCategories].[ProductID] = [Products].[ProductID]
	RETURN