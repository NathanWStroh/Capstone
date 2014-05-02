CREATE PROCEDURE [dbo].[proc_GetShippingVendorsByActive]
	(@Active	Int)
AS
	SELECT *
	FROM [dbo].[ShippingVendors]
	WHERE [Active] = @Active
	ORDER BY [Active] DESC, [ShippingVendorId]
RETURN @@ROWCOUNT