CREATE PROCEDURE [dbo].[proc_GetRolesByActive]
@Active bit
AS
	Select RoleID, Title as 'Name', Active, Description from Roles where Active = @Active