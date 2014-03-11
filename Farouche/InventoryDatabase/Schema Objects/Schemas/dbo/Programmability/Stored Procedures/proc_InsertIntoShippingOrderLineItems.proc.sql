/* ShippingOrderLineItemsDAL Stored Procedures */
CREATE PROCEDURE [proc_InsertIntoShippingOrderLineItems]
(
	@shippingOrderID int,
    @productID int,
    @quantity int,
    @picked bit
)
AS
	INSERT INTO [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity],[Picked])
	VALUES (@shippingOrderID,@productID,@quantity,@picked)


