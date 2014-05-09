CREATE PROCEDURE [dbo].[proc_InsertIntoUsers]
		@RoleID int,
        @Password varchar(50),
        @FirstName varchar(25),
        @LastName varchar(25),
        @PhoneNumber varchar(14),
        @Active bit
AS
	INSERT INTO [dbo].[Users]
           ([RoleID]
           ,[Password]
           ,[FirstName]
           ,[LastName]
           ,[PhoneNumber]
           ,[Active])
     VALUES
           (@RoleID,
           @Password, 
           @FirstName,
           @LastName, 
           @PhoneNumber,
           @Active)