CREATE PROCEDURE [dbo].[proc_GetAllOpenVendorOrdersByVendor]
	@VendorId int
AS
	SELECT [VendorOrderID], [VendorID], [DateOrdered], [AmountOfShipments], [Finalized]
	FROM VendorOrders
	Where [Finalized] = '0' 
	AND [Active] = '1'
	AND [VendorID] = @VendorId
RETURN 