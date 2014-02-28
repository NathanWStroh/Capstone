
/*Object: StoredProcedure [dbo].[sp_GetVendorSourceItemsByVendor] */
CREATE PROCEDURE [sp_GetVendorSourceItemsByVendor]
	(@vendorID int)
AS
	SELECT [VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase]
	FROM [dbo].[VendorSourceItems]
	WHERE [Active] = 1
		AND [VendorID] = @vendorID
	RETURN