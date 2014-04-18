
/*Object: StoredProcedure [dbo].[proc_DeleteProductCategory] */
CREATE PROCEDURE [proc_DeleteProductCategory]
	(@productID int,
	 @category varchar(50))
AS
	DELETE FROM [dbo].[ProductCategories]
		WHERE ProductID = @productID
			AND Category = @category
	RETURN @@ROWCOUNT