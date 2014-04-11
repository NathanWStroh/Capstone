CREATE PROCEDURE [dbo].[proc_UpdateProductReorderAmount]
	(@ProductID		int,
	@Amount			int)
AS
	UPDATE [dbo].[Products]
	SET [ReorderAmount] = @Amount
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT