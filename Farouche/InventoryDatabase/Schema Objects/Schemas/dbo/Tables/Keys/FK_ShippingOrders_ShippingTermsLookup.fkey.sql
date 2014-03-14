/* Alter Table for ShippingOrders Table */
AlTER TABLE [dbo].[ShippingOrders] ADD CONSTRAINT[FK_ShippingOrders_ShippingTermsLookup] 
	FOREIGN KEY([ShippingTermID])
	REFERENCES [dbo].[ShippingTermsLookup] ([ShippingTermID])


