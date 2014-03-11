CREATE PROCEDURE [proc_UpdateShippingVendor]
(
	@name varchar(50),
    @address varchar(50),
    @city varchar(25),
    @state varchar(2),
	@country varchar(50),
    @zip varchar(10),
    @phone varchar(12),
    @contact varchar(50),
    @contactEmail varchar(50),
	@orig_ShippingVendorID int,
	@orig_Name varchar(50),
    @orig_Address varchar(50),
    @orig_City varchar(25),
    @orig_State varchar(2),
	@orig_Country varchar(50),
    @orig_Zip varchar(10),
    @orig_Phone varchar(12),
    @orig_Contact varchar(50),
    @orig_ContactEmail varchar(50)
)
AS
	UPDATE [dbo].[ShippingVendors]
	SET
		[Name]		= @name,
		[Address]	= @address,
		[City]		= @city,
		[State]		= @state,
		[Country]	= @country,
		[Zip]		= @zip,
		[Phone]		= @phone,
		[Contact]   = @contact,
		[ContactEmail] = @contactEmail
	WHERE
		[ShippingVendorID] = @orig_ShippingVendorID AND
		[Name]		= @orig_Name AND
		[Address]	= @orig_Address AND
		[City]		= @orig_City AND
		[State]		= @orig_State AND
		[Country]	= @orig_Country AND
		[Zip]		= @orig_Zip AND
		[Phone]		= @orig_Phone AND
		[Contact]   = @orig_Contact AND
		[ContactEmail] = @orig_ContactEmail
	RETURN @@ROWCOUNT


