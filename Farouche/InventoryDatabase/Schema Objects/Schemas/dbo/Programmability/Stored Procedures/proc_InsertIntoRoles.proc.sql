CREATE PROCEDURE [dbo].[proc_InsertIntoRoles]
	@Title [varchar](25),
	@Description [varchar](250),
	@Active [bit]
AS
	insert into Roles (Title,Description,Active) values (@Title,@Description,@Active)
	RETURN @@IDENTITY