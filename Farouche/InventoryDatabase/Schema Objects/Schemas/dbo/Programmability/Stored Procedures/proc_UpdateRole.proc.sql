CREATE PROCEDURE [dbo].[proc_UpdateRole]
	(
	@RoleID int,
	@Title varchar(25),
	@Description varchar(250),
	@Active	bit,
	@OriginalTitle varchar(25),
	@OriginalDescription varchar(250),
	@OriginalActive	bit
	)
AS
	UPDATE [dbo].[Roles]
	SET [Active] = @Active,
		[Title] = @Title,
		[Description] = @Description
	WHERE [RoleID] = @RoleID
		and [Title] = @OriginalTitle
		and [Description] = @OriginalDescription
		and [Active] = @OriginalActive
	RETURN @@ROWCOUNT