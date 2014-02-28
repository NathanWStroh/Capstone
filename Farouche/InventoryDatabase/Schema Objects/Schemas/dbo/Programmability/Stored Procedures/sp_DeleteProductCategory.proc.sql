
/*Object: StoredProcedure [dbo].[sp_DeleteProductCategory] */
CREATE PROCEDURE [sp_DeleteProductCategory]
	(@productID int,
	 @category varchar(50))
AS
	DELETE FROM [dbo].[ProductCategories]
		WHERE ProductID = @productID
			AND Category = @category
	RETURN @@ROWCOUNT