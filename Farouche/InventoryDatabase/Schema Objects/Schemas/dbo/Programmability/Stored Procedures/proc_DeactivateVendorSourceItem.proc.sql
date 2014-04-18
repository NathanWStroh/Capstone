
/*Object: StoredProcedure [dbo].[proc_DeactivateVendorSourceItem]*/
CREATE PROCEDURE [proc_DeactivateVendorSourceItem]
	(@vendorID int,
	 @productID int)
AS
	UPDATE [dbo].[VendorSourceItems]
		SET [Active] = 0
	WHERE [VendorID] = @vendorID
		AND [ProductID] = @productID
	RETURN @@ROWCOUNT