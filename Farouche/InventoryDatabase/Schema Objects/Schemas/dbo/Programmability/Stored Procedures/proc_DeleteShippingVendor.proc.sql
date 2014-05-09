CREATE PROCEDURE [dbo].[proc_DeleteShippingVendor]
	(@ShippingVendorID		[int],
	@Name					[varchar],
	@Address				[varchar],
	@City					[varchar],
	@State					[varchar],
	@Country				[varchar],
	@Zip					[varchar],
	@Phone					[Varchar],
	@Contact				[varchar],
	@ContactEmail			[varchar],
	@Active					[BIT])
AS
	DELETE FROM [dbo].[ShippingVendors]
	WHERE [ShippingVendorID] = @ShippingVendorID
	AND [Name] = @Name
	AND [Address] = @Address
	AND [City] = @City
	AND [State] = @State
	AND [Country] = @Country
	AND [Zip] = @Zip
	AND [Phone] = @Phone
	AND [Contact] = @Contact
	AND [ContactEmail] = @ContactEmail
	AND [Active] = @Active
RETURN @@ROWCOUNT