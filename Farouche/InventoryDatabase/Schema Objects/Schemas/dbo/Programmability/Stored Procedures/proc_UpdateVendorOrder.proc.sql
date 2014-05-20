CREATE PROCEDURE [dbo].[proc_UpdateVendorOrder]
	(@VendorOrderID int,
	 @VendorID int,
	 @AmountOfShipments int,
	 @Finalized bit,
	 @orig_AmountOfShipments int,
	 @orig_Finalized bit)
AS
	UPDATE [dbo].[VendorOrders]
	SET [AmountOfShipments] = @AmountOfShipments,
	    [Finalized] = @Finalized
	WHERE [VendorOrderID] = @VendorOrderID
	  and [VendorID] = @VendorID
	  and [AmountOfShipments] = @orig_AmountOfShipments
	  and [Finalized] = @orig_Finalized
	
RETURN @@ROWCOUNT