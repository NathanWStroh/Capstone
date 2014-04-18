
/*Object: StoredProcedure [dbo].[proc_GetVendorSourceItems] */
CREATE PROCEDURE [proc_GetAllVendorSourceItems]
AS
	SELECT [VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase]
	FROM [dbo].[VendorSourceItems]
	WHERE [Active] = 1
	RETURN