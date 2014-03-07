/* Alter Table for VendorOrders Table */
AlTER TABLE [dbo].[VendorOrders] ADD CONSTRAINT[FK_VendorOrders_Vendors] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([VendorID])


