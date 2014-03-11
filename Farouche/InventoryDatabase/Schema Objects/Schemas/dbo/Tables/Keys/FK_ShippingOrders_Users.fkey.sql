AlTER TABLE [dbo].[ShippingOrders] WITH NOCHECK ADD CONSTRAINT[FK_ShippingOrders_Users] 
	FOREIGN KEY([UserID])
	REFERENCES [dbo].[Users] ([UserID])


