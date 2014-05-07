CREATE PROCEDURE [dbo].[proc_GetAllVendorOrderLineItemsByVendorOrder]
	@VendorOrderID int
AS
Select VendorOrderLineItems.VendorOrderID, VendorOrderLineItems.ProductID, VendorOrderLineItems.QtyOrdered, VendorOrderLineItems.QtyReceived, VendorOrderLineItems.QtyDamaged, VendorOrderLineItems.Note
From VendorOrderLineItems
Where VendorOrderLineItems.VendorOrderID = @VendorOrderID
RETURN