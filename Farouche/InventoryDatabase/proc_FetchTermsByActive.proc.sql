CREATE PROCEDURE [dbo].[proc_FetchTermsByActive]
	(@Active	Int)
AS
	SELECT [ShippingTermId], [ShippingTermsLookup].[ShippingVendorId], [Description], [Name], [ShippingTermsLookup].[Active]
	FROM [dbo].[ShippingTermsLookup]
	INNER JOIN [ShippingVendors]
	ON [ShippingTermsLookup].[ShippingVendorID] = [ShippingVendors].[ShippingVendorID]
	WHERE [ShippingTermsLookup].[Active] = @Active
	ORDER BY [ShippingTermsLookup].[Active] DESC, [ShippingTermsLookup].[ShippingVendorId]