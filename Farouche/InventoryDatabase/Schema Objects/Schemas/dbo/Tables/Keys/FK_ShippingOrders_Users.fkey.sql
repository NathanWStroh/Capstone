AlTER TABLE [dbo].[ShippingOrders] ADD CONSTRAINT[FK_ShippingOrders_Users] 
	FOREIGN KEY([UserID])
	REFERENCES [dbo].[Users] ([UserID])


