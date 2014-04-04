ALTER TABLE [dbo].[ShippingOrderLineItems] ADD CONSTRAINT [UQ_ShippingOrderID_ProductID]
	UNIQUE ([ShippingOrderID], [ProductID])


