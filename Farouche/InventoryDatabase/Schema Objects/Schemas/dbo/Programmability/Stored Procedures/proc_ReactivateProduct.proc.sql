
/*Object:  StoredProcedure [dbo].[proc_ReactivateProduct]*/
CREATE PROCEDURE [dbo].[proc_ReactivateProduct]
	(@ProductID		Int)
AS
	UPDATE [dbo].[Products]
	SET [Active] = 1
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT