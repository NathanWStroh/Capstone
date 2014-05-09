CREATE TABLE [dbo].[Users] (
    [UserID]      INT          IDENTITY (1, 1) NOT NULL,
    [RoleID]      INT          NULL,
    [Password]    VARCHAR (50) NOT NULL,
    [FirstName]   VARCHAR (25) NOT NULL,
    [LastName]    VARCHAR (25) NOT NULL,
    [PhoneNumber] VARCHAR (14) NULL,
    [Address]     VARCHAR (50) NULL,
    [City]        VARCHAR (25) NULL,
    [State]       VARCHAR (25) NULL,
    [Zip]         VARCHAR (9)  NULL,
    [Active]      BIT          DEFAULT ((1)) NOT NULL
);

