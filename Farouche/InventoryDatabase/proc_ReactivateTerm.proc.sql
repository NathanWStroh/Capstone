CREATE PROCEDURE [dbo].[proc_ReactivateTerm]
	(@ShippingTermId	Int)
AS
	UPDATE [dbo].[ShippingTermsLookup]
	SET [Active] = 1
	WHERE [ShippingTermId] = @ShippingTermId
	RETURN @@ROWCOUNT