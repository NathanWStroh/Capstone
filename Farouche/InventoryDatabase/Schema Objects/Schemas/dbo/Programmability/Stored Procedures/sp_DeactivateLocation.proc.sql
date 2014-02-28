
/*Object: StoredProcedure [dbo].[sp_DeactivateLocation] */
CREATE PROCEDURE [sp_DeactivateLocation]
	(@location varchar(250))
AS
	UPDATE [dbo].[Locations]
		SET [Active] = 0
	WHERE [Location] = @location
	RETURN @@ROWCOUNT