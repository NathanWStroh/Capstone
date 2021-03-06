﻿CREATE PROCEDURE [proc_UpdateShippingOrder]
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
    @shipToZip  varchar(10),		  
    @orig_ShippingOrderID int,
    @orig_PurchaseOrderID int,
    @orig_UserID		int,
    @orig_Picked		bit,
    @orig_ShipDate   date,
    @orig_ShippingTermID int,
	@orig_ShipToName  varchar(50),
    @orig_ShipToAddress varchar(250),
    @orig_ShipToCity varchar(50),
    @orig_ShipToState  varchar(50),
    @orig_ShipToZip  varchar(10)
)
AS
	UPDATE [dbo].[ShippingOrders]
	SET 
		[PurchaseOrderID]= 	@purchaseOrderID,
		[UserID]		=	@userID,
		[Picked]		=	@picked,
		[ShipDate] 		=	@shipDate,
		[ShippingTermID]=	@shippingTermID,
		[ShipToName]	=	@shipToName,
		[ShipToAddress]	=	@shipToAddress,
		[ShipToCity] 	=	@shipToCity,
		[ShipToState]	=	@shipToState,
		[ShipToZip]		=	@shipToZip
	WHERE
		[ShippingOrderID]= 	@orig_ShippingOrderID AND
		[PurchaseOrderID]= 	@orig_PurchaseOrderID AND		
		((@orig_UserID IS NULL AND [UserID] IS NULL)
			OR ([UserID]		=	@orig_UserID)) AND
		[Picked]		=	@orig_Picked AND
		((@orig_ShipDate IS NULL AND [ShipDate] IS NULL)
			OR ([ShipDate]		=	@orig_ShipDate)) AND		
		[ShippingTermID]=   @orig_ShippingTermID AND		
		((@orig_ShipToName IS NULL and [ShipToName] IS NULL)
			OR ([ShipToName] 	=	@orig_ShipToName )) AND		
		((@orig_ShipToAddress IS NULL AND [ShipToAddress] IS NULL)
			OR ([ShipToAddress] =	@orig_ShipToAddress)) AND		
		((@orig_ShipToCity IS NULL AND [ShipToCity] IS NULL)
			OR ([ShipToCity]	=	@orig_ShipToCity)) AND		
		((@orig_ShipToState IS NULL  AND [ShipToState] IS NULL)
			OR ([ShipToState] 	= 	@orig_ShipToState)) AND		
		((@orig_ShipToZip IS NULL AND [ShipToZip] IS NULL)
			OR ([ShipToZip] 	=	@orig_ShipToZip))
	RETURN @@ROWCOUNT


