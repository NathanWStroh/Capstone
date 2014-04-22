
/*Object:  StoredProcedure [dbo].[proc_DeactivateProduct]*/
CREATE PROCEDURE [dbo].[proc_DeactivateProduct]
	(@ProductID		Int)
AS
	UPDATE [dbo].[Products]
	SET [Active] = 0
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT