
/*Object: StoredProcedure [dbo].[sp_DeactivateProductCategory] */
CREATE PROCEDURE [sp_DeactivateProductCategory]
	(@productID int,
	 @category varchar(50))
AS
	UPDATE [dbo].[ProductCategories]
		SET Active = 0
		WHERE ProductID = @productID
			AND Category = @category
	RETURN @@ROWCOUNT