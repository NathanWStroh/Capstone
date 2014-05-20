CREATE PROCEDURE [dbo].[proc_UpdateProductOnHandAmount]
	(@ProductID		int,
	@OnHand			int)
AS
	UPDATE [dbo].[Products]
	SET [OnHand] = @OnHand
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT