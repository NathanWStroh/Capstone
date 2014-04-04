CREATE PROCEDURE [dbo].[proc_InsertVendorOrder]
	@VendorID int, 
	@DateOrdered date
AS
	Insert into [VendorOrders] (VendorID, DateOrdered)
	Values (@VendorID, @DateOrdered)
RETURN @@ROWCOUNT