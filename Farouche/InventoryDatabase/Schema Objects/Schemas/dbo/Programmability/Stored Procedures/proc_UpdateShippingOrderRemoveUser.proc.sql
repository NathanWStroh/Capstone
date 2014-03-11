CREATE PROCEDURE [proc_UpdateShippingOrderRemoveUser]
(
	@shippingOrderID int
)
AS
	UPDATE [dbo].[ShippingOrders]
	SET [UserID] = NULL
	WHERE [ShippingOrderID] = @shippingOrderID


