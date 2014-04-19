/*
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
PRINT N'Creating [dbo].[ApplicationVariables]...';


GO
CREATE TABLE [dbo].[ApplicationVariables] (
    [ParameterKey]   VARCHAR (50)  NOT NULL,
    [ParameterValue] VARCHAR (500) NOT NULL,
    UNIQUE NONCLUSTERED ([ParameterKey] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


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
    [OnOrder]            INT           NOT NULL,
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
PRINT N'Creating [dbo].[ShippingOrderLineItems]...';


GO
CREATE TABLE [dbo].[ShippingOrderLineItems] (
    [ShippingOrderID] INT NOT NULL,
    [ProductID]       INT NOT NULL,
    [Quantity]        INT NOT NULL,
    [Picked]          BIT NOT NULL,
    CONSTRAINT [PK_ShippingOrderLineItems] PRIMARY KEY CLUSTERED ([ShippingOrderID] ASC, [ProductID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating UQ_ShippingOrderID_ProductID...';


GO
ALTER TABLE [dbo].[ShippingOrderLineItems]
    ADD CONSTRAINT [UQ_ShippingOrderID_ProductID] UNIQUE NONCLUSTERED ([ShippingOrderID] ASC, [ProductID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[ShippingOrders]...';


GO
CREATE TABLE [dbo].[ShippingOrders] (
    [ShippingOrderID] INT           IDENTITY (1, 1) NOT NULL,
    [PurchaseOrderID] INT           NOT NULL,
    [ShippingTermID]  INT           NOT NULL,
    [UserID]          INT           NULL,
    [ShipDate]        DATE          NULL,
    [Picked]          BIT           NOT NULL,
    [ShipToName]      VARCHAR (50)  NULL,
    [ShipToAddress]   VARCHAR (250) NULL,
    [ShipToCity]      VARCHAR (50)  NULL,
    [ShipToState]     VARCHAR (50)  NULL,
    [ShipToZip]       VARCHAR (10)  NULL,
    CONSTRAINT [PK_ShippingOrders] PRIMARY KEY CLUSTERED ([ShippingOrderID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[ShippingTermsLookup]...';


GO
CREATE TABLE [dbo].[ShippingTermsLookup] (
    [ShippingTermID]   INT           IDENTITY (1, 1) NOT NULL,
    [ShippingVendorID] INT           NOT NULL,
    [Description]      VARCHAR (250) NOT NULL,
    CONSTRAINT [PK_ShippingTermsLookup] PRIMARY KEY CLUSTERED ([ShippingTermID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[ShippingVendors]...';


GO
CREATE TABLE [dbo].[ShippingVendors] (
    [ShippingVendorID] INT          IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (50) NOT NULL,
    [Address]          VARCHAR (50) NOT NULL,
    [City]             VARCHAR (25) NOT NULL,
    [State]            VARCHAR (2)  NOT NULL,
    [Country]          VARCHAR (50) NOT NULL,
    [Zip]              VARCHAR (10) NOT NULL,
    [Phone]            VARCHAR (12) NOT NULL,
    [Contact]          VARCHAR (50) NOT NULL,
    [ContactEmail]     VARCHAR (50) NULL,
    CONSTRAINT [PK_ShippingVendors] PRIMARY KEY CLUSTERED ([ShippingVendorID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[States]...';


GO
CREATE TABLE [dbo].[States] (
    [StateID]      INT          IDENTITY (1, 1) NOT NULL,
    [StateCode]    CHAR (2)     NOT NULL,
    [StateName]    VARCHAR (20) NOT NULL,
    [FirstZipCode] INT          NOT NULL,
    [LastZipCode]  INT          NOT NULL,
    CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED ([StateCode] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY];


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
    [VendorOrderID]     INT      IDENTITY (1, 1) NOT NULL,
    [VendorID]          INT      NOT NULL,
    [DateOrdered]       DATETIME NOT NULL,
    [AmountOfShipments] INT      NOT NULL,
    [Finalized]         BIT      NOT NULL,
    [Active]            BIT      NOT NULL,
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
PRINT N'Creating On column: OnOrder...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
ALTER TABLE [dbo].[Products]
    ADD DEFAULT ((0)) FOR [OnOrder];


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
PRINT N'Creating On column: Picked...';


GO
ALTER TABLE [dbo].[ShippingOrderLineItems]
    ADD DEFAULT (0) FOR [Picked];


GO
PRINT N'Creating On column: Picked...';


GO
ALTER TABLE [dbo].[ShippingOrders]
    ADD DEFAULT (0) FOR [Picked];


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
PRINT N'Creating FK_ShippingOrderLineItems_Products...';


GO
ALTER TABLE [dbo].[ShippingOrderLineItems] WITH NOCHECK
    ADD CONSTRAINT [FK_ShippingOrderLineItems_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_ShippingOrderLineItems_ShippingOrders...';


GO
ALTER TABLE [dbo].[ShippingOrderLineItems] WITH NOCHECK
    ADD CONSTRAINT [FK_ShippingOrderLineItems_ShippingOrders] FOREIGN KEY ([ShippingOrderID]) REFERENCES [dbo].[ShippingOrders] ([ShippingOrderID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_ShippingOrders_ShippingTermsLookup...';


GO
ALTER TABLE [dbo].[ShippingOrders] WITH NOCHECK
    ADD CONSTRAINT [FK_ShippingOrders_ShippingTermsLookup] FOREIGN KEY ([ShippingTermID]) REFERENCES [dbo].[ShippingTermsLookup] ([ShippingTermID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_ShippingOrders_Users...';


GO
ALTER TABLE [dbo].[ShippingOrders] WITH NOCHECK
    ADD CONSTRAINT [FK_ShippingOrders_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_ShippingTermsLookup_ShippingVendor...';


GO
ALTER TABLE [dbo].[ShippingTermsLookup] WITH NOCHECK
    ADD CONSTRAINT [FK_ShippingTermsLookup_ShippingVendor] FOREIGN KEY ([ShippingVendorID]) REFERENCES [dbo].[ShippingVendors] ([ShippingVendorID]) ON DELETE NO ACTION ON UPDATE NO ACTION;


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
PRINT N'Creating [dbo].[proc_DeactivateCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_DeactivateCategory] */
CREATE PROCEDURE [proc_DeactivateCategory]
	(@category varchar(50))
AS
	UPDATE [dbo].[Categories]
		SET [Active] = 0
	WHERE [Category] = @category
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_DeactivateLocation]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_DeactivateLocation] */
CREATE PROCEDURE [proc_DeactivateLocation]
	(@location varchar(250))
AS
	UPDATE [dbo].[Locations]
		SET [Active] = 0
	WHERE [Location] = @location
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_DeactivateProduct]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object:  StoredProcedure [dbo].[proc_DeactivateProduct]*/
CREATE PROCEDURE [dbo].[proc_DeactivateProduct]
	(@ProductID		Int)
AS
	UPDATE [dbo].[Products]
	SET [Active] = 0
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_DeactivateProductCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_DeactivateProductCategory] */
CREATE PROCEDURE [proc_DeactivateProductCategory]
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
PRINT N'Creating [dbo].[proc_DeactivateVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO


/*Object: StoredProcedure [dbo].[proc_DeactivateVendor]*/
CREATE PROCEDURE [proc_DeactivateVendor]
	(@VendorID int)
AS
	UPDATE [dbo].[Vendors]
		SET [Active] = 0
	WHERE [VendorID] = @VendorID
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_DeactivateVendorSourceItem]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_DeactivateVendorSourceItem]*/
CREATE PROCEDURE [proc_DeactivateVendorSourceItem]
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
PRINT N'Creating [dbo].[proc_DeleteCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
 
/*Object: StoredProcedure [dbo].[proc_DeleteCategory] */
CREATE PROCEDURE [proc_DeleteCategory]
	(@category varchar(50))
AS
	DELETE FROM[dbo].[Categories]
	WHERE [Category] = @category
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_DeleteLocation]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
/*Object: StoredProcedure [dbo].[proc_DeleteLocation] */
CREATE PROCEDURE [proc_DeleteLocation]
	(@location varchar(250))
AS
	DELETE FROM [dbo].[Locations]
	WHERE [Location] = @location
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_DeleteProduct]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE PROCEDURE [dbo].[proc_DeleteProduct]
	(@ProductID				Int,
	@Available				Int,
	@OnHand				int,
	@Description			VarChar(250),
	@Location				varchar(250),
	@UnitPrice				Money,
	@ShortDesc				VarChar(50),
	@ReorderThreshold		int,
	@ReorderAmount			int,
	@OnOrder				int,
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
	AND [OnOrder] = @OnOrder
	AND [ShippingDimensions] = @ShippingDimensions
	AND [ShippingWeight] = @ShippingWeight
	AND [Active] = @Active
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_DeleteProductCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_DeleteProductCategory] */
CREATE PROCEDURE [proc_DeleteProductCategory]
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
PRINT N'Creating [dbo].[proc_DeleteVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_DeleteVendor] */
CREATE PROCEDURE [proc_DeleteVendor]
	(@VendorID int)
AS
	DELETE FROM [dbo].[Vendors]
	WHERE [VendorID] = @VendorID
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_DeleteVendorSourceItem]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_DeleteVendorSourceItem] */
CREATE PROCEDURE [proc_DeleteVendorSourceItem]
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
PRINT N'Creating [dbo].[proc_GenerateReorderReports]...';


GO
CREATE PROCEDURE [dbo].[proc_GenerateReorderReports]
	@VendorID int
AS
	select p.ProductID, ReorderAmount, ReorderThreshold, vsi.VendorID, ItemsPerCase, UnitCost, UnitPrice, MinQtyToOrder
    from Products p
            Join VendorSourceItems vsi on 
                vsi.ProductID = p.ProductID
            where p.active = 'true' and
                vsi.Active = 'true' and
                vsi.VendorID = @VendorID  and
                OnHand + OnOrder < ReorderThreshold
GO
PRINT N'Creating [dbo].[proc_GetAllApplicationVariables]...';


GO
CREATE PROCEDURE [dbo].[proc_GetAllApplicationVariables]
AS
	SELECT ParameterKey as 'Key', ParameterValue as 'Value'
	from ApplicationVariables
GO
PRINT N'Creating [dbo].[proc_GetAllOpenVendorOrders]...';


GO
CREATE PROCEDURE [dbo].[proc_GetAllOpenVendorOrders]
AS
	SELECT [VendorOrderID], [VendorID], [DateOrdered], [AmountOfShipments], [Finalized]
	FROM VendorOrders
	Where [Finalized] = '0' 
	AND [Active] = '1'
RETURN
GO
PRINT N'Creating [dbo].[proc_GetAllOpenVendorOrdersByVendor]...';


GO
CREATE PROCEDURE [dbo].[proc_GetAllOpenVendorOrdersByVendor]
	@VendorId int
AS
	SELECT [VendorOrderID], [VendorID], [DateOrdered], [AmountOfShipments], [Finalized]
	FROM VendorOrders
	Where [Finalized] = '0' 
	AND [Active] = '1'
	AND [VendorID] = @VendorId
RETURN
GO
PRINT N'Creating [dbo].[proc_GetAllShippingOrderLineItems]...';


GO
CREATE PROCEDURE [proc_GetAllShippingOrderLineItems]
AS
	SELECT li.[ShippingOrderID], li.[ProductID], p.[ShortDesc], li.[Quantity], p.[Location], li.[Picked]
	FROM [dbo].[ShippingOrderLineItems] li
	JOIN [dbo].[Products] p
	ON li.[ProductID] = p.[ProductID]
GO
PRINT N'Creating [dbo].[proc_GetAllShippingOrders]...';


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
PRINT N'Creating [dbo].[proc_GetAllShippingOrdersByEmployee]...';


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
PRINT N'Creating [dbo].[proc_GetAllShippingOrdersNotPicked]...';


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
PRINT N'Creating [dbo].[proc_GetAllShippingOrdersNotShipped]...';


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
PRINT N'Creating [dbo].[proc_GetAllShippingOrdersPicked]...';


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
PRINT N'Creating [dbo].[proc_GetAllShippingOrdersShipped]...';


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
PRINT N'Creating [dbo].[proc_GetAllShippingTerms]...';


GO
CREATE PROCEDURE [proc_GetAllShippingTerms]
AS
	SELECT *
	FROM [dbo].[ShippingTermsLookup]
GO
PRINT N'Creating [dbo].[proc_GetAllShippingVendors]...';


