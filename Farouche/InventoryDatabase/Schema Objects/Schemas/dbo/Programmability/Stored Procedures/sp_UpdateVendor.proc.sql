
/*Object:  StoredProcedure [dbo].[sp_UpdateVendor]*/
CREATE PROCEDURE [dbo].[sp_UpdateVendor]
	(@Name varchar(50),
	 @Address varchar(50),
	 @City varchar(50),
	 @State char(2),
	 @Country VarChar(25),
	 @Zip char(10),
	 @Phone char(12),
	 @Contact varchar(50),
	 @ContactEmail varchar(50),
	 @original_VendorID int,
	 @original_Name varchar(50),
	 @original_Address varchar(50),
	 @original_City varchar(50),
	 @original_State char(2),
	 @original_Country varchar(25),
	 @original_Zip char(10),
	 @original_Phone char(12),
	 @original_Contact varchar(50),
	 @original_ContactEmail varchar(50))
AS
	UPDATE Vendors
	   SET Name = @Name,
	       Address = @Address,
	       City = @City,
	       State = @State,
	       Country = @Country,
	       Zip = @Zip,
	       Phone = @Phone,
	       Contact = @Contact
	WHERE VendorID = @original_VendorID
	  AND Name = @original_Name
	  AND Address = @original_Address
	  AND City = @original_City
	  AND State = @original_State
	  AND Country = @original_Country
	  AND Zip = @original_Zip
	  AND Phone = @original_Phone
	  AND Contact = @original_Contact
	  AND ContactEmail = @original_ContactEmail
	
	RETURN @@ROWCOUNT