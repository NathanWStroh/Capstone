CREATE PROCEDURE [dbo].[proc_GetAllVendorOrderLineItemsByVendorOrder]
	@VendorOrderID int
AS
	SELECT [VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems]
	where [VendorOrderID] = @VendorOrderID
RETURN