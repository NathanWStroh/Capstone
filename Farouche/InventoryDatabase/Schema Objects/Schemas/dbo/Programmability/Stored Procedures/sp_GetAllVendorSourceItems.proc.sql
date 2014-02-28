
/*Object: StoredProcedure [dbo].[sp_GetVendorSourceItems] */
CREATE PROCEDURE [sp_GetAllVendorSourceItems]
AS
	SELECT [VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase]
	FROM [dbo].[VendorSourceItems]
	WHERE [Active] = 1
	RETURN