	
/*Object: StoredProcedure [dbo].[proc_UpdateLocation] */
CREATE PROCEDURE [proc_UpdateLocation]
	(@location varchar(250),
	 @orig_location varchar(250))
AS
	UPDATE [dbo].[Locations]
		SET [Location] = @location
	WHERE [Location] = @orig_location
	RETURN @@ROWCOUNT