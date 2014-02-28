	
/*Object: StoredProcedure [dbo].[sp_UpdateLocation] */
CREATE PROCEDURE [sp_UpdateLocation]
	(@location varchar(250),
	 @orig_location varchar(250))
AS
	UPDATE [dbo].[Locations]
		SET [Location] = @location
	WHERE [Location] = @orig_location
	RETURN @@ROWCOUNT