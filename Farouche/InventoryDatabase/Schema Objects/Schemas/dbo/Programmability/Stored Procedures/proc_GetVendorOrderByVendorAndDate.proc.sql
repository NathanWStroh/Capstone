CREATE PROCEDURE [dbo].[proc_GetVendorOrderByVendorAndDate]
	@VendorID int, 
	@DateOrdered datetime
AS
	SELECT [VendorOrderID], [VendorID], [DateOrdered], [AmountOfShipments], [Finalized], [Active]
	FROM VendorOrders
	WHERE [VendorID] = @VendorID
	and [DateOrdered] = @DateOrdered
RETURN