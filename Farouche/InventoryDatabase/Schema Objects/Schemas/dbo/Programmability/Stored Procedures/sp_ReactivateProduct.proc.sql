
/*Object:  StoredProcedure [dbo].[sp_ReactivateProduct]*/
CREATE PROCEDURE [dbo].[sp_ReactivateProduct]
	(@ProductID		Int)
AS
	UPDATE [dbo].[Products]
	SET [Active] = 1
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT