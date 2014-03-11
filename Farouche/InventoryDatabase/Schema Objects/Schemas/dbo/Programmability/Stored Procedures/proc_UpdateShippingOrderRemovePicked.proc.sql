CREATE PROCEDURE [proc_UpdateShippingOrderRemovePicked]
(
	@shippingOrderID int
)
AS
	UPDATE [dbo].[ShippingOrders]
	SET [Picked] = 0
	WHERE [ShippingOrderID] = @shippingOrderID


