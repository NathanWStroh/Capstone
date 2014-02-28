
/*Object: StoredProcedure [dbo].[sp_DeleteVendorSourceItem] */
CREATE PROCEDURE [sp_DeleteVendorSourceItem]
	(@vendorID int,
	 @productID int)
AS
	DELETE FROM [dbo].[VendorSourceItems]
	WHERE [VendorID] = @vendorID
		AND [ProductID] = @productID
	RETURN @@ROWCOUNT