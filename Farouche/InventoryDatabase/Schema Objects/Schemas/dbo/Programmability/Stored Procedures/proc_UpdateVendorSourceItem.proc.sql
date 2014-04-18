	
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