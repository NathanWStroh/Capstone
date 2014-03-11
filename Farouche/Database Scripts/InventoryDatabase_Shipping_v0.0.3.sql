IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'InventoryDatabase') 
BEGIN
	USE InventoryDatabase
END
GO

IF OBJECT_ID('dbo.ShippingVendors') IS NOT NULL
    DROP TABLE [dbo].[ShippingVendors]
GO
IF OBJECT_ID('dbo.ShippingOrders') IS NOT NULL
    DROP TABLE [dbo].[ShippingOrders]
GO
IF OBJECT_ID('dbo.ShippingOrderLineItems') IS NOT NULL
    DROP TABLE [dbo].[ShippingOrderLineItems]
GO
IF OBJECT_ID('dbo.ShippingTermsLookup') IS NOT NULL
    DROP TABLE [dbo].[ShippingTermsLookup]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
/* ShippingVendors */
CREATE TABLE [dbo].[ShippingVendors](
	[ShippingVendorID]	[int] IDENTITY(1,1)	NOT NULL,
	[Name]				[varchar](50)		NOT NULL,
	[Address]			[varchar](50)		NOT NULL,
	[City]				[varchar](25)		NOT NULL,
	[State]				[varchar](2)		NOT NULL,
	[Country]			[varchar](50)		NOT NULL,
	[Zip]				[varchar](10)		NOT NULL,
	[Phone]				[Varchar](12)		NOT NULL,
	[Contact]			[varchar](50)		NOT NULL,
	[ContactEmail]		[varchar](50)		NULL,
CONSTRAINT [PK_ShippingVendors] PRIMARY KEY CLUSTERED (ShippingVendorID ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)ON [PRIMARY]
GO
/* ShippingTermsLookup */
CREATE TABLE [dbo].[ShippingTermsLookup] (
	[ShippingTermID]	[int] IDENTITY(1,1)	NOT NULL,
	[ShippingVendorID]	[int] 				NOT NULL,
	[Description]		[varchar](250)		NOT NULL,
CONSTRAINT [PK_ShippingTermsLookup] PRIMARY KEY CLUSTERED (ShippingTermID ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

/* ShippingOrders */
CREATE TABLE [dbo].[ShippingOrders](
	[ShippingOrderID]	[int] IDENTITY(1,1)	NOT NULL,
	[PurchaseOrderID]	[int]				NOT NULL,
	[ShippingTermID] 	[int]				NOT NULL,
	[UserID]			[int]				NULL,
	[ShipDate]			[Date]				NULL,
	[Picked]			[bit]				NOT NULL DEFAULT(0),
	[ShipToName]		[varchar](50)		NULL,
	[ShipToAddress]		[varchar](250)		NULL,
	[ShipToCity]		[varchar](50)		NULL,
	[ShipToState]		[varchar](50)		NULL,
	[ShipToZip]			[varchar](10)		NULL,
CONSTRAINT [PK_ShippingOrders] PRIMARY KEY CLUSTERED (ShippingOrderID ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

/* ShippingOrderLineItems */
CREATE TABLE [dbo].[ShippingOrderLineItems](
	[ShippingOrderID] 	[int]				NOT NULL,
	[ProductID]			[int]				NOT NULL,
	[Quantity]			[int]				NOT NULL,
	[Picked]			[bit]				NOT NULL DEFAULT(0),
CONSTRAINT [PK_ShippingOrderLineItems] PRIMARY KEY CLUSTERED (ShippingOrderID,ProductID ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)ON [PRIMARY]
GO


/* **********************************Alter Table Statements******************************************* */

/* Alter Table for ShippingTermsLookup Table */
AlTER TABLE [dbo].[ShippingTermsLookup] WITH NOCHECK ADD CONSTRAINT[FK_ShippingTermsLookup_ShippingVendor] 
	FOREIGN KEY([ShippingVendorID])
	REFERENCES [dbo].[ShippingVendors] ([ShippingVendorID])
GO

/* Alter Table for ShippingOrders Table */
AlTER TABLE [dbo].[ShippingOrders] WITH NOCHECK ADD CONSTRAINT[FK_ShippingOrders_ShippingTermsLookup] 
	FOREIGN KEY([ShippingTermID])
	REFERENCES [dbo].[ShippingTermsLookup] ([ShippingTermID])
GO

AlTER TABLE [dbo].[ShippingOrders] WITH NOCHECK ADD CONSTRAINT[FK_ShippingOrders_Users] 
	FOREIGN KEY([UserID])
	REFERENCES [dbo].[Users] ([UserID])
GO



/* Alter Table for ShippingOrderLineItems */
ALTER TABLE [dbo].[ShippingOrderLineItems]  WITH NOCHECK ADD  CONSTRAINT [FK_ShippingOrderLineItems_ShippingOrders] 
	FOREIGN KEY([ShippingOrderID])
	REFERENCES [dbo].[ShippingOrders] ([ShippingOrderID])
GO
ALTER TABLE [dbo].[ShippingOrderLineItems]  WITH NOCHECK ADD  CONSTRAINT [FK_ShippingOrderLineItems_Products] 
	FOREIGN KEY([ProductID])
	REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[ShippingOrderLineItems] WITH NOCHECK ADD CONSTRAINT [UQ_ShippingOrderID_ProductID]
	UNIQUE ([ShippingOrderID], [ProductID])
GO





/* Insert for ShippingVendors */
SET IDENTITY_INSERT [dbo].[ShippingVendors] ON
INSERT [dbo].[ShippingVendors] ([ShippingVendorID],[Name],[Address],[City],[State],[Country],[Zip],[Phone],[Contact],[ContactEmail])
VALUES (1,'FedEx','2315 Edgewood Rd SW','Cedar Rapids','IA','United States','52404','319-390-5393','Speedy Gonzales','QuickMouse@fedex.com')
INSERT [dbo].[ShippingVendors] ([ShippingVendorID],[Name],[Address],[City],[State],[Country],[Zip],[Phone],[Contact],[ContactEmail])
VALUES (2,'UPS','3315 Williams Blvd SW Suite 2','Cedar Rapids','IA','United States','52404','319-365-2112','Road Runner','Acme42@ups.com')
INSERT [dbo].[ShippingVendors] ([ShippingVendorID],[Name],[Address],[City],[State],[Country],[Zip],[Phone],[Contact],[ContactEmail])
VALUES (3,'USPS','615 6th Ave SE','Cedar Rapids','IA','United States','52401-1923','319-39905560','Snail','ItWillGetThereEventually@usps.com')
SET IDENTITY_INSERT [dbo].[ShippingVendors] OFF
GO

/* Insert for shippingTermsLookup */
SET IDENTITY_INSERT [dbo].[ShippingTermsLookup] ON
INSERT [dbo].[ShippingTermsLookup] ([ShippingTermID],[ShippingVendorID],[Description]) VALUES (1,1,'Overnight')
INSERT [dbo].[ShippingTermsLookup] ([ShippingTermID],[ShippingVendorID],[Description]) VALUES (2,1,'2-day')
INSERT [dbo].[ShippingTermsLookup] ([ShippingTermID],[ShippingVendorID],[Description]) VALUES (3,1,'3-day')
INSERT [dbo].[ShippingTermsLookup] ([ShippingTermID],[ShippingVendorID],[Description]) VALUES (4,1,'5-7 days')
INSERT [dbo].[ShippingTermsLookup] ([ShippingTermID],[ShippingVendorID],[Description]) VALUES (5,2,'Overnight')
INSERT [dbo].[ShippingTermsLookup] ([ShippingTermID],[ShippingVendorID],[Description]) VALUES (6,2,'2-day')
INSERT [dbo].[ShippingTermsLookup] ([ShippingTermID],[ShippingVendorID],[Description]) VALUES (7,2,'3-day')
INSERT [dbo].[ShippingTermsLookup] ([ShippingTermID],[ShippingVendorID],[Description]) VALUES (8,2,'5-7 days')
INSERT [dbo].[ShippingTermsLookup] ([ShippingTermID],[ShippingVendorID],[Description]) VALUES (9,3,'Overnight')
INSERT [dbo].[ShippingTermsLookup] ([ShippingTermID],[ShippingVendorID],[Description]) VALUES (10,3,'2-day')
INSERT [dbo].[ShippingTermsLookup] ([ShippingTermID],[ShippingVendorID],[Description]) VALUES (11,3,'3-day')
INSERT [dbo].[ShippingTermsLookup] ([ShippingTermID],[ShippingVendorID],[Description]) VALUES (12,3,'5-7 days')
SET IDENTITY_INSERT [dbo].[ShippingTermsLookup] OFF
GO

/* Insert for ShippingOrders */
SET IDENTITY_INSERT [dbo].[ShippingOrders] ON
INSERT [dbo].[ShippingOrders] ([ShippingOrderID],[PurchaseOrderID],[ShippingTermID],[UserID],[ShipDate]) 
VALUES (1,1,1,1,'2014-02-22')
INSERT [dbo].[ShippingOrders] ([ShippingOrderID],[PurchaseOrderID],[ShippingTermID],[UserID],[ShipDate]) 
VALUES (2,2,2,2,'2014-02-23')
INSERT [dbo].[ShippingOrders] ([ShippingOrderID],[PurchaseOrderID],[ShippingTermID],[UserID],[ShipDate]) 
VALUES (3,3,3,2,'2014-02-23')
INSERT [dbo].[ShippingOrders] ([ShippingOrderID],[PurchaseOrderID],[ShippingTermID],[UserID],[ShipDate]) 
VALUES (4,4,3,2,'2014-02-24')
INSERT [dbo].[ShippingOrders] ([ShippingOrderID],[PurchaseOrderID],[ShippingTermID],[UserID],[ShipDate]) 
VALUES (5,5,1,2,'2014-02-25')
SET IDENTITY_INSERT [dbo].[ShippingOrders] OFF
GO

/* Insert for ShippingOrderLineItems */
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity]) VALUES (1,1,1)
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity]) VALUES (1,3,3)
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity]) VALUES (1,5,2)
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity]) VALUES (1,7,4)
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity]) VALUES (1,8,5)
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity]) VALUES (1,9,3)
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity]) VALUES (2,3,1)
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity]) VALUES (2,5,7)
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity]) VALUES (2,7,2)
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity],[Picked]) VALUES (2,11,15,'1')
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity],[Picked]) VALUES (3,12,4,'1')
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity],[Picked]) VALUES (3,3,8,'1')
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity],[Picked]) VALUES (3,1,1,'1')
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity]) VALUES (4,1,1)
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity]) VALUES (4,10,5)
INSERT [dbo].[ShippingOrderLineItems] ([ShippingOrderID],[ProductID],[Quantity],[Picked]) VALUES (5,5,5,'1')
GO 

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
GO		

CREATE PROCEDURE [proc_UpdateShippingOrder]
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
		[UserID]		=	@orig_UserID AND
		[Picked]		=	@orig_Picked AND
		[ShipDate]		=	@orig_ShipDate AND
		[ShippingTermID]=   @orig_ShippingTermID AND
		[ShipToName] 	=	@orig_ShipToName AND
		[ShipToAddress] =	@orig_ShipToAddress AND
		[ShipToCity]	=	@orig_ShipToCity AND
		[ShipToState] 	= 	@orig_ShipToState AND
		[ShipToZip] 	=	@orig_ShipToZip
	RETURN @@ROWCOUNT
GO

CREATE PROCEDURE [proc_UpdateShippingOrderPicked]
(
	@shippingOrderID int
)
AS
	UPDATE [dbo].[ShippingOrders]
	SET [Picked] = 1
	WHERE [ShippingOrderID] = @shippingOrderID
GO

CREATE PROCEDURE [proc_UpdateShippingOrderRemovePicked]
(
	@shippingOrderID int
)
AS
	UPDATE [dbo].[ShippingOrders]
	SET [Picked] = 0
	WHERE [ShippingOrderID] = @shippingOrderID
GO

/* Changed name from proc_ShipShippingOrder to proc_SetShippingOrderShipDate */
/* This Procedure also replaces proc_UnpickShippingOrder */
CREATE PROCEDURE [proc_UpdateShippingOrderShipDate] 
(
	@shippingOrderID int,
	@shipDate Date
)
AS	
	UPDATE [dbo].[ShippingOrders]
	SET [ShipDate] = @ShipDate
	WHERE [ShippingOrderID] = @ShippingOrderID
