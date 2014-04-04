/* Alter Table for ShippingOrderLineItems */
ALTER TABLE [dbo].[ShippingOrderLineItems] ADD  CONSTRAINT [FK_ShippingOrderLineItems_ShippingOrders] 
	FOREIGN KEY([ShippingOrderID])
	REFERENCES [dbo].[ShippingOrders] ([ShippingOrderID])


