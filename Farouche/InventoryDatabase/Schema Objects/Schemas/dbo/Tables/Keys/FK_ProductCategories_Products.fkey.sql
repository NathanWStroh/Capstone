ALTER TABLE [dbo].[ProductCategories]
    ADD CONSTRAINT [FK_ProductCategories_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