GO

CREATE PROCEDURE [proc_UpdateShippingOrderRemoveShipDate] 
(
	@shippingOrderID int
)
AS
	UPDATE [dbo].[ShippingOrders]
	SET [ShipDate] = NULL
	WHERE [ShippingOrderID] = @shippingOrderID
GO

CREATE PROCEDURE [proc_UpdateShippingOrderUser]
(
	@shippingOrderID int,
	@newUserID int
)
AS
	UPDATE [dbo].[ShippingORders]
	SET [UserID] = @newUserID
	WHERE [ShippingOrderID] = @shippingOrderID
GO

CREATE PROCEDURE [proc_UpdateShippingOrderRemoveUser]
(
	@shippingOrderID int
)
AS
	UPDATE [dbo].[ShippingOrders]
	SET [UserID] = NULL
	WHERE [ShippingOrderID] = @shippingOrderID
GO

CREATE PROCEDURE [proc_GetAllShippingOrders]
AS
	SELECT so.[ShippingOrderID], so.[PurchaseOrderID], so.[UserID], u.[LastName], u.[FirstName],
	so.[Picked],so.[ShipDate], so.[ShippingTermID],st.[Description],sv.[Name],
	so.[ShipToName], so.[ShipToAddress], so.[ShipToCity], so.[ShipToState], so.[ShipToZip]
	FROM [dbo].[Users] u
	RIGHT OUTER JOIN [dbo].[ShippingOrders] so
	ON u.[UserID] = so.[UserID]
	JOIN [dbo].[ShippingTermsLookup] st
	ON so.[ShippingTermID] = st.[ShippingTermID]
	JOIN [dbo].[ShippingVendors] sv
	ON st.[ShippingVendorID] = sv.[ShippingVendorID]
	ORDER BY so.[ShippingOrderID]
