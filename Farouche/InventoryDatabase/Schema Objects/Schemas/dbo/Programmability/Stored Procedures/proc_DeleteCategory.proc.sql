 
/*Object: StoredProcedure [dbo].[proc_DeleteCategory] */
CREATE PROCEDURE [proc_DeleteCategory]
	(@category varchar(50))
AS
	DELETE FROM[dbo].[Categories]
	WHERE [Category] = @category
	RETURN @@ROWCOUNT