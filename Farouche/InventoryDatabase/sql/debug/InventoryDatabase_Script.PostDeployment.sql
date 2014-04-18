/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
			   SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [InventoryDatabase]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
INSERT [dbo].[ShippingOrders] ([ShippingOrderID],[PurchaseOrderID],[ShippingTermID],[UserID],[ShipDate],[ShipToName],[ShipToAddress],[ShipToCity],[ShipToState],[ShipToZip]) 
VALUES (1,1,1,1,'2014-02-22','Chit Richalds','1222 Decoy Street NW','Smalltown','IA','53004')
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

INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'AK', N'Alaska', 99500, 99999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'AL', N'Alabama', 35000, 36999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'AR', N'Arkansas', 71600, 72999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'AZ', N'Arizona', 85000, 86599)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'CA', N'California', 90000, 96699)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'CO', N'Colorado', 80000, 81699)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'CT', N'Connecticut', 6000, 6999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'DC', N'District of Columbia', 20000, 20599)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'DE', N'Delaware', 19700, 19999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'FL', N'Florida', 32000, 34999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'GA', N'Georgia', 30000, 31999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'HI', N'Hawaii', 96700, 96899)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'IA', N'Iowa', 50000, 52899)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'ID', N'Idaho', 83200, 83899)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'IL', N'Illinois', 60000, 62999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'IN', N'Indiana', 46000, 47999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'KS', N'Kansas', 66000, 67999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'KY', N'Kentucky', 40000, 42799)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'LA', N'Lousiana', 70000, 71499)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'MA', N'Massachusetts', 1000, 2799)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'MD', N'Maryland', 20600, 21999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'ME', N'Maine', 3900, 4999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'MI', N'Michigan', 48000, 49999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'MN', N'Minnesota', 55000, 56799)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'MO', N'Missouri', 63000, 65899)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'MS', N'Mississippi', 38600, 39799)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'MT', N'Montana', 59000, 59999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'NC', N'North Carolina', 27000, 28999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'ND', N'North Dakota', 58000, 58899)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'NE', N'Nebraska', 68000, 69399)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'NH', N'New Hampshire', 3000, 3899)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'NJ', N'New Jersey', 7000, 8999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'NM', N'New Mexico', 87000, 88499)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'NV', N'Nevada', 89000, 89899)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'NY', N'New York', 9000, 14999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'OH', N'Ohio', 43000, 45899)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'OK', N'Oklahoma', 73000, 74999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'OR', N'Oregon', 97000, 97999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'PA', N'Pennsylvania', 15000, 19699)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'RI', N'Rhode Island', 2800, 2999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'SC', N'South Carolina', 29000, 29999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'SD', N'South Dakota', 57000, 57799)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'TN', N'Tennessee', 37000, 38599)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'TX', N'Texas', 75000, 79999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'UT', N'Utah', 84000, 84799)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'VA', N'Virginia', 22000, 24699)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'VI', N'Virgin Islands', 801, 850)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'VT', N'Vermont', 5000, 5999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'WA', N'Washington', 98000, 99499)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'WI', N'Wisconsin', 53000, 54999)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'WV', N'West Virginia', 24700, 26899)
INSERT [dbo].[States] ([StateCode], [StateName], [FirstZipCode], [LastZipCode]) VALUES (N'WY', N'Wyoming', 82000, 83199)
GO

/*Inserts for VendorOrders*/
INSERT [dbo].[VendorOrders] ([VendorID],[DateOrdered]) VALUES (1, '2014-01-01T12:29:04') 
INSERT [dbo].[VendorOrders] ([VendorID],[DateOrdered]) VALUES (1, '2014-02-07T09:45:59')
INSERT [dbo].[VendorOrders] ([VendorID],[DateOrdered]) VALUES (2, '2014-03-28T10:44:08')
INSERT [dbo].[VendorOrders] ([VendorID],[DateOrdered]) VALUES (2, '2014-04-01T18:44:08')
INSERT [dbo].[VendorOrders] ([VendorID],[DateOrdered]) VALUES (3, '2013-11-28T20:44:08')
INSERT [dbo].[VendorOrders] ([VendorID],[DateOrdered]) VALUES (3, '2013-12-28T23:44:08')
