CREATE PROCEDURE [proc_GetAllShippingTerms]
AS
	SELECT [ShippingTermId], [ShippingTermsLookup].[ShippingVendorId], [Description], [Name], [ShippingTermsLookup].[Active]
	FROM [dbo].[ShippingTermsLookup]
	INNER JOIN [ShippingVendors]
	ON [ShippingTermsLookup].[ShippingVendorID] = [ShippingVendors].[ShippingVendorID]
	ORDER BY [ShippingTermsLookup].[Active] DESC, [ShippingTermsLookup].[ShippingVendorId]


