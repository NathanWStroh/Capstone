CREATE PROCEDURE [dbo].[proc_UpdateUser](
	@UserID int,
	@RoleID int,
	@FirstName varchar(25),
	@LastName varchar(25),
	@PhoneNumber varchar(14),
	@Active bit,
	@Orig_RoleID int,
	@Orig_FirstName varchar(25),
	@Orig_LastName varchar(25),
	@Orig_PhoneNumber varchar(14),
	@Orig_Active bit
)
as
UPDATE [dbo].[Users]
   SET [RoleID] = @RoleID,
      [FirstName] = @FirstName, 
      [LastName] = @LastName, 
      [PhoneNumber] = @PhoneNumber, 
      [Active] = @Active
 WHERE UserId = @UserID
	and RoleId = @Orig_RoleID
	and FirstName = @Orig_FirstName
	and LastName	= @Orig_LastName
	and PhoneNumber = @Orig_PhoneNumber
	and Active = @Orig_Active