GO

CREATE PROCEDURE [proc_GetAllShippingOrdersPicked]
As
	SELECT so.[ShippingOrderID], so.[PurchaseOrderID], so.[UserID], u.[LastName], u.[FirstName],
	so.[Picked],so.[ShipDate], so.[ShippingTermID],st.[Description],sv.[Name],
	so.[ShipToName], so.[ShipToAddress], so.[ShipToCity], so.[ShipToState], so.[ShipToZip]
	FROM [dbo].[Users] u
	RIGHT OUTER JOIN [dbo].[ShippingOrders] so
	ON u.[UserID] = so.[UserID]
	JOIN [dbo].[ShippingTermsLookup] st
	ON so.[ShippingTermID] = st.[ShippingTermID]
	JOIN [dbo].[ShippingVendors] sv
	ON st.[ShippingVendorID] = sv.[ShippingVendorID]
	WHERE [Picked] = 1
	ORDER BY so.[ShippingOrderID]
GO

CREATE PROCEDURE [proc_GetAllShippingOrdersNotPicked]
As
	SELECT so.[ShippingOrderID], so.[PurchaseOrderID], so.[UserID], u.[LastName], u.[FirstName],
	so.[Picked],so.[ShipDate], so.[ShippingTermID],st.[Description],sv.[Name],
	so.[ShipToName], so.[ShipToAddress], so.[ShipToCity], so.[ShipToState], so.[ShipToZip]
	FROM [dbo].[Users] u
	RIGHT OUTER JOIN [dbo].[ShippingOrders] so
	ON u.[UserID] = so.[UserID]
	JOIN [dbo].[ShippingTermsLookup] st
	ON so.[ShippingTermID] = st.[ShippingTermID]
	JOIN [dbo].[ShippingVendors] sv
	ON st.[ShippingVendorID] = sv.[ShippingVendorID]
	WHERE [Picked] = 0
	ORDER BY so.[ShippingOrderID]
