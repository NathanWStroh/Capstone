/* Alter Table for VendorOrderLineItems Table */
AlTER TABLE [dbo].[VendorOrderLineItems] ADD CONSTRAINT[FK_VendorOrderLineItems_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])


