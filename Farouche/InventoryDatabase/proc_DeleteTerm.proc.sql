CREATE PROCEDURE [dbo].[proc_DeleteTerm]
	(@Id					int,
	@ShippingVendorId		int,
	@Active					bit)
AS
	DELETE FROM [dbo].[ShippingTermsLookup]
	WHERE [ShippingTermID] = @Id
	AND [ShippingVendorID] = @ShippingVendorId
	AND [Active] = @Active
RETURN @@ROWCOUNT