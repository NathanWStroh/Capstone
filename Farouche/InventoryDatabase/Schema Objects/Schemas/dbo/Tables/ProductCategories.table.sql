CREATE TABLE [dbo].[ProductCategories] (
    [ProductID] INT          NOT NULL,
    [Category]  VARCHAR (50) NOT NULL,
    [Active]    BIT          DEFAULT ((1)) NOT NULL
);

