
/*Object: StoredProcedure [dbo].[proc_GetCategories] */
CREATE PROCEDURE [proc_GetCategories]
AS
	SELECT [Category]
	FROM [dbo].[Categories]
	WHERE [Active] = 1
	RETURN