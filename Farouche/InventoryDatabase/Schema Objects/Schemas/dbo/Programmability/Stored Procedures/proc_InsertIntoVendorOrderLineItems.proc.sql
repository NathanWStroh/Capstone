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


