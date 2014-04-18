
/*Object: StoredProcedure [dbo].[proc_ReactivateProductCategory] */
CREATE PROCEDURE [proc_ReactivateProductCategory]
	(@productID int,
	 @category varchar(50))
AS
	UPDATE [dbo].[ProductCategories]
		SET Active = 1
		WHERE ProductID = @productID
			AND Category = @category
	RETURN @@ROWCOUNT