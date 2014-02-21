IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'Inventory') 
BEGIN
DROP DATABASE Inventory
END
GO

CREATE DATABASE Inventory
GO

USE [Inventory]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

/* **************************************Create Table Statements************************************** */
/* Roles */
CREATE TABLE [dbo].[Roles](
RoleID 			[int] IDENTITY(1000,100) NOT NULL,
Title			[varchar](25)		NOT NULL,
Description 	[varchar](250) 		NOT NULL,
CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/* Users */
CREATE TABLE [dbo].[Users] (
UserID 			[int] IDENTITY(1,1) NOT NULL,
RoleID 			[int]						,
Password 		[varchar](50) 	 	NOT NULL,
FirstName 		[varchar](25) 		NOT NULL,
LastName 		[varchar](25) 		NOT NULL,
PhoneNumber 	[varchar](14) 		NOT NULL,
Address 		[varchar](50) 		NOT NULL,
City 			[varchar](25) 		NOT NULL,
State 			[varchar](25) 		NOT NULL,
Zip 			[varchar](9)		NOT NULL,
Active 			[Bit]				NOT NULL DEFAULT(1),
CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/* Products */
CREATE TABLE [dbo].[Products] (
	[ProductID] 		[int] IDENTITY(1,1) not null,
	[Available]			[int]			 	not null DEFAULT(0),
	[OnHand]			[int]				not null DEFAULT(0),
	[Description]		[varchar](250)		not null,
	[Location]			[varchar](250)		,
	[UnitPrice]			[money]				not null,
	[ShortDesc]			[varchar](50)		not null,
	[ReorderThreshold]	[int]				null,
	[ReorderAmount]		[int]				null,
	[ShippingDimensions][varchar](50)		null,
	[ShippingWeight]	[float]				null,
	[Active]			[bit]				not null DEFAULT(1),
CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductID] ASC)
WITH (PAD_INDEX=OFF, STATISTICS_NORECOMPUTE=OFF, ALLOW_ROW_LOCKS=ON, ALLOW_PAGE_LOCKS=ON) ON [PRIMARY]
)ON [PRIMARY]
GO

/* Locations */
CREATE TABLE [dbo].[Locations] (
	[Location] 	[varchar](250) 		not null,
	[Active]	[bit]				not null DEFAULT(1),
CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED ([Location] ASC)
WITH (PAD_INDEX=OFF, STATISTICS_NORECOMPUTE=OFF, ALLOW_ROW_LOCKS=ON, ALLOW_PAGE_LOCKS=ON) ON [PRIMARY]
)ON [PRIMARY]
GO

/* Categories */
CREATE TABLE [dbo].[Categories] (
	[Category] 		[varchar](50) 		not null,
	[Active]		[bit]				not null DEFAULT(1),
CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Category] ASC)
WITH (PAD_INDEX=OFF, STATISTICS_NORECOMPUTE=OFF, ALLOW_ROW_LOCKS=ON, ALLOW_PAGE_LOCKS=ON) ON [PRIMARY]
)ON [PRIMARY]
GO

/* ProductCategories */
CREATE TABLE [dbo].[ProductCategories] (
	[ProductID] 			[int] 				not null,
	[Category]				[varchar](50)		not null,
	[Active]				[bit]				not null DEFAULT(1),
CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED ([ProductID],[Category])
WITH (PAD_INDEX=OFF, STATISTICS_NORECOMPUTE=OFF, ALLOW_ROW_LOCKS=ON, ALLOW_PAGE_LOCKS=ON) ON [PRIMARY]
)ON [PRIMARY]
GO

/* Vendors */
CREATE TABLE [dbo].[Vendors] (
	[VendorID]		[int] IDENTITY(1,1)	not null,
	[Name]			[varchar](50)		not null,
	[Address]		[varchar](50)		not null,
	[City]			[varchar](50)		not null,
	[State]			[char](2)			not null,
	[Country]		[varchar](25)		not null,
	[Zip]			[char](10)			not null,
	[Phone]			[char](12)			not null,
	[Contact]		[varchar](50)		not null,
	[ContactEmail]	[varchar](50)		not null,
	[Active]		[bit] 				not null DEFAULT(1),
	
CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED ([VendorID] ASC)
WITH (PAD_INDEX=OFF, STATISTICS_NORECOMPUTE=OFF, ALLOW_ROW_LOCKS=ON, ALLOW_PAGE_LOCKS=ON)ON [PRIMARY]
) ON [PRIMARY]
GO

