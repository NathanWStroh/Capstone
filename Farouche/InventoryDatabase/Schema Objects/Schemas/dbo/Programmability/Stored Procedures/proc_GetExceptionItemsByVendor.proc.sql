CREATE PROCEDURE [dbo].[proc_GetExceptionItemsByVendor]
@VendorID int
AS
	SELECT [VendorOrderLineItems].[VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems],[VendorOrders]
	where [VendorID] = @VendorID
	and (QtyReceived > QtyOrdered
	or QtyDamaged > 0)
RETURN