CREATE PROCEDURE [dbo].[proc_UpdateVendorOrderLineItems]
	(
     
     @QtyOrdered int,
     @QtyReceived int,
     @QtyDamaged int,
	 @orig_VendorOrderID int,
     @orig_ProductID int,
	 @orig_QtyOrdered int,
	 @orig_QtyReceived int,
	 @orig_QtyDamaged int
	 )
AS
	UPDATE [dbo].[VendorOrderLineItems]
   SET 
      [QtyOrdered] = @QtyOrdered,
      [QtyReceived] = @QtyReceived, 
      [QtyDamaged] = @QtyDamaged
 WHERE 
		[VendorOrderID] = @orig_VendorOrderID
		and [ProductID] = @orig_ProductID
		and [QtyOrdered] = @orig_QtyOrdered
		and [QtyDamaged] = @orig_QtyDamaged
		and [QtyReceived] = @orig_QtyReceived
		
RETURN @@ROWCOUNT