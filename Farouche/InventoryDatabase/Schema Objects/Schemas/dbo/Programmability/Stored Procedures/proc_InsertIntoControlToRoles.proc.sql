Create PROCEDURE [dbo].[proc_InsertIntoControlToRoles]
@RoleID int,
@FormName varchar(50),
@Control varchar(50),
@Visible bit,
@Disabled bit
AS
BEGIN
	
	insert into ControlsToRoles (RoleID, Form, Control, Visible, Disabled) 
		values (@RoleID, @FormName, @Control, @Visible, @Disabled)
END