GO
CREATE PROCEDURE [proc_GetAllShippingVendors]
AS
	SELECT *
	FROM [dbo].[ShippingVendors]
GO
PRINT N'Creating [dbo].[proc_GetAllStates]...';


GO
CREATE PROCEDURE [dbo].[proc_GetAllStates]
AS
	select * from [dbo].States
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
PRINT N'Creating [dbo].[proc_GetAllVendorOrders]...';


GO
CREATE PROCEDURE [dbo].[proc_GetAllVendorOrders]

AS
	SELECT [VendorOrderID], [VendorID], [DateOrdered], [AmountOfShipments], [Finalized], [Active]
	From VendorOrders
RETURN
GO
PRINT N'Creating [dbo].[proc_GetAllVendorSourceItems]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_GetVendorSourceItems] */
CREATE PROCEDURE [proc_GetAllVendorSourceItems]
AS
	SELECT [VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase]
	FROM [dbo].[VendorSourceItems]
	WHERE [Active] = 1
	RETURN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_GetCategories]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_GetCategories] */
CREATE PROCEDURE [proc_GetCategories]
AS
	SELECT [Category]
	FROM [dbo].[Categories]
	WHERE [Active] = 1
	RETURN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_GetCLSPackDetails]...';


GO
CREATE PROCEDURE [dbo].[proc_GetCLSPackDetails]
	(@ShippingOrderId int)
AS
	SELECT so.ShippingOrderID, so.ShippingTermID, sv.ShippingVendorID, st.Description, sv.Name, st.Description, si.ProductID, pr.ShortDesc, si.Quantity, so.ShipDate, so.ShipToName, so.ShipToAddress, so.ShipToCity, so.ShipToState, so.ShipToZip
	FROM [dbo].[ShippingTermsLookup] st, [dbo].[Products] pr, [dbo].[ShippingVendors] sv, [dbo].[ShippingOrders] so, [dbo].[ShippingOrderLineItems] si
	WHERE so.ShippingOrderID = @ShippingOrderId AND so.ShippingTermID = st.ShippingTermID AND st.ShippingVendorID = sv.ShippingVendorID AND so.ShippingOrderID = si.ShippingOrderID AND si.ProductID = pr.ProductID
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
PRINT N'Creating [dbo].[proc_GetLocations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
/*Object: StoredProcedure [dbo].[proc_GetLocations] */
CREATE PROCEDURE [proc_GetLocations]
AS
	SELECT [Location]
	FROM [dbo].[Locations]
	WHERE [Active] = 1
	RETURN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_GetProduct]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object:  StoredProcedure [dbo].[proc_GetProduct]*/
CREATE PROCEDURE [dbo].[proc_GetProduct]
	(@ProductID		Int)
AS
	SELECT * FROM [dbo].[Products]
	WHERE [ProductID] = @ProductID
	ORDER BY [ProductID]
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_GetProductCategories]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_GetProductCategories] */
CREATE PROCEDURE [proc_GetProductCategories]
AS
	SELECT [ProductID], [Category]
	FROM [dbo].[ProductCategories]
	WHERE [Active] = 1
	RETURN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_GetProductCategoriesByCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_GetProductCategoriesByCategory] */
CREATE PROCEDURE [proc_GetProductCategoriesByCategory]
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
PRINT N'Creating [dbo].[proc_GetProductCategoriesByProduct]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_GetProductCategoriesByProduct] */
CREATE PROCEDURE [proc_GetProductCategoriesByProduct]
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
PRINT N'Creating [dbo].[proc_GetProducts]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object:  StoredProcedure [dbo].[proc_GetProducts]*/
CREATE PROCEDURE [dbo].[proc_GetProducts]
AS
	SELECT * FROM [dbo].[Products]
	ORDER BY [Active] DESC, [ProductID]
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_GetProductsByActive]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object:  StoredProcedure [dbo].[proc_GetProductsByActive]*/
CREATE PROCEDURE [dbo].[proc_GetProductsByActive]
	(@Active	Int)
AS
	SELECT * FROM [dbo].[Products]
	WHERE [Active] = @Active
	ORDER BY [ProductID]
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_GetShippingOrderByID]...';


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
PRINT N'Creating [dbo].[proc_GetShippingOrderByPurchaseOrderID]...';


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
PRINT N'Creating [dbo].[proc_GetShippingOrderLineItem]...';


