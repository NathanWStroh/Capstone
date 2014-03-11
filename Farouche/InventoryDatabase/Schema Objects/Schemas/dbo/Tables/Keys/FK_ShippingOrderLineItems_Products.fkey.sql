ALTER TABLE [dbo].[ShippingOrderLineItems]  WITH NOCHECK ADD  CONSTRAINT [FK_ShippingOrderLineItems_Products] 
	FOREIGN KEY([ProductID])
	REFERENCES [dbo].[Products] ([ProductID])


