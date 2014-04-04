CREATE PROCEDURE [proc_UpdateShippingOrderUser]
(
	@shippingOrderID int,
	@newUserID int
)
AS
	UPDATE [dbo].[ShippingOrders]
	SET [UserID] = @newUserID
	WHERE [ShippingOrderID] = @shippingOrderID


