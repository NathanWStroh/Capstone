/*Object: StoredProcedure [dbo].[sp_GetLocations] */
CREATE PROCEDURE [sp_GetLocations]
AS
	SELECT [Location]
	FROM [dbo].[Locations]
	WHERE [Active] = 1
	RETURN