CREATE PROCEDURE [dbo].[proc_InsertIntoVendorOrderLineItems]
	(@VendorOrderID int,
     @ProductID int,
     @QtyOrdered int,
     @QtyReceived int,
     @QtyDamaged int,
	 @Note varchar(250))
AS
	INSERT INTO [dbo].[VendorOrderLineItems]
           ([VendorOrderID]
           ,[ProductID]
           ,[QtyOrdered]
           ,[QtyReceived]
           ,[QtyDamaged],
		   [Note])
     VALUES
           (@VendorOrderID, @ProductID, @QtyOrdered, @QtyReceived, @QtyDamaged, @Note)
RETURN @@IDENTITY