/* VendorSourceItems */
CREATE TABLE [dbo].[VendorSourceItems](
	[VendorID] 				[int] 			not null,
	[ProductID] 			[int] 			not null,
	[UnitCost]				[Money]  		not null,
	[MinQtyToOrder] 		[int]			not null,
	[ItemsPerCase]			[int]			not null,
	[Active]				[bit]			not null DEFAULT(1)
 CONSTRAINT [PK_VendorSourceItems] PRIMARY KEY CLUSTERED 
(
	ProductID,VendorID ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/* **********************************Alter Table Statements******************************************* */
/* Alter Table for Users Table */
AlTER TABLE [dbo].[Users] WITH NOCHECK ADD CONSTRAINT[FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
/* Alter Table for Products Table */
ALTER TABLE [dbo].[Products] WITH NOCHECK ADD CONSTRAINT [FK_Products_Locations] 
	FOREIGN KEY([Location])
	REFERENCES [dbo].[Locations]([Location])
GO

/* Alter Table for ProductCategories */
ALTER TABLE [dbo].[ProductCategories] WITH NOCHECK ADD CONSTRAINT [FK_ProductCategories_Products] 
	FOREIGN KEY([ProductID])
	REFERENCES [dbo].[Products]([ProductID])
GO
ALTER TABLE [dbo].[ProductCategories] WITH NOCHECK ADD CONSTRAINT [FK_ProductCategories_Categories] 
	FOREIGN KEY([Category])
	REFERENCES [dbo].[Categories]([Category])
GO
ALTER TABLE [dbo].[ProductCategories] WITH NOCHECK ADD CONSTRAINT [UQ_ProductID_Category] 
	UNIQUE ([ProductID], [Category])
GO

/* Alter Table for VendorSourceItems */
ALTER TABLE [dbo].[VendorSourceItems]  WITH NOCHECK ADD  CONSTRAINT [FK_VendorSourceItems_Products] 
	FOREIGN KEY([ProductID])
	REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[VendorSourceItems]  WITH NOCHECK ADD  CONSTRAINT [FK_VendorSourceItems_Vendors] 
	FOREIGN KEY([VendorID])
	REFERENCES [dbo].[Vendors] ([VendorID])
GO
ALTER TABLE [dbo].[VendorSourceItems] WITH NOCHECK ADD CONSTRAINT [UQ_ProductID_VendorID]
	UNIQUE ([ProductID], [VendorID])
GO


/* **************************************Insert Statements******************************************** */           
/* Inserts for Roles */
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([RoleID],[Title], [Description]) VALUES (1000,'Manager', 'Oversees all activity.')
INSERT [dbo].[Roles] ([RoleID],[Title], [Description]) VALUES (1100,'Employee', 'More work!?')
INSERT [dbo].[Roles] ([RoleID],[Title], [Description]) VALUES (1200,'Guest', 'Restricted Access')
INSERT [dbo].[Roles] ([RoleID],[Title], [Description]) VALUES (1300,'Level 4', '-------To Be filled--------')
INSERT [dbo].[Roles] ([RoleID],[Title], [Description]) VALUES (1400,'Level 5', '-------To Be filled--------')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO

/* Inserts for Users */
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([UserID],[RoleID],[Password],[FirstName],[LastName],[PhoneNumber],[Address],[City],[State],[Zip],[Active]) 
VALUES (1,1000,'1111','Bob','Ross','1-800-262-7677','314 Happy Tree Lane','Daytona Beach', 'Florida', '32114', '1')
INSERT [dbo].[Users] ([UserID],[RoleID],[Password],[FirstName],[LastName],[PhoneNumber],[Address],[City],[State],[Zip],[Active]) 
VALUES (2,1100,'1111','James Tiberius','Kirk','1-555-555-1701','NCC-1701 Enterprise','Riverside', 'Iowa', '57001', '1')
INSERT [dbo].[Users] ([UserID],[RoleID],[Password],[FirstName],[LastName],[PhoneNumber],[Address],[City],[State],[Zip],[Active]) 
VALUES (3,1200,'1111','Rose','Tyler','1-555-555-1963','42 Wibbly Wobbly Timey Wimey Road','Gallifrey', 'South Dakota', '32114', '1')
INSERT [dbo].[Users] ([UserID],[RoleID],[Password],[FirstName],[LastName],[PhoneNumber],[Address],[City],[State],[Zip],[Active]) 
VALUES (4,1300,'1111','Jayne','Cobb','1-555-555-2002','Corner of Firefly and Serenity','Canton', 'Missouri', '63435', '1')
INSERT [dbo].[Users] ([UserID],[RoleID],[Password],[FirstName],[LastName],[PhoneNumber],[Address],[City],[State],[Zip],[Active]) 
VALUES (5,1400,'1111','Jaedis','Tristran','1-555-555-1337','221B Baker Street','Martha''s Vineyard', 'Massachusetts', '02552', '0')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

/* Inserts for Locations */
INSERT [dbo].[Locations] ([Location]) VALUES ('Bin 1A')
INSERT [dbo].[Locations] ([Location]) VALUES ('Bin 1B')
INSERT [dbo].[Locations] ([Location]) VALUES ('Bin 2A')
INSERT [dbo].[Locations] ([Location]) VALUES ('Bin 2B')
INSERT [dbo].[Locations] ([Location]) VALUES ('Bin 3A')
INSERT [dbo].[Locations] ([Location]) VALUES ('Bin 3B')
GO
/* Inserts for Categories */

INSERT [dbo].[Categories] ([Category]) Values ('Keyboard')
INSERT [dbo].[Categories] ([Category]) Values ('Mouse')
INSERT [dbo].[Categories] ([Category]) Values ('Hard Drive')
INSERT [dbo].[Categories] ([Category]) Values ('Monitor')
INSERT [dbo].[Categories] ([Category]) Values ('Graphics Card')
INSERT [dbo].[Categories] ([Category]) Values ('Computer Case')
INSERT [dbo].[Categories] ([Category]) Values ('MotherBoard')
GO
/* Inserts for Products */
SET IDENTITY_INSERT [dbo].[Products] ON
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
VALUES (1, 10, 3, 'Basic Qwerty Keyboard', 'Bin 2A', 10.99, 'Keyboard Basic 23', 4, 3, '26x10x2', 4.62)
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
VALUES (2, 10, 4, 'Rollerball Mouse', 11.99, 'Mouse 2.3.1' , 2, 2, '6x4x3', 1.00)
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
VALUES (3, 10, 2, 'Really Awesome 450T Hard Drive', 'Bin 2B', 1000.99, '450T Hard drive', 5, 5, '4x3x1', 2.16)
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
VALUES (5, 10, 4, 'Pretty Pink Computer Case', 'Bin 2B', 25.75, 'Ugly Pink Case', 1, 3, '32x26x9', 10.93)
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
VALUES (6, 10, 8, 'Wireless Mouse and Keyboard Set', 'Bin 3A', 25.75, 'Wireless Mouse&Keyboard', 4, 6, '34x10x2', 6.81)
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
VALUES (7, 10, 7, 'Super Awesome Mouse Pad', 'Bin 3B', 35.99, 'Mouse Pad', 4, 4, '8x8x1', 0.32)
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
VALUES (8, 10, 10, 'Happy Days Graphics Card v10.99.21', 'Bin 1A', 40.99, 'Buggy Card', 3, 3, '4x5x3', 2.38)
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
VALUES (9, 10, 2, 'Clean Your Room Reminder Board', 'Bin 2A', 376.98, 'Yes Mom, Mother Board', 6, 10, '8x12x2', 3.92)
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
VALUES (10, 10, 0, 'Huge Amazing 8 Inch Monitor', 10.72, '8 inch Monitor', 6, 12, '24x19x4', 12.90)
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
VALUES (11, 10, 1, 'Better Than Yours Accessory Pack', 'Bin 3B', 98.77, 'Better Pack', 5, 10, '24x36x10', 36.42)
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight], [Active])
VALUES (12, 10, 2, 'Ivan the Chess Wiz Computer Drive', 'Bin 2A', 700.66, 'Ivan Drive', 8, 16, '10x8x2', 5.36, 0)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
/* Inserts for ProductCategories */
INSERT [dbo].[ProductCategories] ([ProductID], [Category]) VALUES (1, 'MotherBoard')
INSERT [dbo].[ProductCategories] ([ProductID], [Category]) VALUES (2, 'MotherBoard')
INSERT [dbo].[ProductCategories] ([ProductID], [Category]) VALUES (3, 'MotherBoard')
INSERT [dbo].[ProductCategories] ([ProductID], [Category]) VALUES (5, 'MotherBoard')
INSERT [dbo].[ProductCategories] ([ProductID], [Category]) VALUES (6, 'MotherBoard')
INSERT [dbo].[ProductCategories] ([ProductID], [Category]) VALUES (7, 'MotherBoard')
INSERT [dbo].[ProductCategories] ([ProductID], [Category]) VALUES (8, 'MotherBoard')
INSERT [dbo].[ProductCategories] ([ProductID], [Category]) VALUES (9, 'MotherBoard')
INSERT [dbo].[ProductCategories] ([ProductID], [Category]) VALUES (10, 'MotherBoard')
INSERT [dbo].[ProductCategories] ([ProductID], [Category]) VALUES (11, 'MotherBoard')
INSERT [dbo].[ProductCategories] ([ProductID], [Category]) VALUES (12, 'MotherBoard')
GO

/* Inserts for Vendors */
/* I didnt do Identity_Insert, is that bad? - Andrew 1/26/14 1700 */
INSERT [dbo].[Vendors] ( [Name], [Address], [City], [State], [Country], [Zip], [Phone], [Contact], [ContactEmail] ) VALUES ( 'DerTech', '802 Bird St.','Dallas', 'TX', 'United States', '75266-0199', '972-995-2011', 'Bob Ducca', 'bob@ducca.com' )
INSERT [dbo].[Vendors] ( [Name], [Address], [City], [State], [Country], [Zip], [Phone], [Contact], [ContactEmail] ) VALUES ( 'PlaceNet', '6301 Owens Ave.','Woodland Hills', 'CA', 'United States', '91367-0123', '888-942-6650', 'Scott Auckerman', 'scott@auckerman.biz' )
INSERT [dbo].[Vendors] ( [Name], [Address], [City], [State], [Country], [Zip], [Phone], [Contact], [ContactEmail] ) VALUES ( 'NokaBiz', '200 S Mathilda Ave.','Sunnyvale', 'CA', 'United States', '94086-4444', '888-456-8181', 'Will Forte', 'will@forte.com' )
INSERT [dbo].[Vendors] ( [Name], [Address], [City], [State], [Country], [Zip], [Phone], [Contact], [ContactEmail] ) VALUES ( 'BriblyTech', '808 Garth St.','Gally', 'CA', 'United States', '94086-7788', '800-678-8888', 'Gary Busey', 'gary@busey.edu' )
INSERT [dbo].[Vendors] ( [Name], [Address], [City], [State], [Country], [Zip], [Phone], [Contact], [ContactEmail], [Active] ) VALUES ( 'Terrorbyte', '689 Tick Dr.','Poow', 'CA', 'United States', '95086-7788', '800-222-5646', 'Nick Nolte', 'nick@nolte.org', '0' )
GO

/* Inserts for VendorSourceItems */
INSERT [dbo].[VendorSourceItems] ([ProductID],[VendorID], [UnitCost],[MinQtyToOrder],[ItemsPerCase],[Active]) VALUES (1, 1, 5.00, 10, 25, 1)
INSERT [dbo].[VendorSourceItems] ([ProductID],[VendorID], [UnitCost],[MinQtyToOrder],[ItemsPerCase],[Active]) VALUES (5, 1, 15.00, 10,25, 1)
INSERT [dbo].[VendorSourceItems] ([ProductID],[VendorID], [UnitCost],[MinQtyToOrder],[ItemsPerCase],[Active]) VALUES (7, 1, 30.00, 10,25, 1)
INSERT [dbo].[VendorSourceItems] ([ProductID],[VendorID], [UnitCost],[MinQtyToOrder],[ItemsPerCase],[Active]) VALUES (10, 1, 5.00, 10,25, 1)

INSERT [dbo].[VendorSourceItems] ([ProductID],[VendorID], [UnitCost],[MinQtyToOrder],[ItemsPerCase],[Active]) VALUES (2, 2, 5.00, 10,  25,1)
INSERT [dbo].[VendorSourceItems] ([ProductID],[VendorID], [UnitCost],[MinQtyToOrder],[ItemsPerCase],[Active]) VALUES (5, 2, 15.00, 10, 25,1)
INSERT [dbo].[VendorSourceItems] ([ProductID],[VendorID], [UnitCost],[MinQtyToOrder],[ItemsPerCase],[Active]) VALUES (8, 2, 30.00, 10, 25,1)
INSERT [dbo].[VendorSourceItems] ([ProductID],[VendorID], [UnitCost],[MinQtyToOrder],[ItemsPerCase],[Active]) VALUES (11, 2, 50.00, 10,25, 0)

INSERT [dbo].[VendorSourceItems] ([ProductID],[VendorID], [UnitCost],[MinQtyToOrder],[ItemsPerCase],[Active]) VALUES (3, 3, 500.00, 10,25, 1)
INSERT [dbo].[VendorSourceItems] ([ProductID],[VendorID], [UnitCost],[MinQtyToOrder],[ItemsPerCase],[Active]) VALUES (6, 3, 20.00, 10, 25,1)
INSERT [dbo].[VendorSourceItems] ([ProductID],[VendorID], [UnitCost],[MinQtyToOrder],[ItemsPerCase],[Active]) VALUES (9, 3, 200.00, 10,25, 1)
INSERT [dbo].[VendorSourceItems] ([ProductID],[VendorID], [UnitCost],[MinQtyToOrder],[ItemsPerCase],[Active]) VALUES (12, 3, 500.00, 10,25, 0)
GO




/* **************************************Stored Procedures******************************************** */   


/* ** Stored Procedures for Vendors** */

/* Insert Vendor into Vendors */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertIntoVendor]
	(@Name varchar(50),
	 @Address varchar(50),
	 @City varchar(50),
	 @State char(2),
	 @Country VarChar(25),
	 @Zip Char(10),
	 @Phone Char(12),
	 @Contact VarChar(50),
	 @ContactEmail VarChar(50)
	 )
