
/*Object: StoredProcedure [dbo].[sp_ReactivateCategory] */
CREATE PROCEDURE [sp_ReactivateCategory]
	(@category varchar(50))
AS
	UPDATE [dbo].[Categories]
		SET [Active] = 1
	WHERE [Category] = @category
	RETURN @@ROWCOUNT