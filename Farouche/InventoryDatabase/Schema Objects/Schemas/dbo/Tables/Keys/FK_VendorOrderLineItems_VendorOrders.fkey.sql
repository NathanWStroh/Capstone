AlTER TABLE [dbo].[VendorOrderLineItems] ADD CONSTRAINT[FK_VendorOrderLineItems_VendorOrders] FOREIGN KEY([VendorOrderID])
REFERENCES [dbo].[VendorOrders] ([VendorOrderID])