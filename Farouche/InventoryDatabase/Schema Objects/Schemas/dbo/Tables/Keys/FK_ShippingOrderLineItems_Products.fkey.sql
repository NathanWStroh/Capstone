ALTER TABLE [dbo].[ShippingOrderLineItems] ADD  CONSTRAINT [FK_ShippingOrderLineItems_Products] 
	FOREIGN KEY([ProductID])
	REFERENCES [dbo].[Products] ([ProductID])


