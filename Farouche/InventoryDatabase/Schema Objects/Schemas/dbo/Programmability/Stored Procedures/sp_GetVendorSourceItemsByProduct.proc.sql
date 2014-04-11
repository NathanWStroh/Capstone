	
/*Object: StoredProcedure [dbo].[sp_GetVendorSourceItemsByProduct] */
CREATE PROCEDURE [sp_GetVendorSourceItemsByProduct]
	(@productID int)
AS
	SELECT [VendorSourceItems].[VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase], [Vendors].[Name]
	FROM [dbo].[VendorSourceItems]
	INNER JOIN [dbo].[Vendors]
	ON [VendorSourceItems].[VendorID] = [Vendors].[VendorID]
	WHERE [VendorSourceItems].[Active] = 1
	AND [ProductID] = @productID
	RETURN