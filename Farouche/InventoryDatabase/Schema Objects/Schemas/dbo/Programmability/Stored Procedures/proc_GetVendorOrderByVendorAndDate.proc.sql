CREATE PROCEDURE [dbo].[proc_GetVendorOrderByVendorAndDate]
	@VendorID int
AS
	SELECT top(1) [VendorOrderID], [VendorID], [DateOrdered], [AmountOfShipments], [Finalized], [Active]
	FROM VendorOrders
	WHERE [VendorID] = @VendorID
	order by DateOrdered desc
RETURN