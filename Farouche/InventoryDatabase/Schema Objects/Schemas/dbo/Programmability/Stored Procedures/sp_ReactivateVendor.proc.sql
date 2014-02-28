
/* Object: StoredProcedure [dbo].[sp_ReactivateVendor] */
CREATE PROCEDURE [sp_ReactivateVendor]
	(@VendorID int)
AS
	UPDATE [dbo].[Vendors]
		SET [Active] = 1
	WHERE VendorID = @VendorID
	RETURN @@ROWCOUNT