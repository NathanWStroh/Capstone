
/*Object: StoredProcedure [dbo].[sp_DeactivateVendorSourceItem]*/
CREATE PROCEDURE [sp_DeactivateVendorSourceItem]
	(@vendorID int,
	 @productID int)
AS
	UPDATE [dbo].[VendorSourceItems]
		SET [Active] = 0
	WHERE [VendorID] = @vendorID
		AND [ProductID] = @productID
	RETURN @@ROWCOUNT