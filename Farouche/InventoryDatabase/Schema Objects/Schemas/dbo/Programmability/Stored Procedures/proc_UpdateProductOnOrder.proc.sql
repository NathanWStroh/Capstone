CREATE PROCEDURE [dbo].[proc_UpdateProductOnOrder]
	(@ProductID		int,
	@Amount			int)
AS
	UPDATE [dbo].[Products]
	SET [OnOrder] = @Amount
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT