﻿/*
Deployment script for InventoryDatabase
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, NUMERIC_ROUNDABORT, QUOTED_IDENTIFIER OFF;


GO
:setvar DatabaseName "InventoryDatabase"
:setvar DefaultDataPath "c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\"

GO
USE [master]

GO
:on error exit
GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL
    AND DATABASEPROPERTYEX(N'$(DatabaseName)','Status') <> N'ONLINE')
BEGIN
    RAISERROR(N'The state of the target database, %s, is not set to ONLINE. To deploy to this database, its state must be set to ONLINE.', 16, 127,N'$(DatabaseName)') WITH NOWAIT
    RETURN
END

GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [Inventory], FILENAME = 'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\Inventory.mdf', SIZE = 2304 KB, FILEGROWTH = 1024 KB)
    LOG ON (NAME = [Inventory_log], FILENAME = 'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\Inventory_log.LDF', SIZE = 768 KB, MAXSIZE = 2097152 MB, FILEGROWTH = 10 %) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
EXECUTE sp_dbcmptlevel [$(DatabaseName)], 100;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS OFF,
                ANSI_PADDING OFF,
                ANSI_WARNINGS OFF,
                ARITHABORT OFF,
                CONCAT_NULL_YIELDS_NULL OFF,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER OFF,
                ANSI_NULL_DEFAULT OFF,
                CURSOR_DEFAULT GLOBAL,
                RECOVERY SIMPLE,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY CHECKSUM,
                DATE_CORRELATION_OPTIMIZATION OFF,
                ENABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
USE [$(DatabaseName)]

GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
PRINT N'Creating [dbo].[Categories]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[Categories] (
    [Category] VARCHAR (50) NOT NULL,
    [Active]   BIT          NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_Categories...';


GO
ALTER TABLE [dbo].[Categories]
    ADD CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Category] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Locations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[Locations] (
    [Location] VARCHAR (250) NOT NULL,
    [Active]   BIT           NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_Locations...';


GO
ALTER TABLE [dbo].[Locations]
    ADD CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED ([Location] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[ProductCategories]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[ProductCategories] (
    [ProductID] INT          NOT NULL,
    [Category]  VARCHAR (50) NOT NULL,
    [Active]    BIT          NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_ProductCategories...';


GO
ALTER TABLE [dbo].[ProductCategories]
    ADD CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED ([ProductID] ASC, [Category] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating UQ_ProductID_Category...';


GO
ALTER TABLE [dbo].[ProductCategories]
    ADD CONSTRAINT [UQ_ProductID_Category] UNIQUE NONCLUSTERED ([ProductID] ASC, [Category] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[Products]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[Products] (
    [ProductID]          INT           IDENTITY (1, 1) NOT NULL,
    [Available]          INT           NOT NULL,
    [OnHand]             INT           NOT NULL,
    [Description]        VARCHAR (250) NOT NULL,
    [Location]           VARCHAR (250) NULL,
    [UnitPrice]          MONEY         NOT NULL,
    [ShortDesc]          VARCHAR (50)  NOT NULL,
    [ReorderThreshold]   INT           NULL,
    [ReorderAmount]      INT           NULL,
    [ShippingDimensions] VARCHAR (50)  NULL,
    [ShippingWeight]     FLOAT         NULL,
    [Active]             BIT           NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_Products...';


GO
ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Roles]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[Roles] (
    [RoleID]      INT           IDENTITY (1000, 100) NOT NULL,
    [Title]       VARCHAR (25)  NOT NULL,
    [Description] VARCHAR (250) NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_Roles...';


GO
ALTER TABLE [dbo].[Roles]
    ADD CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([RoleID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Users]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[Users] (
    [UserID]      INT          IDENTITY (1, 1) NOT NULL,
    [RoleID]      INT          NULL,
    [Password]    VARCHAR (50) NOT NULL,
    [FirstName]   VARCHAR (25) NOT NULL,
    [LastName]    VARCHAR (25) NOT NULL,
    [PhoneNumber] VARCHAR (14) NOT NULL,
    [Address]     VARCHAR (50) NOT NULL,
    [City]        VARCHAR (25) NOT NULL,
    [State]       VARCHAR (25) NOT NULL,
    [Zip]         VARCHAR (9)  NOT NULL,
    [Active]      BIT          NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_Users...';


GO
ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[VendorOrderLineItems]...';


GO
CREATE TABLE [dbo].[VendorOrderLineItems] (
    [VendorOrderID] INT NOT NULL,
    [ProductID]     INT NOT NULL,
    [QtyOrdered]    INT NOT NULL,
    [QtyReceived]   INT NOT NULL,
    [QtyDamaged]    INT NOT NULL,
    CONSTRAINT [PK_VendorOrderLineItems] PRIMARY KEY CLUSTERED ([VendorOrderID] ASC, [ProductID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[VendorOrders]...';


GO
CREATE TABLE [dbo].[VendorOrders] (
    [VendorOrderID]     INT           IDENTITY (1, 1) NOT NULL,
    [VendorID]          INT           NOT NULL,
    [DateOrdered]       SMALLDATETIME NOT NULL,
    [AmountOfShipments] INT           NOT NULL,
    [Finalized]         BIT           NOT NULL,
    [Active]            BIT           NOT NULL,
    CONSTRAINT [PK_VendorOrders] PRIMARY KEY CLUSTERED ([VendorOrderID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[Vendors]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[Vendors] (
    [VendorID]     INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50) NOT NULL,
    [Address]      VARCHAR (50) NOT NULL,
    [City]         VARCHAR (50) NOT NULL,
    [State]        CHAR (2)     NOT NULL,
    [Country]      VARCHAR (25) NOT NULL,
    [Zip]          CHAR (10)    NOT NULL,
    [Phone]        CHAR (12)    NOT NULL,
    [Contact]      VARCHAR (50) NOT NULL,
    [ContactEmail] VARCHAR (50) NOT NULL,
    [Active]       BIT          NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_Vendors...';


GO
ALTER TABLE [dbo].[Vendors]
    ADD CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED ([VendorID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[VendorSourceItems]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[VendorSourceItems] (
    [VendorID]      INT   NOT NULL,
    [ProductID]     INT   NOT NULL,
    [UnitCost]      MONEY NOT NULL,
    [MinQtyToOrder] INT   NOT NULL,
    [ItemsPerCase]  INT   NOT NULL,
    [Active]        BIT   NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_VendorSourceItems...';


GO
ALTER TABLE [dbo].[VendorSourceItems]
    ADD CONSTRAINT [PK_VendorSourceItems] PRIMARY KEY CLUSTERED ([ProductID] ASC, [VendorID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating UQ_ProductID_VendorID...';


GO
ALTER TABLE [dbo].[VendorSourceItems]
    ADD CONSTRAINT [UQ_ProductID_VendorID] UNIQUE NONCLUSTERED ([ProductID] ASC, [VendorID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY];


GO
PRINT N'Creating On column: Active...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
ALTER TABLE [dbo].[Categories]
    ADD DEFAULT ((1)) FOR [Active];


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating On column: Active...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
ALTER TABLE [dbo].[Locations]
    ADD DEFAULT ((1)) FOR [Active];


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating On column: Active...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
ALTER TABLE [dbo].[ProductCategories]
    ADD DEFAULT ((1)) FOR [Active];


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating On column: Available...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
ALTER TABLE [dbo].[Products]
    ADD DEFAULT ((0)) FOR [Available];


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating On column: OnHand...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
ALTER TABLE [dbo].[Products]
    ADD DEFAULT ((0)) FOR [OnHand];


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating On column: Active...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
ALTER TABLE [dbo].[Products]
    ADD DEFAULT ((1)) FOR [Active];


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating On column: Active...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
ALTER TABLE [dbo].[Users]
    ADD DEFAULT ((1)) FOR [Active];


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating On column: QtyOrdered...';


GO
ALTER TABLE [dbo].[VendorOrderLineItems]
    ADD DEFAULT (1) FOR [QtyOrdered];


GO
PRINT N'Creating On column: QtyReceived...';


GO
ALTER TABLE [dbo].[VendorOrderLineItems]
    ADD DEFAULT (1) FOR [QtyReceived];


GO
PRINT N'Creating On column: QtyDamaged...';


GO
ALTER TABLE [dbo].[VendorOrderLineItems]
    ADD DEFAULT (1) FOR [QtyDamaged];


GO
PRINT N'Creating On column: AmountOfShipments...';


GO
ALTER TABLE [dbo].[VendorOrders]
    ADD DEFAULT (1) FOR [AmountOfShipments];


GO
PRINT N'Creating On column: Finalized...';


GO
ALTER TABLE [dbo].[VendorOrders]
    ADD DEFAULT (0) FOR [Finalized];


GO
PRINT N'Creating On column: Active...';


GO
ALTER TABLE [dbo].[VendorOrders]
    ADD DEFAULT (1) FOR [Active];


GO
PRINT N'Creating On column: Active...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
ALTER TABLE [dbo].[Vendors]
    ADD DEFAULT ((1)) FOR [Active];


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating On column: Active...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
ALTER TABLE [dbo].[VendorSourceItems]
    ADD DEFAULT ((1)) FOR [Active];


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating FK_ProductCategories_Categories...';


GO
ALTER TABLE [dbo].[ProductCategories] WITH NOCHECK
    ADD CONSTRAINT [FK_ProductCategories_Categories] FOREIGN KEY ([Category]) REFERENCES [dbo].[Categories] ([Category]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_ProductCategories_Products...';


GO
ALTER TABLE [dbo].[ProductCategories] WITH NOCHECK
    ADD CONSTRAINT [FK_ProductCategories_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Products_Locations...';


GO
ALTER TABLE [dbo].[Products] WITH NOCHECK
    ADD CONSTRAINT [FK_Products_Locations] FOREIGN KEY ([Location]) REFERENCES [dbo].[Locations] ([Location]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Users_Roles...';


GO
ALTER TABLE [dbo].[Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Roles] ([RoleID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_VendorOrderLineItems_Products...';


GO
ALTER TABLE [dbo].[VendorOrderLineItems] WITH NOCHECK
    ADD CONSTRAINT [FK_VendorOrderLineItems_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_VendorOrderLineItems_VendorOrders...';


GO
ALTER TABLE [dbo].[VendorOrderLineItems] WITH NOCHECK
    ADD CONSTRAINT [FK_VendorOrderLineItems_VendorOrders] FOREIGN KEY ([VendorOrderID]) REFERENCES [dbo].[VendorOrders] ([VendorOrderID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_VendorOrders_Vendors...';


GO
ALTER TABLE [dbo].[VendorOrders] WITH NOCHECK
    ADD CONSTRAINT [FK_VendorOrders_Vendors] FOREIGN KEY ([VendorID]) REFERENCES [dbo].[Vendors] ([VendorID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_VendorSourceItems_Products...';


GO
ALTER TABLE [dbo].[VendorSourceItems] WITH NOCHECK
    ADD CONSTRAINT [FK_VendorSourceItems_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_VendorSourceItems_Vendors...';


GO
ALTER TABLE [dbo].[VendorSourceItems] WITH NOCHECK
    ADD CONSTRAINT [FK_VendorSourceItems_Vendors] FOREIGN KEY ([VendorID]) REFERENCES [dbo].[Vendors] ([VendorID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating [dbo].[proc_GetAllVendorOrderLineItems]...';


GO
CREATE PROCEDURE [dbo].[proc_GetAllVendorOrderLineItems]
AS
	SELECT [VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems]
RETURN
GO
PRINT N'Creating [dbo].[proc_GetAllVendorOrderLineItemsByVendor]...';


GO
CREATE PROCEDURE [dbo].[proc_GetAllVendorOrderLineItemsByVendor]
	(@VendorID int)
AS
	SELECT [VendorOrderLineItems].[VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems], [VendorOrders]
	where [VendorID] = @VendorID
RETURN
GO
PRINT N'Creating [dbo].[proc_GetAllVendorOrderLineItemsByVendorOrder]...';


GO
CREATE PROCEDURE [dbo].[proc_GetAllVendorOrderLineItemsByVendorOrder]
	@VendorOrderID int
AS
	SELECT [VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems]
	where [VendorOrderID] = @VendorOrderID
RETURN
GO
PRINT N'Creating [dbo].[proc_GetExceptionItems]...';


GO
CREATE PROCEDURE [dbo].[proc_GetExceptionItems]
AS
	SELECT [VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems]
	where QtyReceived > QtyOrdered
	or QtyDamaged > 0
RETURN
GO
PRINT N'Creating [dbo].[proc_GetExceptionItemsByVendor]...';


GO
CREATE PROCEDURE [dbo].[proc_GetExceptionItemsByVendor]
@VendorID int
AS
	SELECT [VendorOrderLineItems].[VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems],[VendorOrders]
	where [VendorID] = @VendorID
	and (QtyReceived > QtyOrdered
	or QtyDamaged > 0)
RETURN
GO
PRINT N'Creating [dbo].[proc_GetExceptionItemsByVendorOrder]...';


GO
CREATE PROCEDURE [dbo].[proc_GetExceptionItemsByVendorOrder]
@VendorOrderID int
AS
	SELECT [VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems]
	where [VendorOrderID] = @VendorOrderID
	and (QtyReceived > QtyOrdered
	or QtyDamaged > 0)
RETURN
GO
PRINT N'Creating [dbo].[proc_GetVendorOrderLineItem]...';


GO
CREATE PROCEDURE [dbo].[proc_GetVendorOrderLineItem]
	@VendorOrderID int, 
	@ProductID int
AS
	SELECT [VendorOrderID],[ProductID],[QtyOrdered],[QtyReceived],[QtyDamaged]
	from [VendorOrderLineItems]
	where [VendorOrderID] = @VendorOrderID
		and [ProductID] = @ProductID
RETURN
GO
PRINT N'Creating [dbo].[proc_InsertIntoVendorOrderLineItems]...';


GO
CREATE PROCEDURE [dbo].[proc_InsertIntoVendorOrderLineItems]
	(@VendorOrderID int,
     @ProductID int,
     @QtyOrdered int,
     @QtyReceived int,
     @QtyDamaged int)
AS
	INSERT INTO [dbo].[VendorOrderLineItems]
           ([VendorOrderID]
           ,[ProductID]
           ,[QtyOrdered]
           ,[QtyReceived]
           ,[QtyDamaged])
     VALUES
           (@VendorOrderID, @ProductID, @QtyOrdered, @QtyReceived, @QtyDamaged)
RETURN @@IDENTITY
GO
PRINT N'Creating [dbo].[proc_UpdateVendorOrderLineItems]...';


GO
CREATE PROCEDURE [dbo].[proc_UpdateVendorOrderLineItems]
	(@VendorOrderID int,
     @ProductID int,
     @QtyOrdered int,
     @QtyReceived int,
     @QtyDamaged int,
	 @orig_VendorOrderID int,
     @orig_ProductID int,
     @orig_QtyOrdered int,
     @orig_QtyReceived int,
     @orig_QtyDamaged int)
AS
	UPDATE [dbo].[VendorOrderLineItems]
   SET 
      [QtyOrdered] = @QtyOrdered,
      [QtyReceived] = @QtyReceived, 
      [QtyDamaged] = @QtyDamaged
 WHERE 
		[VendorOrderID] = @VendorOrderID
		and [ProductID] = @ProductID
		and [QtyOrdered] = @QtyOrdered
		and [QtyDamaged] = @QtyDamaged
		and [QtyReceived] = @QtyReceived
RETURN @@ROWCOUNT
GO
PRINT N'Creating [dbo].[sp_DeactivateCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_DeactivateLocation]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_DeactivateProduct]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_DeactivateProductCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_DeactivateVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_DeactivateVendorSourceItem]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_DeleteCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
 
/*Object: StoredProcedure [dbo].[sp_DeleteCategory] */
CREATE PROCEDURE [sp_DeleteCategory]
	(@category varchar(50))