AS
	INSERT INTO Vendors
	    (Name, Address, City, State, Country, Zip, Phone, Contact, ContactEmail)
	VALUES
	    (@Name, @Address, @City, @State, @Country, @Zip, @Phone, @Contact, @ContactEmail)

	RETURN @@ROWCOUNT
GO


/*Object:  StoredProcedure [dbo].[sp_UpdateVendorName]*/
CREATE PROCEDURE [dbo].[sp_UpdateVendorName]
	(@Name varchar(50),
	 @original_VendorID int,
	 @original_Name varchar(50))
AS
	UPDATE Vendors
	SET Name = @Name
	WHERE VendorID = @original_VendorID
	AND Name = @original_Name

	RETURN @@ROWCOUNT
GO

/*Object:  StoredProcedure [dbo].[sp_UpdateVendor]*/
CREATE PROCEDURE [dbo].[sp_UpdateVendor]
	(@Name varchar(50),
	 @Address varchar(50),
	 @City varchar(50),
	 @State char(2),
	 @Country VarChar(25),
	 @Zip char(10),
	 @Phone char(12),
	 @Contact varchar(50),
	 @ContactEmail varchar(50),
	 @original_VendorID int,
	 @original_Name varchar(50),
	 @original_Address varchar(50),
	 @original_City varchar(50),
	 @original_State char(2),
	 @original_Country varchar(25),
	 @original_Zip char(10),
	 @original_Phone char(12),
	 @original_Contact varchar(50),
	 @original_ContactEmail varchar(50))
