
/*Object:  StoredProcedure [dbo].[sp_GetProductsByActive]*/
CREATE PROCEDURE [dbo].[sp_GetProductsByActive]
	(@Active	Int)
AS
	SELECT * FROM [dbo].[Products]
	WHERE [Active] = @Active
	ORDER BY [ProductID]