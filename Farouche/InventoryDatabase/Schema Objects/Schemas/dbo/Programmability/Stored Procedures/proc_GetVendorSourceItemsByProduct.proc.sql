	
/*Object: StoredProcedure [dbo].[proc_GetVendorSourceItemsByProduct] */
CREATE PROCEDURE [proc_GetVendorSourceItemsByProduct]
	(@productID int)
AS
	SELECT [VendorSourceItems].[VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase], [Vendors].[Name]
	FROM [dbo].[VendorSourceItems]
	INNER JOIN [dbo].[Vendors]
	ON [VendorSourceItems].[VendorID] = [Vendors].[VendorID]
	WHERE [VendorSourceItems].[Active] = 1
	AND [ProductID] = @productID
	RETURN