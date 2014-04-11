

/* VendorSourceItems Stored Procedures */
/*Object: StoredProcedure [dbo].[sp_InsertIntoVendorSourceItems]*/
CREATE PROCEDURE [sp_InsertIntoVendorSourceItems]
	(@productID		int,
	@vendorID 		int,
	@unitCost		money,
	@minQtyToOrder	int,
	@itemsPerCase	int,
	@active			bit)
AS
	INSERT INTO VendorSourceItems(ProductID, VendorID, UnitCost, MinQtyToOrder,ItemsPerCase, Active) 
	VALUES (@productID, @vendorID, @unitCost, @minQtyToOrder,@itemsPerCase, @active)
	RETURN @@IDENTITY