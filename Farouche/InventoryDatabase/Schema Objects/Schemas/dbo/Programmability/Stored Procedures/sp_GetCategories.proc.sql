
/*Object: StoredProcedure [dbo].[sp_GetCategories] */
CREATE PROCEDURE [sp_GetCategories]
AS
	SELECT [Category]
	FROM [dbo].[Categories]
	WHERE [Active] = 1
	RETURN