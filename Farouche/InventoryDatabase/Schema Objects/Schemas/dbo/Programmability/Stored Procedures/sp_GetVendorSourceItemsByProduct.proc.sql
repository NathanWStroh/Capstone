	
/*Object: StoredProcedure [dbo].[sp_GetVendorSourceItemsByProduct] */
CREATE PROCEDURE [sp_GetVendorSourceItemsByProduct]
	(@productID int)
AS
	SELECT [VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase]
	FROM [dbo].[VendorSourceItems]
	WHERE [Active] = 1
		AND [ProductID] = @productID
	RETURN