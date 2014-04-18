
/*Object: StoredProcedure [dbo].[proc_DeactivateLocation] */
CREATE PROCEDURE [proc_DeactivateLocation]
	(@location varchar(250))
AS
	UPDATE [dbo].[Locations]
		SET [Active] = 0
	WHERE [Location] = @location
	RETURN @@ROWCOUNT