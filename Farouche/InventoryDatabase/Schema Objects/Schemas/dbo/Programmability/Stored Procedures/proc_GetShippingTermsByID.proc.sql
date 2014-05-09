CREATE PROCEDURE [proc_GetShippingTermsByID]
(
	@shippingTermID int
)
AS
	SELECT [ShippingTermId], [ShippingTermsLookup].[ShippingVendorId], [Description], [Name], [ShippingTermsLookup].[Active]
	FROM [dbo].[ShippingTermsLookup]
	INNER JOIN [ShippingVendors]
	ON [ShippingTermsLookup].[ShippingVendorID] = [ShippingVendors].[ShippingVendorID]
	WHERE [ShippingTermID] = @shippingTermID
	ORDER BY [ShippingTermsLookup].[ShippingVendorId]