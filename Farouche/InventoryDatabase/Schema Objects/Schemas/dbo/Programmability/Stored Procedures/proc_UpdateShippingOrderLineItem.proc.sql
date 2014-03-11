CREATE PROCEDURE [proc_UpdateShippingOrderLineItem]
(
	@shippingOrderID int,
    @productID int,
    @quantity int,
    @picked bit,
	@orig_ShippingOrderID int,
    @orig_ProductID int,
    @orig_Quantity int,
    @orig_Picked bit
)
AS
	UPDATE [dbo].[ShippingOrderLineItems]
	SET
		[ShippingOrderID] = @shippingOrderID,
		[ProductID] = @productID,
		[Quantity] = @quantity,
		[Picked] = @picked
	WHERE 
		[ShippingOrderID] = @orig_ShippingOrderID AND
		[ProductID] = @orig_ProductID AND
		[Quantity] = @orig_Quantity AND
		[Picked] = @orig_Picked
	RETURN @@ROWCOUNT


