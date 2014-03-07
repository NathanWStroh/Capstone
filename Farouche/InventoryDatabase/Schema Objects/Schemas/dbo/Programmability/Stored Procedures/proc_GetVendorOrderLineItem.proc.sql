CREATE PROCEDURE [dbo].[proc_GetVendorOrderLineItem]
	@VendorOrderID int, 
	@ProductID int
AS
	SELECT [VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems]
	where [VendorOrderID] = @VendorOrderID
		and [ProductID] = @ProductID
RETURN