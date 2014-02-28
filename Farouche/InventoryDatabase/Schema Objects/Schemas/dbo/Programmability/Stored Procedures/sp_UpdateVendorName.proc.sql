

/*Object:  StoredProcedure [dbo].[sp_UpdateVendorName]*/
CREATE PROCEDURE [dbo].[sp_UpdateVendorName]
	(@Name varchar(50),
	 @original_VendorID int,
	 @original_Name varchar(50))
AS
	UPDATE Vendors
	SET Name = @Name
	WHERE VendorID = @original_VendorID
	AND Name = @original_Name

	RETURN @@ROWCOUNT