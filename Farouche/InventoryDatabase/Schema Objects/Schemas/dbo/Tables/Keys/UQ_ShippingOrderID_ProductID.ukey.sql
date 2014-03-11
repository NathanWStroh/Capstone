ALTER TABLE [dbo].[ShippingOrderLineItems] WITH NOCHECK ADD CONSTRAINT [UQ_ShippingOrderID_ProductID]
	UNIQUE ([ShippingOrderID], [ProductID])


