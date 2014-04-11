CREATE PROCEDURE [dbo].[proc_UpdateProductThreshold]
	(@ProductID		int,
	@Amount			int)
AS
	UPDATE [dbo].[Products]
	SET [ReorderThreshold] = @Amount
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT