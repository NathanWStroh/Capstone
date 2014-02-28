ALTER TABLE [dbo].[VendorSourceItems]
    ADD CONSTRAINT [FK_VendorSourceItems_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

