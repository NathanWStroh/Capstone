/* ShippingOrders */
CREATE TABLE [dbo].[ShippingOrders](
	[ShippingOrderID]	[int] IDENTITY(1,1)	NOT NULL,
	[PurchaseOrderID]	[int]				NOT NULL,
	[ShippingTermID] 	[int]				NOT NULL,
	[UserID]			[int]				NULL,
	[ShipDate]			[Date]				NULL,
	[Picked]			[bit]				NOT NULL DEFAULT(0),
	[ShipToName]		[varchar](50)		NULL,
	[ShipToAddress]		[varchar](250)		NULL,
	[ShipToCity]		[varchar](50)		NULL,
	[ShipToState]		[varchar](50)		NULL,
	[ShipToZip]			[varchar](10)		NULL,
CONSTRAINT [PK_ShippingOrders] PRIMARY KEY CLUSTERED (ShippingOrderID ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)ON [PRIMARY]


