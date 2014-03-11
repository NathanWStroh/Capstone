/* ShippingTermsLookup */
CREATE TABLE [dbo].[ShippingTermsLookup] (
	[ShippingTermID]	[int] IDENTITY(1,1)	NOT NULL,
	[ShippingVendorID]	[int] 				NOT NULL,
	[Description]		[varchar](250)		NOT NULL,
CONSTRAINT [PK_ShippingTermsLookup] PRIMARY KEY CLUSTERED (ShippingTermID ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)ON [PRIMARY]


