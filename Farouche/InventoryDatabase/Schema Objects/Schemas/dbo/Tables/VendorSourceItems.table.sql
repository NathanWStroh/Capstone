CREATE TABLE [dbo].[VendorSourceItems] (
    [VendorID]      INT   NOT NULL,
    [ProductID]     INT   NOT NULL,
    [UnitCost]      MONEY NOT NULL,
    [MinQtyToOrder] INT   NOT NULL,
    [ItemsPerCase]  INT   NOT NULL,
    [Active]        BIT   DEFAULT ((1)) NOT NULL
);

