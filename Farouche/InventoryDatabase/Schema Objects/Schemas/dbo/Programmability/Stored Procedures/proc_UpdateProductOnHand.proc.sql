CREATE PROCEDURE [dbo].[proc_UpdateProductOnHand]

	(@productID		int,
	 @amount		int)
AS
	UPDATE [dbo].[Products]
	SET [OnHand] = @amount
	WHERE [ProductID] = @productID
	RETURN @@ROWCOUNT