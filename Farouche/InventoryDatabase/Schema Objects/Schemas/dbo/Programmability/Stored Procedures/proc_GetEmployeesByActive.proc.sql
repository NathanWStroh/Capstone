CREATE PROCEDURE [dbo].[proc_GetEmployeesByActive]
	@Active bit
AS
	Select UserID,RoleID,FirstName,LastName,PhoneNumber,Active from Users where Active = @Active