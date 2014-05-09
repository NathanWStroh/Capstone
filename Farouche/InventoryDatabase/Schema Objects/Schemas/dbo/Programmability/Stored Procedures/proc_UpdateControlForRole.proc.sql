
CREATE PROCEDURE [dbo].[proc_UpdateControlForRole]
	@RoleID int,
	@Form varchar(50),
	@Control varchar(50) ,
	@Visible bit ,
	@Disabled bit
AS
UPDATE [dbo].[ControlsToRoles]
   SET [Visible] = @Visible
      ,[Disabled] = @Disabled
 WHERE RoleID = @RoleID and Form = @Form and Control = @Control



