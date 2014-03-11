/* Changed name from proc_ShipShippingOrder to proc_SetShippingOrderShipDate */
/* This Procedure also replaces proc_UnpickShippingOrder */
CREATE PROCEDURE [proc_UpdateShippingOrderShipDate] 
(
	@shippingOrderID int,
	@shipDate Date
)
AS	
	UPDATE [dbo].[ShippingOrders]
	SET [ShipDate] = @ShipDate
	WHERE [ShippingOrderID] = @ShippingOrderID


