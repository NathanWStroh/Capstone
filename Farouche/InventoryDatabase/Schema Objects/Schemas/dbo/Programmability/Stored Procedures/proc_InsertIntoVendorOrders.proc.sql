CREATE PROCEDURE [dbo].[proc_InsertVendorOrder]
	@VendorID int, 
	@DateOrdered date,
	@NumberOfShipments int
AS
	Insert into [VendorOrders] (VendorID, DateOrdered, AmountOfShipments)
	Values (@VendorID, @DateOrdered, @NumberOfShipments)
RETURN @@ROWCOUNT