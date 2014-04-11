CREATE PROCEDURE [dbo].[proc_GetAllVendorOrders]

AS
	SELECT [VendorOrderID], [VendorID], [DateOrdered], [AmountOfShipments], [Finalized], [Active]
	From VendorOrders
RETURN