AS
	UPDATE Vendors
	   SET Name = @Name,
	       Address = @Address,
	       City = @City,
	       State = @State,
	       Country = @Country,
	       Zip = @Zip,
	       Phone = @Phone,
	       Contact = @Contact
	WHERE VendorID = @original_VendorID
	  AND Name = @original_Name
	  AND Address = @original_Address
	  AND City = @original_City
	  AND State = @original_State
	  AND Country = @original_Country
	  AND Zip = @original_Zip
	  AND Phone = @original_Phone
	  AND Contact = @original_Contact
	  AND ContactEmail = @original_ContactEmail
	
	RETURN @@ROWCOUNT
GO


/*Object: StoredProcedure [dbo].[sp_DeactivateVendor]*/
CREATE PROCEDURE [sp_DeactivateVendor]
	(@VendorID int)
AS
	UPDATE [dbo].[Vendors]
		SET [Active] = 0
	WHERE [VendorID] = @VendorID
	RETURN @@ROWCOUNT
GO

/* Object: StoredProcedure [dbo].[sp_ReactivateVendor] */
CREATE PROCEDURE [sp_ReactivateVendor]
	(@VendorID int)
AS
	UPDATE [dbo].[Vendors]
		SET [Active] = 1
	WHERE VendorID = @VendorID
	RETURN @@ROWCOUNT
