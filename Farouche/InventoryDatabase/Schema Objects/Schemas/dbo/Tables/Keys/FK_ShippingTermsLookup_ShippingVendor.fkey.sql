/* **********************************Alter Table Statements******************************************* */

/* Alter Table for ShippingTermsLookup Table */
AlTER TABLE [dbo].[ShippingTermsLookup]ADD CONSTRAINT[FK_ShippingTermsLookup_ShippingVendor] 
	FOREIGN KEY([ShippingVendorID])
	REFERENCES [dbo].[ShippingVendors] ([ShippingVendorID])


