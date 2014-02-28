
/*Object: StoredProcedure [dbo].[sp_DeactivateCategory] */
CREATE PROCEDURE [sp_DeactivateCategory]
	(@category varchar(50))
AS
	UPDATE [dbo].[Categories]
		SET [Active] = 0
	WHERE [Category] = @category
	RETURN @@ROWCOUNT