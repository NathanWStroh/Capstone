

/*Object: StoredProcedure [dbo].[sp_DeactivateVendor]*/
CREATE PROCEDURE [sp_DeactivateVendor]
	(@VendorID int)
AS
	UPDATE [dbo].[Vendors]
		SET [Active] = 0
	WHERE [VendorID] = @VendorID
	RETURN @@ROWCOUNT