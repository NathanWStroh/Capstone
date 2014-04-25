CREATE PROCEDURE [dbo].[proc_GetAllVendorOrderLineItemsByVendor]
	(@VendorID int)
AS
SELECT [VendorOrders].VendorID,[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems], [VendorOrders]
	where [VendorOrders].VendorID = @VendorID
RETURN