CREATE PROCEDURE [proc_UpdateShippingOrderRemoveShipDate] 
(
	@shippingOrderID int
)
AS
	UPDATE [dbo].[ShippingOrders]
	SET [ShipDate] = NULL
	WHERE [ShippingOrderID] = @shippingOrderID


