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
    [Active]       BIT          DEFAULT ((1)) NOT NULL
);