GO

/*Object: StoredProcedure [dbo].[sp_DeleteVendor] */
CREATE PROCEDURE [sp_DeleteVendor]
	(@VendorID int)
AS
	DELETE FROM [dbo].[Vendors]
	WHERE [VendorID] = @VendorID
	RETURN @@ROWCOUNT
GO


/*Object:  StoredProcedure [dbo].[sp_GetVendor]*/
CREATE PROCEDURE [dbo].[sp_GetVendor]
	(@VendorID int)
AS
	SELECT *
	FROM Vendors
	WHERE VendorID = @VendorID
	Return
GO

/*Object:  StoredProcedure [dbo].[sp_GetVendors]*/
CREATE PROCEDURE [dbo].[sp_GetVendors]
AS
	SELECT *
	FROM Vendors 
	Return
GO

/*Object:  StoredProcedure [dbo].[sp_GetVendorsActive]*/
CREATE PROCEDURE [dbo].[sp_GetVendorsActive]
AS
	SELECT *
	FROM Vendors
	WHERE Active = 1
	Return
GO

/*Stored Procedures for [dbo].[Products] table*/
/*Object:  StoredProcedure [dbo].[sp_InsertIntoProducts]*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE PROCEDURE [dbo].[sp_InsertIntoProducts]
	(@Available			Int,
	@OnHand			Int,
	@Description		VarChar(250),
	@Location			varchar(250),
	@UnitPrice			Money,
	@ShortDesc			VarChar(50),
	@ReorderThreshold	int,
	@ReorderAmount		int,
	@ShippingDimensions varchar(50),
	@ShippingWeight		float,
	@Active				Bit)
AS
	INSERT IntO [dbo].[Products]([Available],[OnHand],[Description],[Location],[UnitPrice],[ShortDesc],[ReorderThreshold],[ReorderAmount],[ShippingDimensions],[ShippingWeight],[Active])
	VALUES ( @Available, @OnHand, @Description, @Location, @UnitPrice, @ShortDesc, @ReorderThreshold, @ReorderAmount, @ShippingDimensions, @ShippingWeight, @Active)
	RETURN @@ROWCOUNT
GO

/*Object:  StoredProcedure [dbo].[sp_UpdateProducts]*/
CREATE PROCEDURE [dbo].[sp_UpdateProducts]
	(@ProductID				Int,
	@Available				Int,
	@OriginalAvailable		Int,
	@OnHand				Int,
	@OriginalOnHand		Int,
	@Description			VarChar(250),
	@OriginalDescription	VarChar(250),
	@Location				varchar(250),
	@OriginalLocation		varchar(250),
	@UnitPrice				Money,
	@OriginalUnitPrice		Money,
	@ShortDesc				VarChar(50),
	@OriginalShortDesc		VarChar(50),
	@ReorderThreshold		int,
	@OriginalReorderThreshold int,
	@ReorderAmount			int,
	@OriginalReorderAmount	int,
	@ShippingDimensions		varchar(50),
	@OriginalShippingDimensions varchar(50),
	@ShippingWeight			float,
	@OriginalShippingWeight	float,
	@Active					Bit,
	@OriginalActive			Bit)
