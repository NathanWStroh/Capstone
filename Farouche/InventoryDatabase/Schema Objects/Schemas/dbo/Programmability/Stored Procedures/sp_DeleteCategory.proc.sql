 
/*Object: StoredProcedure [dbo].[sp_DeleteCategory] */
CREATE PROCEDURE [sp_DeleteCategory]
	(@category varchar(50))
AS
	DELETE FROM[dbo].[Categories]
	WHERE [Category] = @category
	RETURN @@ROWCOUNT