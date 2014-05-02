CREATE PROCEDURE [dbo].[proc_DeactivateShippingVendor]
	(@ShippingVendorId	Int)
AS
	UPDATE [dbo].[ShippingVendors]
	SET [Active] = 0
	WHERE [ShippingVendorID] = @ShippingVendorId
	RETURN @@ROWCOUNT