GO
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
GO
PRINT N'Creating [dbo].[proc_GetShippingOrderLineItems]...';


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
PRINT N'Creating [dbo].[proc_GetShippingTermsByID]...';


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
PRINT N'Creating [dbo].[proc_GetShippingVendorByID]...';


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
PRINT N'Creating [dbo].[proc_GetVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO


/*Object:  StoredProcedure [dbo].[proc_GetVendor]*/
CREATE PROCEDURE [dbo].[proc_GetVendor]
	(@VendorID int)
AS
	SELECT *
	FROM Vendors
	WHERE VendorID = @VendorID
	Return
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_getVendorOrder]...';


GO
CREATE PROCEDURE [dbo].[proc_getVendorOrder]
	@VendorOrderId int 
AS
	SELECT [VendorOrderID], [VendorID], [DateOrdered], [AmountOfShipments], [Finalized], [Active]
	FROM VendorOrders
	WHERE [VendorOrderID] = @VendorOrderId
RETURN
GO
PRINT N'Creating [dbo].[proc_GetVendorOrderByVendorAndDate]...';


GO
CREATE PROCEDURE [dbo].[proc_GetVendorOrderByVendorAndDate]
	@VendorID int, 
	@DateOrdered datetime
AS
	SELECT [VendorOrderID], [VendorID], [DateOrdered], [AmountOfShipments], [Finalized], [Active]
	FROM VendorOrders
	WHERE [VendorID] = @VendorID
	and [DateOrdered] = @DateOrdered
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
PRINT N'Creating [dbo].[proc_GetVendors]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object:  StoredProcedure [dbo].[proc_GetVendors]*/
CREATE PROCEDURE [dbo].[proc_GetVendors]
AS
	SELECT *
	FROM Vendors 
	Return
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_GetVendorsActive]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object:  StoredProcedure [dbo].[proc_GetVendorsActive]*/
CREATE PROCEDURE [dbo].[proc_GetVendorsActive]
AS
	SELECT *
	FROM Vendors
	WHERE Active = 1
	Return
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_GetVendorSourceItem]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_GetVendorSourceItem] */
CREATE PROCEDURE [proc_GetVendorSourceItem]
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
PRINT N'Creating [dbo].[proc_GetVendorSourceItemsByProduct]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
	
/*Object: StoredProcedure [dbo].[proc_GetVendorSourceItemsByProduct] */
CREATE PROCEDURE [proc_GetVendorSourceItemsByProduct]
	(@productID int)
AS
	SELECT [VendorSourceItems].[VendorID], [ProductID], [UnitCost], [MinQtyToOrder], [ItemsPerCase], [Vendors].[Name]
	FROM [dbo].[VendorSourceItems]
	INNER JOIN [dbo].[Vendors]
	ON [VendorSourceItems].[VendorID] = [Vendors].[VendorID]
	WHERE [VendorSourceItems].[Active] = 1
	AND [ProductID] = @productID
	RETURN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_GetVendorSourceItemsByVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_GetVendorSourceItemsByVendor] */
CREATE PROCEDURE [proc_GetVendorSourceItemsByVendor]
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
PRINT N'Creating [dbo].[proc_InsertIntoCategories]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
/* Categories Stored Procedures */

/*Object: StoredProcedure [dbo].[proc_InsertIntoCategories] */
CREATE PROCEDURE [proc_InsertIntoCategories]
	(@category varchar(50))
AS
	INSERT INTO [dbo].[Categories]
		([Category])
	VALUES
		(@Category)
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_InsertIntoLocations]...';


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

/*Object: StoredProcedure [dbo].[proc_InsertIntoLocations] */
CREATE PROCEDURE [proc_InsertIntoLocations]
	(@location varchar(250))
AS
	INSERT INTO [dbo].[Locations]
		([Location])
	VALUES
		(@location)
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_InsertIntoProductCategories]...';


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

