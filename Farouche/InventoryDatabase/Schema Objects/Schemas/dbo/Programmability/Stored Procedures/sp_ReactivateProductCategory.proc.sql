
/*Object: StoredProcedure [dbo].[sp_ReactivateProductCategory] */
CREATE PROCEDURE [sp_ReactivateProductCategory]
	(@productID int,
	 @category varchar(50))
AS
	UPDATE [dbo].[ProductCategories]
		SET Active = 1
		WHERE ProductID = @productID
			AND Category = @category
	RETURN @@ROWCOUNT