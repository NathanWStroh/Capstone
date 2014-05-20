ALTER TABLE [dbo].[ControlsToRoles]  ADD  CONSTRAINT [FK_ControlsToRoles_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])