
/*Object:  StoredProcedure [dbo].[sp_GetProduct]*/
CREATE PROCEDURE [dbo].[sp_GetProduct]
	(@ProductID		Int)
AS
	SELECT * FROM [dbo].[Products]
	WHERE [ProductID] = @ProductID
	ORDER BY [ProductID]