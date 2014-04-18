/*Object: StoredProcedure [dbo].[sp_GetLocation] */
/*No need for this either*/
/*CREATE PROCEDURE [sp_GetLocation]
	(@locationID int)
AS
	SELECT [LocationID], [Description]
	FROM [dbo].[Locations]
	WHERE [Active] = 1
		AND [LocationID] = @locationID
	RETURN
GO
*/

/* ProductCategories Stored Procedures */

/*Object: StoredProcedure [dbo].[proc_InsertIntoProductCategories] */
CREATE PROCEDURE [proc_InsertIntoProductCategories]
	(@productID int,
	 @category varchar(50))
AS
	INSERT INTO [dbo].[ProductCategories]
		([ProductID], [Category])
	VALUES
		(@productID, @category)
	RETURN @@IDENTITY