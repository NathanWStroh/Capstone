CREATE PROCEDURE [dbo].[proc_UpdateVendorOrder]
	(@VendorOrderID int,
	 @VendorID,
	 @DateOrdered,
	 @AmountOfShipments,
	 @Finalized,
	 @orig_AmountOfShipments,
	 @orig_Finalized)
AS
	UPDATE [dbo].[VendorOrders]
	SET [AmountOfShipments] = @AmountOfShipments,
	    [Finalized] = @Finalized
	WHERE [VendorOrderID] = @VendorOrderID
	  and [VendorID] = @VendorID
	  and [DateOrdered] = @DateOrdered
	  and [AmountOfShipments] = @orig_AmountOfShipments
	  and [Finalized] = @orig_Finalized
	
RETURN @@ROWCOUNT