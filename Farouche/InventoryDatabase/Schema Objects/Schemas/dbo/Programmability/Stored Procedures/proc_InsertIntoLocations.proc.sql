
/*Object: StoredProcedure [dbo].[sp_GetCategory] */
/*No need for this anymore*/
/*CREATE PROCEDURE [sp_GetCategory]
	(@categoryID int)
AS
	SELECT [CategoryID], [Description]
	FROM [dbo].[Categories]
	WHERE [Active] = 1
		AND [CategoryID] = @categoryID
	RETURN
GO
*/

/* Locations Stored Procedures */

/*Object: StoredProcedure [dbo].[proc_InsertIntoLocations] */
CREATE PROCEDURE [proc_InsertIntoLocations]
	(@location varchar(250))
AS
	INSERT INTO [dbo].[Locations]
		([Location])
	VALUES
		(@location)