CREATE PROCEDURE [dbo].[proc_GetAllVendorOrders]
	As
	SELECT [VendorOrderID],[VendorID],[DateOrdered],[AmountofShipments]
	from [VendorOrders]
RETURN 

