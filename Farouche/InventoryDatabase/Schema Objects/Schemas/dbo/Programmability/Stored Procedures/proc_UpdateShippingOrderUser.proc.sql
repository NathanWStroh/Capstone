CREATE PROCEDURE [proc_UpdateShippingOrderUser]
(
	@shippingOrderID int,
	@newUserID int
)
AS
	UPDATE [dbo].[ShippingORders]
	SET [UserID] = @newUserID
	WHERE [ShippingOrderID] = @shippingOrderID


