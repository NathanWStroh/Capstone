/* VendorOrders */
CREATE TABLE [dbo].[VendorOrders] (
VendorOrderID 		[int] IDENTITY(1,1)	NOT NULL,
VendorID 			[int]				NOT NULL,
DateOrdered			[datetime]			NOT NULL DEFAULT SYSDATETIME(),	
AmountOfShipments	[int]				NOT NULL DEFAULT(1),
Finalized			[Bit]				NOT NULL DEFAULT(0),
Active 				[Bit]				NOT NULL DEFAULT(1)
CONSTRAINT [PK_VendorOrders] PRIMARY KEY CLUSTERED
(	[VendorOrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]