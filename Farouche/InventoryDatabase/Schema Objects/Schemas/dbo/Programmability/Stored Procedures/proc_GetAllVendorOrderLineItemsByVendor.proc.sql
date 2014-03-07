CREATE PROCEDURE [dbo].[proc_GetAllVendorOrderLineItemsByVendor]
	(@VendorID int)
AS
	SELECT [VendorOrderLineItems].[VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems], [VendorOrders]
	where [VendorID] = @VendorID
RETURN