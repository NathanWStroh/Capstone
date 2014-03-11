/* ShippingTermDAL Stored Procedures */
/* ShippingTermID is an Identity and will be created on Update can not pass it in */
CREATE PROCEDURE [proc_InsertIntoShippingTerm]
(
	@shippingVendorID int,
	@description varchar(250)
)
AS
	INSERT INTO [dbo].[ShippingTermsLookup]([ShippingVendorID],[Description])
	VALUES (@shippingVendorID,@description)


