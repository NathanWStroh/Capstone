﻿ALTER TABLE [dbo].[Vendors]
    ADD CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED ([VendorID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