GO

CREATE PROCEDURE [proc_GetAllShippingOrdersShipped]
As
	SELECT so.[ShippingOrderID], so.[PurchaseOrderID], so.[UserID], u.[LastName], u.[FirstName],
	so.[Picked],so.[ShipDate], so.[ShippingTermID],st.[Description],sv.[Name],
	so.[ShipToName], so.[ShipToAddress], so.[ShipToCity], so.[ShipToState], so.[ShipToZip]
	FROM [dbo].[Users] u
	RIGHT OUTER JOIN [dbo].[ShippingOrders] so
	ON u.[UserID] = so.[UserID]
	JOIN [dbo].[ShippingTermsLookup] st
	ON so.[ShippingTermID] = st.[ShippingTermID]
	JOIN [dbo].[ShippingVendors] sv
	ON st.[ShippingVendorID] = sv.[ShippingVendorID]
	WHERE so.[ShipDate] IS NOT NULL
	ORDER BY so.[ShippingOrderID]
GO

CREATE PROCEDURE [proc_GetAllShippingOrdersNotShipped]
As
	SELECT so.[ShippingOrderID], so.[PurchaseOrderID], so.[UserID], u.[LastName], u.[FirstName],
	so.[Picked],so.[ShipDate], so.[ShippingTermID],st.[Description],sv.[Name],
	so.[ShipToName], so.[ShipToAddress], so.[ShipToCity], so.[ShipToState], so.[ShipToZip]
	FROM [dbo].[Users] u
	RIGHT OUTER JOIN [dbo].[ShippingOrders] so
	ON u.[UserID] = so.[UserID]
	JOIN [dbo].[ShippingTermsLookup] st
	ON so.[ShippingTermID] = st.[ShippingTermID]
	JOIN [dbo].[ShippingVendors] sv
	ON st.[ShippingVendorID] = sv.[ShippingVendorID]
	WHERE so.[ShipDate] IS NULL
	ORDER BY so.[ShippingOrderID]
GO

CREATE PROCEDURE [proc_GetShippingOrderByID]
(
	@shippingOrderID int
)
AS
	SELECT so.[ShippingOrderID], so.[PurchaseOrderID], so.[UserID], u.[LastName], u.[FirstName],
	so.[Picked],so.[ShipDate], so.[ShippingTermID],st.[Description],sv.[Name],
	so.[ShipToName], so.[ShipToAddress], so.[ShipToCity], so.[ShipToState], so.[ShipToZip]
	FROM [dbo].[Users] u
	RIGHT OUTER JOIN [dbo].[ShippingOrders] so
	ON u.[UserID] = so.[UserID]
	JOIN [dbo].[ShippingTermsLookup] st
	ON so.[ShippingTermID] = st.[ShippingTermID]
	JOIN [dbo].[ShippingVendors] sv
	ON st.[ShippingVendorID] = sv.[ShippingVendorID]
	WHERE so.[ShippingOrderID] = @shippingOrderID
	ORDER BY so.[ShippingOrderID]
GO

CREATE PROCEDURE [proc_GetShippingOrderByPurchaseOrderID]
(
	@purchaseOrderID int
)
AS
	SELECT so.[ShippingOrderID], so.[PurchaseOrderID], so.[UserID], u.[LastName], u.[FirstName],
	so.[Picked],so.[ShipDate], so.[ShippingTermID],st.[Description],sv.[Name],
	so.[ShipToName], so.[ShipToAddress], so.[ShipToCity], so.[ShipToState], so.[ShipToZip]
	FROM [dbo].[Users] u
	RIGHT OUTER JOIN [dbo].[ShippingOrders] so
	ON u.[UserID] = so.[UserID]
	JOIN [dbo].[ShippingTermsLookup] st
	ON so.[ShippingTermID] = st.[ShippingTermID]
	JOIN [dbo].[ShippingVendors] sv
	ON st.[ShippingVendorID] = sv.[ShippingVendorID]
	WHERE so.[PurchaseOrderID] = @purchaseOrderID
	ORDER BY so.[PurchaseOrderID]