AS
	UPDATE [dbo].[Products]
	SET [Available] = @Available, [OnHand] = @OnHand, [Description] = @Description, [Location] = @Location, [UnitPrice] = @UnitPrice, [ShortDesc] = @ShortDesc, [ReorderThreshold] = @ReorderThreshold, [ReorderAmount] = @ReorderAmount, [ShippingDimensions] = @ShippingDimensions, [ShippingWeight] = @ShippingWeight, [Active] = @Active
	WHERE [ProductID] = @ProductID
	AND [Available] = @OriginalAvailable
	AND [OnHand] = @OriginalOnHand
	AND [Description] = @OriginalDescription
	AND [Location] = @OriginalLocation
	AND [UnitPrice] = @OriginalUnitPrice
	AND [ShortDesc] = @OriginalShortDesc
	AND [ReorderThreshold] = @OriginalReorderThreshold
	AND [ReorderAmount] = @OriginalReorderAmount
	AND [ShippingDimensions] = @OriginalShippingDimensions
	AND	[ShippingWeight] = @OriginalShippingWeight
	AND [Active] = @OriginalActive
	RETURN @@ROWCOUNT
GO

/*Object:  StoredProcedure [dbo].[sp_DeactivateProduct]*/
CREATE PROCEDURE [dbo].[sp_DeactivateProduct]
	(@ProductID		Int)
AS
	UPDATE [dbo].[Products]
	SET [Active] = 0
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT
GO

/*Object:  StoredProcedure [dbo].[sp_ReactivateProduct]*/
CREATE PROCEDURE [dbo].[sp_ReactivateProduct]
	(@ProductID		Int)
AS
	UPDATE [dbo].[Products]
	SET [Active] = 1
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT
GO

/*Object:  StoredProcedure [dbo].[sp_DeleteProduct]*/
CREATE PROCEDURE [dbo].[sp_DeleteProduct]
	(@ProductID				Int,
	@Available				Int,
	@OnHand				int,
	@Description			VarChar(250),
	@Location				varchar(250),
	@UnitPrice				Money,
	@ShortDesc				VarChar(50),
	@ReorderThreshold		int,
	@ReorderAmount			int,
	@ShippingDimensions		varchar(50),
	@ShippingWeight			float,
	@Active					Bit)
AS
	DELETE FROM [dbo].[Products]
	WHERE [ProductID] = @ProductID
	AND [Available] = @Available
	AND [OnHand] = @OnHand
	AND [Description] = @Description
	AND [Location] = @Location
	AND [UnitPrice] = @UnitPrice
	AND [ShortDesc] = @ShortDesc
	AND [ReorderThreshold] = @ReorderThreshold
	AND [ReorderAmount] = @ReorderAmount
	AND [ShippingDimensions] = @ShippingDimensions
	AND [ShippingWeight] = @ShippingWeight
	AND [Active] = @Active
	RETURN @@ROWCOUNT
GO

/*Object:  StoredProcedure [dbo].[sp_GetProducts]*/
CREATE PROCEDURE [dbo].[sp_GetProducts]
AS
	SELECT * FROM [dbo].[Products]
	ORDER BY [ProductID]
GO

/*Object:  StoredProcedure [dbo].[sp_GetProduct]*/
CREATE PROCEDURE [dbo].[sp_GetProduct]
	(@ProductID		Int)
AS
	SELECT * FROM [dbo].[Products]
	WHERE [ProductID] = @ProductID
	ORDER BY [ProductID]
GO

/*Object:  StoredProcedure [dbo].[sp_GetProductsByActive]*/
CREATE PROCEDURE [dbo].[sp_GetProductsByActive]
	(@Active	Int)
AS
	SELECT * FROM [dbo].[Products]
	WHERE [Active] = @Active
	ORDER BY [ProductID]
GO


/* VendorSourceItems Stored Procedures */
/*Object: StoredProcedure [dbo].[sp_InsertIntoVendorSourceItems]*/
CREATE PROCEDURE [sp_InsertIntoVendorSourceItems]
	(@productID int,
	@vendorID 	int,
	@unitCost	money,
	@minQtyToOrder		int,
	@itemsPerCase  int,
	@active		bit)
AS
	INSERT INTO VendorSourceItems(ProductID, VendorID, UnitCost, MinQtyToOrder,ItemsPerCase, Active) VALUES (@productID, @vendorID, @unitCost, @minQtyToOrder,@itemsPerCase, @active)
	RETURN @@IDENTITY
GO
	
/*Object: StoredProcedure [dbo].[sp_UpdateVendorSourceItem]*/
CREATE PROCEDURE [sp_UpdateVendorSourceItem]
	(@vendorID int,
	 @productID int,
	 @unitCost money,
	 @minQtyToOrder int,
	 @itemsPerCase int,
	 @orig_vendorID int,
	 @orig_productID int,
	 @orig_unitCost money,
	 @orig_minQtyToOrder int,
	 @orig_itemsPerCase int)
AS
	UPDATE [dbo].[VendorSourceItems]
		SET [VendorID] = @vendorID,
			[ProductID] = @productID,
			[UnitCost] = @unitCost,
			[MinQtyToOrder] = @minQtyToOrder,
			[ItemsPerCase] = @itemsPerCase
	WHERE [VendorID] = @orig_vendorID
		AND [ProductID] = @orig_productID
		AND [UnitCost] = @orig_unitCost
		AND [MinQtyToOrder] = @orig_minQtyToOrder
		AND [ItemsPerCase] = @orig_itemsPerCase
	RETURN @@ROWCOUNT
