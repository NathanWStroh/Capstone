CREATE PROCEDURE [dbo].[proc_Authenticate]
	@UserID int,
	@Password varchar(50)
AS
Declare @RoleId int
	SELECT [UserID]
		  ,[Roles].[RoleID]
		  ,[Title]
		  ,[FirstName]
		  ,[LastName]
		  ,[Roles].[Description]
	  FROM [dbo].[Users] 
	  inner join Roles on(Users.RoleID = Roles.RoleID and Roles.Active = 1)
	  where Password = @Password
	  and UserID = @UserID
	  and users.Active = 1
	  Select * from
	  ControlsToRoles 
	  where RoleID = (Select RoleID from Users where Password = @Password and UserID = @UserID)