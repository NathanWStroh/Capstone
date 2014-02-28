ALTER TABLE [dbo].[ProductCategories]
    ADD CONSTRAINT [FK_ProductCategories_Categories] FOREIGN KEY ([Category]) REFERENCES [dbo].[Categories] ([Category]) ON DELETE NO ACTION ON UPDATE NO ACTION;

