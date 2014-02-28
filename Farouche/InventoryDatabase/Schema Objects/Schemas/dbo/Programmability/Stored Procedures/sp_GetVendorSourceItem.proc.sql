
/*Object: StoredProcedure [dbo].[sp_GetVendorSourceItem] */
CREATE PROCEDURE [sp_GetVendorSourceItem]
	(@vendorID int,
	 @productID int)
AS
	SELECT [VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase], [Active]
	FROM [dbo].[VendorSourceItems]
	WHERE [VendorID] = @vendorID
		AND [ProductID] = @productID
	RETURN @@ROWCOUNT
	RETURN