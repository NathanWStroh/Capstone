CREATE PROCEDURE [dbo].[proc_InsertIntoVendor]
	(@Name varchar(50),
	 @Address varchar(50),
	 @City varchar(50),
	 @State char(2),
	 @Country VarChar(25),
	 @Zip Char(10),
	 @Phone Char(12),
	 @Contact VarChar(50),
	 @ContactEmail VarChar(50)
	 )
AS
	INSERT INTO Vendors
	    (Name, Address, City, State, Country, Zip, Phone, Contact, ContactEmail)
	VALUES
	    (@Name, @Address, @City, @State, @Country, @Zip, @Phone, @Contact, @ContactEmail)

	RETURN @@ROWCOUNT