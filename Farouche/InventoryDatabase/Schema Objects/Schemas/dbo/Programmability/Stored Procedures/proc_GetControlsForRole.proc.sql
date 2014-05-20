CREATE PROCEDURE [dbo].[proc_GetControlsForRole]
	@RoleID int 
AS
	SELECT * from ControlsToRoles where RoleID = @RoleID