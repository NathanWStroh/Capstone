/* ShippingOrderDAL Stored Procedures */
CREATE PROCEDURE [proc_InsertIntoShippingOrders]
(     
	@purchaseOrderID int,
	@userID int,
	@picked		bit,
	@shipDate  date,
	@shippingTermID int,
	@shipToName  varchar(50),
	@shipToAddress varchar(250),
	@shipToCity   varchar(50),
	@shipToState   varchar(50),
	@shipToZip  varchar(10)
)
AS
	INSERT INTO [dbo].[ShippingOrders]
		([PurchaseOrderID],[UserID],[Picked],[ShipDate],[ShippingTermID],[ShipToName],[ShipToAddress],
																[ShipToCity],[ShipToState],[ShipToZip]) 
	VALUES 
		(@purchaseOrderID,@userID,@picked,@shipDate,@shippingTermID,@shipToName,@shipToAddress,@shipToCity,
																@shipToState, @shipToZip)


