
/*Object:  StoredProcedure [dbo].[proc_GetProducts]*/
CREATE PROCEDURE [dbo].[proc_GetProducts]
AS
	SELECT * FROM [dbo].[Products]
	ORDER BY [Active] DESC, [ProductID]