GO

CREATE PROCEDURE [proc_GetAllShippingOrdersByEmployee]
(
	@userID int
)
AS
	SELECT so.[ShippingOrderID], so.[PurchaseOrderID], so.[UserID], u.[LastName], u.[FirstName],
	so.[Picked],so.[ShipDate], so.[ShippingTermID],st.[Description],sv.[Name],
	so.[ShipToName], so.[ShipToAddress], so.[ShipToCity], so.[ShipToState], so.[ShipToZip]
	FROM [dbo].[Users] u
	RIGHT OUTER JOIN [dbo].[ShippingOrders] so
	ON u.[UserID] = so.[UserID]
	JOIN [dbo].[ShippingTermsLookup] st
	ON so.[ShippingTermID] = st.[ShippingTermID]
	JOIN [dbo].[ShippingVendors] sv
	ON st.[ShippingVendorID] = sv.[ShippingVendorID]
	WHERE so.[UserID] = @userID
	ORDER BY so.[UserID]
GO

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
GO

CREATE PROCEDURE [proc_UpdateShippingOrderLineItem]
(
	@shippingOrderID int,
    @productID int,
    @quantity int,
    @picked bit,
	@orig_ShippingOrderID int,
    @orig_ProductID int,
    @orig_Quantity int,
    @orig_Picked bit
)
AS
	UPDATE [dbo].[ShippingOrderLineItems]
	SET
		[ShippingOrderID] = @shippingOrderID,
		[ProductID] = @productID,
		[Quantity] = @quantity,
		[Picked] = @picked
	WHERE 
		[ShippingOrderID] = @orig_ShippingOrderID AND
		[ProductID] = @orig_ProductID AND
		[Quantity] = @orig_Quantity AND
		[Picked] = @orig_Picked
	RETURN @@ROWCOUNT
GO

CREATE PROCEDURE [proc_UpdateShippingOrderLineItemPicked]
(
	@shippingOrderID int,
	@productID int
)
AS
	UPDATE [dbo].[ShippingOrderLineItems]
	SET [Picked] = 1
	WHERE [ShippingOrderID] = @shippingOrderID AND
		  [ProductID] = @productID
GO

CREATE PROCEDURE [proc_UpdateShippingOrderLineItemRemovePicked]
(
	@shippingOrderID int,
	@productID int
)
AS
	UPDATE [dbo].[ShippingOrderLineItems]
	SET [Picked] = 0
	WHERE [ShippingOrderID] = @shippingOrderID AND
		  [ProductID] = @productID
GO



CREATE PROCEDURE [proc_GetAllShippingOrderLineItems]
AS
	SELECT li.[ShippingOrderID], li.[ProductID], p.[ShortDesc], li.[Quantity], p.[Location], li.[Picked]
	FROM [dbo].[ShippingOrderLineItems] li
	JOIN [dbo].[Products] p
	ON li.[ProductID] = p.[ProductID]
GO



CREATE PROCEDURE [proc_GetShippingOrderLineItems]
(
	@shippingOrderID int
)	
AS
	SELECT li.[ShippingOrderID], li.[ProductID], p.[ShortDesc], li.[Quantity], p.[Location], li.[Picked]
	FROM [dbo].[ShippingOrderLineItems] li
	JOIN [dbo].[Products] p
	ON li.[ProductID] = p.[ProductID]
	WHERE li.[ShippingOrderID] = @shippingOrderID
GO

