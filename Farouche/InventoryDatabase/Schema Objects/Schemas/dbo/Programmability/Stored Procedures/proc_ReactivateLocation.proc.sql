/*Object: StoredProcedure [dbo].[proc_ReactivateLocation] */
CREATE PROCEDURE [proc_ReactivateLocation]
	(@location varchar(250))
AS
	UPDATE [dbo].[Locations]
		SET [Active] = 1
	WHERE [Location] = @location
	RETURN @@ROWCOUNT