/*Object: StoredProcedure [dbo].[proc_InsertIntoProductCategories] */
CREATE PROCEDURE [proc_InsertIntoProductCategories]
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
PRINT N'Creating [dbo].[proc_InsertIntoProducts]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE PROCEDURE [dbo].[proc_InsertIntoProducts]
	(@Available			Int,
	@OnHand				Int,
	@Description		VarChar(250),
	@Location			varchar(250),
	@UnitPrice			Money,
	@ShortDesc			VarChar(50),
	@ReorderThreshold	int,
	@ReorderAmount		int,
	@OnOrder			int,
	@ShippingDimensions varchar(50),
	@ShippingWeight		float,
	@Active				Bit)
AS
	INSERT INTO [dbo].[Products]([Available],[OnHand],[Description],[Location],[UnitPrice],[ShortDesc],[ReorderThreshold],[ReorderAmount],[OnOrder],[ShippingDimensions],[ShippingWeight],[Active])
	VALUES ( @Available, @OnHand, @Description, @Location, @UnitPrice, @ShortDesc, @ReorderThreshold, @ReorderAmount, @OnOrder, @ShippingDimensions, @ShippingWeight, @Active)
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_InsertIntoShippingOrderLineItems]...';


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
PRINT N'Creating [dbo].[proc_InsertIntoShippingOrders]...';


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
PRINT N'Creating [dbo].[proc_InsertIntoShippingTerm]...';


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
PRINT N'Creating [dbo].[proc_InsertIntoShippingVendors]...';


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
PRINT N'Creating [dbo].[proc_InsertIntoVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE PROCEDURE [dbo].[proc_InsertIntoVendor]
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
PRINT N'Creating [dbo].[proc_InsertIntoVendorSourceItems]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO


/* VendorSourceItems Stored Procedures */
/*Object: StoredProcedure [dbo].[proc_InsertIntoVendorSourceItems]*/
CREATE PROCEDURE [proc_InsertIntoVendorSourceItems]
	(@productID		int,
	@vendorID 		int,
	@unitCost		money,
	@minQtyToOrder	int,
	@itemsPerCase	int,
	@active			bit)
AS
	INSERT INTO VendorSourceItems(ProductID, VendorID, UnitCost, MinQtyToOrder,ItemsPerCase, Active) 
	VALUES (@productID, @vendorID, @unitCost, @minQtyToOrder,@itemsPerCase, @active)
	RETURN @@IDENTITY
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_InsertVendorOrder]...';


GO
CREATE PROCEDURE [dbo].[proc_InsertVendorOrder]
	@VendorID int, 
	@DateOrdered date
AS
	Insert into [VendorOrders] (VendorID, DateOrdered)
	Values (@VendorID, @DateOrdered)
RETURN @@ROWCOUNT
GO
PRINT N'Creating [dbo].[proc_ReactivateCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_ReactivateCategory] */
CREATE PROCEDURE [proc_ReactivateCategory]
	(@category varchar(50))
AS
	UPDATE [dbo].[Categories]
		SET [Active] = 1
	WHERE [Category] = @category
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_ReactivateLocation]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
/*Object: StoredProcedure [dbo].[proc_ReactivateLocation] */
CREATE PROCEDURE [proc_ReactivateLocation]
	(@location varchar(250))
AS
	UPDATE [dbo].[Locations]
		SET [Active] = 1
	WHERE [Location] = @location
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_ReactivateProduct]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object:  StoredProcedure [dbo].[proc_ReactivateProduct]*/
CREATE PROCEDURE [dbo].[proc_ReactivateProduct]
	(@ProductID		Int)
AS
	UPDATE [dbo].[Products]
	SET [Active] = 1
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_ReactivateProductCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object: StoredProcedure [dbo].[proc_ReactivateProductCategory] */
CREATE PROCEDURE [proc_ReactivateProductCategory]
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
PRINT N'Creating [dbo].[proc_ReactivateVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/* Object: StoredProcedure [dbo].[proc_ReactivateVendor] */
CREATE PROCEDURE [proc_ReactivateVendor]
	(@VendorID int)
AS
	UPDATE [dbo].[Vendors]
		SET [Active] = 1
	WHERE VendorID = @VendorID
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_ReactivateVendorSourceItem]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/* Object: StoredProcedure [dbo].[proc_ReactivateVendorSourceItem] */
CREATE PROCEDURE [proc_ReactivateVendorSourceItem]
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
PRINT N'Creating [dbo].[proc_UpdateCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
	
