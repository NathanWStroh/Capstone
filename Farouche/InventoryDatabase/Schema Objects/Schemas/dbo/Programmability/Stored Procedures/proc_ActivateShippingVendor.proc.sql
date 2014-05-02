CREATE PROCEDURE [dbo].[proc_ActivateShippingVendor]
	(@ShippingVendorId	Int)
AS
	UPDATE [dbo].[ShippingVendors]
	SET [Active] = 1
	WHERE [ShippingVendorID] = @ShippingVendorId
	RETURN @@ROWCOUNT