AS
	DELETE FROM[dbo].[Categories]
	WHERE [Category] = @category
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_DeleteLocation]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
/*Object: StoredProcedure [dbo].[sp_DeleteLocation] */
CREATE PROCEDURE [sp_DeleteLocation]
	(@location varchar(250))
AS
	DELETE FROM [dbo].[Locations]
	WHERE [Location] = @location
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_DeleteProduct]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_DeleteProductCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_DeleteVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[sp_DeleteVendor] */
CREATE PROCEDURE [sp_DeleteVendor]
	(@VendorID int)
AS
	DELETE FROM [dbo].[Vendors]
	WHERE [VendorID] = @VendorID
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_DeleteVendorSourceItem]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetAllVendorSourceItems]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[sp_GetVendorSourceItems] */
CREATE PROCEDURE [sp_GetAllVendorSourceItems]
AS
	SELECT [VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase]
	FROM [dbo].[VendorSourceItems]
	WHERE [Active] = 1
	RETURN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetCategories]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[sp_GetCategories] */
CREATE PROCEDURE [sp_GetCategories]
AS
	SELECT [Category]
	FROM [dbo].[Categories]
	WHERE [Active] = 1
	RETURN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetLocations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
/*Object: StoredProcedure [dbo].[sp_GetLocations] */
CREATE PROCEDURE [sp_GetLocations]
AS
	SELECT [Location]
	FROM [dbo].[Locations]
	WHERE [Active] = 1
	RETURN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetProduct]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object:  StoredProcedure [dbo].[sp_GetProduct]*/