/*Object: StoredProcedure [dbo].[proc_UpdateCategory] */
CREATE PROCEDURE [proc_UpdateCategory]
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
PRINT N'Creating [dbo].[proc_UpdateLocation]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
	
/*Object: StoredProcedure [dbo].[proc_UpdateLocation] */
CREATE PROCEDURE [proc_UpdateLocation]
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
PRINT N'Creating [dbo].[proc_UpdateProductCategory]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
	
/*Object: StoredProcedure [dbo].[proc_UpdateProductCategory] */
CREATE PROCEDURE [proc_UpdateProductCategory]
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
PRINT N'Creating [dbo].[proc_UpdateProductOnOrder]...';


GO
CREATE PROCEDURE [dbo].[proc_UpdateProductOnOrder]
	(@ProductID		int,
	@Amount			int)
AS
	UPDATE [dbo].[Products]
	SET [OnOrder] = @Amount
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT
GO
PRINT N'Creating [dbo].[proc_UpdateProductReorderAmount]...';


GO
CREATE PROCEDURE [dbo].[proc_UpdateProductReorderAmount]
	(@ProductID		int,
	@Amount			int)
AS
	UPDATE [dbo].[Products]
	SET [ReorderAmount] = @Amount
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT
GO
PRINT N'Creating [dbo].[proc_UpdateProducts]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE PROCEDURE [dbo].[proc_UpdateProducts]
	(@ProductID						Int,
	@Available						Int,
	@OnHand							Int,
	@Description					VarChar(250),
	@Location						varchar(250),
	@UnitPrice						Money,
	@ShortDesc						VarChar(50),
	@ReorderThreshold				int,
	@ReorderAmount					int,
	@OnOrder						int,
	@ShippingDimensions				varchar(50),
	@ShippingWeight					float,
	@Active							Bit,
	@OriginalAvailable				Int,
	@OriginalOnHand					Int,
	@OriginalDescription			VarChar(250),
	@OriginalLocation				varchar(250),
	@OriginalUnitPrice				Money,
	@OriginalShortDesc				VarChar(50),
	@OriginalReorderThreshold 		int,
	@OriginalReorderAmount			int,
	@OriginalOnOrder				int,
	@OriginalShippingDimensions 	varchar(50),
	@OriginalShippingWeight			float,
	@OriginalActive					Bit)
AS
	UPDATE [dbo].[Products]
	SET [Available] = @Available, 
		[OnHand] = @OnHand, 
		[Description] = @Description, 
		[Location] = @Location, 
		[UnitPrice] = @UnitPrice, 
		[ShortDesc] = @ShortDesc, 
		[ReorderThreshold] = @ReorderThreshold, 
		[ReorderAmount] = @ReorderAmount, 
		[ShippingDimensions] = @ShippingDimensions, 
		[ShippingWeight] = @ShippingWeight, 
		[Active] = @Active, 
		[OnOrder] = @OnOrder
	WHERE [ProductID] = @ProductID
		AND [Available] = @OriginalAvailable
		AND [OnHand] = @OriginalOnHand
		AND [Description] = @OriginalDescription
		AND (([Location] = @OriginalLocation)
		OR (@OriginalLocation IS NULL))
		AND [UnitPrice] = @OriginalUnitPrice
		AND [ShortDesc] = @OriginalShortDesc
		AND (([ReorderThreshold] = @OriginalReorderThreshold)
		OR (@OriginalReorderThreshold IS NULL))
		AND (([ReorderAmount] = @OriginalReorderAmount)
		OR (@OriginalReorderAmount IS NULL))
		AND [OnOrder] = @OriginalOnOrder
		AND (([ShippingDimensions] = @OriginalShippingDimensions)
		OR (@OriginalShippingDimensions IS NULL))
		AND (([ShippingWeight] = @OriginalShippingWeight)
		OR (@OriginalShippingWeight IS NULL))
		AND [Active] = @OriginalActive
	RETURN @@ROWCOUNT
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[proc_UpdateProductThreshold]...';


GO
CREATE PROCEDURE [dbo].[proc_UpdateProductThreshold]
	(@ProductID		int,
	@Amount			int)
AS
	UPDATE [dbo].[Products]
	SET [ReorderThreshold] = @Amount
	WHERE [ProductID] = @ProductID
	RETURN @@ROWCOUNT
