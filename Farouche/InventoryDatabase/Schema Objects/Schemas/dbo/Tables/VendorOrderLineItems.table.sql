/* VendorOrderLineItems */
CREATE TABLE [dbo].[VendorOrderLineItems] (
VendorOrderID 				[int]				NOT NULL,
ProductID 				[int]				NOT NULL,
QtyOrdered		[int]				NOT NULL DEFAULT(1),
QtyReceived		[int]				NOT NULL DEFAULT(1),
QtyDamaged		[int]				NOT NULL DEFAULT(1)
CONSTRAINT [PK_VendorOrderLineItems] PRIMARY KEY CLUSTERED
(
	VendorOrderID,ProductID ASC 
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


