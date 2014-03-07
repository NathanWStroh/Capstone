CREATE PROCEDURE [dbo].[proc_UpdateVendorOrderLineItems]
	(@VendorOrderID int,
     @ProductID int,
     @QtyOrdered int,
     @QtyReceived int,
     @QtyDamaged int,
	 @orig_VendorOrderID int,
     @orig_ProductID int,
     @orig_QtyOrdered int,
     @orig_QtyReceived int,
     @orig_QtyDamaged int)
AS
	UPDATE [dbo].[VendorOrderLineItems]
   SET 
      [QtyOrdered] = @QtyOrdered,
      [QtyReceived] = @QtyReceived, 
      [QtyDamaged] = @QtyDamaged
 WHERE 
		[VendorOrderID] = @VendorOrderID
		and [ProductID] = @ProductID
		and [QtyOrdered] = @QtyOrdered
		and [QtyDamaged] = @QtyDamaged
		and [QtyReceived] = @QtyReceived
RETURN @@ROWCOUNT