GO

/*Object: StoredProcedure [dbo].[sp_DeactivateVendorSourceItem]*/
CREATE PROCEDURE [sp_DeactivateVendorSourceItem]
	(@vendorID int,
	 @productID int)
AS
	UPDATE [dbo].[VendorSourceItems]
		SET [Active] = 0
	WHERE [VendorID] = @vendorID
		AND [ProductID] = @productID
	RETURN @@ROWCOUNT
GO

/* Object: StoredProcedure [dbo].[sp_ReactivateVendorSourceItem] */
CREATE PROCEDURE [sp_ReactivateVendorSourceItem]
	(@vendorID int,
	 @productID int)
AS
	UPDATE [dbo].[VendorSourceItems]
		SET [Active] = 1
	WHERE [VendorID] = @vendorID
		AND [ProductID] = @productID
	RETURN @@ROWCOUNT
GO

/*Object: StoredProcedure [dbo].[sp_DeleteVendorSourceItem] */
CREATE PROCEDURE [sp_DeleteVendorSourceItem]
	(@vendorID int,
	 @productID int)
AS
	DELETE FROM [dbo].[VendorSourceItems]
	WHERE [VendorID] = @vendorID
		AND [ProductID] = @productID
	RETURN @@ROWCOUNT
GO

/*Object: StoredProcedure [dbo].[sp_GetVendorSourceItems] */
CREATE PROCEDURE [sp_GetAllVendorSourceItems]
AS
	SELECT [VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase]
	FROM [dbo].[VendorSourceItems]
	WHERE [Active] = 1
	RETURN
GO

/*Object: StoredProcedure [dbo].[sp_GetVendorSourceItem] */
CREATE PROCEDURE [sp_GetVendorSourceItem]
	(@vendorID int,
	 @productID int)
AS
	SELECT [VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase], [Active]
	FROM [dbo].[VendorSourceItems]
	WHERE [VendorID] = @vendorID
		AND [ProductID] = @productID
	RETURN @@ROWCOUNT
	RETURN
GO

/*Object: StoredProcedure [dbo].[sp_GetVendorSourceItemsByVendor] */
CREATE PROCEDURE [sp_GetVendorSourceItemsByVendor]
	(@vendorID int)
AS
	SELECT [VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase]
	FROM [dbo].[VendorSourceItems]
	WHERE [Active] = 1
		AND [VendorID] = @vendorID
	RETURN
GO
	
/*Object: StoredProcedure [dbo].[sp_GetVendorSourceItemsByProduct] */
CREATE PROCEDURE [sp_GetVendorSourceItemsByProduct]
	(@productID int)
AS
	SELECT [VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase]
	FROM [dbo].[VendorSourceItems]
	WHERE [Active] = 1
		AND [ProductID] = @productID
	RETURN
GO
/* Categories Stored Procedures */

/*Object: StoredProcedure [dbo].[sp_InsertIntoCategories] */
CREATE PROCEDURE [sp_InsertIntoCategories]
	(@category varchar(50))
AS
	INSERT INTO [dbo].[Categories]
		([Category])
	VALUES
		(@Category)
GO	
	
/*Object: StoredProcedure [dbo].[sp_UpdateCategory] */
CREATE PROCEDURE [sp_UpdateCategory]
	(@category varchar(50),
	 @orig_category varchar(50))
AS
	UPDATE [dbo].[Categories]
		SET [Category] = @category
	WHERE [Category] = @orig_category
	RETURN @@ROWCOUNT
GO

/*Object: StoredProcedure [dbo].[sp_DeactivateCategory] */
CREATE PROCEDURE [sp_DeactivateCategory]
	(@category varchar(50))
AS
	UPDATE [dbo].[Categories]
		SET [Active] = 0
	WHERE [Category] = @category
	RETURN @@ROWCOUNT
GO

/*Object: StoredProcedure [dbo].[sp_ReactivateCategory] */
CREATE PROCEDURE [sp_ReactivateCategory]
	(@category varchar(50))
AS
	UPDATE [dbo].[Categories]
		SET [Active] = 1
	WHERE [Category] = @category
	RETURN @@ROWCOUNT
GO
 
/*Object: StoredProcedure [dbo].[sp_DeleteCategory] */
CREATE PROCEDURE [sp_DeleteCategory]
	(@category varchar(50))
AS
	DELETE FROM[dbo].[Categories]
	WHERE [Category] = @category
	RETURN @@ROWCOUNT
GO

/*Object: StoredProcedure [dbo].[sp_GetCategories] */
CREATE PROCEDURE [sp_GetCategories]
AS
	SELECT [Category]
	FROM [dbo].[Categories]
	WHERE [Active] = 1
	RETURN
GO

/*Object: StoredProcedure [dbo].[sp_GetCategory] */
/*No need for this anymore*/
/*CREATE PROCEDURE [sp_GetCategory]
	(@categoryID int)
AS
	SELECT [CategoryID], [Description]
	FROM [dbo].[Categories]
	WHERE [Active] = 1
		AND [CategoryID] = @categoryID
	RETURN
GO
*/

