CREATE PROCEDURE [dbo].[proc_DeactivateTerm]
	(@ShippingTermId	Int)
AS
	UPDATE [dbo].[ShippingTermsLookup]
	SET [Active] = 0
	WHERE [ShippingTermId] = @ShippingTermId
	RETURN @@ROWCOUNT