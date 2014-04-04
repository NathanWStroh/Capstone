CREATE PROCEDURE [dbo].[proc_getVendorOrder]
	@VendorOrderId int 
AS
	SELECT [VendorOrderID], [VendorID], [DateOrdered], [AmountOfShipments], [Finalized], [Active]
	FROM VendorOrders
	WHERE [VendorOrderID] = @VendorOrderId
RETURN