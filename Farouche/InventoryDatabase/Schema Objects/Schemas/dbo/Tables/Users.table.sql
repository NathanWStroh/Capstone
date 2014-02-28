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
    [Active]      BIT          DEFAULT ((1)) NOT NULL
);

