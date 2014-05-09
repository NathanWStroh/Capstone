CREATE PROCEDURE [dbo].[proc_UpdateActiveRole]
	(
	@RoleID int,
	@Active	bit
	)
AS
	UPDATE [dbo].[Roles]
	SET [Active] = @Active
	WHERE [RoleID] = @RoleID
	RETURN @@ROWCOUNT