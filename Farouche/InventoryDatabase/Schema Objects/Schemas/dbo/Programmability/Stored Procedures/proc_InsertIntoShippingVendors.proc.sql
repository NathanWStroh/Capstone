/* ShippingVendorDAL stored Procedures */
CREATE PROCEDURE [proc_InsertIntoShippingVendors]
(
    @name varchar(50),
    @address varchar(50),
    @city varchar(25),
    @state varchar(2),
	@country varchar(50),
    @zip varchar(10),
    @phone varchar(12),
    @contact varchar(50),
    @contactEmail varchar(50)
)
AS
	INSERT INTO [dbo].[ShippingVendors]([Name],[Address],[City],[State],[Country],[Zip],[Phone],[Contact],[ContactEmail])
	VALUES(@name,@address,@city,@state,@country,@zip,@phone,@contact,@contactEmail)


