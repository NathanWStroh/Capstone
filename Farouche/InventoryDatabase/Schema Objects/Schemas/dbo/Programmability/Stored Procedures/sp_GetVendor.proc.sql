

/*Object:  StoredProcedure [dbo].[sp_GetVendor]*/
CREATE PROCEDURE [dbo].[sp_GetVendor]
	(@VendorID int)
AS
	SELECT *
	FROM Vendors
	WHERE VendorID = @VendorID
	Return