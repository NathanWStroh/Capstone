CREATE PROCEDURE [dbo].[proc_InsertVendorOrder]
	@VendorID int, 
	@NumberOfShipments int
AS
	Insert into [VendorOrders] (VendorID, AmountOfShipments)
	Values (@VendorID, @NumberOfShipments)
RETURN @@ROWCOUNT