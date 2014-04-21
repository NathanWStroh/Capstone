CREATE PROCEDURE [dbo].[proc_GetVendorsByActive]
	(@Active	Int)
AS
	SELECT * FROM [dbo].[Vendors]
	WHERE [Active] = @Active
	ORDER BY [VendorID]
