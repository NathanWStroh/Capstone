CREATE PROCEDURE [dbo].[proc_UpdateActiveEmployee]
	@UserID int,
	@Active bit
AS
	Update [dbo].Users
	Set Active = @Active
	where UserID = @UserID