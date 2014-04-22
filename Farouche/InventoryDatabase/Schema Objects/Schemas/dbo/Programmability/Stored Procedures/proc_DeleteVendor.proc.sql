
/*Object: StoredProcedure [dbo].[proc_DeleteVendor] */
CREATE PROCEDURE [proc_DeleteVendor]
	(@VendorID int)
AS
	DELETE FROM [dbo].[Vendors]
	WHERE [VendorID] = @VendorID
	RETURN @@ROWCOUNT