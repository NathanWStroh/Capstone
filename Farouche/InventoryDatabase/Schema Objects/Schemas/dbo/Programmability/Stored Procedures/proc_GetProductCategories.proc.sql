
/*Object: StoredProcedure [dbo].[proc_GetProductCategories] */
CREATE PROCEDURE [proc_GetProductCategories]
AS
	SELECT [ProductID], [Category]
	FROM [dbo].[ProductCategories]
	WHERE [Active] = 1
	RETURN