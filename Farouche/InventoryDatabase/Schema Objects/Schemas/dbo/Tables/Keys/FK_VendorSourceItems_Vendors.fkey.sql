ALTER TABLE [dbo].[VendorSourceItems]
    ADD CONSTRAINT [FK_VendorSourceItems_Vendors] FOREIGN KEY ([VendorID]) REFERENCES [dbo].[Vendors] ([VendorID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

