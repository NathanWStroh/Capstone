CREATE PROCEDURE [proc_UpdateShippingOrderLineItemRemovePicked]
(
	@shippingOrderID int,
	@productID int
)
AS
	UPDATE [dbo].[ShippingOrderLineItems]
	SET [Picked] = 0
	WHERE [ShippingOrderID] = @shippingOrderID AND
		  [ProductID] = @productID


