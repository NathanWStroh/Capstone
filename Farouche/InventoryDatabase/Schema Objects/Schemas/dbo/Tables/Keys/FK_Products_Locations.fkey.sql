ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [FK_Products_Locations] FOREIGN KEY ([Location]) REFERENCES [dbo].[Locations] ([Location]) ON DELETE NO ACTION ON UPDATE NO ACTION;

