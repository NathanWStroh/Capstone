CREATE TABLE [dbo].[Roles] (
    [RoleID]      INT           IDENTITY (1000, 100) NOT NULL,
    [Title]       VARCHAR (25)  NOT NULL,
    [Description] VARCHAR (250) NOT NULL,
	[Active]	  BIT DEFAULT(1) NOT NULL
	)

