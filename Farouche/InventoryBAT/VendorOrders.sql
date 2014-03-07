USE [InventoryDatabase]
go

CREATE TABLE [dbo].[VendorOrders] (
VendorOrderID 			[int] IDENTITY(1000,10) NOT NULL,
VendorID 				[int]					NOT NULL,
DateOrdered				[smalldatetime]			NOT NULL,	
ShipmentsExpected		[int]					NOT NULL DEFAULT(1),
ShipmentsReceived		[int]					NOT NULL DEFAULT(0),
Active 					[Bit]					NOT NULL DEFAULT(1)
CONSTRAINT [PK_VendorOrders] PRIMARY KEY CLUSTERED
([VendorOrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[VendorOrders] WITH NOCHECK ADD CONSTRAINT [FK_VendorOrders_Vendors] 
	FOREIGN KEY ([VendorID]) 
	REFERENCES [dbo].[Vendors] ([VendorID])
GO

SET IDENTITY_INSERT [dbo].[VendorOrders] on
INSERT [dbo].[VendorOrders] ([VendorOrderID], [VendorID], [DateOrdered]) VALUES (1000, 1, '2014-03-01 15:00:07')
INSERT [dbo].[VendorOrders] ([VendorOrderID], [VendorID], [DateOrdered]) VALUES (1010, 1, '2014-03-02 15:30:00')
INSERT [dbo].[VendorOrders] ([VendorOrderID], [VendorID], [DateOrdered]) VALUES (1020, 2, '2014-03-03 14:40:00')
INSERT [dbo].[VendorOrders] ([VendorOrderID], [VendorID], [DateOrdered]) VALUES (1030, 2, '2014-03-04 13:50:06')
INSERT [dbo].[VendorOrders] ([VendorOrderID], [VendorID], [DateOrdered]) VALUES (1040, 3, '2014-03-05 12:10:00')
INSERT [dbo].[VendorOrders] ([VendorOrderID], [VendorID], [DateOrdered]) VALUES (1050, 3, '2014-03-06 11:20:04')
SET IDENTITY_INSERT [dbo].[VendorOrders] off
GO

