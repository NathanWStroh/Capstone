/*Object: StoredProcedure [dbo].[sp_DeleteLocation] */
CREATE PROCEDURE [sp_DeleteLocation]
	(@location varchar(250))
AS
	DELETE FROM [dbo].[Locations]
	WHERE [Location] = @location
	RETURN @@ROWCOUNT