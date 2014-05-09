CREATE PROCEDURE [dbo].[proc_GetProductOnHand]
	@productID int 
AS
	SELECT OnHand
	FROM Products
	WHERE ProductID = @productID
RETURN 