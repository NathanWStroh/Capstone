/* Categories Stored Procedures */

/*Object: StoredProcedure [dbo].[sp_InsertIntoCategories] */
CREATE PROCEDURE [sp_InsertIntoCategories]
	(@category varchar(50))
AS
	INSERT INTO [dbo].[Categories]
		([Category])
	VALUES
		(@Category)