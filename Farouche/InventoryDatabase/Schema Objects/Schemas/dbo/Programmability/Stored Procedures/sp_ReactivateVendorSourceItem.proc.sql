
/* Object: StoredProcedure [dbo].[sp_ReactivateVendorSourceItem] */
CREATE PROCEDURE [sp_ReactivateVendorSourceItem]
	(@vendorID int,
	 @productID int)
AS
	UPDATE [dbo].[VendorSourceItems]
		SET [Active] = 1
	WHERE [VendorID] = @vendorID
		AND [ProductID] = @productID
	RETURN @@ROWCOUNT