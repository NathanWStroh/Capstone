CREATE PROCEDURE [proc_GetShippingTermsByID]
(
	@shippingTermID int
)
AS
	SELECT *
	FROM [dbo].[ShippingTermsLookup]
	WHERE [ShippingTermID] = @shippingTermID


