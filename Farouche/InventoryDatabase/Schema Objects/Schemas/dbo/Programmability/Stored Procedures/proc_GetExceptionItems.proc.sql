CREATE PROCEDURE [dbo].[proc_GetExceptionItems]
AS
	SELECT [VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems]
	where QtyReceived > QtyOrdered
	or QtyDamaged > 0
RETURN