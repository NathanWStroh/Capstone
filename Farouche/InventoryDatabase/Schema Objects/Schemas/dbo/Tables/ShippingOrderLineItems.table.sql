/* ShippingOrderLineItems */
CREATE TABLE [dbo].[ShippingOrderLineItems](
	[ShippingOrderID] 	[int]				NOT NULL,
	[ProductID]			[int]				NOT NULL,
	[Quantity]			[int]				NOT NULL,
	[Picked]			[bit]				NOT NULL DEFAULT(0),
CONSTRAINT [PK_ShippingOrderLineItems] PRIMARY KEY CLUSTERED (ShippingOrderID,ProductID ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)ON [PRIMARY]


