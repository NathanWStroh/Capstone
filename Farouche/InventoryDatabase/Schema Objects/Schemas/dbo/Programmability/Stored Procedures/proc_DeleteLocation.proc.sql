/*Object: StoredProcedure [dbo].[proc_DeleteLocation] */
CREATE PROCEDURE [proc_DeleteLocation]
	(@location varchar(250))
AS
	DELETE FROM [dbo].[Locations]
	WHERE [Location] = @location
	RETURN @@ROWCOUNT