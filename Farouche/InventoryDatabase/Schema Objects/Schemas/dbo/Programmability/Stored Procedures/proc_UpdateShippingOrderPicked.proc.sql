CREATE PROCEDURE [proc_UpdateShippingOrderPicked]
(
	@shippingOrderID int
)
AS
	UPDATE [dbo].[ShippingOrders]
	SET [Picked] = 1
	WHERE [ShippingOrderID] = @shippingOrderID