/* Locations Stored Procedures */

/*Object: StoredProcedure [dbo].[sp_InsertIntoLocations] */
CREATE PROCEDURE [sp_InsertIntoLocations]
	(@location varchar(250))
AS
	INSERT INTO [dbo].[Locations]
		([Location])
	VALUES
		(@location)
GO
	
/*Object: StoredProcedure [dbo].[sp_UpdateLocation] */
CREATE PROCEDURE [sp_UpdateLocation]
	(@location varchar(250),
	 @orig_location varchar(250))
AS
	UPDATE [dbo].[Locations]
		SET [Location] = @location
	WHERE [Location] = @orig_location
	RETURN @@ROWCOUNT
GO

/*Object: StoredProcedure [dbo].[sp_DeactivateLocation] */
CREATE PROCEDURE [sp_DeactivateLocation]
	(@location varchar(250))
AS
	UPDATE [dbo].[Locations]
		SET [Active] = 0
	WHERE [Location] = @location
	RETURN @@ROWCOUNT
GO
/*Object: StoredProcedure [dbo].[sp_ReactivateLocation] */
CREATE PROCEDURE [sp_ReactivateLocation]
	(@location varchar(250))
AS
	UPDATE [dbo].[Locations]
		SET [Active] = 1
	WHERE [Location] = @location
	RETURN @@ROWCOUNT
GO
/*Object: StoredProcedure [dbo].[sp_DeleteLocation] */
CREATE PROCEDURE [sp_DeleteLocation]
	(@location varchar(250))
AS
	DELETE FROM [dbo].[Locations]
	WHERE [Location] = @location
	RETURN @@ROWCOUNT
GO
/*Object: StoredProcedure [dbo].[sp_GetLocations] */
CREATE PROCEDURE [sp_GetLocations]
AS
	SELECT [Location]
	FROM [dbo].[Locations]
	WHERE [Active] = 1
	RETURN
GO
/*Object: StoredProcedure [dbo].[sp_GetLocation] */
/*No need for this either*/
/*CREATE PROCEDURE [sp_GetLocation]
	(@locationID int)
AS
	SELECT [LocationID], [Description]
	FROM [dbo].[Locations]
	WHERE [Active] = 1
		AND [LocationID] = @locationID
	RETURN
GO
*/

/* ProductCategories Stored Procedures */

/*Object: StoredProcedure [dbo].[sp_InsertIntoProductCategories] */
CREATE PROCEDURE [sp_InsertIntoProductCategories]
	(@productID int,
	 @category varchar(50))
AS
	INSERT INTO [dbo].[ProductCategories]
		([ProductID], [Category])
	VALUES
		(@productID, @category)
	RETURN @@IDENTITY
GO	
	
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
GO

/*Object: StoredProcedure [dbo].[sp_DeactivateProductCategory] */
CREATE PROCEDURE [sp_DeactivateProductCategory]
	(@productID int,
	 @category varchar(50))
AS
	UPDATE [dbo].[ProductCategories]
		SET Active = 0
		WHERE ProductID = @productID
			AND Category = @category
	RETURN @@ROWCOUNT
GO

/*Object: StoredProcedure [dbo].[sp_ReactivateProductCategory] */
CREATE PROCEDURE [sp_ReactivateProductCategory]
	(@productID int,
	 @category varchar(50))
AS
	UPDATE [dbo].[ProductCategories]
		SET Active = 1
		WHERE ProductID = @productID
			AND Category = @category
	RETURN @@ROWCOUNT
GO

/*Object: StoredProcedure [dbo].[sp_DeleteProductCategory] */
CREATE PROCEDURE [sp_DeleteProductCategory]
	(@productID int,
	 @category varchar(50))
AS
	DELETE FROM [dbo].[ProductCategories]
		WHERE ProductID = @productID
			AND Category = @category
	RETURN @@ROWCOUNT
GO

/*Object: StoredProcedure [dbo].[sp_GetProductCategories] */
CREATE PROCEDURE [sp_GetProductCategories]
AS
	SELECT [ProductID], [Category]
	FROM [dbo].[ProductCategories]
	WHERE [Active] = 1
	RETURN
GO

/*Object: StoredProcedure [dbo].[sp_GetProductCategoriesByProduct] */
CREATE PROCEDURE [sp_GetProductCategoriesByProduct]
	(@productID int)
AS
	SELECT [ProductID], [ProductCategories].[Category]
	FROM [ProductCategories], [Categories]
	WHERE [ProductID] = @productID
		AND [ProductCategories].[Category] = [Categories].[Category]
	RETURN
GO

/*Object: StoredProcedure [dbo].[sp_GetProductCategoriesByCategory] */
CREATE PROCEDURE [sp_GetProductCategoriesByCategory]
	(@category varchar(50))
AS
	SELECT [Category], [ProductCategories].[ProductID], [Products].[ShortDesc] 
	FROM [ProductCategories], [Products]
	WHERE [Category] = @category
		AND [ProductCategories].[ProductID] = [Products].[ProductID]
	RETURN
GO
