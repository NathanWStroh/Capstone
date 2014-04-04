CREATE PROCEDURE [proc_GetShippingOrderLineItem]
(
	@productID int,
	@shippingOrderID int
)
AS
	SELECT li.[ShippingOrderID], li.[ProductID], p.[ShortDesc], li.[Quantity], p.[Location], li.[Picked]
	FROM [dbo].[ShippingOrderLineItems] li
	JOIN [dbo].[Products] p
	ON li.[ProductID] = p.[ProductID]
	WHERE li.[ProductID] = @productID
	AND li.[ShippingOrderID] = @shippingOrderID