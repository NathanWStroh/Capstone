/* **********************************Alter Table Statements******************************************* */

/* Alter Table for ShippingTermsLookup Table */
AlTER TABLE [dbo].[ShippingTermsLookup] WITH NOCHECK ADD CONSTRAINT[FK_ShippingTermsLookup_ShippingVendor] 
	FOREIGN KEY([ShippingVendorID])
	REFERENCES [dbo].[ShippingVendors] ([ShippingVendorID])


