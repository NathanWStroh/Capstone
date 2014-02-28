	
/*Object: StoredProcedure [dbo].[sp_UpdateProductCategory] */
CREATE PROCEDURE [sp_UpdateProductCategory]
	(@productID int,
	 @category varchar(50),
	 @orig_productID int,
	 @orig_category varchar(50))
AS
	UPDATE [dbo].[ProductCategories]
		SET ProductID = @productID,
			Category = @category
		WHERE ProductID = @orig_productID
			AND Category = @orig_category
	RETURN @@ROWCOUNT