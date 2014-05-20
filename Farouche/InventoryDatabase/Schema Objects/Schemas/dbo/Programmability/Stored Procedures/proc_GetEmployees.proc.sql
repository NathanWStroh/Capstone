CREATE PROCEDURE [dbo].[proc_GetEmployees]
AS
	Select UserID,RoleID,FirstName,LastName,PhoneNumber,Active from Users