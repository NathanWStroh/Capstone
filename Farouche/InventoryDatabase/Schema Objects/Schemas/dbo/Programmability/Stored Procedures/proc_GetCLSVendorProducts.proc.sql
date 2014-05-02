/*Object: StoredProcedure [dbo].[proc_GetCLSVendorProducts] */
CREATE PROCEDURE [dbo].[proc_GetCLSVendorProducts]
AS
	SELECT v.[VendorID], v.[Name], vs.[ProductID], p.[ShortDesc], p.[Description], vs.[UnitCost]
	FROM [dbo].[Vendors] v
	JOIN [dbo].[VendorSourceItems] vs
	ON vs.[VendorID] = v.[VendorID]
	JOIN [dbo].[Products] p
	ON vs.[ProductID] = p.[productID]
	ORDER BY v.[VendorID]
RETURN