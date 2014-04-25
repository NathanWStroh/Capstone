CREATE PROCEDURE [dbo].[proc_GetAllVendorOrderLineItemsByVendorOrder]
	@VendorOrderID int
AS
	SELECT [VendorOrders].VendorID,[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems], [VendorOrders]
	where [VendorOrders].VendorOrderID = @VendorOrderID
RETURN