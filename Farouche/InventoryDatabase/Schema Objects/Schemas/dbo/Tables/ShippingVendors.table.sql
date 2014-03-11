/* ShippingVendors */
CREATE TABLE [dbo].[ShippingVendors](
	[ShippingVendorID]	[int] IDENTITY(1,1)	NOT NULL,
	[Name]				[varchar](50)		NOT NULL,
	[Address]			[varchar](50)		NOT NULL,
	[City]				[varchar](25)		NOT NULL,
	[State]				[varchar](2)		NOT NULL,
	[Country]			[varchar](50)		NOT NULL,
	[Zip]				[varchar](10)		NOT NULL,
	[Phone]				[Varchar](12)		NOT NULL,
	[Contact]			[varchar](50)		NOT NULL,
	[ContactEmail]		[varchar](50)		NULL,
CONSTRAINT [PK_ShippingVendors] PRIMARY KEY CLUSTERED (ShippingVendorID ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)ON [PRIMARY]