/* ShippingTermDAL Stored Procedures */
/* ShippingTermID is an Identity and will be created on Update can not pass it in */
CREATE PROCEDURE [proc_InsertIntoShippingTerm]
(
	@shippingVendorID int,
	@description varchar(250)
)
AS
	INSERT INTO [dbo].[ShippingTermsLookup]([ShippingVendorID],[Description])
	VALUES (@shippingVendorID,@description)
GO

CREATE PROCEDURE [proc_UpdateShippingTerm]
(
	@shippingVendorID int,
	@description varchar(250),
	@orig_ShippingTermID int,
	@orig_ShippingVendorID int,
	@orig_Description varchar(250)
)
AS
	UPDATE [dbo].[ShippingTermsLookup]
	SET
		[ShippingVendorID]  = @shippingVendorID,
		[Description] 		= @description
	WHERE 
		[ShippingTermID]	= @orig_ShippingTermID AND
		[ShippingVendorID]	= @orig_ShippingVendorID AND
		[Description]		= @orig_Description
	RETURN @@ROWCOUNT
GO

CREATE PROCEDURE [proc_GetShippingTermsByID]
(
	@shippingTermID int
)
AS
	SELECT *
	FROM [dbo].[ShippingTermsLookup]
	WHERE [ShippingTermID] = @shippingTermID
GO

CREATE PROCEDURE [proc_GetAllShippingTerms]
AS
	SELECT *
	FROM [dbo].[ShippingTermsLookup]
GO

/* ShippingVendorDAL stored Procedures */
CREATE PROCEDURE [proc_InsertIntoShippingVendors]
(
    @name varchar(50),
    @address varchar(50),
    @city varchar(25),
    @state varchar(2),
	@country varchar(50),
    @zip varchar(10),
    @phone varchar(12),
    @contact varchar(50),
    @contactEmail varchar(50)
)
AS
	INSERT INTO [dbo].[ShippingVendors]([Name],[Address],[City],[State],[Country],[Zip],[Phone],[Contact],[ContactEmail])
	VALUES(@name,@address,@city,@state,@country,@zip,@phone,@contact,@contactEmail)
GO

CREATE PROCEDURE [proc_UpdateShippingVendor]
(
	@name varchar(50),
    @address varchar(50),
    @city varchar(25),
    @state varchar(2),
	@country varchar(50),
    @zip varchar(10),
    @phone varchar(12),
    @contact varchar(50),
    @contactEmail varchar(50),
	@orig_ShippingVendorID int,
	@orig_Name varchar(50),
    @orig_Address varchar(50),
    @orig_City varchar(25),
    @orig_State varchar(2),
	@orig_Country varchar(50),
    @orig_Zip varchar(10),
    @orig_Phone varchar(12),
    @orig_Contact varchar(50),
    @orig_ContactEmail varchar(50)
)
AS
	UPDATE [dbo].[ShippingVendors]
	SET
		[Name]		= @name,
		[Address]	= @address,
		[City]		= @city,
		[State]		= @state,
		[Country]	= @country,
		[Zip]		= @zip,
		[Phone]		= @phone,
		[Contact]   = @contact,
		[ContactEmail] = @contactEmail
	WHERE
		[ShippingVendorID] = @orig_ShippingVendorID AND
		[Name]		= @orig_Name AND
		[Address]	= @orig_Address AND
		[City]		= @orig_City AND
		[State]		= @orig_State AND
		[Country]	= @orig_Country AND
		[Zip]		= @orig_Zip AND
		[Phone]		= @orig_Phone AND
		[Contact]   = @orig_Contact AND
		[ContactEmail] = @orig_ContactEmail
	RETURN @@ROWCOUNT
GO

CREATE PROCEDURE [proc_GetShippingVendorByID]
(
	@shippingVendorID int
)
AS
	SELECT *
	FROM [dbo].[ShippingVendors]
	WHERE [ShippingVendorID] = @shippingVendorID
GO

CREATE PROCEDURE [proc_GetAllShippingVendors]
AS
	SELECT *
	FROM [dbo].[ShippingVendors]
GO


