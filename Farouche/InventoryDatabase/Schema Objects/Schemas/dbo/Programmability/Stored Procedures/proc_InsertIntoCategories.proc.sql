/* Categories Stored Procedures */

/*Object: StoredProcedure [dbo].[proc_InsertIntoCategories] */
CREATE PROCEDURE [proc_InsertIntoCategories]
	(@category varchar(50))
AS
	INSERT INTO [dbo].[Categories]
		([Category])
	VALUES
		(@Category)