CREATE TABLE [dbo].[Products] (
    [ProductID]          INT           IDENTITY (1, 1) NOT NULL,
    [Available]          INT           DEFAULT ((0)) NOT NULL,
    [OnHand]             INT           DEFAULT ((0)) NOT NULL,
    [OnOrder]            INT           DEFAULT ((0)) NOT NULL,
    [Description]        VARCHAR (250) NOT NULL,
    [Location]           VARCHAR (250) NULL,
    [UnitPrice]          MONEY         NOT NULL,
    [ShortDesc]          VARCHAR (50)  NOT NULL,
    [ReorderThreshold]   INT           NULL,
    [ReorderAmount]      INT           NULL,
    [ShippingDimensions] VARCHAR (50)  NULL,
    [ShippingWeight]     FLOAT         NULL,
    [Active]             BIT           DEFAULT ((1)) NOT NULL
);

