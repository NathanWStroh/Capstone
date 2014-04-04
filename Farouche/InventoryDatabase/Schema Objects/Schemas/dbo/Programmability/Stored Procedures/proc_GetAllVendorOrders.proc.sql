CREATE PROCEDURE [dbo].[proc_GetAllVendorOrders]
<<<<<<< HEAD
	As
	SELECT [VendorOrderID],[VendorID],[DateOrdered],[AmountofShipments]
	from [VendorOrders]
RETURN 

=======
AS
	SELECT [VendorOrderID], [VendorID], [DateOrdered], [AmountOfShipments], [Finalized], [Active]
	From VendorOrders
RETURN
>>>>>>> origin/master
