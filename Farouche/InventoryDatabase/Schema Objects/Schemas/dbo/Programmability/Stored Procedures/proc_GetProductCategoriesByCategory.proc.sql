
/*Object: StoredProcedure [dbo].[proc_GetProductCategoriesByCategory] */
CREATE PROCEDURE [proc_GetProductCategoriesByCategory]
	(@category varchar(50))
AS
	SELECT [Category], [ProductCategories].[ProductID], [Products].[ShortDesc] 
	FROM [ProductCategories], [Products]
	WHERE [Category] = @category
		AND [ProductCategories].[ProductID] = [Products].[ProductID]
	RETURN