
/*Object:  StoredProcedure [dbo].[sp_DeactivateProduct]*/
CREATE PROCEDURE [dbo].[sp_DeactivateProduct]
	(@ProductID		Int)
AS
	UPDATE [dbo].[Products]
	SET [Active] = 0
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT