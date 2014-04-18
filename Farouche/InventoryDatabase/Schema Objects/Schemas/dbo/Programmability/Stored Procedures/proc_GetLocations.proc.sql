/*Object: StoredProcedure [dbo].[proc_GetLocations] */
CREATE PROCEDURE [proc_GetLocations]
AS
	SELECT [Location]
	FROM [dbo].[Locations]
	WHERE [Active] = 1
	RETURN