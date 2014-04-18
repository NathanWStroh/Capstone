
/*Object: StoredProcedure [dbo].[proc_DeactivateCategory] */
CREATE PROCEDURE [proc_DeactivateCategory]
	(@category varchar(50))
AS
	UPDATE [dbo].[Categories]
		SET [Active] = 0
	WHERE [Category] = @category
	RETURN @@ROWCOUNT