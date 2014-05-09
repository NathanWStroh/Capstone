CREATE PROCEDURE [dbo].[proc_GetProductAvailable]
	@productID int 
AS
	SELECT Available
	FROM Products
	WHERE ProductID = @productID
RETURN 