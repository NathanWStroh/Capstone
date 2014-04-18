

/*Object:  StoredProcedure [dbo].[proc_GetVendor]*/
CREATE PROCEDURE [dbo].[proc_GetVendor]
	(@VendorID int)
AS
	SELECT *
	FROM Vendors
	WHERE VendorID = @VendorID
	Return