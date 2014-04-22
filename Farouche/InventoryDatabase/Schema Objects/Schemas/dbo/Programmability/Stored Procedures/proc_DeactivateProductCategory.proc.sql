
/*Object: StoredProcedure [dbo].[proc_DeactivateProductCategory] */
CREATE PROCEDURE [proc_DeactivateProductCategory]
	(@productID int,
	 @category varchar(50))
AS
	UPDATE [dbo].[ProductCategories]
		SET Active = 0
		WHERE ProductID = @productID
			AND Category = @category
	RETURN @@ROWCOUNT