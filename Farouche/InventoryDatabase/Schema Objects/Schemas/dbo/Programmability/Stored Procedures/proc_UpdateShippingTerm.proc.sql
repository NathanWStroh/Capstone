CREATE PROCEDURE [proc_UpdateShippingTerm]
(
	@shippingVendorID int,
	@description varchar(250),
	@orig_ShippingTermID int,
	@orig_ShippingVendorID int,
	@orig_Description varchar(250)
)
AS
	UPDATE [dbo].[ShippingTermsLookup]
	SET
		[ShippingVendorID]  = @shippingVendorID,
		[Description] 		= @description
	WHERE 
		[ShippingTermID]	= @orig_ShippingTermID AND
		[ShippingVendorID]	= @orig_ShippingVendorID AND
		[Description]		= @orig_Description
	RETURN @@ROWCOUNT


