ALTER TABLE [dbo].[UserRoles]  ADD  CONSTRAINT [FK_UsersRoles_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
