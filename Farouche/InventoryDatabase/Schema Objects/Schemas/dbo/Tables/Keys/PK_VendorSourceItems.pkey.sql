﻿ALTER TABLE [dbo].[VendorSourceItems]
    ADD CONSTRAINT [PK_VendorSourceItems] PRIMARY KEY CLUSTERED ([ProductID] ASC, [VendorID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

