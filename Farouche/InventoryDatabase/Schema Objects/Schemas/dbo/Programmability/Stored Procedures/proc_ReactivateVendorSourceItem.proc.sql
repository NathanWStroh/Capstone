
/* Object: StoredProcedure [dbo].[proc_ReactivateVendorSourceItem] */
CREATE PROCEDURE [proc_ReactivateVendorSourceItem]
	(@vendorID int,
	 @productID int)
AS
	UPDATE [dbo].[VendorSourceItems]
		SET [Active] = 1
	WHERE [VendorID] = @vendorID
		AND [ProductID] = @productID
	RETURN @@ROWCOUNT