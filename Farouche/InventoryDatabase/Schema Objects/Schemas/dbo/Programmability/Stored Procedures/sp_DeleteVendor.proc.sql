
/*Object: StoredProcedure [dbo].[sp_DeleteVendor] */
CREATE PROCEDURE [sp_DeleteVendor]
	(@VendorID int)
AS
	DELETE FROM [dbo].[Vendors]
	WHERE [VendorID] = @VendorID
	RETURN @@ROWCOUNT