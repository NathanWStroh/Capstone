CREATE PROCEDURE [proc_GetAllShippingVendors]
AS
	SELECT *
	FROM [dbo].[ShippingVendors]
	ORDER BY [Active] DESC, [ShippingVendorId]


