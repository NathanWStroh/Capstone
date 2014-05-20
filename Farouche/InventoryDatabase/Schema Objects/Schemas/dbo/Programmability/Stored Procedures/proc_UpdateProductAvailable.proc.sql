CREATE PROCEDURE [dbo].[proc_UpdateProductAvailable]
	(@productID		int,
	@amount			int)
AS
	UPDATE [dbo].[Products]
	SET [Available] = @amount
	WHERE [ProductID] = @productID
	RETURN @@ROWCOUNT