
/*Object:  StoredProcedure [dbo].[sp_GetProducts]*/
CREATE PROCEDURE [dbo].[sp_GetProducts]
AS
	SELECT * FROM [dbo].[Products]
	ORDER BY [Active] DESC, [ProductID]