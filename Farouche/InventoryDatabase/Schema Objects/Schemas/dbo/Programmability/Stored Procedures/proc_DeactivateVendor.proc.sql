

/*Object: StoredProcedure [dbo].[proc_DeactivateVendor]*/
CREATE PROCEDURE [proc_DeactivateVendor]
	(@VendorID int)
AS
	UPDATE [dbo].[Vendors]
		SET [Active] = 0
	WHERE [VendorID] = @VendorID
	RETURN @@ROWCOUNT