CREATE PROCEDURE [dbo].[proc_GetAllVendorOrderLineItems]
AS
	SELECT [VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems]
RETURN