
/*Object: StoredProcedure [dbo].[sp_GetProductCategories] */
CREATE PROCEDURE [sp_GetProductCategories]
AS
	SELECT [ProductID], [Category]
	FROM [dbo].[ProductCategories]
	WHERE [Active] = 1
	RETURN