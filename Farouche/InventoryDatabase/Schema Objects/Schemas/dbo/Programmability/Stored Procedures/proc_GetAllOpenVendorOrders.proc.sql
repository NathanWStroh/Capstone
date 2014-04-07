CREATE PROCEDURE [dbo].[proc_GetAllOpenVendorOrders]
AS
	SELECT [VendorOrderID], [VendorID], [DateOrdered], [AmountOfShipments], [Finalized]
	FROM VendorOrders
	Where [Finalized] = '0' 
	AND [Active] = '1'
RETURN 