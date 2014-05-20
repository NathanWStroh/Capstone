
CREATE PROCEDURE [dbo].[proc_InsertControlForRole]
	@RoleID int,
	@Form varchar(50),
	@Control varchar(50),
	@Visible bit ,
	@Disabled bit
AS
INSERT INTO [dbo].[ControlsToRoles]
           ([RoleID]
           ,[Form]
           ,[Control]
           ,[Visible]
           ,[Disabled])
     VALUES (@RoleID,@Form,@Control,@Visible,@Disabled)


