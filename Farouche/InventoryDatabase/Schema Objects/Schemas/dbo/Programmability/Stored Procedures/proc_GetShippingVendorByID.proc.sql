CREATE PROCEDURE [proc_GetShippingVendorByID]
(
	@shippingVendorID int
)
AS
	SELECT *
	FROM [dbo].[ShippingVendors]
	WHERE [ShippingVendorID] = @shippingVendorID


