
/*Object: StoredProcedure [dbo].[proc_GetVendorSourceItemsByVendor] */
CREATE PROCEDURE [proc_GetVendorSourceItemsByVendor]
	(@vendorID int)
AS
	SELECT [VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase]
	FROM [dbo].[VendorSourceItems]
	WHERE [Active] = 1
		AND [VendorID] = @vendorID
	RETURN