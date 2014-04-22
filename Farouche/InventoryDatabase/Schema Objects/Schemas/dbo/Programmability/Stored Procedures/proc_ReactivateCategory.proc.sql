
/*Object: StoredProcedure [dbo].[proc_ReactivateCategory] */
CREATE PROCEDURE [proc_ReactivateCategory]
	(@category varchar(50))
AS
	UPDATE [dbo].[Categories]
		SET [Active] = 1
	WHERE [Category] = @category
	RETURN @@ROWCOUNT