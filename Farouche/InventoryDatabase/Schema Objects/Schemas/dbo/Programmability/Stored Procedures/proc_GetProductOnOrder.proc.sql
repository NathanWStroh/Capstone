CREATE PROCEDURE [dbo].[proc_GetProductOnOrder]
	@productID int 
AS
	SELECT OnOrder
	FROM Products
	WHERE ProductID = @productID
RETURN 