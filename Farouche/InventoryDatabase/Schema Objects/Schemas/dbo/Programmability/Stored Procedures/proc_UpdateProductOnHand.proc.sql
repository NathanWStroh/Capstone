CREATE PROCEDURE [dbo].[proc_UpdateProductOnHand]
	(@ProductID		int,
	@Amount			int)
AS
	UPDATE [dbo].[Products]
	SET [OnHand] = @Amount
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT