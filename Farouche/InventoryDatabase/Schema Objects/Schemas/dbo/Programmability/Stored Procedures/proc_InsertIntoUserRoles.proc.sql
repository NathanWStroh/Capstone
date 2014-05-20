CREATE PROCEDURE [dbo].[proc_InsertIntoUserRoles]
	@UserID int,
	@RoleID int
AS
BEGIN
	insert into UserRoles (UserID, RoleID) values (@UserID , @RoleID)
END
