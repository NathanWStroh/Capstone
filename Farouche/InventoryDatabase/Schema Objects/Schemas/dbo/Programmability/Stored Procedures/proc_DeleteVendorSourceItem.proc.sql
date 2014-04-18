
/*Object: StoredProcedure [dbo].[proc_DeleteVendorSourceItem] */
CREATE PROCEDURE [proc_DeleteVendorSourceItem]
	(@vendorID int,
	 @productID int)
AS
	DELETE FROM [dbo].[VendorSourceItems]
	WHERE [VendorID] = @vendorID
		AND [ProductID] = @productID
	RETURN @@ROWCOUNT