CREATE PROCEDURE [dbo].[proc_GetRoles]
AS
	Select RoleID, Title as 'Name', Active, Description from Roles