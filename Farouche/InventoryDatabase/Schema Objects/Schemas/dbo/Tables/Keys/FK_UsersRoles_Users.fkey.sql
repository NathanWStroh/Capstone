ALTER TABLE [dbo].[UserRoles]  ADD  CONSTRAINT [FK_UsersRoles_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])