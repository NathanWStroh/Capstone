/*Object: StoredProcedure [dbo].[sp_ReactivateLocation] */
CREATE PROCEDURE [sp_ReactivateLocation]
	(@location varchar(250))
AS
	UPDATE [dbo].[Locations]
		SET [Active] = 1
	WHERE [Location] = @location
	RETURN @@ROWCOUNT