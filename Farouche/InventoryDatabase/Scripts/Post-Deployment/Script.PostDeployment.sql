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
/*
*//* **************************************Insert Statements******************************************** */           
/* Inserts for Roles */
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([RoleID],[Title], [Description]) VALUES (1000,'Manager', 'Oversees all activity.')
INSERT [dbo].[Roles] ([RoleID],[Title], [Description]) VALUES (1100,'Employee', 'More work!?')
INSERT [dbo].[Roles] ([RoleID],[Title], [Description]) VALUES (1200,'Guest', 'Restricted Access')
INSERT [dbo].[Roles] ([RoleID],[Title], [Description]) VALUES (1300,'Level 4', '-------To Be filled--------')
INSERT [dbo].[Roles] ([RoleID],[Title], [Description]) VALUES (1400,'Level 5', '-------To Be filled--------')
SET IDENTITY_INSERT [dbo].[Roles] OFF

/* Inserts for Users */
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([UserID],[RoleID],[Password],[FirstName],[LastName],[PhoneNumber],[Address],[City],[State],[Zip],[Active]) 
INSERT [dbo].[Users] ([UserID],[RoleID],[Password],[FirstName],[LastName],[PhoneNumber],[Address],[City],[State],[Zip],[Active]) 
INSERT [dbo].[Users] ([UserID],[RoleID],[Password],[FirstName],[LastName],[PhoneNumber],[Address],[City],[State],[Zip],[Active]) 
INSERT [dbo].[Users] ([UserID],[RoleID],[Password],[FirstName],[LastName],[PhoneNumber],[Address],[City],[State],[Zip],[Active]) 
INSERT [dbo].[Users] ([UserID],[RoleID],[Password],[FirstName],[LastName],[PhoneNumber],[Address],[City],[State],[Zip],[Active]) 
SET IDENTITY_INSERT [dbo].[Users] OFF

/* Inserts for Locations */
INSERT [dbo].[Locations] ([Location]) VALUES ('Bin 1A')
INSERT [dbo].[Locations] ([Location]) VALUES ('Bin 1B')
INSERT [dbo].[Locations] ([Location]) VALUES ('Bin 2A')
INSERT [dbo].[Locations] ([Location]) VALUES ('Bin 2B')
INSERT [dbo].[Locations] ([Location]) VALUES ('Bin 3A')
INSERT [dbo].[Locations] ([Location]) VALUES ('Bin 3B')

/* Inserts for Categories */
INSERT [dbo].[Categories] ([Category]) Values ('Keyboard')
INSERT [dbo].[Categories] ([Category]) Values ('Mouse')
INSERT [dbo].[Categories] ([Category]) Values ('Hard Drive')
INSERT [dbo].[Categories] ([Category]) Values ('Monitor')
INSERT [dbo].[Categories] ([Category]) Values ('Graphics Card')
INSERT [dbo].[Categories] ([Category]) Values ('Computer Case')
INSERT [dbo].[Categories] ([Category]) Values ('MotherBoard')

/* Inserts for Products */
SET IDENTITY_INSERT [dbo].[Products] ON
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight])
INSERT [dbo].[Products] ([ProductID], [Available], [OnHand], [Description], [Location], [UnitPrice], [ShortDesc], [ReorderThreshold], [ReorderAmount], [ShippingDimensions], [ShippingWeight], [Active])
SET IDENTITY_INSERT [dbo].[Products] OFF

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

/* Inserts for Vendors */
/* I didnt do Identity_Insert, is that bad? - Andrew 1/26/14 1700 */
INSERT [dbo].[Vendors] ( [Name], [Address], [City], [State], [Country], [Zip], [Phone], [Contact], [ContactEmail] ) VALUES ( 'DerTech', '802 Bird St.','Dallas', 'TX', 'United States', '75266-0199', '972-995-2011', 'Bob Ducca', 'bob@ducca.com' )
INSERT [dbo].[Vendors] ( [Name], [Address], [City], [State], [Country], [Zip], [Phone], [Contact], [ContactEmail] ) VALUES ( 'PlaceNet', '6301 Owens Ave.','Woodland Hills', 'CA', 'United States', '91367-0123', '888-942-6650', 'Scott Auckerman', 'scott@auckerman.biz' )
INSERT [dbo].[Vendors] ( [Name], [Address], [City], [State], [Country], [Zip], [Phone], [Contact], [ContactEmail] ) VALUES ( 'NokaBiz', '200 S Mathilda Ave.','Sunnyvale', 'CA', 'United States', '94086-4444', '888-456-8181', 'Will Forte', 'will@forte.com' )
INSERT [dbo].[Vendors] ( [Name], [Address], [City], [State], [Country], [Zip], [Phone], [Contact], [ContactEmail] ) VALUES ( 'BriblyTech', '808 Garth St.','Gally', 'CA', 'United States', '94086-7788', '800-678-8888', 'Gary Busey', 'gary@busey.edu' )
INSERT [dbo].[Vendors] ( [Name], [Address], [City], [State], [Country], [Zip], [Phone], [Contact], [ContactEmail], [Active] ) VALUES ( 'Terrorbyte', '689 Tick Dr.','Poow', 'CA', 'United States', '95086-7788', '800-222-5646', 'Nick Nolte', 'nick@nolte.org', '0' )

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
*/