
/*Object:  StoredProcedure [dbo].[proc_GetProduct]*/
CREATE PROCEDURE [dbo].[proc_GetProduct]
	(@ProductID		Int)
AS
	SELECT * FROM [dbo].[Products]
	WHERE [ProductID] = @ProductID
	ORDER BY [ProductID]