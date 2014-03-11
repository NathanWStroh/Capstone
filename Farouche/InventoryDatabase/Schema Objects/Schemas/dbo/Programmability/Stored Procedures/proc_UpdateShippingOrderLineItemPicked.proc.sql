CREATE PROCEDURE [proc_UpdateShippingOrderLineItemPicked]
(
	@shippingOrderID int,
	@productID int
)
AS
	UPDATE [dbo].[ShippingOrderLineItems]
	SET [Picked] = 1
	WHERE [ShippingOrderID] = @shippingOrderID AND
		  [ProductID] = @productID


