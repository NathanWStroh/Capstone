
/*Object:  StoredProcedure [dbo].[proc_GetProductsByActive]*/
CREATE PROCEDURE [dbo].[proc_GetProductsByActive]
	(@Active	Int)
AS
	SELECT * FROM [dbo].[Products]
	WHERE [Active] = @Active
	ORDER BY [ProductID]