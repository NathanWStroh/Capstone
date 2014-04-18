
/* Object: StoredProcedure [dbo].[proc_ReactivateVendor] */
CREATE PROCEDURE [proc_ReactivateVendor]
	(@VendorID int)
AS
	UPDATE [dbo].[Vendors]
		SET [Active] = 1
	WHERE VendorID = @VendorID
	RETURN @@ROWCOUNT