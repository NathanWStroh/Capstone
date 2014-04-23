/*Object: StoredProcedure [dbo].[proc_GetCLSEmployees] */
CREATE PROCEDURE [proc_GetCLSEmployees]
AS
	SELECT u.[UserID], r.[RoleID], r.[Title], u.[FirstName], u.[LastName]
	FROM [dbo].[Users] u, [dbo].[Roles] r
	WHERE r.[RoleID] = u.[RoleID]
RETURN