GO
PRINT N'Creating [dbo].[proc_UpdateShippingOrder]...';


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
GO
PRINT N'Creating [dbo].[proc_UpdateShippingOrderLineItem]...';


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
PRINT N'Creating [dbo].[proc_UpdateShippingOrderLineItemPicked]...';


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
PRINT N'Creating [dbo].[proc_UpdateShippingOrderLineItemRemovePicked]...';


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
PRINT N'Creating [dbo].[proc_UpdateShippingOrderPicked]...';


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
PRINT N'Creating [dbo].[proc_UpdateShippingOrderRemovePicked]...';


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
PRINT N'Creating [dbo].[proc_UpdateShippingOrderRemoveShipDate]...';


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
PRINT N'Creating [dbo].[proc_UpdateShippingOrderRemoveUser]...';


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
PRINT N'Creating [dbo].[proc_UpdateShippingOrderShipDate]...';


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
PRINT N'Creating [dbo].[proc_UpdateShippingOrderUser]...';


GO
CREATE PROCEDURE [proc_UpdateShippingOrderUser]
(
	@shippingOrderID int,
	@newUserID int
)
AS
	UPDATE [dbo].[ShippingOrders]
	SET [UserID] = @newUserID
	WHERE [ShippingOrderID] = @shippingOrderID
GO
PRINT N'Creating [dbo].[proc_UpdateShippingTerm]...';


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
PRINT N'Creating [dbo].[proc_UpdateShippingVendor]...';


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
PRINT N'Creating [dbo].[proc_UpdateVendor]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

/*Object:  StoredProcedure [dbo].[proc_UpdateVendor]*/
CREATE PROCEDURE [dbo].[proc_UpdateVendor]
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
PRINT N'Creating [dbo].[proc_UpdateVendorName]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO


/*Object:  StoredProcedure [dbo].[proc_UpdateVendorName]*/
CREATE PROCEDURE [dbo].[proc_UpdateVendorName]
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
PRINT N'Creating [dbo].[proc_UpdateVendorOrder]...';


GO
CREATE PROCEDURE [dbo].[proc_UpdateVendorOrder]
	(@VendorOrderID int,
	 @VendorID int,
	 @DateOrdered datetime,
	 @AmountOfShipments int,
	 @Finalized bit,
	 @orig_AmountOfShipments int,
	 @orig_Finalized bit)
AS
	UPDATE [dbo].[VendorOrders]
	SET [AmountOfShipments] = @AmountOfShipments,
	    [Finalized] = @Finalized
	WHERE [VendorOrderID] = @VendorOrderID
	  and [VendorID] = @VendorID
	  and [DateOrdered] = @DateOrdered
	  and [AmountOfShipments] = @orig_AmountOfShipments
	  and [Finalized] = @orig_Finalized
	
RETURN @@ROWCOUNT
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
PRINT N'Creating [dbo].[proc_UpdateVendorSourceItem]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
	
/*Object: StoredProcedure [dbo].[proc_UpdateVendorSourceItem]*/
CREATE PROCEDURE [proc_UpdateVendorSourceItem]
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

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[ProductCategories] WITH CHECK CHECK CONSTRAINT [FK_ProductCategories_Categories];

ALTER TABLE [dbo].[ProductCategories] WITH CHECK CHECK CONSTRAINT [FK_ProductCategories_Products];

ALTER TABLE [dbo].[Products] WITH CHECK CHECK CONSTRAINT [FK_Products_Locations];

ALTER TABLE [dbo].[ShippingOrderLineItems] WITH CHECK CHECK CONSTRAINT [FK_ShippingOrderLineItems_Products];

ALTER TABLE [dbo].[ShippingOrderLineItems] WITH CHECK CHECK CONSTRAINT [FK_ShippingOrderLineItems_ShippingOrders];

ALTER TABLE [dbo].[ShippingOrders] WITH CHECK CHECK CONSTRAINT [FK_ShippingOrders_ShippingTermsLookup];

ALTER TABLE [dbo].[ShippingOrders] WITH CHECK CHECK CONSTRAINT [FK_ShippingOrders_Users];

ALTER TABLE [dbo].[ShippingTermsLookup] WITH CHECK CHECK CONSTRAINT [FK_ShippingTermsLookup_ShippingVendor];

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