CREATE PROCEDURE [dbo].[sp_GetProduct]
	(@ProductID		Int)
AS
	SELECT * FROM [dbo].[Products]
	WHERE [ProductID] = @ProductID
	ORDER BY [ProductID]
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetProductCategories]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[sp_GetProductCategories] */
CREATE PROCEDURE [sp_GetProductCategories]
AS
	SELECT [ProductID], [Category]
	FROM [dbo].[ProductCategories]
	WHERE [Active] = 1
	RETURN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetProductCategoriesByCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetProductCategoriesByProduct]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetProducts]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object:  StoredProcedure [dbo].[sp_GetProducts]*/
CREATE PROCEDURE [dbo].[sp_GetProducts]
AS
	SELECT * FROM [dbo].[Products]
	ORDER BY [Active] DESC, [ProductID]
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetProductsByActive]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object:  StoredProcedure [dbo].[sp_GetProductsByActive]*/
CREATE PROCEDURE [dbo].[sp_GetProductsByActive]
	(@Active	Int)
AS
	SELECT * FROM [dbo].[Products]
	WHERE [Active] = @Active
	ORDER BY [ProductID]
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetVendors]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object:  StoredProcedure [dbo].[sp_GetVendors]*/
CREATE PROCEDURE [dbo].[sp_GetVendors]
AS
	SELECT *
	FROM Vendors 
	Return
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetVendorsActive]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object:  StoredProcedure [dbo].[sp_GetVendorsActive]*/
CREATE PROCEDURE [dbo].[sp_GetVendorsActive]
AS
	SELECT *
	FROM Vendors
	WHERE Active = 1
	Return
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetVendorSourceItem]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetVendorSourceItemsByProduct]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_GetVendorSourceItemsByVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_InsertIntoCategories]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_InsertIntoLocations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_InsertIntoProductCategories]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_InsertIntoProducts]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_InsertIntoVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_InsertIntoVendorSourceItems]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_ReactivateCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_ReactivateLocation]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_ReactivateProduct]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_ReactivateProductCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_ReactivateVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_ReactivateVendorSourceItem]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_UpdateCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_UpdateLocation]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_UpdateProductCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_UpdateProducts]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_UpdateVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_UpdateVendorName]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[sp_UpdateVendorSourceItem]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


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
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
-- Refactoring step to update target server with deployed transaction logs
CREATE TABLE  [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
GO
sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
GO

GO
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


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[ProductCategories] WITH CHECK CHECK CONSTRAINT [FK_ProductCategories_Categories];

ALTER TABLE [dbo].[ProductCategories] WITH CHECK CHECK CONSTRAINT [FK_ProductCategories_Products];

ALTER TABLE [dbo].[Products] WITH CHECK CHECK CONSTRAINT [FK_Products_Locations];

ALTER TABLE [dbo].[Users] WITH CHECK CHECK CONSTRAINT [FK_Users_Roles];

ALTER TABLE [dbo].[VendorOrderLineItems] WITH CHECK CHECK CONSTRAINT [FK_VendorOrderLineItems_Products];

ALTER TABLE [dbo].[VendorOrderLineItems] WITH CHECK CHECK CONSTRAINT [FK_VendorOrderLineItems_VendorOrders];

ALTER TABLE [dbo].[VendorOrders] WITH CHECK CHECK CONSTRAINT [FK_VendorOrders_Vendors];

ALTER TABLE [dbo].[VendorSourceItems] WITH CHECK CHECK CONSTRAINT [FK_VendorSourceItems_Products];

ALTER TABLE [dbo].[VendorSourceItems] WITH CHECK CHECK CONSTRAINT [FK_VendorSourceItems_Vendors];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        DECLARE @VarDecimalSupported AS BIT;
        SELECT @VarDecimalSupported = 0;
        IF ((ServerProperty(N'EngineEdition') = 3)
            AND (((@@microsoftversion / power(2, 24) = 9)
                  AND (@@microsoftversion & 0xffff >= 3024))
                 OR ((@@microsoftversion / power(2, 24) = 10)
                     AND (@@microsoftversion & 0xffff >= 1600))))
            SELECT @VarDecimalSupported = 1;
        IF (@VarDecimalSupported > 0)
            BEGIN
                EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
            END
    END


GO