CREATE PROCEDURE [dbo].[proc_GetExceptionItemsByVendorOrder]
@VendorOrderID int
AS
	SELECT [VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems]
	where [VendorOrderID] = @VendorOrderID
	and (QtyReceived > QtyOrdered
	or QtyDamaged > 0)
RETURN